using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class VideosConfiguration : IEntityTypeConfiguration<VideoEntity>
    {
        public void Configure(EntityTypeBuilder<VideoEntity> builder)
        {
            builder.HasKey(e => e.Idvideo)
                  .HasName("pk_videos");

            builder.ToTable("videos");

            builder.HasIndex(e => e.Idcurso, "relationship_2_fk");

            builder.HasIndex(e => e.Idvideo, "videos_pk")
                .IsUnique();

            builder.Property(e => e.Idvideo)
                .ValueGeneratedNever()
                .HasColumnName("idvideo");

            builder.Property(e => e.Idcurso).HasColumnName("idcurso");

            builder.Property(e => e.RutaVideo)
                .HasMaxLength(400)
                .HasColumnName("ruta_video");

            builder.HasOne(d => d.IdcursoNavigation)
                .WithMany(p => p.Videos)
                .HasForeignKey(d => d.Idcurso)
                .HasConstraintName("fk_videos_relations_cursos");
        }
    }
}
