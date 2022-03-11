using GrupoCiencias.Intranet.Domain.Models.Entity;
using GrupoCiencias.Intranet.Repository.Implementations.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GrupoCiencias.Intranet.Repository.Implementations.Data
{
    public class DataContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContext;
        public DataContext(DbContextOptions<DataContext> options, IHttpContextAccessor httpContext)
          : base(options)
        {
            _httpContext = httpContext;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new SolicitudesConfiguration());
            builder.ApplyConfiguration(new EstudiantesConfiguration());
            builder.ApplyConfiguration(new ApoderadosConfiguration());
            builder.ApplyConfiguration(new CarrerasConfiguration());
            builder.ApplyConfiguration(new AreasCarreraConfiguration());
            builder.ApplyConfiguration(new CiclosConfiguration());
            builder.ApplyConfiguration(new CursosCicloConfiguration());
            builder.ApplyConfiguration(new UniversidadConfiguration());
        }

        public virtual DbSet<SolicitudesEntity> Solicitudes { get; set; }
        public virtual DbSet<EstudiantesEntity> Estudiantes { get; set; }
        public virtual DbSet<ApoderadosEntity> Apoderado { get; set; }
        public virtual DbSet<CarrerasEntity> Carreras { get; set; }
        public virtual DbSet<AreasCarreraEntity> AreasCarrera { get; set; }
        public virtual DbSet<CiclosEntity> Ciclos { get; set; }
        public virtual DbSet<CursosCicloEntity> CursosCiclo { get; set; }
        public virtual DbSet<UniversidadEntity> Universidad { get; set; }
    }
}
