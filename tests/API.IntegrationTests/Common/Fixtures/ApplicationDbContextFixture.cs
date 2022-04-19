using Domain.Entities;
using Domain.Common.Enums;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace API.IntegrationTests.Common;

public class ApplicationDbContextFixture : IDisposable
{
    public ApplicationDbContextFixture()
    {
        var application = new HostBuilder();
        var scope = application.Services.CreateScope();
        var provider = scope.ServiceProvider;
        context = provider.GetRequiredService<ApplicationDbContext>();
    }

    public void Dispose()
    {
        context.Dispose();
    }

    public ApplicationDbContext context { get; private set; }

    public async Task SeedSampleDataAsync()
    {
        
        await context.Database.EnsureCreatedAsync();

        await context.Products.AddAsync(new Product { Name = "Product", Description = "Description", Price = 12.05m, StatusId = StatusId.Active, Stock = 2 });
        await context.SaveChangesAsync();
            
        
    }
}