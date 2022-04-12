using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class MesesConfiguration : IEntityTypeConfiguration<MesesEntity>
    {
        public void Configure(EntityTypeBuilder<MesesEntity> builder)
        {
            builder.HasKey(e => e.Idmes)
                  .HasName("pk_meses");

            builder.ToTable("meses");

            builder.HasIndex(e => e.Idmes, "meses_pk")
                .IsUnique();

            builder.Property(e => e.Idmes)
                .ValueGeneratedNever()
                .HasColumnName("idmes");

            builder.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("fecha_creacion");

            builder.Property(e => e.Mes)
                .HasMaxLength(20)
                .HasColumnName("mes");
        }
    }
}
