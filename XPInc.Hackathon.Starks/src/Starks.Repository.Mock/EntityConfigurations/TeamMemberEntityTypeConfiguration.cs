using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XPInc.Hackathon.Starks.Domain.AggregatesModel.TeamAggregate;

namespace XPInc.Hackathon.Starks.Infrastructure.EntityConfigurations
{
    class TeamMemberEntityTypeConfiguration : IEntityTypeConfiguration<TeamMember>
    {
        public void Configure(EntityTypeBuilder<TeamMember> teamMemberConfiguration)
        {
            teamMemberConfiguration.ToTable("teamMembers", StarksContext.DEFAULT_SCHEMA);

            teamMemberConfiguration.HasKey(tm => tm.Id);

            teamMemberConfiguration.Property(tm => tm.Id)
                .HasColumnType("UniqueIdentifier")
                .IsRequired();

            teamMemberConfiguration.Property(tm => tm.TeamId)
                .HasColumnType("UniqueIdentifier")
                .IsRequired();

            teamMemberConfiguration.Property(tm => tm.Email)
              .HasMaxLength(100)
              .IsRequired();

            teamMemberConfiguration.Property(tm => tm.Name)
                .HasMaxLength(100)
                .IsRequired();

            teamMemberConfiguration.Property(tm => tm.Surname)
                .HasMaxLength(100)
                .IsRequired();

            teamMemberConfiguration.Property(tm => tm.Phone)
                .HasMaxLength(13)
                .IsRequired();

            teamMemberConfiguration.Property(tm => tm.Date)
                .IsRequired();

            teamMemberConfiguration.HasOne<Team>()
                .WithMany(tm => tm.TeamMembers);
        }
    }
}
