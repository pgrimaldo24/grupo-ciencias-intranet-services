using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class ParametrosConfiguration : IEntityTypeConfiguration<ParametrosEntity>
    {
        public void Configure(EntityTypeBuilder<ParametrosEntity> builder)
        {
            builder.HasKey(e => e.Idparametro)
                  .HasName("pk_parametros");

            builder.ToTable("parametros");

            builder.HasIndex(e => e.Idparametro, "parametros_pk")
                .IsUnique();

            builder.Property(e => e.Idparametro)
                .ValueGeneratedNever()
                .HasColumnName("idparametro");

            builder.Property(e => e.Descripcion)
                .HasMaxLength(400)
                .HasColumnName("descripcion");
        }
    }
}
