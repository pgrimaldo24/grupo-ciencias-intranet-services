using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class AreasCarreraConfiguration : IEntityTypeConfiguration<AreasCarreraEntity>
    {
        public void Configure(EntityTypeBuilder<AreasCarreraEntity> builder)
        {
            builder.HasKey(e => e.Idarea)
                                .HasName("areas_carrera_pkey");

            builder.ToTable("areas_carrera");

            builder.Property(e => e.Idarea).HasColumnName("idarea");

            builder.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");

            builder.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("fecha_creacion");

            builder.Property(e => e.Iduniversidad).HasColumnName("iduniversidad");

            builder.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            builder.Property(e => e.PreguntaCorrecta)
                .HasPrecision(5, 2)
                .HasColumnName("pregunta_correcta");

            builder.Property(e => e.PreguntaEnBlanco)
                .HasPrecision(5, 2)
                .HasColumnName("pregunta_en_blanco");

            builder.Property(e => e.PreguntaIncorrecta).HasColumnName("pregunta_incorrecta");

            builder.HasOne(d => d.Universidad)
                .WithMany(p => p.AreasCarreras)
                .HasForeignKey(d => d.Iduniversidad)
                .HasConstraintName("areas_carreras_universidad_constraint");
        }
    }
}
