using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class HistorialWebhooksConfiguration : IEntityTypeConfiguration<HistorialWebhookEntity>
    {
        public void Configure(EntityTypeBuilder<HistorialWebhookEntity> builder)
        {
            builder.HasKey(e => e.IdHistorialWebhooks)
                   .HasName("historial_webhooks_pkey");

            builder.ToTable("historial_webhooks");

            builder.Property(e => e.IdHistorialWebhooks).HasColumnName("id_historial_webhooks");

            builder.Property(e => e.FechaBaja)
                .HasColumnType("date")
                .HasColumnName("fecha_baja");

            builder.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("fecha_creacion");

            builder.Property(e => e.IdTransaccionPago).HasColumnName("id_transaccion_pago");

            builder.Property(e => e.IdTransactionService)
                .HasMaxLength(20)
                .HasColumnName("id_transaction_service");

            builder.Property(e => e.Message)
                .HasMaxLength(100)
                .HasColumnName("message");

            builder.Property(e => e.StatusCode)
                .HasMaxLength(15)
                .HasColumnName("status_code");

            builder.Property(e => e.UrlGuid)
                .HasMaxLength(200)
                .HasColumnName("url_guid");
        }
    }
}
