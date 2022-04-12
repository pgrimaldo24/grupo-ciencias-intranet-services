using GrupoCiencias.Intranet.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoCiencias.Intranet.Repository.Implementations.Configuration
{
    public class AniosConfiguration : IEntityTypeConfiguration<AnioEntity>
    {
        public void Configure(EntityTypeBuilder<AnioEntity> builder)
        {
            builder.HasKey(e => e.Idanio)
                    .HasName("pk_anios");

            builder.ToTable("anios");

            builder.HasIndex(e => e.Idanio, "anios_pk")
                .IsUnique();

            builder.Property(e => e.Idanio)
                .ValueGeneratedNever()
                .HasColumnName("idanio");

            builder.Property(e => e.Anio1)
                .HasMaxLength(5)
                .HasColumnName("anio");

            builder.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("fecha_creacion");
        }
    }
}
