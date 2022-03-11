using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class RedsocialConfiguration : IEntityTypeConfiguration<RedSocialEntity>
    {
        public void Configure(EntityTypeBuilder<RedSocialEntity> builder)
        {
            builder.HasKey(e => e.Idred)
                  .HasName("redsocial_pkey");

            builder.ToTable("redsocial");

            builder.Property(e => e.Idred).HasColumnName("idred");

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
                .WithMany(p => p.Redsocials)
                .HasForeignKey(d => d.Idmaster)
                .HasConstraintName("master_redsocial_constraint");
        }
    }
}
