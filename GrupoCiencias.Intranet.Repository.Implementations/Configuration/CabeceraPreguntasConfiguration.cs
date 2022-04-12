using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class CabeceraPreguntasConfiguration : IEntityTypeConfiguration<CabeceraPreguntasEntity> 
    {
        public void Configure(EntityTypeBuilder<CabeceraPreguntasEntity> builder)
        {
            builder.HasKey(e => e.Idcabecerapregunta)
                    .HasName("pk_cabecera_pregunta");

            builder.ToTable("cabecera_pregunta");

            builder.HasIndex(e => e.Idcabecerapregunta, "cebecerapregunta_pk")
                .IsUnique();

            builder.HasIndex(e => e.Idusuario, "relationship_10_fk");

            builder.HasIndex(e => e.Idtema, "relationship_11_fk");

            builder.HasIndex(e => e.Idciclo, "relationship_9_fk");

            builder.Property(e => e.Idcabecerapregunta)
                .ValueGeneratedNever()
                .HasColumnName("idcabecerapregunta");

            builder.Property(e => e.Deco)
                .HasMaxLength(20)
                .HasColumnName("deco");

            builder.Property(e => e.Dificultad).HasColumnName("dificultad");

            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.Property(e => e.FechaRegistro)
                .HasColumnType("date")
                .HasColumnName("fecha_registro");

            builder.Property(e => e.Idciclo).HasColumnName("idciclo");

            builder.Property(e => e.Idtema).HasColumnName("idtema");

            builder.Property(e => e.Idusuario).HasColumnName("idusuario");

            builder.Property(e => e.Observacion)
                .HasMaxLength(200)
                .HasColumnName("observacion");

            builder.Property(e => e.Texto).HasColumnName("texto");

            builder.Property(e => e.TipoPregunta)
                .HasMaxLength(50)
                .HasColumnName("tipo_pregunta");

            builder.HasOne(d => d.IdcicloNavigation)
                .WithMany(p => p.CabeceraPregunta)
                .HasForeignKey(d => d.Idciclo)
                .HasConstraintName("fk_cabecera_relations_ciclos");

            builder.HasOne(d => d.IdtemaNavigation)
                .WithMany(p => p.CabeceraPregunta)
                .HasForeignKey(d => d.Idtema)
                .HasConstraintName("fk_cabecera_relations_temas");

            builder.HasOne(d => d.IdusuarioNavigation)
                .WithMany(p => p.CabeceraPregunta)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("fk_cabecera_relations_usuarios");
        }
    }
}
