using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XPInc.Hackathon.Starks.Domain.AggregatesModel.ManagerAggregate;

namespace XPInc.Hackathon.Starks.Infrastructure.EntityConfigurations
{
    class ManagerEntityTypeConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> managerConfiguration)
        {
            managerConfiguration.ToTable("managers", StarksContext.DEFAULT_SCHEMA);

            managerConfiguration.HasKey(o => o.Id);

            managerConfiguration.Property(b => b.Id)
                .HasColumnType("UniqueIdentifier")
                .IsRequired();

            managerConfiguration.Property(b => b.Email)
                .HasMaxLength(100)
                .IsRequired();

            managerConfiguration.Property(b => b.Name)
                .HasMaxLength(100)
                .IsRequired();

            managerConfiguration.Property(b => b.Surname)
                .HasMaxLength(100)
                .IsRequired();

            managerConfiguration.Property(b => b.Phone)
                .HasMaxLength(13)
                .IsRequired();
        }
    }
}