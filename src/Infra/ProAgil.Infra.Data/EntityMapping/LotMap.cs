using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProAgil.Domain.Entities;

namespace ProAgil.Infra.Data.EntityMapping
{
    public class LotMap : IEntityTypeConfiguration<Lot>
    {
        public void Configure(EntityTypeBuilder<Lot> builder)
        {
            builder.ToTable("Lots");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
            .IsRequired();

            builder.Property(b => b.Description)
                .HasMaxLength(150)
                .IsRequired();

            builder.OwnsOne(e => e.Activater, a =>
            {
                a.Property(p => p.Active)
                    .IsRequired()
                    .HasColumnName("Active");
            });
        }
    }
}