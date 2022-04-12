using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class ComunicadosConfiguration : IEntityTypeConfiguration<ComunicadosEntity>
    {
        public void Configure(EntityTypeBuilder<ComunicadosEntity> builder)
        {
            builder.HasKey(e => e.Idcomunicado)
                         .HasName("pk_comunicados");

            builder.ToTable("comunicados");

            builder.HasIndex(e => e.Idcomunicado, "comunicados_pk")
                .IsUnique();

            builder.HasIndex(e => e.Idciclo, "relationship_20_fk");

            builder.Property(e => e.Idcomunicado)
                .ValueGeneratedNever()
                .HasColumnName("idcomunicado");

            builder.Property(e => e.Descripcion).HasColumnName("descripcion");

            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.Property(e => e.FechaFin)
                .HasColumnType("date")
                .HasColumnName("fecha_fin");

            builder.Property(e => e.FechaInicio)
                .HasColumnType("date")
                .HasColumnName("fecha_inicio");

            builder.Property(e => e.Idciclo).HasColumnName("idciclo");

            builder.Property(e => e.Universidad).HasColumnName("universidad");

            builder.HasOne(d => d.IdcicloNavigation)
                .WithMany(p => p.Comunicados)
                .HasForeignKey(d => d.Idciclo)
                .HasConstraintName("fk_comunica_relations_ciclos");
        }
    }
}
