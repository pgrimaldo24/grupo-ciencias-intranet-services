using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GrupoCiencias.Intranet.Repository.Implementations.Models
{
    public partial class grupocienciasbdContext : DbContext
    {
        public grupocienciasbdContext()
        {
        }

        public grupocienciasbdContext(DbContextOptions<grupocienciasbdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccesoMese> AccesoMeses { get; set; }
        public virtual DbSet<Anio> Anios { get; set; }
        public virtual DbSet<Apoderado> Apoderados { get; set; }
        public virtual DbSet<AreaConocimiento> AreaConocimientos { get; set; }
        public virtual DbSet<AreasCarrera> AreasCarreras { get; set; }
        public virtual DbSet<AsistenciaCurso> AsistenciaCursos { get; set; }
        public virtual DbSet<AsistenciaEstudiante> AsistenciaEstudiantes { get; set; }
        public virtual DbSet<CabeceraPreguntum> CabeceraPregunta { get; set; }
        public virtual DbSet<Carrera> Carreras { get; set; }
        public virtual DbSet<Ciclo> Ciclos { get; set; }
        public virtual DbSet<ClaseBiblioteca> ClaseBibliotecas { get; set; }
        public virtual DbSet<ClaveBiblioteca> ClaveBibliotecas { get; set; }
        public virtual DbSet<Comunicado> Comunicados { get; set; }
        public virtual DbSet<ComunicadosLanding> ComunicadosLandings { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<CursosCiclo> CursosCiclos { get; set; }
        public virtual DbSet<DetalleAreaCurso> DetalleAreaCursos { get; set; }
        public virtual DbSet<DetallePreguntum> DetallePregunta { get; set; }
        public virtual DbSet<DetalleTemaEstadistica> DetalleTemaEstadisticas { get; set; }
        public virtual DbSet<EscaneoBiblioteca> EscaneoBibliotecas { get; set; }
        public virtual DbSet<EstadisticaExaman> EstadisticaExamen { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<Examan> Examen { get; set; }
        public virtual DbSet<ExamenEstudiante> ExamenEstudiantes { get; set; }
        public virtual DbSet<HistorialSeguimiento> HistorialSeguimientos { get; set; }
        public virtual DbSet<MaterialBiblioteca> MaterialBibliotecas { get; set; }
        public virtual DbSet<Mese> Meses { get; set; }
        public virtual DbSet<Parametro> Parametros { get; set; }
        public virtual DbSet<Parametros2> Parametros2s { get; set; }
        public virtual DbSet<PreguntasTemp> PreguntasTemps { get; set; }
        public virtual DbSet<ProspectoBiblioteca> ProspectoBibliotecas { get; set; }
        public virtual DbSet<Recurso> Recursos { get; set; }
        public virtual DbSet<Semestre> Semestres { get; set; }
        public virtual DbSet<Solicitude> Solicitudes { get; set; }
        public virtual DbSet<SolucionarioBiblioteca> SolucionarioBibliotecas { get; set; }
        public virtual DbSet<Tema> Temas { get; set; }
        public virtual DbSet<TemaBiblioteca> TemaBibliotecas { get; set; }
        public virtual DbSet<Universidad> Universidads { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Video> Videos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=104.36.166.16;Port=5432;User Id=test_pgrimald;Password=123456;Database=grupocienciasbd;CommandTimeout=0;KeepAlive=120;Trust Server Certificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("unaccent");

            modelBuilder.Entity<AccesoMese>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("acceso_meses");

                entity.HasIndex(e => e.Idmes, "relationship_18_fk");

                entity.HasIndex(e => e.Idestudiante, "relationship_19_fk");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Idestudiante).HasColumnName("idestudiante");

                entity.Property(e => e.Idmes).HasColumnName("idmes");

                entity.HasOne(d => d.IdestudianteNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idestudiante)
                    .HasConstraintName("fk_acceso_m_relations_estudian");

                entity.HasOne(d => d.IdmesNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idmes)
                    .HasConstraintName("fk_acceso_m_relations_meses");
            });

            modelBuilder.Entity<Anio>(entity =>
            {
                entity.HasKey(e => e.Idanio)
                    .HasName("pk_anios");

                entity.ToTable("anios");

                entity.HasIndex(e => e.Idanio, "anios_pk")
                    .IsUnique();

                entity.Property(e => e.Idanio)
                    .ValueGeneratedNever()
                    .HasColumnName("idanio");

                entity.Property(e => e.Anio1)
                    .HasMaxLength(5)
                    .HasColumnName("anio");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_creacion");
            });

            modelBuilder.Entity<Apoderado>(entity =>
            {
                entity.HasKey(e => e.Idapoderado)
                    .HasName("pk_apoderados");

                entity.ToTable("apoderados");

                entity.HasIndex(e => e.Idapoderado, "apoderados_pk")
                    .IsUnique();

                entity.Property(e => e.Idapoderado)
                    .ValueGeneratedNever()
                    .HasColumnName("idapoderado");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Celular)
                    .HasMaxLength(10)
                    .HasColumnName("celular");

                entity.Property(e => e.Dni)
                    .HasMaxLength(8)
                    .HasColumnName("dni")
                    .IsFixedLength(true);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .HasColumnName("nombres");

                entity.Property(e => e.RutaFotoDni)
                    .HasMaxLength(400)
                    .HasColumnName("ruta_foto_dni");
            });

            modelBuilder.Entity<AreaConocimiento>(entity =>
            {
                entity.HasKey(e => e.Idareaconocimiento)
                    .HasName("pk_area_conocimiento");

                entity.ToTable("area_conocimiento");

                entity.HasIndex(e => e.Idareaconocimiento, "area_conocimiento_pk")
                    .IsUnique();

                entity.Property(e => e.Idareaconocimiento)
                    .ValueGeneratedNever()
                    .HasColumnName("idareaconocimiento");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.Orden).HasColumnName("orden");
            });

            modelBuilder.Entity<AreasCarrera>(entity =>
            {
                entity.HasKey(e => e.Idarea)
                    .HasName("pk_areas_carrera");

                entity.ToTable("areas_carrera");

                entity.HasIndex(e => e.Idarea, "areas_pk")
                    .IsUnique();

                entity.HasIndex(e => e.Iduniversidad, "relationship_21_fk");

                entity.Property(e => e.Idarea)
                    .ValueGeneratedNever()
                    .HasColumnName("idarea");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.Iduniversidad).HasColumnName("iduniversidad");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.PreguntaCorrecta)
                    .HasPrecision(5, 2)
                    .HasColumnName("pregunta_correcta");

                entity.Property(e => e.PreguntaEnBlanco)
                    .HasPrecision(5, 2)
                    .HasColumnName("pregunta_en_blanco");

                entity.Property(e => e.PreguntaIncorrecta).HasColumnName("pregunta_incorrecta");

                entity.HasOne(d => d.IduniversidadNavigation)
                    .WithMany(p => p.AreasCarreras)
                    .HasForeignKey(d => d.Iduniversidad)
                    .HasConstraintName("fk_areas_ca_relations_universi");
            });

            modelBuilder.Entity<AsistenciaCurso>(entity =>
            {
                entity.HasKey(e => e.Idasistencia)
                    .HasName("pk_asistencia_curso");

                entity.ToTable("asistencia_curso");

                entity.HasIndex(e => e.Idasistencia, "asistencia_curso_pk")
                    .IsUnique();

                entity.HasIndex(e => e.Idcurso, "relationship_54_fk");

                entity.Property(e => e.Idasistencia)
                    .ValueGeneratedNever()
                    .HasColumnName("idasistencia");

                entity.Property(e => e.Dia).HasColumnName("dia");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Idcurso).HasColumnName("idcurso");

                entity.HasOne(d => d.IdcursoNavigation)
                    .WithMany(p => p.AsistenciaCursos)
                    .HasForeignKey(d => d.Idcurso)
                    .HasConstraintName("fk_asistenc_relations_cursos");
            });

            modelBuilder.Entity<AsistenciaEstudiante>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("asistencia_estudiante");

                entity.HasIndex(e => e.Idestudiante, "relationship_52_fk");

                entity.HasIndex(e => e.Idasistencia, "relationship_53_fk");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Idasistencia).HasColumnName("idasistencia");

                entity.Property(e => e.Idestudiante).HasColumnName("idestudiante");

                entity.Property(e => e.Indicador)
                    .HasMaxLength(2)
                    .HasColumnName("indicador");

                entity.Property(e => e.Justificacion)
                    .HasMaxLength(200)
                    .HasColumnName("justificacion");

                entity.HasOne(d => d.IdasistenciaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idasistencia)
                    .HasConstraintName("fk_asistenc_relations_asistenc");

                entity.HasOne(d => d.IdestudianteNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idestudiante)
                    .HasConstraintName("fk_asistenc_relations_estudian");
            });

            modelBuilder.Entity<CabeceraPreguntum>(entity =>
            {
                entity.HasKey(e => e.Idcabecerapregunta)
                    .HasName("pk_cabecera_pregunta");

                entity.ToTable("cabecera_pregunta");

                entity.HasIndex(e => e.Idcabecerapregunta, "cebecerapregunta_pk")
                    .IsUnique();

                entity.HasIndex(e => e.Idusuario, "relationship_10_fk");

                entity.HasIndex(e => e.Idtema, "relationship_11_fk");

                entity.HasIndex(e => e.Idciclo, "relationship_9_fk");

                entity.Property(e => e.Idcabecerapregunta)
                    .ValueGeneratedNever()
                    .HasColumnName("idcabecerapregunta");

                entity.Property(e => e.Deco)
                    .HasMaxLength(20)
                    .HasColumnName("deco");

                entity.Property(e => e.Dificultad).HasColumnName("dificultad");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("date")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.Idciclo).HasColumnName("idciclo");

                entity.Property(e => e.Idtema).HasColumnName("idtema");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(200)
                    .HasColumnName("observacion");

                entity.Property(e => e.Texto).HasColumnName("texto");

                entity.Property(e => e.TipoPregunta)
                    .HasMaxLength(50)
                    .HasColumnName("tipo_pregunta");

                entity.HasOne(d => d.IdcicloNavigation)
                    .WithMany(p => p.CabeceraPregunta)
                    .HasForeignKey(d => d.Idciclo)
                    .HasConstraintName("fk_cabecera_relations_ciclos");

                entity.HasOne(d => d.IdtemaNavigation)
                    .WithMany(p => p.CabeceraPregunta)
                    .HasForeignKey(d => d.Idtema)
                    .HasConstraintName("fk_cabecera_relations_temas");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.CabeceraPregunta)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("fk_cabecera_relations_usuarios");
            });

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => e.Idcarrera)
                    .HasName("carreras_pkey");

                entity.ToTable("carreras");

                entity.Property(e => e.Idcarrera)
                    .ValueGeneratedNever()
                    .HasColumnName("idcarrera");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("date")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.Idarea).HasColumnName("idarea");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdareaNavigation)
                    .WithMany(p => p.Carreras)
                    .HasForeignKey(d => d.Idarea)
                    .HasConstraintName("fk_area_carrera");
            });

            modelBuilder.Entity<Ciclo>(entity =>
            {
                entity.HasKey(e => e.Idciclo)
                    .HasName("pk_ciclos");

                entity.ToTable("ciclos");

                entity.HasIndex(e => e.Idciclo, "ciclos_pk")
                    .IsUnique();

                entity.HasIndex(e => e.Iduniversidad, "relationship_14_fk");

                entity.Property(e => e.Idciclo)
                    .ValueGeneratedNever()
                    .HasColumnName("idciclo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.GrupoCiclos).HasColumnName("grupo_ciclos");

                entity.Property(e => e.Iduniversidad).HasColumnName("iduniversidad");

                entity.Property(e => e.Precio)
                    .HasPrecision(9, 2)
                    .HasColumnName("precio");

                entity.Property(e => e.VisibleLanding)
                    .HasColumnName("visible_landing")
                    .HasDefaultValueSql("1");

                entity.HasOne(d => d.IduniversidadNavigation)
                    .WithMany(p => p.Ciclos)
                    .HasForeignKey(d => d.Iduniversidad)
                    .HasConstraintName("fk_ciclos_relations_universi");
            });

            modelBuilder.Entity<ClaseBiblioteca>(entity =>
            {
                entity.HasKey(e => e.Idclase)
                    .HasName("pk_clase_biblioteca");

                entity.ToTable("clase_biblioteca");

                entity.HasIndex(e => e.Idclase, "clase_biblioteca_pk")
                    .IsUnique();

                entity.HasIndex(e => e.Idtema, "relationship_48_fk");

                entity.Property(e => e.Idclase)
                    .HasColumnName("idclase")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Idtema).HasColumnName("idtema");

                entity.Property(e => e.UrlClase)
                    .HasMaxLength(500)
                    .HasColumnName("url_clase");

                entity.HasOne(d => d.IdtemaNavigation)
                    .WithMany(p => p.ClaseBibliotecas)
                    .HasForeignKey(d => d.Idtema)
                    .HasConstraintName("fk_clase_bi_relations_tema_bib");
            });

            modelBuilder.Entity<ClaveBiblioteca>(entity =>
            {
                entity.HasKey(e => e.Idclave)
                    .HasName("pk_clave_biblioteca");

                entity.ToTable("clave_biblioteca");

                entity.HasIndex(e => e.Idclave, "clave_biblioteca_pk")
                    .IsUnique();

                entity.HasIndex(e => e.Idsemestre, "relationship_39_fk");

                entity.Property(e => e.Idclave)
                    .HasColumnName("idclave")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Idarea).HasColumnName("idarea");

                entity.Property(e => e.Idsemestre).HasColumnName("idsemestre");

                entity.Property(e => e.NombreClave)
                    .HasMaxLength(100)
                    .HasColumnName("nombre_clave");

                entity.Property(e => e.UrlClaseRelacionada)
                    .HasMaxLength(500)
                    .HasColumnName("url_clase_relacionada");

                entity.Property(e => e.UrlClave)
                    .HasMaxLength(500)
                    .HasColumnName("url_clave");

                entity.HasOne(d => d.IdareaNavigation)
                    .WithMany(p => p.ClaveBibliotecas)
                    .HasForeignKey(d => d.Idarea)
                    .HasConstraintName("fk_area_clave_biblioteca");

                entity.HasOne(d => d.IdsemestreNavigation)
                    .WithMany(p => p.ClaveBibliotecas)
                    .HasForeignKey(d => d.Idsemestre)
                    .HasConstraintName("fk_clave_bi_relations_semestre");
            });

            modelBuilder.Entity<Comunicado>(entity =>
            {
                entity.HasKey(e => e.Idcomunicado)
                    .HasName("pk_comunicados");

                entity.ToTable("comunicados");

                entity.HasIndex(e => e.Idcomunicado, "comunicados_pk")
                    .IsUnique();

                entity.HasIndex(e => e.Idciclo, "relationship_20_fk");

                entity.Property(e => e.Idcomunicado)
                    .ValueGeneratedNever()
                    .HasColumnName("idcomunicado");

                entity.Property(e => e.Descripcion).HasColumnName("descripcion");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasColumnName("fecha_fin");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fecha_inicio");

                entity.Property(e => e.Idciclo).HasColumnName("idciclo");

                entity.Property(e => e.Universidad).HasColumnName("universidad");

                entity.HasOne(d => d.IdcicloNavigation)
                    .WithMany(p => p.Comunicados)
                    .HasForeignKey(d => d.Idciclo)
                    .HasConstraintName("fk_comunica_relations_ciclos");
            });

            modelBuilder.Entity<ComunicadosLanding>(entity =>
            {
                entity.HasKey(e => e.Idcomunicado)
                    .HasName("comunicados_landing_pkey");

                entity.ToTable("comunicados_landing");

                entity.Property(e => e.Idcomunicado)
                    .ValueGeneratedNever()
                    .HasColumnName("idcomunicado");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasColumnName("fecha_fin");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fecha_inicio");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.Idcurso)
                    .HasName("pk_cursos");

                entity.ToTable("cursos");

                entity.HasIndex(e => e.Idcurso, "cursos_pk")
                    .IsUnique();

                entity.HasIndex(e => e.Idareaconocimiento, "relationship_28_fk");

                entity.Property(e => e.Idcurso)
                    .ValueGeneratedNever()
                    .HasColumnName("idcurso");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.Idareaconocimiento).HasColumnName("idareaconocimiento");

                entity.Property(e => e.NombreCorto)
                    .HasMaxLength(70)
                    .HasColumnName("nombre_corto");

                entity.Property(e => e.NombreCurso)
                    .HasMaxLength(70)
                    .HasColumnName("nombre_curso");

                entity.Property(e => e.Orden).HasColumnName("orden");

                entity.Property(e => e.OrdenExamen).HasColumnName("orden_examen");

                entity.Property(e => e.UrlTemarioBiblioteca)
                    .HasMaxLength(500)
                    .HasColumnName("url_temario_biblioteca");

                entity.HasOne(d => d.IdareaconocimientoNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.Idareaconocimiento)
                    .HasConstraintName("fk_cursos_relations_area_con");
            });

            modelBuilder.Entity<CursosCiclo>(entity =>
            {
                entity.HasKey(e => new { e.Idciclo, e.Idcurso })
                    .HasName("pk_cursos_ciclos");

                entity.ToTable("cursos_ciclos");

                entity.HasIndex(e => new { e.Idciclo, e.Idcurso }, "cursos_ciclos_pk")
                    .IsUnique();

                entity.HasIndex(e => e.Idcurso, "relationship_33_fk");

                entity.HasIndex(e => e.Idciclo, "relationship_34_fk");

                entity.Property(e => e.Idciclo).HasColumnName("idciclo");

                entity.Property(e => e.Idcurso).HasColumnName("idcurso");

                entity.HasOne(d => d.IdcicloNavigation)
                    .WithMany(p => p.CursosCiclos)
                    .HasForeignKey(d => d.Idciclo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cursos_c_relations_ciclos");

                entity.HasOne(d => d.IdcursoNavigation)
                    .WithMany(p => p.CursosCiclos)
                    .HasForeignKey(d => d.Idcurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cursos_c_relations_cursos");
            });

            modelBuilder.Entity<DetalleAreaCurso>(entity =>
            {
                entity.HasKey(e => e.Iddetalle)
                    .HasName("detalle_area_curso_pkey");

                entity.ToTable("detalle_area_curso");

                entity.Property(e => e.Iddetalle).HasColumnName("iddetalle");

                entity.Property(e => e.CantidadPreguntas).HasColumnName("cantidad_preguntas");

                entity.Property(e => e.Idarea).HasColumnName("idarea");

                entity.Property(e => e.Idcurso).HasColumnName("idcurso");

                entity.HasOne(d => d.IdareaNavigation)
                    .WithMany(p => p.DetalleAreaCursos)
                    .HasForeignKey(d => d.Idarea)
                    .HasConstraintName("fk_area_detalle");

                entity.HasOne(d => d.IdcursoNavigation)
                    .WithMany(p => p.DetalleAreaCursos)
                    .HasForeignKey(d => d.Idcurso)
                    .HasConstraintName("fk_courso_detalle");
            });

            modelBuilder.Entity<DetallePreguntum>(entity =>
            {
                entity.HasKey(e => e.Idpregunta)
                    .HasName("pk_detalle_pregunta");

                entity.ToTable("detalle_pregunta");

                entity.HasComment("estado:\n\n1 - registrada\n2 - aprobada\n3- observada\n0-eliminada");

                entity.HasIndex(e => e.Idpregunta, "detallepregunta_pk")
                    .IsUnique();

                entity.HasIndex(e => e.Idpregunta, "idx_idpregunta_detalle_pregunta");

                entity.HasIndex(e => e.Idcabecerapregunta, "relationship_8_fk");

                entity.Property(e => e.Idpregunta)
                    .ValueGeneratedNever()
                    .HasColumnName("idpregunta");

                entity.Property(e => e.Alternativa)
                    .HasMaxLength(200)
                    .HasColumnName("alternativa");

                entity.Property(e => e.Descripcion).HasColumnName("descripcion");

                entity.Property(e => e.DetalleObservacion)
                    .HasMaxLength(200)
                    .HasColumnName("detalle_observacion");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Idcabecerapregunta).HasColumnName("idcabecerapregunta");

                entity.HasOne(d => d.IdcabecerapreguntaNavigation)
                    .WithMany(p => p.DetallePregunta)
                    .HasForeignKey(d => d.Idcabecerapregunta)
                    .HasConstraintName("fk_detalle__relations_cabecera");
            });

            modelBuilder.Entity<DetalleTemaEstadistica>(entity =>
            {
                entity.HasKey(e => new { e.Idestadistica, e.Idtema })
                    .HasName("pk_detalle_tema_estadistica");

                entity.ToTable("detalle_tema_estadistica");

                entity.HasIndex(e => new { e.Idestadistica, e.Idtema }, "detalle_tema_estadistica_pk")
                    .IsUnique();

                entity.HasIndex(e => e.Idtema, "relationship_49_fk");

                entity.HasIndex(e => e.Idestadistica, "relationship_50_fk");

                entity.Property(e => e.Idestadistica).HasColumnName("idestadistica");

                entity.Property(e => e.Idtema).HasColumnName("idtema");

                entity.Property(e => e.CantidadPreguntas).HasColumnName("cantidad_preguntas");

                entity.HasOne(d => d.IdestadisticaNavigation)
                    .WithMany(p => p.DetalleTemaEstadisticas)
                    .HasForeignKey(d => d.Idestadistica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_detalle__relations_estadist");

                entity.HasOne(d => d.IdtemaNavigation)
                    .WithMany(p => p.DetalleTemaEstadisticas)
                    .HasForeignKey(d => d.Idtema)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_detalle__relations_tema_bib");
            });

            modelBuilder.Entity<EscaneoBiblioteca>(entity =>
            {
                entity.HasKey(e => e.Idescaneo)
                    .HasName("pk_escaneo_biblioteca");

                entity.ToTable("escaneo_biblioteca");

                entity.HasIndex(e => e.Idescaneo, "escaneo_biblioteca_pk")
                    .IsUnique();

                entity.HasIndex(e => e.Idarea, "relationship_37_fk");

                entity.HasIndex(e => e.Idsemestre, "relationship_38_fk");

                entity.Property(e => e.Idescaneo)
                    .HasColumnName("idescaneo")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Idarea).HasColumnName("idarea");

                entity.Property(e => e.Idsemestre).HasColumnName("idsemestre");

                entity.Property(e => e.NombreEscaneo)
                    .HasMaxLength(100)
                    .HasColumnName("nombre_escaneo");

                entity.Property(e => e.UrlClaseRelacionada)
                    .HasMaxLength(500)
                    .HasColumnName("url_clase_relacionada");

                entity.Property(e => e.UrlEscaneo)
                    .HasMaxLength(500)
                    .HasColumnName("url_escaneo");

                entity.HasOne(d => d.IdareaNavigation)
                    .WithMany(p => p.EscaneoBibliotecas)
                    .HasForeignKey(d => d.Idarea)
                    .HasConstraintName("fk_escaneo__relations_areas_ca");

                entity.HasOne(d => d.IdsemestreNavigation)
                    .WithMany(p => p.EscaneoBibliotecas)
                    .HasForeignKey(d => d.Idsemestre)
                    .HasConstraintName("fk_escaneo__relations_semestre");
            });

            modelBuilder.Entity<EstadisticaExaman>(entity =>
            {
                entity.HasKey(e => e.Idestadistica)
                    .HasName("pk_estadistica_examen");

                entity.ToTable("estadistica_examen");

                entity.HasIndex(e => e.Idestadistica, "estadistica_examen_pk")
                    .IsUnique();

                entity.HasIndex(e => e.Iduniversidad, "relationship_45_fk");

                entity.HasIndex(e => e.Idsemestre, "relationship_46_fk");

                entity.Property(e => e.Idestadistica)
                    .ValueGeneratedNever()
                    .HasColumnName("idestadistica");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Idsemestre).HasColumnName("idsemestre");

                entity.Property(e => e.Iduniversidad).HasColumnName("iduniversidad");

                entity.Property(e => e.NombreEstadistica)
                    .HasMaxLength(100)
                    .HasColumnName("nombre_estadistica");

                entity.HasOne(d => d.IdsemestreNavigation)
                    .WithMany(p => p.EstadisticaExamen)
                    .HasForeignKey(d => d.Idsemestre)
                    .HasConstraintName("fk_estadist_relations_semestre");

                entity.HasOne(d => d.IduniversidadNavigation)
                    .WithMany(p => p.EstadisticaExamen)
                    .HasForeignKey(d => d.Iduniversidad)
                    .HasConstraintName("fk_estadist_relations_universi");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.Idestudiante)
                    .HasName("pk_estudiantes");

                entity.ToTable("estudiantes");

                entity.HasIndex(e => e.Idestudiante, "estudiantes_pk")
                    .IsUnique();

                entity.HasIndex(e => e.Idapoderado, "relationship_23_fk");

                entity.HasIndex(e => e.Idciclo, "relationship_4_fk");

                entity.Property(e => e.Idestudiante)
                    .ValueGeneratedNever()
                    .HasColumnName("idestudiante");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Carrera).HasColumnName("carrera");

                entity.Property(e => e.Celular)
                    .HasMaxLength(10)
                    .HasColumnName("celular");

                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(400)
                    .HasColumnName("contrasenia");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .HasColumnName("correo");

                entity.Property(e => e.Dni)
                    .HasMaxLength(8)
                    .HasColumnName("dni")
                    .IsFixedLength(true);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Idapoderado).HasColumnName("idapoderado");

                entity.Property(e => e.Idciclo).HasColumnName("idciclo");

                entity.Property(e => e.MedioInfo)
                    .HasMaxLength(15)
                    .HasColumnName("medio_info")
                    .HasDefaultValueSql("'facebook'::character varying");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .HasColumnName("nombres");

                entity.Property(e => e.PerfilFacebook)
                    .HasMaxLength(100)
                    .HasColumnName("perfil_facebook");

                entity.Property(e => e.RutaFotoDni)
                    .HasMaxLength(400)
                    .HasColumnName("ruta_foto_dni");

                entity.Property(e => e.RutaFotoDni2).HasColumnName("ruta_foto_dni2");

                entity.Property(e => e.RutaFotoFacebook)
                    .HasMaxLength(400)
                    .HasColumnName("ruta_foto_facebook");

                entity.Property(e => e.RutaFotoPerfil)
                    .HasMaxLength(400)
                    .HasColumnName("ruta_foto_perfil");

                entity.Property(e => e.RutaFotoVoucherPago)
                    .HasMaxLength(400)
                    .HasColumnName("ruta_foto_voucher_pago");

                entity.Property(e => e.RutaVideoRegistro)
                    .HasMaxLength(400)
                    .HasColumnName("ruta_video_registro");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(20)
                    .HasColumnName("usuario");

                entity.HasOne(d => d.IdapoderadoNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.Idapoderado)
                    .HasConstraintName("fk_estudian_relations_apoderad");

                entity.HasOne(d => d.IdcicloNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.Idciclo)
                    .HasConstraintName("fk_estudian_relations_ciclos");
            });

            modelBuilder.Entity<Examan>(entity =>
            {
                entity.HasKey(e => e.Idexamen)
                    .HasName("pk_examen");

                entity.ToTable("examen");

                entity.HasComment("puederetroceder:\n\n1- si\n0 -no\n\nestado:\n\n1-programado\n2-finalizado\n3-cancelado\n0-eliminado");

                entity.HasIndex(e => e.Idexamen, "examen_pk")
                    .IsUnique();

                entity.HasIndex(e => e.Idarea, "relationship_12_fk");

                entity.HasIndex(e => e.Idciclo, "relationship_29_fk");

                entity.Property(e => e.Idexamen)
                    .ValueGeneratedNever()
                    .HasColumnName("idexamen");

                entity.Property(e => e.Encuesta).HasColumnName("encuesta");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaExamen)
                    .HasColumnType("date")
                    .HasColumnName("fecha_examen");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("date")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.HoraFin)
                    .HasColumnType("time without time zone")
                    .HasColumnName("hora_fin");

                entity.Property(e => e.HoraInicio)
                    .HasColumnType("time without time zone")
                    .HasColumnName("hora_inicio");

                entity.Property(e => e.Idarea).HasColumnName("idarea");

                entity.Property(e => e.Idciclo).HasColumnName("idciclo");

                entity.Property(e => e.ListaPreguntas).HasColumnName("lista_preguntas");

                entity.Property(e => e.PuedeRetroceder).HasColumnName("puede_retroceder");

                entity.Property(e => e.SaltoPregunta)
                    .HasColumnName("salto_pregunta")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TipoExamen)
                    .HasColumnName("tipo_examen")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UrlExamenBlanco).HasColumnName("url_examen_blanco");

                entity.Property(e => e.UrlExamenBlancoResumido).HasColumnName("url_examen_blanco_resumido");

                entity.Property(e => e.UrlExamenRespuestas).HasColumnName("url_examen_respuestas");

                entity.Property(e => e.UrlExamenRespuestasResumido).HasColumnName("url_examen_respuestas_resumido");

                entity.HasOne(d => d.IdareaNavigation)
                    .WithMany(p => p.Examen)
                    .HasForeignKey(d => d.Idarea)
                    .HasConstraintName("fk_examen_relations_areas_ca");

                entity.HasOne(d => d.IdcicloNavigation)
                    .WithMany(p => p.Examen)
                    .HasForeignKey(d => d.Idciclo)
                    .HasConstraintName("fk_examen_relations_ciclos");
            });

            modelBuilder.Entity<ExamenEstudiante>(entity =>
            {
                entity.HasKey(e => new { e.Idexamen, e.Idestudiante })
                    .HasName("pk_examen_estudiante");

                entity.ToTable("examen_estudiante");

                entity.HasComment("lista_respuestas: \n  idpregunta,\n  estado_pregunta:(buena,mala,en blanco),\n  valoracion de la pregunta\n\n \n");

                entity.HasIndex(e => new { e.Idexamen, e.Idestudiante }, "examen_estudiante_pk")
                    .IsUnique();

                entity.HasIndex(e => e.Idestudiante, "relationship_26_fk");

                entity.HasIndex(e => e.Idexamen, "relationship_32_fk");

                entity.Property(e => e.Idexamen).HasColumnName("idexamen");

                entity.Property(e => e.Idestudiante).HasColumnName("idestudiante");

                entity.Property(e => e.ListaRespuestas).HasColumnName("lista_respuestas");

                entity.Property(e => e.NotaTotal).HasColumnName("nota_total");

                entity.Property(e => e.Tiempo)
                    .HasMaxLength(10)
                    .HasColumnName("tiempo");

                entity.Property(e => e.TotalCorrectas).HasColumnName("total_correctas");

                entity.Property(e => e.TotalEnBlanco).HasColumnName("total_en_blanco");

                entity.Property(e => e.TotalIncorrectas).HasColumnName("total_incorrectas");

                entity.HasOne(d => d.IdestudianteNavigation)
                    .WithMany(p => p.ExamenEstudiantes)
                    .HasForeignKey(d => d.Idestudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_examen_e_relations_estudian");

                entity.HasOne(d => d.IdexamenNavigation)
                    .WithMany(p => p.ExamenEstudiantes)
                    .HasForeignKey(d => d.Idexamen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_examen_e_relations_examen");
            });

            modelBuilder.Entity<HistorialSeguimiento>(entity =>
            {
                entity.HasKey(e => e.Idhistorial)
                    .HasName("pk_historial_seguimiento");

                entity.ToTable("historial_seguimiento");

                entity.HasIndex(e => e.Idhistorial, "historial_seguimiento_pk")
                    .IsUnique();

                entity.HasIndex(e => e.Idusuario, "relationship_35_fk");

                entity.Property(e => e.Idhistorial)
                    .ValueGeneratedNever()
                    .HasColumnName("idhistorial");

                entity.Property(e => e.Actividad)
                    .HasMaxLength(500)
                    .HasColumnName("actividad");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Hora)
                    .HasColumnType("time without time zone")
                    .HasColumnName("hora");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.HistorialSeguimientos)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("fk_historia_relations_usuarios");
            });

            modelBuilder.Entity<MaterialBiblioteca>(entity =>
            {
                entity.HasKey(e => e.Idmaterial)
                    .HasName("pk_material_biblioteca");

                entity.ToTable("material_biblioteca");

                entity.HasIndex(e => e.Idmaterial, "material_biblioteca_pk")
                    .IsUnique();

                entity.HasIndex(e => e.Idtema, "relationship_51_fk");

                entity.Property(e => e.Idmaterial)
                    .HasColumnName("idmaterial")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Idtema).HasColumnName("idtema");

                entity.Property(e => e.NombreMaterial)
                    .HasMaxLength(100)
                    .HasColumnName("nombre_material");

                entity.Property(e => e.UrlClaseRelacionada)
                    .HasMaxLength(500)
                    .HasColumnName("url_clase_relacionada");

                entity.Property(e => e.UrlMaterial)
                    .HasMaxLength(500)
                    .HasColumnName("url_material");

                entity.HasOne(d => d.IdtemaNavigation)
                    .WithMany(p => p.MaterialBibliotecas)
                    .HasForeignKey(d => d.Idtema)
                    .HasConstraintName("fk_material_relations_tema");
            });

            modelBuilder.Entity<Mese>(entity =>
            {
                entity.HasKey(e => e.Idmes)
                    .HasName("pk_meses");

                entity.ToTable("meses");

                entity.HasIndex(e => e.Idmes, "meses_pk")
                    .IsUnique();

                entity.Property(e => e.Idmes)
                    .ValueGeneratedNever()
                    .HasColumnName("idmes");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.Mes)
                    .HasMaxLength(20)
                    .HasColumnName("mes");
            });

            modelBuilder.Entity<Parametro>(entity =>
            {
                entity.HasKey(e => e.Idparametro)
                    .HasName("pk_parametros");

                entity.ToTable("parametros");

                entity.HasIndex(e => e.Idparametro, "parametros_pk")
                    .IsUnique();

                entity.Property(e => e.Idparametro)
                    .ValueGeneratedNever()
                    .HasColumnName("idparametro");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(400)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Parametros2>(entity =>
            {
                entity.HasKey(e => new { e.PNumero, e.PTipo, e.PCodigo })
                    .HasName("pk_parametros2");

                entity.ToTable("parametros2");

                entity.HasIndex(e => new { e.PNumero, e.PTipo, e.PCodigo }, "parametros2_pk")
                    .IsUnique();

                entity.Property(e => e.PNumero).HasColumnName("p_numero");

                entity.Property(e => e.PTipo)
                    .HasMaxLength(1)
                    .HasColumnName("p_tipo");

                entity.Property(e => e.PCodigo)
                    .HasMaxLength(20)
                    .HasColumnName("p_codigo");

                entity.Property(e => e.PDescripcion)
                    .HasMaxLength(130)
                    .HasColumnName("p_descripcion");

                entity.Property(e => e.PFecAct)
                    .HasColumnType("date")
                    .HasColumnName("p_fec_act");

                entity.Property(e => e.PUsuario)
                    .HasMaxLength(8)
                    .HasColumnName("p_usuario");
            });

            modelBuilder.Entity<PreguntasTemp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("preguntas_temp");

                entity.Property(e => e.Alternativa)
                    .HasColumnType("character varying")
                    .HasColumnName("alternativa");

                entity.Property(e => e.Cabecerapregunta).HasColumnName("cabecerapregunta");

                entity.Property(e => e.Descripcion).HasColumnName("descripcion");

                entity.Property(e => e.DetalleObservacion)
                    .HasColumnType("character varying")
                    .HasColumnName("detalle_observacion");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Idpregunta).HasColumnName("idpregunta");
            });

            modelBuilder.Entity<ProspectoBiblioteca>(entity =>
            {
                entity.HasKey(e => e.Idprospecto)
                    .HasName("pk_prospecto_biblioteca");

                entity.ToTable("prospecto_biblioteca");

                entity.HasIndex(e => e.Idprospecto, "prospecto_biblioteca_pk")
                    .IsUnique();

                entity.HasIndex(e => e.Idsemestre, "relationship_41_fk");

                entity.HasIndex(e => e.Idarea, "relationship_42_fk");

                entity.Property(e => e.Idprospecto)
                    .HasColumnName("idprospecto")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Idarea).HasColumnName("idarea");

                entity.Property(e => e.Idsemestre).HasColumnName("idsemestre");

                entity.Property(e => e.NombreProspecto)
                    .HasMaxLength(100)
                    .HasColumnName("nombre_prospecto");

                entity.Property(e => e.UrlClaseRelacionada)
                    .HasMaxLength(500)
                    .HasColumnName("url_clase_relacionada");

                entity.Property(e => e.UrlProspecto)
                    .HasMaxLength(500)
                    .HasColumnName("url_prospecto");

                entity.HasOne(d => d.IdareaNavigation)
                    .WithMany(p => p.ProspectoBibliotecas)
                    .HasForeignKey(d => d.Idarea)
                    .HasConstraintName("fk_prospect_relations_areas_ca");

                entity.HasOne(d => d.IdsemestreNavigation)
                    .WithMany(p => p.ProspectoBibliotecas)
                    .HasForeignKey(d => d.Idsemestre)
                    .HasConstraintName("fk_prospect_relations_semestre");
            });

            modelBuilder.Entity<Recurso>(entity =>
            {
                entity.HasKey(e => e.Idrecurso)
                    .HasName("pk_recurso");

                entity.ToTable("recurso");

                entity.HasIndex(e => e.Idrecurso, "recurso_pk")
                    .IsUnique();

                entity.HasIndex(e => e.Idanio, "relationship_16_fk");

                entity.HasIndex(e => e.Idcurso, "relationship_24_fk");

                entity.Property(e => e.Idrecurso)
                    .ValueGeneratedNever()
                    .HasColumnName("idrecurso");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("date")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.Idanio).HasColumnName("idanio");

                entity.Property(e => e.Idciclo).HasColumnName("idciclo");

                entity.Property(e => e.Idcurso).HasColumnName("idcurso");

                entity.Property(e => e.Mes).HasColumnName("mes");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Orden).HasColumnName("orden");

                entity.Property(e => e.RutaRecurso)
                    .HasMaxLength(400)
                    .HasColumnName("ruta_recurso");

                entity.HasOne(d => d.IdanioNavigation)
                    .WithMany(p => p.Recursos)
                    .HasForeignKey(d => d.Idanio)
                    .HasConstraintName("fk_recurso_relations_anios");

                entity.HasOne(d => d.IdcursoNavigation)
                    .WithMany(p => p.Recursos)
                    .HasForeignKey(d => d.Idcurso)
                    .HasConstraintName("fk_recurso_relations_cursos");
            });

            modelBuilder.Entity<Semestre>(entity =>
            {
                entity.HasKey(e => e.Idsemestre)
                    .HasName("pk_semestre");

                entity.ToTable("semestre");

                entity.HasIndex(e => e.Idanio, "relationship_36_fk");

                entity.HasIndex(e => e.Idsemestre, "semestre_pk")
                    .IsUnique();

                entity.Property(e => e.Idsemestre)
                    .ValueGeneratedNever()
                    .HasColumnName("idsemestre");

                entity.Property(e => e.Idanio).HasColumnName("idanio");

                entity.Property(e => e.NombreSemestre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre_semestre");

                entity.HasOne(d => d.IdanioNavigation)
                    .WithMany(p => p.Semestres)
                    .HasForeignKey(d => d.Idanio)
                    .HasConstraintName("fk_semestre_relations_anios");
            });

            modelBuilder.Entity<Solicitude>(entity =>
            {
                entity.HasKey(e => e.Idsolicitud)
                    .HasName("pk_solicitudes");

                entity.ToTable("solicitudes");

                entity.HasIndex(e => e.Idapoderado, "relationship_22_fk");

                entity.HasIndex(e => e.Idsolicitud, "solicitudes_pk")
                    .IsUnique();

                entity.Property(e => e.Idsolicitud)
                    .ValueGeneratedNever()
                    .HasColumnName("idsolicitud");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .HasColumnName("apellidos");

                entity.Property(e => e.CarreraInteres)
                    .HasMaxLength(50)
                    .HasColumnName("carrera_interes");

                entity.Property(e => e.Celular)
                    .HasMaxLength(10)
                    .HasColumnName("celular");

                entity.Property(e => e.Ciclo).HasColumnName("ciclo");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .HasColumnName("correo");

                entity.Property(e => e.Dni)
                    .HasMaxLength(8)
                    .HasColumnName("dni")
                    .IsFixedLength(true);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");

                entity.Property(e => e.Idapoderado).HasColumnName("idapoderado");

                entity.Property(e => e.MedioInfo)
                    .HasMaxLength(15)
                    .HasColumnName("medio_info")
                    .HasDefaultValueSql("'facebook'::character varying");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .HasColumnName("nombres");

                entity.Property(e => e.PerfilFacebook)
                    .HasMaxLength(100)
                    .HasColumnName("perfil_facebook");

                entity.Property(e => e.Referido)
                    .HasMaxLength(50)
                    .HasColumnName("referido");

                entity.Property(e => e.RutaFotoDni)
                    .HasMaxLength(400)
                    .HasColumnName("ruta_foto_dni");

                entity.Property(e => e.RutaFotoDni2).HasColumnName("ruta_foto_dni2");

                entity.Property(e => e.RutaFotoFacebook)
                    .HasMaxLength(400)
                    .HasColumnName("ruta_foto_facebook");

                entity.Property(e => e.RutaFotoPerfil)
                    .HasMaxLength(400)
                    .HasColumnName("ruta_foto_perfil");

                entity.Property(e => e.RutaFotoVoucherPago)
                    .HasMaxLength(400)
                    .HasColumnName("ruta_foto_voucher_pago");

                entity.Property(e => e.RutaVideoRegistro)
                    .HasMaxLength(400)
                    .HasColumnName("ruta_video_registro");

                entity.Property(e => e.Universidad)
                    .HasMaxLength(100)
                    .HasColumnName("universidad");

                entity.HasOne(d => d.IdapoderadoNavigation)
                    .WithMany(p => p.Solicitudes)
                    .HasForeignKey(d => d.Idapoderado)
                    .HasConstraintName("fk_solicitu_relations_apoderad");
            });

            modelBuilder.Entity<SolucionarioBiblioteca>(entity =>
            {
                entity.HasKey(e => e.Idsolucionario)
                    .HasName("pk_solucionario_biblioteca");

                entity.ToTable("solucionario_biblioteca");

                entity.HasIndex(e => e.Idsemestre, "relationship_43_fk");

                entity.HasIndex(e => e.Iduniversidad, "relationship_44_fk");

                entity.HasIndex(e => e.Idsolucionario, "solucionario_biblioteca_pk")
                    .IsUnique();

                entity.Property(e => e.Idsolucionario)
                    .HasColumnName("idsolucionario")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Idsemestre).HasColumnName("idsemestre");

                entity.Property(e => e.Iduniversidad).HasColumnName("iduniversidad");

                entity.Property(e => e.NombreSolucionario)
                    .HasMaxLength(100)
                    .HasColumnName("nombre_solucionario");

                entity.Property(e => e.UrlSolucionario)
                    .HasMaxLength(500)
                    .HasColumnName("url_solucionario");

                entity.HasOne(d => d.IdsemestreNavigation)
                    .WithMany(p => p.SolucionarioBibliotecas)
                    .HasForeignKey(d => d.Idsemestre)
                    .HasConstraintName("fk_solucion_relations_semestre");

                entity.HasOne(d => d.IduniversidadNavigation)
                    .WithMany(p => p.SolucionarioBibliotecas)
                    .HasForeignKey(d => d.Iduniversidad)
                    .HasConstraintName("fk_solucion_relations_universi");
            });

            modelBuilder.Entity<Tema>(entity =>
            {
                entity.HasKey(e => e.Idtema)
                    .HasName("pk_temas");

                entity.ToTable("temas");

                entity.HasIndex(e => e.Idcurso, "relationship_1_fk");

                entity.HasIndex(e => e.Idtema, "temas_pk")
                    .IsUnique();

                entity.Property(e => e.Idtema)
                    .ValueGeneratedNever()
                    .HasColumnName("idtema");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.Idcurso).HasColumnName("idcurso");

                entity.Property(e => e.NombreTema)
                    .HasMaxLength(150)
                    .HasColumnName("nombre_tema");

                entity.Property(e => e.Orden)
                    .HasColumnName("orden")
                    .HasDefaultValueSql("1");

                entity.HasOne(d => d.IdcursoNavigation)
                    .WithMany(p => p.Temas)
                    .HasForeignKey(d => d.Idcurso)
                    .HasConstraintName("fk_temas_relations_cursos");
            });

            modelBuilder.Entity<TemaBiblioteca>(entity =>
            {
                entity.HasKey(e => e.Idtema)
                    .HasName("pk_tema_biblioteca");

                entity.ToTable("tema_biblioteca");

                entity.HasIndex(e => e.Idcurso, "relationship_47_fk");

                entity.HasIndex(e => e.Idtema, "tema_biblioteca_pk")
                    .IsUnique();

                entity.Property(e => e.Idtema)
                    .ValueGeneratedNever()
                    .HasColumnName("idtema");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");

                entity.Property(e => e.Idcurso).HasColumnName("idcurso");

                entity.Property(e => e.NombreTema)
                    .HasMaxLength(150)
                    .HasColumnName("nombre_tema");

                entity.Property(e => e.Orden)
                    .HasColumnName("orden")
                    .HasDefaultValueSql("1");

                entity.HasOne(d => d.IdcursoNavigation)
                    .WithMany(p => p.TemaBibliotecas)
                    .HasForeignKey(d => d.Idcurso)
                    .HasConstraintName("fk_tema_bib_relations_cursos");
            });

            modelBuilder.Entity<Universidad>(entity =>
            {
                entity.HasKey(e => e.Iduniversidad)
                    .HasName("pk_universidad");

                entity.ToTable("universidad");

                entity.HasIndex(e => e.Iduniversidad, "universidad_pk")
                    .IsUnique();

                entity.Property(e => e.Iduniversidad)
                    .ValueGeneratedNever()
                    .HasColumnName("iduniversidad");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .HasName("pk_usuarios");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.Idusuario, "usuarios_pk")
                    .IsUnique();

                entity.Property(e => e.Idusuario)
                    .ValueGeneratedNever()
                    .HasColumnName("idusuario");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Celular)
                    .HasMaxLength(10)
                    .HasColumnName("celular");

                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(400)
                    .HasColumnName("contrasenia");

                entity.Property(e => e.Dni)
                    .HasMaxLength(8)
                    .HasColumnName("dni")
                    .IsFixedLength(true);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("date")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.FotoPerfil)
                    .HasMaxLength(400)
                    .HasColumnName("foto_perfil");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .HasColumnName("nombres");

                entity.Property(e => e.Perfil)
                    .HasMaxLength(100)
                    .HasColumnName("perfil");

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(20)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.HasKey(e => e.Idvideo)
                    .HasName("pk_videos");

                entity.ToTable("videos");

                entity.HasIndex(e => e.Idcurso, "relationship_2_fk");

                entity.HasIndex(e => e.Idvideo, "videos_pk")
                    .IsUnique();

                entity.Property(e => e.Idvideo)
                    .ValueGeneratedNever()
                    .HasColumnName("idvideo");

                entity.Property(e => e.Idcurso).HasColumnName("idcurso");

                entity.Property(e => e.RutaVideo)
                    .HasMaxLength(400)
                    .HasColumnName("ruta_video");

                entity.HasOne(d => d.IdcursoNavigation)
                    .WithMany(p => p.Videos)
                    .HasForeignKey(d => d.Idcurso)
                    .HasConstraintName("fk_videos_relations_cursos");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
