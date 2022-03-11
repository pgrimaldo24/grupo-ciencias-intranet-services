using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class CursosCicloConfiguration : IEntityTypeConfiguration<CursosCicloEntity>
    {
        public void Configure(EntityTypeBuilder<CursosCicloEntity> builder)
        {
            builder.HasKey(e => e.Idciclo)
                   .HasName("cursos_ciclos_pkey");

            builder.ToTable("cursos_ciclos");

            builder.Property(e => e.Idciclo).HasColumnName("idciclo");

            builder.Property(e => e.Idcurso).HasColumnName("idcurso");
        }
    }
}
