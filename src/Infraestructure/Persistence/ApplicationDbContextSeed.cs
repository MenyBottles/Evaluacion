using Domain.Entities;
using Domain.Common.Enums;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence;

public static class ApplicationDbContextSeed
{

    public static async Task SeedSampleDataAsync(ApplicationDbContext context)
    {

        var anyStatus = await context.Status.AnyAsync();
        // Seed, if necessary
        if (!anyStatus)
        {
            await context.Database.EnsureCreatedAsync();
            var status = Enum.GetValues(typeof(StatusId))
                        .Cast<StatusId>()
                        .Select(e => new Status()
                        {
                            StatusId = e,
                            Value = e.ToString()
                        });
            await context.Status.AddRangeAsync(status);

            await context.SaveChangesAsync();
        }
    }
}