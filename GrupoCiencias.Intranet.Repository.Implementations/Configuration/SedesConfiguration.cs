using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class SedesConfiguration : IEntityTypeConfiguration<SedeEntity>
    {
        public void Configure(EntityTypeBuilder<SedeEntity> builder)
        {
            builder.HasKey(e => e.Idsedes)
                    .HasName("sedes_pkey");

            builder.ToTable("sedes");

            builder.Property(e => e.Idsedes).HasColumnName("idsedes");

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
                .WithMany(p => p.Sedes)
                .HasForeignKey(d => d.Idmaster)
                .HasConstraintName("master_sedes_constraint");
        }
    }
}
