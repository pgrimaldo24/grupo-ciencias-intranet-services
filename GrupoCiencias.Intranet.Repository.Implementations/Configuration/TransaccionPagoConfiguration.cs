using GrupoCiencias.Intranet.Domain.Models.MercadoPago;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class TransaccionPagoConfiguration : IEntityTypeConfiguration<TransaccionPagoEntity>
    {
        public void Configure(EntityTypeBuilder<TransaccionPagoEntity> builder)
        {
            builder.ToTable("transaccion_pago");

            builder.HasKey(e => e.IdTransaccionPago)
                   .HasName("transaccion_pago_pkey"); 
             
            builder.Property(e => e.IdTransaccionPago).HasColumnName("id_transaccion_pago");

            builder.Property(e => e.ApellidoTitular)
                .HasMaxLength(100)
                .HasColumnName("apellido_titular");

            builder.Property(e => e.CodPagoReferencia)
                .HasMaxLength(50)
                .HasColumnName("cod_pago_referencia");

            builder.Property(e => e.CodPagoRefIndex).HasColumnName("codpagorefindex");

            builder.Property(e => e.CuotasPago)
                 .HasMaxLength(100)
                .HasColumnName("cuotas_pago");

            builder.Property(e => e.EmailTitular)
               .HasMaxLength(100)
                .HasColumnName("email_titular");

            builder.Property(e => e.EstadoPago)
                .HasMaxLength(100)
                .HasColumnName("estado_pago");

            builder.Property(e => e.EstadoPagoDetalle)
                .HasMaxLength(100)
                .HasColumnName("estado_pago_detalle");

            builder.Property(e => e.EstadoRegistro)
                .HasColumnName("estado_registro")
                .HasDefaultValueSql("1");
             

            builder.Property(e => e.FechaAprovadaPago)
                .HasMaxLength(100)
                .HasColumnName("fecha_aprovada_pago");

            builder.Property(e => e.FechaBajaRegistro)
                .HasColumnType("date")
                .HasColumnName("fecha_baja_registro");

            builder.Property(e => e.FechaCreacionRegistro)
                .HasColumnType("date")
                .HasColumnName("fecha_creacion_registro")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(e => e.FechaCreadaPago)
                .HasMaxLength(100)
                .HasColumnName("fecha_creada_pago");

            builder.Property(e => e.FechaLiberacionDinero)
                .HasMaxLength(100)
                .HasColumnName("fecha_liberacion_dinero");

            builder.Property(e => e.FechaUltimaActualizacion)
                .HasMaxLength(100)
                .HasColumnName("fecha_ultima_actualizacion");

            builder.Property(e => e.IdComprobantePago)
                .HasMaxLength(50)
                .HasColumnName("id_comprobante_pago");

            builder.Property(e => e.IdTipoTarjeta)
                .HasMaxLength(100)
                .HasColumnName("id_tipo_tarjeta");

            builder.Property(e => e.MetodoPagoId)
                .HasMaxLength(100)
                .HasColumnName("metodo_pago_id");

            builder.Property(e => e.MontoTransaccion)
                .HasMaxLength(100)
                .HasColumnName("monto_transaccion");

            builder.Property(e => e.NombreTitular)
                .HasMaxLength(100)
                .HasColumnName("nombre_titular");

            builder.Property(e => e.NotificacionUrl)
                .HasMaxLength(100)
                .HasColumnName("notificacion_url");

            builder.Property(e => e.NumeroDocumentoTitular)
                .HasMaxLength(100)
                .HasColumnName("numero_documento_titular");

            builder.Property(e => e.Proveedor)
                .HasMaxLength(50)
                .HasColumnName("proveedor");

            builder.Property(e => e.TipoDocumentoTitularId)
                .HasColumnType("int4")
                .HasColumnName("tipo_documento_titular_id");

            builder.Property(e => e.TipoMoneda)
                .HasMaxLength(100)
                .HasColumnName("tipo_moneda");

            builder.Property(e => e.TokenCard)
                .HasMaxLength(200)
                .HasColumnName("token_card");
        }
    }
}
