using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class ExamenConfiguration : IEntityTypeConfiguration<ExamenEntity>
    {
        public void Configure(EntityTypeBuilder<ExamenEntity> builder)
        {
            builder.HasKey(e => e.Idexamen)
                  .HasName("pk_examen");

            builder.ToTable("examen");

            builder.HasComment("puederetroceder:\n\n1- si\n0 -no\n\nestado:\n\n1-programado\n2-finalizado\n3-cancelado\n0-eliminado");

            builder.HasIndex(e => e.Idexamen, "examen_pk")
                .IsUnique();

            builder.HasIndex(e => e.Idarea, "relationship_12_fk");

            builder.HasIndex(e => e.Idciclo, "relationship_29_fk");

            builder.Property(e => e.Idexamen)
                .ValueGeneratedNever()
                .HasColumnName("idexamen");

            builder.Property(e => e.Encuesta).HasColumnName("encuesta");

            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.Property(e => e.FechaExamen)
                .HasColumnType("date")
                .HasColumnName("fecha_examen");

            builder.Property(e => e.FechaRegistro)
                .HasColumnType("date")
                .HasColumnName("fecha_registro");

            builder.Property(e => e.HoraFin)
                .HasColumnType("time without time zone")
                .HasColumnName("hora_fin");

            builder.Property(e => e.HoraInicio)
                .HasColumnType("time without time zone")
                .HasColumnName("hora_inicio");

            builder.Property(e => e.Idarea).HasColumnName("idarea");

            builder.Property(e => e.Idciclo).HasColumnName("idciclo");

            builder.Property(e => e.ListaPreguntas).HasColumnName("lista_preguntas");

            builder.Property(e => e.PuedeRetroceder).HasColumnName("puede_retroceder");

            builder.Property(e => e.SaltoPregunta)
                .HasColumnName("salto_pregunta")
                .HasDefaultValueSql("0");

            builder.Property(e => e.TipoExamen)
                .HasColumnName("tipo_examen")
                .HasDefaultValueSql("0");

            builder.Property(e => e.UrlExamenBlanco).HasColumnName("url_examen_blanco");

            builder.Property(e => e.UrlExamenBlancoResumido).HasColumnName("url_examen_blanco_resumido");

            builder.Property(e => e.UrlExamenRespuestas).HasColumnName("url_examen_respuestas");

            builder.Property(e => e.UrlExamenRespuestasResumido).HasColumnName("url_examen_respuestas_resumido");

            builder.HasOne(d => d.AreaNavigation)
                .WithMany(p => p.Examenes)
                .HasForeignKey(d => d.Idarea)
                .HasConstraintName("fk_examen_relations_areas_ca");

            builder.HasOne(d => d.CicloNavigation)
                .WithMany(p => p.Examenes)
                .HasForeignKey(d => d.Idciclo)
                .HasConstraintName("fk_examen_relations_ciclos");
        }
    }
}
