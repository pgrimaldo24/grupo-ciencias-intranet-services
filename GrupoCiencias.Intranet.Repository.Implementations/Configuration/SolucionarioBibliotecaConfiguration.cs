using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class SolucionarioBibliotecaConfiguration : IEntityTypeConfiguration<SolucionarioBibliotecaEntity>
    {
        public void Configure(EntityTypeBuilder<SolucionarioBibliotecaEntity> builder)
        {
            builder.HasKey(e => e.Idsolucionario)
                    .HasName("pk_solucionario_biblioteca");

            builder.ToTable("solucionario_biblioteca");

            builder.HasIndex(e => e.Idsemestre, "relationship_43_fk");

            builder.HasIndex(e => e.Iduniversidad, "relationship_44_fk");

            builder.HasIndex(e => e.Idsolucionario, "solucionario_biblioteca_pk")
                .IsUnique();

            builder.Property(e => e.Idsolucionario)
                .HasColumnName("idsolucionario")
                .UseIdentityAlwaysColumn();

            builder.Property(e => e.Estado)
                .HasColumnName("estado")
                .HasDefaultValueSql("1");

            builder.Property(e => e.Idsemestre).HasColumnName("idsemestre");

            builder.Property(e => e.Iduniversidad).HasColumnName("iduniversidad");

            builder.Property(e => e.NombreSolucionario)
                .HasMaxLength(100)
                .HasColumnName("nombre_solucionario");

            builder.Property(e => e.UrlSolucionario)
                .HasMaxLength(500)
                .HasColumnName("url_solucionario");

            builder.HasOne(d => d.IdsemestreNavigation)
                .WithMany(p => p.SolucionarioBibliotecas)
                .HasForeignKey(d => d.Idsemestre)
                .HasConstraintName("fk_solucion_relations_semestre");

            builder.HasOne(d => d.IduniversidadNavigation)
                .WithMany(p => p.SolucionarioBibliotecas)
                .HasForeignKey(d => d.Iduniversidad)
                .HasConstraintName("fk_solucion_relations_universi");
        }
    }
}
