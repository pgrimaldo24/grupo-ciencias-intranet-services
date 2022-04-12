using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class AccesoMesesConfiguration : IEntityTypeConfiguration<AccesoMesesEntity>
    {
        public void Configure(EntityTypeBuilder<AccesoMesesEntity> builder)
        {
            builder.HasNoKey();

            builder.ToTable("acceso_meses");

            builder.HasIndex(e => e.Idmes, "relationship_18_fk");

            builder.HasIndex(e => e.Idestudiante, "relationship_19_fk");

            builder.Property(e => e.Estado).HasColumnName("estado");
 
            builder.Property(e => e.Idestudiante).HasColumnName("idestudiante");

            builder.Property(e => e.Idmes).HasColumnName("idmes");

            builder.HasOne(d => d.EstudianteNavigation)
                .WithMany()
                .HasForeignKey(d => d.Idestudiante)
                .HasConstraintName("fk_acceso_m_relations_estudian");

            builder.HasOne(d => d.MesNavigation)
                .WithMany()
                .HasForeignKey(d => d.Idmes)
                .HasConstraintName("fk_acceso_m_relations_meses");
        }
    }
}
