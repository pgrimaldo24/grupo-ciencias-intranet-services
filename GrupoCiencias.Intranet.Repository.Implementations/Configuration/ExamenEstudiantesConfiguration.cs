using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class ExamenEstudiantesConfiguration : IEntityTypeConfiguration<ExamenEstudiantesEntity>
    {
        public void Configure(EntityTypeBuilder<ExamenEstudiantesEntity> builder)
        {
            builder.HasKey(e => new { e.Idexamen, e.Idestudiante })
                    .HasName("pk_examen_estudiante");

            builder.ToTable("examen_estudiante");

            builder.HasComment("lista_respuestas: \n  idpregunta,\n  estado_pregunta:(buena,mala,en blanco),\n  valoracion de la pregunta\n\n \n");

            builder.HasIndex(e => new { e.Idexamen, e.Idestudiante }, "examen_estudiante_pk")
                .IsUnique();

            builder.HasIndex(e => e.Idestudiante, "relationship_26_fk");

            builder.HasIndex(e => e.Idexamen, "relationship_32_fk");

            builder.Property(e => e.Idexamen).HasColumnName("idexamen");

            builder.Property(e => e.Idestudiante).HasColumnName("idestudiante");

            builder.Property(e => e.ListaRespuestas).HasColumnName("lista_respuestas");

            builder.Property(e => e.NotaTotal).HasColumnName("nota_total");

            builder.Property(e => e.Tiempo)
                .HasMaxLength(10)
                .HasColumnName("tiempo");

            builder.Property(e => e.TotalCorrectas).HasColumnName("total_correctas");

            builder.Property(e => e.TotalEnBlanco).HasColumnName("total_en_blanco");

            builder.Property(e => e.TotalIncorrectas).HasColumnName("total_incorrectas");

            builder.HasOne(d => d.IdestudianteNavigation)
                .WithMany(p => p.ExamenEstudiantes)
                .HasForeignKey(d => d.Idestudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_examen_e_relations_estudian");

            builder.HasOne(d => d.IdexamenNavigation)
                .WithMany(p => p.ExamenEstudiantes)
                .HasForeignKey(d => d.Idexamen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_examen_e_relations_examen");

        }
    }
}
