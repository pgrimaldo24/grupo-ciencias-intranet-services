using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class Parametros2Configuration : IEntityTypeConfiguration<Parametros2Entity>
    {
        public void Configure(EntityTypeBuilder<Parametros2Entity> builder)
        {
            builder.HasKey(e => new { e.PNumero, e.PTipo, e.PCodigo })
                 .HasName("pk_parametros2");

            builder.ToTable("parametros2");

            builder.HasIndex(e => new { e.PNumero, e.PTipo, e.PCodigo }, "parametros2_pk")
                .IsUnique();

            builder.Property(e => e.PNumero).HasColumnName("p_numero");

            builder.Property(e => e.PTipo)
                .HasMaxLength(1)
                .HasColumnName("p_tipo");

            builder.Property(e => e.PCodigo)
                .HasMaxLength(20)
                .HasColumnName("p_codigo");

            builder.Property(e => e.PDescripcion)
                .HasMaxLength(130)
                .HasColumnName("p_descripcion");

            builder.Property(e => e.PFecAct)
                .HasColumnType("date")
                .HasColumnName("p_fec_act");

            builder.Property(e => e.PUsuario)
                .HasMaxLength(8)
                .HasColumnName("p_usuario");
        }
    }
}
