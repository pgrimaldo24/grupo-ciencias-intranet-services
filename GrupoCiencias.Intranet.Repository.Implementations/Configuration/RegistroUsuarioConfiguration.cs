using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class RegistroUsuarioConfiguration : IEntityTypeConfiguration<RegistroUsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<RegistroUsuarioEntity> builder)
        {
            builder.HasKey(e => e.Id)
                   .HasName("registrousuario_pkey");

            builder.ToTable("registrousuario");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Ciclo)
                .HasMaxLength(50)
                .HasColumnName("ciclo");

            builder.Property(e => e.Nombreapellido)
                .HasMaxLength(100)
                .HasColumnName("nombreapellido");

            builder.Property(e => e.Dni).HasColumnName("dni");

            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");

            builder.Property(e => e.Celular).HasColumnName("celular");
        }
    }
}