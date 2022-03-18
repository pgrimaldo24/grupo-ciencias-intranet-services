using GrupoCiencias.Intranet.Domain.Models.MercadoPago;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class EstadoPagoConfiguration : IEntityTypeConfiguration<EstadoPagoEntity>
    {
        public void Configure(EntityTypeBuilder<EstadoPagoEntity> builder)
        {

            builder.ToTable("estado_pago");

            builder.Property(e => e.IdEstadoPago).HasColumnName("idestadopago");

            builder.Property(e => e.Estado)
                .HasColumnName("estado")
                .HasDefaultValueSql("1");

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


            builder.Property(e => e.Usuario)
               .HasMaxLength(50)
               .HasColumnName("usuario");

            builder.Property(e => e.EstadoPago)
                .HasMaxLength(50)
                .HasColumnName("estadopago");

            builder.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasColumnName("descripcion"); 
        }
    }
}
