using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class EstudiantesConfiguration : IEntityTypeConfiguration<EstudiantesEntity>
    {
        public void Configure(EntityTypeBuilder<EstudiantesEntity> builder)
        {
            builder.HasKey(e => e.Idestudiante)
                    .HasName("estudiantes_pkey");

            builder.ToTable("estudiantes");

            builder.Property(e => e.Idestudiante).HasColumnName("idestudiante");

            builder.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .HasColumnName("apellidos");

            builder.Property(e => e.Carrera).HasColumnName("carrera");

            builder.Property(e => e.Celular)
                .HasMaxLength(10)
                .HasColumnName("celular");

            builder.Property(e => e.Contrasenia)
                .HasMaxLength(400)
                .HasColumnName("contrasenia");

            builder.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");

            builder.Property(e => e.Dni)
                .HasMaxLength(8)
                .HasColumnName("dni")
                .IsFixedLength(true);

            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.Property(e => e.IdTipoDocumento).HasColumnName("id_tipo_documento");

            builder.Property(e => e.Idapoderado).HasColumnName("idapoderado");

            builder.Property(e => e.Idciclo).HasColumnName("idciclo");

            builder.Property(e => e.MedioInfo)
                .HasMaxLength(15)
                .HasColumnName("medio_info");

            builder.Property(e => e.Nombres)
                .HasMaxLength(50)
                .HasColumnName("nombres");

            builder.Property(e => e.PerfilFacebook)
                .HasMaxLength(100)
                .HasColumnName("perfil_facebook");

            builder.Property(e => e.RutaFotoDni)
                .HasMaxLength(400)
                .HasColumnName("ruta_foto_dni");

            builder.Property(e => e.RutaFotoDni2).HasColumnName("ruta_foto_dni2");

            builder.Property(e => e.RutaFotoFacebook)
                .HasMaxLength(400)
                .HasColumnName("ruta_foto_facebook");

            builder.Property(e => e.RutaFotoPerfil)
                .HasMaxLength(400)
                .HasColumnName("ruta_foto_perfil");

            builder.Property(e => e.RutaFotoVoucherPago)
                .HasMaxLength(400)
                .HasColumnName("ruta_foto_voucher_pago");

            builder.Property(e => e.RutaVideoRegistro)
                .HasMaxLength(400)
                .HasColumnName("ruta_video_registro");

            builder.Property(e => e.Usuario)
                .HasMaxLength(20)
                .HasColumnName("usuario");

            builder.HasOne(d => d.Apoderado)
                .WithMany(p => p.Estudiantes)
                .HasForeignKey(d => d.Idapoderado)
                .HasConstraintName("apoderados_estudiantes_constraint");
        }
    }
}
