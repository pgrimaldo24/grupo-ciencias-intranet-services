using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class MarketingConfiguration : IEntityTypeConfiguration<MarketingEntity>
    {
        public void Configure(EntityTypeBuilder<MarketingEntity> builder)
        {
            builder.HasKey(e => e.Idmarketing)
                    .HasName("marketing_pkey");

            builder.ToTable("marketing");

            builder.Property(e => e.Idmarketing).HasColumnName("idmarketing");

            builder.Property(e => e.Activo)
                .HasColumnName("activo")
                .HasDefaultValueSql("1");

            builder.Property(e => e.Fechabaja)
                .HasColumnType("date")
                .HasColumnName("fechabaja");

            builder.Property(e => e.Fechacreacion)
                .HasColumnType("date")
                .HasColumnName("fechacreacion")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(e => e.Idmaster)
                .HasMaxLength(50)
                .HasColumnName("idmaster");

            builder.Property(e => e.Usuario)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("usuario")
                .HasDefaultValueSql("'ADMIN'::character varying");

            builder.Property(e => e.Valor)
                .HasMaxLength(200)
                .HasColumnName("valor");

            builder.HasOne(d => d.Master)
                .WithMany(p => p.Marketings)
                .HasForeignKey(d => d.Idmaster)
                .HasConstraintName("master_marketing_constraint");
        }
    }
}
