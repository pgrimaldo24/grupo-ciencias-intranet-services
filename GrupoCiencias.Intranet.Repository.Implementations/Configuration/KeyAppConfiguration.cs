using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class KeyAppConfiguration : IEntityTypeConfiguration<KeyappEntity>
    {
        public void Configure(EntityTypeBuilder<KeyappEntity> builder)
        {
            builder.ToTable("keyapp");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Estado)
                .HasColumnName("estado")
                .HasDefaultValueSql("1");

            builder.Property(e => e.Fechabaja)
                .HasColumnType("date")
                .HasColumnName("fechabaja");

            builder.Property(e => e.Fechacreacion)
                .HasColumnType("date")
                .HasColumnName("fechacreacion")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
             
            builder.Property(e => e.UsuarioCreacion)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("usuario_creacion")
                .HasDefaultValueSql("'ADMIN'::character varying");


            builder.Property(e => e.Usuario)
               .HasMaxLength(50)
               .HasColumnName("usuario");

            builder.Property(e => e.Clave)
               .HasMaxLength(50)
               .HasColumnName("clave");

            builder.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("descripcion");

        }
    }
}
