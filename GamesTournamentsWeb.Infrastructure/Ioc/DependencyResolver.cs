using System.Text;
using AutoMapper.EquivalencyExpression;
using FoolProof.Core;
using GamesTournamentsWeb.Common.Enums.Account;
using GamesTournamentsWeb.DataAccess.Contexts;
using GamesTournamentsWeb.DataAccess.Repositories;
using GamesTournamentsWeb.Infrastructure.Configuration;
using GamesTournamentsWeb.Infrastructure.Extensions;
using GamesTournamentsWeb.Infrastructure.Operations;
using GamesTournamentsWeb.Infrastructure.Operations.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace GamesTournamentsWeb.Infrastructure.Ioc;

public static class DependencyResolver
{
    public static IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        var appSettingsSection = configuration.GetSection(Constants.AppSettings);
        services.Configure<AppSettings>(appSettingsSection);
        var appSettings = appSettingsSection.Get<AppSettings>();
        
        // Register app settings as options
        services.Configure<AppSettings>(appSettingsSection);
        
        // Foolproof validation
        services.AddFoolProof();
        
        // Time provider
        services.AddSingleton(TimeProvider.System);
        
        // Context
        services.AddDbContext<WebContext>(ServiceLifetime.Scoped);

        // Register repositories
        services.RegisterInheritedFromType(typeof(IRepository));
        // Register operations
        services.RegisterInheritedFromType(typeof(IOperation));
        services.RegisterInheritedFromType(typeof(ISingletonOperation), ServiceLifetime.Singleton);
        
        services.AddAutoMapper(cfg =>
            {
                cfg.AddCollectionMappers();
            },
            AppDomain.CurrentDomain.GetAssemblies()
        );
        
        // JWT
        var key = Encoding.ASCII.GetBytes(appSettings.Secret);
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.Events = new JwtBearerEvents
            {
                OnTokenValidated = async context =>
                {
                    if (context.Principal?.Identity?.Name == null)
                    {
                        context.Fail("Unauthorized");
                        return;
                    }
                    
                    // Get user id for the token
                    var accountOperation = context.HttpContext.RequestServices.GetRequiredService<IAccountOperation>();
                    var accountId = int.Parse(context.Principal.Identity.Name);
                    var account = await accountOperation.GetAccountByIdAsync(accountId);
                    
                    if (account == null)
                    {
                        context.Fail("Unauthorized");
                        return;
                    }

                    // Get authorization attribute and role if any
                    var actionDescriptor = context.HttpContext.GetEndpoint();
                    var authorizeAttribute = actionDescriptor?.Metadata?.GetMetadata<AuthorizeAttribute>();
                    if (authorizeAttribute != null && !string.IsNullOrWhiteSpace(authorizeAttribute.Roles))
                    {
                        string roleName = authorizeAttribute.Roles;
                        var requiredRole = Enum.Parse(typeof(RoleEnum), roleName);

                        // Check whether user has greater or equal role
                        // This is because the roles are ordered in the enum - greater role has permissions of lower
                        bool hasRole = account.RoleId >= (int)requiredRole;
                        if (!hasRole)
                        {
                            context.Fail("Unauthorized");
                        }
                    }
                    
                    context.Success();
                }
            };
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
        
        // Serilog.Log.Logger = new LoggerConfiguration()
        //     .Enrich.FromLogContext()
        //     .WriteTo.MSSqlServer(
        //         connectionString: configuration.GetConnectionString("ProductionTools"),
        //         columnOptionsSection: configuration.GetSection("Serilog:ColumnOptions"),
        //         sinkOptions: new MSSqlServerSinkOptions
        //         {
        //             AutoCreateSqlTable = true,
        //             TableName = configuration.GetSection("Serilog:TableName").Value,
        //             SchemaName = configuration.GetSection("Serilog:SchemaName").Value
        //         })
        //     .CreateLogger();


        return services;
    }

}