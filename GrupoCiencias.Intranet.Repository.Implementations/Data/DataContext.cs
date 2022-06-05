using GrupoCiencias.Intranet.Domain.Models.Entity; 
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
            builder.ApplyConfiguration(new MarketingConfiguration());
            builder.ApplyConfiguration(new RedsocialConfiguration());
            builder.ApplyConfiguration(new SedesConfiguration());
            builder.ApplyConfiguration(new TipoDocumentoConfiguration());
            builder.ApplyConfiguration(new KeyAppConfiguration());
            builder.ApplyConfiguration(new TipoPagoDetalleConfiguration());
            builder.ApplyConfiguration(new EstadoPagoConfiguration());
            builder.ApplyConfiguration(new TransaccionPagoConfiguration());
            builder.ApplyConfiguration(new HistorialPagoSolicitudConfiguration());
            builder.ApplyConfiguration(new HistorialWebhooksConfiguration()); 
            builder.ApplyConfiguration(new AccesoMesesConfiguration());
            builder.ApplyConfiguration(new AniosConfiguration());
            builder.ApplyConfiguration(new AreaConocimientoConfiguration());
            builder.ApplyConfiguration(new AsistenciaCursosConfiguration());
            builder.ApplyConfiguration(new AsistenciaEstudiantesConfiguration());
            builder.ApplyConfiguration(new CabeceraPreguntasConfiguration());
            builder.ApplyConfiguration(new ClaseBibliotecaConfiguration());
            builder.ApplyConfiguration(new ClaveBibliotecaConfiguration());
            builder.ApplyConfiguration(new ComunicadosConfiguration());
            builder.ApplyConfiguration(new ComunicadosLandingConfiguration());
            builder.ApplyConfiguration(new CursosConfiguration());
            builder.ApplyConfiguration(new DetalleAreaCursosConfiguration());
            builder.ApplyConfiguration(new DetallePreguntasConfiguration());
            builder.ApplyConfiguration(new DetalleTemaEstadisticaConfiguration());
            builder.ApplyConfiguration(new EscaneoBibliotecaConfiguration());
            builder.ApplyConfiguration(new EstadisticaExamenConfiguration());
            builder.ApplyConfiguration(new ExamenConfiguration());
            builder.ApplyConfiguration(new ExamenEstudiantesConfiguration());
            builder.ApplyConfiguration(new HistorialSeguimientoConfiguration());
            builder.ApplyConfiguration(new MaterialBibliotecaConfiguration());
            builder.ApplyConfiguration(new MesesConfiguration());
            builder.ApplyConfiguration(new ParametrosConfiguration());
            builder.ApplyConfiguration(new Parametros2Configuration());
            builder.ApplyConfiguration(new PreguntasTempConfiguration());
            builder.ApplyConfiguration(new ProspectoBibliotecaConfiguration());
            builder.ApplyConfiguration(new RecursosConfiguration());
            builder.ApplyConfiguration(new SemestreConfiguration());
            builder.ApplyConfiguration(new SolucionarioBibliotecaConfiguration());
            builder.ApplyConfiguration(new TemaConfiguration());
            builder.ApplyConfiguration(new TemaBibliotecaConfiguration());
            builder.ApplyConfiguration(new UsuarioConfiguration());
            builder.ApplyConfiguration(new VideosConfiguration());
            builder.ApplyConfiguration(new BuzonCorreoConfiguration());
        }

        public virtual DbSet<SolicitudesEntity> Solicitudes { get; set; }
        public virtual DbSet<EstudiantesEntity> Estudiantes { get; set; }
        public virtual DbSet<ApoderadosEntity> Apoderado { get; set; }
        public virtual DbSet<CarrerasEntity> Carreras { get; set; }
        public virtual DbSet<AreasCarrerasEntity> AreasCarrera { get; set; }
        public virtual DbSet<CiclosEntity> Ciclos { get; set; }
        public virtual DbSet<CursosCicloEntity> CursosCiclo { get; set; }
        public virtual DbSet<UniversidadEntity> Universidad { get; set; }
        public virtual DbSet<MarketingEntity> Marketings { get; set; }
        public virtual DbSet<TipoPagoEntity> TipoPagos { get; set; }
        public virtual DbSet<SedeEntity> Sedes { get; set; }
        public virtual DbSet<TipoDocumentosEntity> TipoDocumentos { get; set; } 
        public virtual DbSet<KeyappEntity> Keyapps { get; set; }
        public virtual DbSet<TipoPagoDetalleEntity> TipoPagoDetalle { get; set; }
        public virtual DbSet<EstadoPagoEntity> EstadoPagos { get; set; }
        public virtual DbSet<TransaccionPagoEntity> TransaccionPagos { get; set; }
        public virtual DbSet<HistorialPagoSolicitudEntity> HistorialPagoSolicitudes { get; set; }
        public virtual DbSet<HistorialWebhookEntity> HistorialWebhooks { get; set; }  
        public virtual DbSet<AccesoMesesEntity> AccesoMeses { get; set; }
        public virtual DbSet<AnioEntity> Anios { get; set; } 
        public virtual DbSet<AreaConocimientoEntity> AreaConocimientos { get; set; } 
        public virtual DbSet<AsistenciaCursosEntity> AsistenciaCursos { get; set; }
        public virtual DbSet<AsistenciaEstudiantesEntity> AsistenciaEstudiantes { get; set; }
        public virtual DbSet<CabeceraPreguntasEntity> CabeceraPreguntas { get; set; } 
        public virtual DbSet<ClaseBibliotecaEntity> ClaseBibliotecas { get; set; }
        public virtual DbSet<ClaveBibliotecaEntity> ClaveBibliotecas { get; set; }
        public virtual DbSet<ComunicadosEntity> Comunicados { get; set; }
        public virtual DbSet<ComunicadosLandingEntity> ComunicadosLandings { get; set; }
        public virtual DbSet<CursosEntity> Cursos { get; set; } 
        public virtual DbSet<DetalleAreaCursosEntity> DetalleAreaCursos { get; set; }
        public virtual DbSet<DetallePreguntasEntity> DetallePregunta { get; set; }
        public virtual DbSet<DetalleTemaEstadisticaEntity> DetalleTemaEstadisticas { get; set; }
        public virtual DbSet<EscaneoBibliotecaEntity> EscaneoBibliotecas { get; set; }
        public virtual DbSet<EstadisticaExamenEntity> EstadisticaExamenes { get; set; } 
        public virtual DbSet<ExamenEntity> Examenes { get; set; }
        public virtual DbSet<ExamenEstudiantesEntity> ExamenEstudiantes { get; set; } 
        public virtual DbSet<HistorialSeguimientoEntity> HistorialSeguimientos { get; set; } 
        public virtual DbSet<MaterialBibliotecaEntity> MaterialBibliotecas { get; set; }
        public virtual DbSet<MesesEntity> Meses { get; set; }
        public virtual DbSet<ParametrosEntity> Parametros { get; set; }
        public virtual DbSet<Parametros2Entity> Parametros2s { get; set; }
        public virtual DbSet<PreguntasTempEntity> PreguntasTemps { get; set; }
        public virtual DbSet<ProspectoBibliotecaEntity> ProspectoBibliotecas { get; set; }
        public virtual DbSet<RecursosEntity> Recursos { get; set; } 
        public virtual DbSet<SemestreEntity> Semestres { get; set; } 
        public virtual DbSet<SolucionarioBibliotecaEntity> SolucionarioBibliotecas { get; set; }
        public virtual DbSet<TemaEntity> Temas { get; set; }
        public virtual DbSet<TemaBibliotecaEntity> TemaBibliotecas { get; set; } 
        public virtual DbSet<UsuarioEntity> Usuarios { get; set; }
        public virtual DbSet<VideoEntity> Videos { get; set; }
        public virtual DbSet<BuzonCorreoEntity> BuzonCorreos { get; set; }
    }
}
