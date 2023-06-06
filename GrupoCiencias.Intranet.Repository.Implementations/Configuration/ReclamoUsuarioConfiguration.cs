using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class ReclamoUsuarioConfiguration : IEntityTypeConfiguration<ReclamoUsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<ReclamoUsuarioEntity> builder)
        {
            builder.HasKey(e => e.Id)
                   .HasName("registrousuario_pkey");

            builder.ToTable("reclamousuario");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Tipodocumento)
                .HasMaxLength(50)
                .HasColumnName("tipodocumento");

            builder.Property(e => e.Numerodocumento).HasColumnName("numerodocumento");

            builder.Property(e => e.Nombres)
                .HasMaxLength(100)
                .HasColumnName("nombres");

            builder.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .HasColumnName("apellidos");

            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");

            builder.Property(e => e.Telefono).HasColumnName("telefono");

            builder.Property(e => e.Provincia)
                .HasMaxLength(100)
                .HasColumnName("provincia");

            builder.Property(e => e.Direccion)
                .HasMaxLength(150)
                .HasColumnName("direccion");

            builder.Property(e => e.Sede)
                .HasMaxLength(150)
                .HasColumnName("sede");

            builder.Property(e => e.Ciclo)
                .HasMaxLength(150)
                .HasColumnName("ciclo");

            builder.Property(e => e.Comentario)
                .HasMaxLength(150)
                .HasColumnName("comentario");

            builder.Property(e => e.Solicitud)
                .HasMaxLength(150)
                .HasColumnName("solicitud");

            builder.Property(e => e.PoliticasFinesComerciales).HasColumnName("politicasfinescomerciales");

            builder.Property(e => e.PoliticasSeguridad).HasColumnName("politicasseguridad");
        }
    }
}