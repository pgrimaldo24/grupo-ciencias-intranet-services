using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.HasKey(e => e.Idusuario)
                  .HasName("pk_usuarios");

            builder.ToTable("usuarios");

            builder.HasIndex(e => e.Idusuario, "usuarios_pk")
                .IsUnique();

            builder.Property(e => e.Idusuario)
                .ValueGeneratedNever()
                .HasColumnName("idusuario");

            builder.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .HasColumnName("apellidos");

            builder.Property(e => e.Celular)
                .HasMaxLength(10)
                .HasColumnName("celular");

            builder.Property(e => e.Contrasenia)
                .HasMaxLength(400)
                .HasColumnName("contrasenia");

            builder.Property(e => e.Dni)
                .HasMaxLength(8)
                .HasColumnName("dni")
                .IsFixedLength(true);

            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.Property(e => e.FechaRegistro)
                .HasColumnType("date")
                .HasColumnName("fecha_registro");

            builder.Property(e => e.FotoPerfil)
                .HasMaxLength(400)
                .HasColumnName("foto_perfil");

            builder.Property(e => e.Nombres)
                .HasMaxLength(50)
                .HasColumnName("nombres");

            builder.Property(e => e.Perfil)
                .HasMaxLength(100)
                .HasColumnName("perfil");

            builder.Property(e => e.Usuario1)
                .HasMaxLength(20)
                .HasColumnName("usuario");
        }
    }
}
