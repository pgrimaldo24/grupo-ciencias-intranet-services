using GrupoCiencias.Intranet.Domain.Models.Entity; 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class EstadoPagoConfiguration : IEntityTypeConfiguration<EstadoPagoEntity>
    {
        public void Configure(EntityTypeBuilder<EstadoPagoEntity> builder)
        {
            builder.HasKey(e => e.Idestadopago)
                   .HasName("estado_pago_pkey");

            builder.ToTable("estado_pago");

            builder.Property(e => e.Idestadopago).HasColumnName("idestadopago");

            builder.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasColumnName("descripcion");

            builder.Property(e => e.Estado)
                .HasColumnName("estado")
                .HasDefaultValueSql("1");

            builder.Property(e => e.EstadoPagoDetalle)
                .HasMaxLength(50)
                .HasColumnName("estado_pago_detalle");

            builder.Property(e => e.EstadoPago)
                .HasMaxLength(50)
                .HasColumnName("estadopago");

            builder.Property(e => e.FechaBaja)
                .HasColumnType("date")
                .HasColumnName("fechabaja");

            builder.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("fechacreacion")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(e => e.Usuario)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("usuario")
                .HasDefaultValueSql("'ADMIN'::character varying");
        }
    }
}
