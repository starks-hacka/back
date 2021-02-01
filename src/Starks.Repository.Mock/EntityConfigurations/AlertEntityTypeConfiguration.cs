using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using XPInc.Hackathon.Starks.Domain.AggregatesModel.AlertAggregate;

namespace XPInc.Hackathon.Starks.Infrastructure.EntityConfigurations
{
    public class AlertEntityTypeConfiguration : IEntityTypeConfiguration<Alert>
    {
        public void Configure(EntityTypeBuilder<Alert> alertConfiguration)
        {
            alertConfiguration.ToTable("alerts", StarksContext.DEFAULT_SCHEMA);

            alertConfiguration.HasKey(o => o.Id);

            alertConfiguration.Property(b => b.Id)
                .HasColumnType("UniqueIdentifier")
                .IsRequired();

            alertConfiguration.Property(b => b.Alerta)
                .HasMaxLength(100)
                .IsRequired();

            alertConfiguration.Property(b => b.Host)
                .HasMaxLength(100)
                .IsRequired();

            alertConfiguration.Property(b => b.Prioridade)
                .HasMaxLength(100)
                .IsRequired();

            alertConfiguration.Property(b => b.Ambiente)
                .HasMaxLength(100)
                .IsRequired();

            alertConfiguration.Property(b => b.Corretora)
                .HasMaxLength(100)
                .IsRequired();

            alertConfiguration.Property(b => b.Equipe)
                .HasMaxLength(100)
                .IsRequired();

            alertConfiguration.Property(b => b.Email_app)
                .HasMaxLength(100)
                .HasColumnName("EmailApp")
                .IsRequired();

            alertConfiguration.Property(b => b.Criticidade)
                .HasMaxLength(100)
                .IsRequired();

            alertConfiguration.Property(b => b.Status)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
