using Domain.Entities;
using Domain.Common.Enums;
using Infraestructure.Persistence;

namespace Infraestructure.Persistence;

public static class ApplicationDbContextSeed
{

    public static async Task SeedSampleDataAsync(ApplicationDbContext context)
    {
        // Seed, if necessary
        if (!context.Status.Any())
        {
            context.Status.AddRange(Enum.GetValues(typeof(StatusId))
                        .Cast<StatusId>()
                        .Select(e => new Status()
                        {
                            StatusId = e,
                            Value = e.ToString()
                        }));

            await context.SaveChangesAsync();
        }
    }
}