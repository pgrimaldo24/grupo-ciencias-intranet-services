using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class TipoPagoDetalleConfiguration : IEntityTypeConfiguration<TipoPagoDetalleEntity>
    {
        public void Configure(EntityTypeBuilder<TipoPagoDetalleEntity> builder)
        {
            builder.ToTable("tipo_pago_detalle");

            builder.HasKey(e => e.idpagodetalle)
            .HasName("idpagodetalle");

            builder.Property(e => e.idtipopago).
            HasColumnName("idtipopago");

            builder.Property(e => e.idciclo)
            .HasColumnName("idciclo");

            builder.Property(e => e.subtotal)
            .HasColumnName("subtotal")
            .HasColumnType("numeric(9, 2)");

            builder.Property(e => e.descuento)
            .HasColumnName("descuento")
            .HasColumnType("numeric(9, 2)");

            builder.Property(e => e.preciofinal)
            .HasColumnName("preciofinal")
            .HasColumnType("numeric(9, 2)"); 

        }
    }
}
