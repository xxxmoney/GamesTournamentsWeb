using GamesTournamentsWeb.DataAccess.Contexts;
using GamesTournamentsWeb.DataAccess.Repositories;
using GamesTournamentsWeb.Infrastructure.Operations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GamesTournamentsWeb.Infrastructure.Ioc;

public static class DependencyResolver
{
    public static IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        // TODO: Add services here
        
        // Context
        services.AddDbContext<WebContext>(ServiceLifetime.Transient);
        
        // Repositories
        services.AddScoped<ICurrencyRepository, CurrencyRepository>();
        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<IMatchRepository, MatchRepository>();
        services.AddScoped<IPrizeRepository, PrizeRepository>();
        services.AddScoped<IStreamRepository, StreamRepository>();
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<ITournamentPlayerRepository, TournamentPlayerRepository>();
        services.AddScoped<ITournamentRepository, TournamentRepository>();
        
        // Operations
        services.AddSingleton<IRepositoryProvider, RepositoryProvider>();
        
        // services.AddAutoMapper(cfg =>
        //     {
        //         cfg.AddCollectionMappers();
        //     },
        //     AppDomain.CurrentDomain.GetAssemblies()
        // );
        
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