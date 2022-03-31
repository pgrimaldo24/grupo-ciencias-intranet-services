using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class SolicitudesConfiguration : IEntityTypeConfiguration<SolicitudesEntity>
    {
        public void Configure(EntityTypeBuilder<SolicitudesEntity> builder)
        {
            builder.HasKey(e => e.Idsolicitud)
                   .HasName("solicitudes_pkey");

            builder.ToTable("solicitudes");

            builder.Property(e => e.Idsolicitud).HasColumnName("idsolicitud");

            builder.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .HasColumnName("apellidos");

            builder.Property(e => e.CarreraInteres)
                .HasMaxLength(50)
                .HasColumnName("carrera_interes");

            builder.Property(e => e.Celular)
                .HasMaxLength(10)
                .HasColumnName("celular");

            builder.Property(e => e.Ciclo).HasColumnName("ciclo");

            builder.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");

            builder.Property(e => e.Dni)
                .HasMaxLength(8)
                .HasColumnName("dni")
                .IsFixedLength(true);

            builder.Property(e => e.Estado).HasColumnName("estado");


            builder.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fecha_nacimiento");

            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");

            builder.Property(e => e.IdTipoDocumento).HasColumnName("id_tipo_documento");

            builder.Property(e => e.Idapoderado).HasColumnName("idapoderado");

            builder.Property(e => e.MedioInfo)
                .HasMaxLength(15)
                .HasColumnName("medio_info");

            builder.Property(e => e.Nombres)
                .HasMaxLength(50)
                .HasColumnName("nombres");

            builder.Property(e => e.PerfilFacebook)
                .HasMaxLength(100)
                .HasColumnName("perfil_facebook");

            builder.Property(e => e.PoliticasFinesComerciales).HasColumnName("politicas_fines_comerciales");

            builder.Property(e => e.Politicasseguridad).HasColumnName("politicasseguridad");

            builder.Property(e => e.Referido)
                .HasMaxLength(50)
                .HasColumnName("referido");

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

            builder.Property(e => e.Universidad)
                .HasMaxLength(100)
                .HasColumnName("universidad");

            builder.HasOne(d => d.Apoderado)
                .WithMany(p => p.Solicitudes)
                .HasForeignKey(d => d.Idapoderado)
                .HasConstraintName("apoderados_constraint");

            builder.Property(e => e.id_sede).HasColumnName("id_sede");

            builder.Property(e => e.id_tipopago).HasColumnName("id_tipopago");

            builder.Property(e => e.PoliticasVeracidad).HasColumnName("politicas_veracidad");
        }
    }
}
