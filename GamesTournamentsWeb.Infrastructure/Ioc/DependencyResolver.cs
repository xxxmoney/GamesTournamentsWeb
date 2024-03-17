using AutoMapper.EquivalencyExpression;
using GamesTournamentsWeb.DataAccess.Contexts;
using GamesTournamentsWeb.DataAccess.Repositories;
using GamesTournamentsWeb.Infrastructure.Extensions;
using GamesTournamentsWeb.Infrastructure.Operations;
using GamesTournamentsWeb.Infrastructure.Operations.Games;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GamesTournamentsWeb.Infrastructure.Ioc;

public static class DependencyResolver
{
    
    
    public static IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        // Context
        services.AddDbContext<WebContext>(ServiceLifetime.Transient);
        
        // Repositories
        // services.AddScoped<ICurrencyRepository, CurrencyRepository>();
        // services.AddScoped<IGameRepository, GameRepository>();
        // services.AddScoped<IGenreRepository, GenreRepository>();
        // services.AddScoped<IMatchRepository, MatchRepository>();
        // services.AddScoped<IPrizeRepository, PrizeRepository>();
        // services.AddScoped<IStreamRepository, StreamRepository>();
        // services.AddScoped<ITeamRepository, TeamRepository>();
        // services.AddScoped<ITournamentPlayerRepository, TournamentPlayerRepository>();
        // services.AddScoped<ITournamentRepository, TournamentRepository>();
        // services.AddScoped<IRegionRepository, RegionRepository>();
        // services.AddScoped<IPlatformRepository, PlatformRepository>();
        // services.AddScoped<IAccountRepository, AccountRepository>();
        
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