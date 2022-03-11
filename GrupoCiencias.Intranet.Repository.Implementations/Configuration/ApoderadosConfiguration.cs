using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class ApoderadosConfiguration : IEntityTypeConfiguration<ApoderadosEntity>
    {
        public void Configure(EntityTypeBuilder<ApoderadosEntity> builder)
        {
            builder.HasKey(e => e.Idapoderado)
                   .HasName("apoderados_pkey");    

            builder.ToTable("apoderados");

            builder.Property(e => e.Idapoderado).HasColumnName("idapoderado");

            builder.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .HasColumnName("apellidos");

            builder.Property(e => e.Celular)
                .HasMaxLength(10)
                .HasColumnName("celular");

            builder.Property(e => e.Dni)
                .HasMaxLength(8)
                .HasColumnName("dni")
                .IsFixedLength(true);

            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.Property(e => e.Nombres)
                .HasMaxLength(50)
                .HasColumnName("nombres");

            builder.Property(e => e.RutaFotoDni)
                .HasMaxLength(400)
                .HasColumnName("ruta_foto_dni");
        }
    }
}
