using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class MaterialBibliotecaConfiguration : IEntityTypeConfiguration<MaterialBibliotecaEntity>
    {
        public void Configure(EntityTypeBuilder<MaterialBibliotecaEntity> builder)
        {
            builder.HasKey(e => e.Idmaterial)
                   .HasName("pk_material_biblioteca");

            builder.ToTable("material_biblioteca");

            builder.HasIndex(e => e.Idmaterial, "material_biblioteca_pk")
                .IsUnique();

            builder.HasIndex(e => e.Idtema, "relationship_51_fk");

            builder.Property(e => e.Idmaterial)
                .HasColumnName("idmaterial")
                .UseIdentityAlwaysColumn();

            builder.Property(e => e.Estado)
                .HasColumnName("estado")
                .HasDefaultValueSql("1");

            builder.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");

            builder.Property(e => e.Idtema).HasColumnName("idtema");

            builder.Property(e => e.NombreMaterial)
                .HasMaxLength(100)
                .HasColumnName("nombre_material");

            builder.Property(e => e.UrlClaseRelacionada)
                .HasMaxLength(500)
                .HasColumnName("url_clase_relacionada");

            builder.Property(e => e.UrlMaterial)
                .HasMaxLength(500)
                .HasColumnName("url_material");

            builder.HasOne(d => d.IdtemaNavigation)
                .WithMany(p => p.MaterialBibliotecas)
                .HasForeignKey(d => d.Idtema)
                .HasConstraintName("fk_material_relations_tema");
        }
    }
}
