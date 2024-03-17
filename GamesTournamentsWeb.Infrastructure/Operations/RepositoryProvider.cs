﻿using GamesTournamentsWeb.DataAccess.Contexts;
using GamesTournamentsWeb.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GamesTournamentsWeb.Infrastructure.Operations;

public interface IRepositoryProvider
{
    IRepositoryProviderScope CreateScope();
}

public class RepositoryProvider(IServiceScopeFactory scopeFactory) : IRepositoryProvider
{
    public IRepositoryProviderScope CreateScope()
    {
        return new RepositoryProviderScope(scopeFactory.CreateScope());
    }
}

public interface IRepositoryProviderScope : IDisposable
{
    T Provide<T>() 
        where T : IRepository;
    
    Task SaveChangesAsync();
}

public class RepositoryProviderScope(IServiceScope scope) : IRepositoryProviderScope
{
    private readonly WebContext context = scope.ServiceProvider.GetRequiredService<WebContext>();

    public T Provide<T>() where T : IRepository
    {
        return scope.ServiceProvider.GetRequiredService<T>();
    }

    public Task SaveChangesAsync()
    {
        return this.context.SaveChangesAsync();
    }

    public void Dispose()
    {
        scope.Dispose();
    }
}

