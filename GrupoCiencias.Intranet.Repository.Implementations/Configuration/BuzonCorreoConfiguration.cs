using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class BuzonCorreoConfiguration : IEntityTypeConfiguration<BuzonCorreoEntity>
    {
        public void Configure(EntityTypeBuilder<BuzonCorreoEntity> builder)
        { 

            builder.ToTable("buzon_correo");

            builder.HasKey(e => e.Buzoncorreoid)
                   .HasName("buzon_correo_pkey");

            builder.Property(e => e.Buzoncorreoid).HasColumnName("buzoncorreoid");

            builder.Property(e => e.Activo)
                .HasColumnName("activo")
                .HasDefaultValueSql("1");

            builder.Property(e => e.Asunto)
                .HasMaxLength(250)
                .HasColumnName("asunto");

            builder.Property(e => e.Buzoncopia)
                .HasMaxLength(250)
                .HasColumnName("buzoncopia");

            builder.Property(e => e.Buzonsalida)
                .HasMaxLength(250)
                .HasColumnName("buzonsalida");

            builder.Property(e => e.Cuerpocorreo)
                .HasMaxLength(250)
                .HasColumnName("cuerpocorreo");

            builder.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");

            builder.Property(e => e.Fechacreacion)
                .HasColumnType("date")
                .HasColumnName("fechacreacion")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(e => e.Fechaeliminacion)
                .HasColumnType("date")
                .HasColumnName("fechaeliminacion");

            builder.Property(e => e.TipoNotificacion)
                .HasMaxLength(200)
                .HasColumnName("tipo_notificacion");

            builder.Property(e => e.Usuario)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("usuario")
                .HasDefaultValueSql("'ADMIN'::character varying");
        }
    }
}
