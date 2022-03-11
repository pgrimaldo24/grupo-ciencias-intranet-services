using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class MasterConfiguration : IEntityTypeConfiguration<MasterEntity>
    {
        public void Configure(EntityTypeBuilder<MasterEntity> builder)
        {
            builder.HasKey(e => e.Idmaster)
                  .HasName("master_pkey");

            builder.ToTable("master");

            builder.Property(e => e.Idmaster)
                .HasMaxLength(50)
                .HasColumnName("idmaster");

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

            builder.Property(e => e.Usuario)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("usuario")
                .HasDefaultValueSql("'ADMIN'::character varying");

            builder.Property(e => e.Valor)
                .HasMaxLength(200)
                .HasColumnName("valor");
        }
    }
}
