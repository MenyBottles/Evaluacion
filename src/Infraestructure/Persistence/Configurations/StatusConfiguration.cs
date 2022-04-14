using Domain.Common.Enums;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Configurations;

public class StatusConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.HasKey(x => x.StatusId);
        builder
        .Property(e => e.StatusId)
        .HasConversion<int>();

        builder.
           HasData(
                Enum.GetValues(typeof(StatusId))
                    .Cast<StatusId>()
                    .Select(e => new Status()
                    {
                        StatusId = e,
                        Value = e.ToString()
                    })
            );
    }
}
