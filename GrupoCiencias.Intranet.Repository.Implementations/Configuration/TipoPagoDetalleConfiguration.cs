using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class TipoPagoDetalleConfiguration : IEntityTypeConfiguration<TipoPagoDetalleEntity>
    {
        public void Configure(EntityTypeBuilder<TipoPagoDetalleEntity> builder)
        {
            builder.HasKey(e => e.Idpagodetalle)
                    .HasName("tipo_pago_detalle_pkey");

            builder.ToTable("tipo_pago_detalle");

            builder.Property(e => e.Idpagodetalle).HasColumnName("idpagodetalle");

            builder.Property(e => e.Descuento)
                .HasPrecision(9, 2)
                .HasColumnName("descuento");

            builder.Property(e => e.Idciclo).HasColumnName("idciclo");

            builder.Property(e => e.Idtipopago).HasColumnName("idtipopago");

            builder.Property(e => e.Preciofinal)
                .HasPrecision(9, 2)
                .HasColumnName("preciofinal");

            builder.Property(e => e.Subtotal)
                .HasPrecision(9, 2)
                .HasColumnName("subtotal");

            builder.Property(e => e.IdSede).HasColumnName("idsede");

        }
    }
}
