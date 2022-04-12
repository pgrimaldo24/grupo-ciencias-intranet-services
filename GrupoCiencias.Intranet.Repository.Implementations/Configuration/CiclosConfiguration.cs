using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class CiclosConfiguration : IEntityTypeConfiguration<CiclosEntity>
    {
        public void Configure(EntityTypeBuilder<CiclosEntity> builder)
        {
            builder.HasKey(e => e.Idciclo)
                   .HasName("ciclos_pkey");

            builder.ToTable("ciclos");

            builder.Property(e => e.Idciclo).HasColumnName("idciclo");

            builder.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("descripcion");

            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("fecha_creacion");

            builder.Property(e => e.GrupoCiclos).HasColumnName("grupo_ciclos");

            builder.Property(e => e.Iduniversidad).HasColumnName("iduniversidad");

            builder.Property(e => e.Precio)
                .HasPrecision(9, 2)
                .HasColumnName("precio");

            builder.Property(e => e.VisibleLanding).HasColumnName("visible_landing");

            builder.HasOne(d => d.UniversidadNavigation)
                .WithMany(p => p.Ciclos)
                .HasForeignKey(d => d.Iduniversidad)
                .HasConstraintName("ciclos_universidad_constraint");
            
        }
    }
}
