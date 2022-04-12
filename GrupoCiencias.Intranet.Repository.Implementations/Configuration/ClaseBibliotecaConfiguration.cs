using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class ClaseBibliotecaConfiguration : IEntityTypeConfiguration<ClaseBibliotecaEntity>
    {
        public void Configure(EntityTypeBuilder<ClaseBibliotecaEntity> builder)
        {
            builder.HasKey(e => e.Idclase)
                 .HasName("pk_clase_biblioteca");

            builder.ToTable("clase_biblioteca");

            builder.HasIndex(e => e.Idclase, "clase_biblioteca_pk")
                .IsUnique();

            builder.HasIndex(e => e.Idtema, "relationship_48_fk");

            builder.Property(e => e.Idclase)
                .HasColumnName("idclase")
                .UseIdentityAlwaysColumn();

            builder.Property(e => e.Estado)
                .HasColumnName("estado")
                .HasDefaultValueSql("1");

            builder.Property(e => e.Idtema).HasColumnName("idtema");

            builder.Property(e => e.UrlClase)
                .HasMaxLength(500)
                .HasColumnName("url_clase");

            builder.HasOne(d => d.IdtemaNavigation)
                .WithMany(p => p.ClaseBibliotecas)
                .HasForeignKey(d => d.Idtema)
                .HasConstraintName("fk_clase_bi_relations_tema_bib");
        }
    }
}
