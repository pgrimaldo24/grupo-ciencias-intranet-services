using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class HistorialSeguimientoConfiguration : IEntityTypeConfiguration<HistorialSeguimientoEntity>
    {
        public void Configure(EntityTypeBuilder<HistorialSeguimientoEntity> builder)
        {
            builder.HasKey(e => e.Idhistorial)
                       .HasName("pk_historial_seguimiento");

            builder.ToTable("historial_seguimiento");

            builder.HasIndex(e => e.Idhistorial, "historial_seguimiento_pk")
                .IsUnique();

            builder.HasIndex(e => e.Idusuario, "relationship_35_fk");

            builder.Property(e => e.Idhistorial)
                .ValueGeneratedNever()
                .HasColumnName("idhistorial");

            builder.Property(e => e.Actividad)
                .HasMaxLength(500)
                .HasColumnName("actividad");

            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");

            builder.Property(e => e.Hora)
                .HasColumnType("time without time zone")
                .HasColumnName("hora");

            builder.Property(e => e.Idusuario).HasColumnName("idusuario");

            builder.HasOne(d => d.IdusuarioNavigation)
                .WithMany(p => p.HistorialSeguimientos)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("fk_historia_relations_usuarios");
        }
    }
}
