using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XPInc.Hackathon.Starks.Domain.AggregatesModel.ManagerAggregate;
using XPInc.Hackathon.Starks.Domain.AggregatesModel.TeamAggregate;

namespace XPInc.Hackathon.Starks.Infrastructure.EntityConfigurations
{
    class TeamEntityTypeConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> teamConfiguration)
        {
            {
                teamConfiguration.ToTable("teams", StarksContext.DEFAULT_SCHEMA);

                teamConfiguration.HasKey(o => o.Id);

                teamConfiguration.Property(b => b.Id)
                    .HasColumnType("UniqueIdentifier")
                    .IsRequired();

                teamConfiguration.Property(b => b.Alliance)
                    .HasMaxLength(100)
                    .IsRequired();

                teamConfiguration.Property(b => b.Tribe)
                    .HasMaxLength(100)
                    .IsRequired();

                teamConfiguration.Property(b => b.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                teamConfiguration.Property(b => b.Email)
                    .HasMaxLength(100)
                    .IsRequired();

                var navigation = teamConfiguration.Metadata.FindNavigation(nameof(Team.TeamMembers));

                navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

                teamConfiguration.HasOne<Manager>()
                    .WithMany()
                    .IsRequired(false)
                    .HasForeignKey("ManagerId");

                teamConfiguration.HasMany(t => t.TeamMembers)
                    .WithOne()
                    .HasForeignKey("TeamId"); 
            }
        }
    }
}