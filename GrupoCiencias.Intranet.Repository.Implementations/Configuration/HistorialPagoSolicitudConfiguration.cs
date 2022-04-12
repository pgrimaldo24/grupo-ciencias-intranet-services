using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class HistorialPagoSolicitudConfiguration : IEntityTypeConfiguration<HistorialPagoSolicitudEntity>
    {
        public void Configure(EntityTypeBuilder<HistorialPagoSolicitudEntity> builder)
        { 
            builder.ToTable("historial_pago_solicitud");

            builder.HasKey(e => e.IdHistorialPagoSolicitud).HasName("historial_pago_solictud_pkey");

            builder.Property(e => e.IdHistorialPagoSolicitud).HasColumnName("id_historial_pago_solicitud");

            builder.Property(e => e.Idsolicitud).HasColumnName("idsolicitud");

            builder.Property(e => e.IdTransaccionPago).HasColumnName("id_transaccion_pago");

            builder.Property(e => e.Fechacreacion)
                 .HasColumnType("date")
                 .HasColumnName("fechacreacion")
                 .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(e => e.Fechabaja)
                  .HasColumnType("date")
                  .HasColumnName("fechabaja");
        }
    }
}
