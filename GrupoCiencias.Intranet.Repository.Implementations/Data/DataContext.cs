using GrupoCiencias.Intranet.Domain.Models.Entity;
using GrupoCiencias.Intranet.Domain.Models.MercadoPago;
using GrupoCiencias.Intranet.Repository.Implementations.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GrupoCiencias.Intranet.Repository.Implementations.Data
{
    public class DataContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContext;
        public DataContext(DbContextOptions<DataContext> options, IHttpContextAccessor httpContext) : base(options)
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
            builder.ApplyConfiguration(new MasterConfiguration());
            builder.ApplyConfiguration(new MarketingConfiguration());
            builder.ApplyConfiguration(new RedsocialConfiguration());
            builder.ApplyConfiguration(new SedesConfiguration());
            builder.ApplyConfiguration(new TipoDocumentoConfiguration());
            builder.ApplyConfiguration(new KeyAppConfiguration());
            builder.ApplyConfiguration(new TipoPagoDetalleConfiguration());
            builder.ApplyConfiguration(new EstadoPagoConfiguration());
            builder.ApplyConfiguration(new TransaccionPagoConfiguration());
            builder.ApplyConfiguration(new HistorialPagoSolicitudConfiguration());
        }

        public virtual DbSet<SolicitudesEntity> Solicitudes { get; set; }
        public virtual DbSet<EstudiantesEntity> Estudiantes { get; set; }
        public virtual DbSet<ApoderadosEntity> Apoderado { get; set; }
        public virtual DbSet<CarrerasEntity> Carreras { get; set; }
        public virtual DbSet<AreasCarreraEntity> AreasCarrera { get; set; }
        public virtual DbSet<CiclosEntity> Ciclos { get; set; }
        public virtual DbSet<CursosCicloEntity> CursosCiclo { get; set; }
        public virtual DbSet<UniversidadEntity> Universidad { get; set; }
        public virtual DbSet<MarketingEntity> Marketings { get; set; }
        public virtual DbSet<TipoPagoEntity> TipoPagos { get; set; }
        public virtual DbSet<SedeEntity> Sedes { get; set; }
        public virtual DbSet<TipoDocumentoEntity> TipoDocumentos { get; set; }
        public virtual DbSet<MasterEntity> Masters { get; set; }
        public virtual DbSet<KeyAppEntity> Keyapps { get; set; }
        public virtual DbSet<TipoPagoDetalleEntity> TipoPagoDetalle { get; set; }
        public virtual DbSet<EstadoPagoEntity> EstadoPagos { get; set; }
        public virtual DbSet<TransaccionPagoEntity> TransaccionPagos { get; set; }
        public virtual DbSet<HistorialPagoSolicitudEntity> HistorialPagoSolicitudes { get; set; }
    }
}
