using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProAgil.Domain.Entities;

namespace ProAgil.Infra.Data.EntityMapping
{
    public class EventMap : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events");
            builder.HasKey(e => e.Id);

            //#### Properties
            builder.Property(b => b.Id)
            .IsRequired();


            builder.Property(b => b.Theme)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(b => b.Capacity)
                .IsRequired();

            //#### ValueObjects
            builder.OwnsOne(e => e.Address, a =>
            {
                a.Property(p => p.Street)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("Street");

                a.Property(p => p.Number)
                    .HasMaxLength(10)
                    .HasColumnName("Number");

                a.Property(p => p.Neigborhood)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("Neigborhood");

                a.Property(p => p.City)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("City");

                a.Property(p => p.State)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("State");

                a.Property(p => p.Country)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("Country");

                a.Property(p => p.ZipCode)
                    .HasMaxLength(8)
                    .HasColumnName("ZipCode");
            });

            builder.OwnsOne(e => e.Activater, a =>
            {
                a.Property(p => p.Active)
                    .IsRequired()
                    .HasColumnName("Active");
            });

            builder.OwnsOne(e => e.MaintenanceDate, a =>
            {
                a.Property(p => p.LastUpdateDate)
                    .IsRequired()
                    .HasColumnName("LastUpdateDate");

                a.Property(p => p.RegisterDate)
                    .IsRequired()
                    .HasColumnName("RegisterDate");
            });

            //#### ForeignKeys

            // builder.HasOne(e => e.CurrentBatch)
            //         .WithOne(b => b.CurrentEvent)
            //         .HasForeignKey<Event>(x => x.CurrentBatchId)
            //         .OnDelete(DeleteBehavior.NoAction);
            // ;

            builder.HasMany(e => e.Lots)
                .WithOne(b => b.Event)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}