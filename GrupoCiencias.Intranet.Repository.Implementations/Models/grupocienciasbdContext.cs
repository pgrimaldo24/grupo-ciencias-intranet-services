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

        public virtual DbSet<Apoderado> Apoderados { get; set; }
        public virtual DbSet<AreasCarrera> AreasCarreras { get; set; }
        public virtual DbSet<Carrera> Carreras { get; set; }
        public virtual DbSet<Ciclo> Ciclos { get; set; }
        public virtual DbSet<CursosCiclo> CursosCiclos { get; set; }
        public virtual DbSet<EstadoPago> EstadoPagos { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<Keyapp> Keyapps { get; set; }
        public virtual DbSet<Marketing> Marketings { get; set; }
        public virtual DbSet<Master> Masters { get; set; }
        public virtual DbSet<Sede> Sedes { get; set; }
        public virtual DbSet<Solicitude> Solicitudes { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public virtual DbSet<TipoPago> TipoPagos { get; set; }
        public virtual DbSet<TipoPagoDetalle> TipoPagoDetalles { get; set; }
        public virtual DbSet<TransaccionPago> TransaccionPagos { get; set; }
        public virtual DbSet<Universidad> Universidads { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;User Id=postgres;Password=Peru123.;Database=grupocienciasbd;Trust Server Certificate=true;CommandTimeout=0;Keepalive=59;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apoderado>(entity =>
            {
                entity.HasKey(e => e.Idapoderado)
                    .HasName("apoderados_pkey");

                entity.ToTable("apoderados");

                entity.Property(e => e.Idapoderado).HasColumnName("idapoderado");

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

                entity.Property(e => e.IdTipoDocumento).HasColumnName("id_tipo_documento");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .HasColumnName("nombres");

                entity.Property(e => e.RutaFotoDni)
                    .HasMaxLength(400)
                    .HasColumnName("ruta_foto_dni");
            });

            modelBuilder.Entity<AreasCarrera>(entity =>
            {
                entity.HasKey(e => e.Idarea)
                    .HasName("areas_carrera_pkey");

                entity.ToTable("areas_carrera");

                entity.Property(e => e.Idarea).HasColumnName("idarea");

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
                    .HasConstraintName("areas_carreras_universidad_constraint");
            });

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => e.Idcarrera)
                    .HasName("carreras_pkey");

                entity.ToTable("carreras");

                entity.Property(e => e.Idcarrera).HasColumnName("idcarrera");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("date")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.Idarea).HasColumnName("idarea");

                entity.Property(e => e.Idmaster)
                    .HasMaxLength(50)
                    .HasColumnName("idmaster");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdareaNavigation)
                    .WithMany(p => p.Carreras)
                    .HasForeignKey(d => d.Idarea)
                    .HasConstraintName("areas_carreras_constraint");

                entity.HasOne(d => d.IdmasterNavigation)
                    .WithMany(p => p.Carreras)
                    .HasForeignKey(d => d.Idmaster)
                    .HasConstraintName("carreras_master_constraint");
            });

            modelBuilder.Entity<Ciclo>(entity =>
            {
                entity.HasKey(e => e.Idciclo)
                    .HasName("ciclos_pkey");

                entity.ToTable("ciclos");

                entity.Property(e => e.Idciclo).HasColumnName("idciclo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.GrupoCiclos).HasColumnName("grupo_ciclos");

                entity.Property(e => e.Idmaster)
                    .HasMaxLength(50)
                    .HasColumnName("idmaster");

                entity.Property(e => e.Iduniversidad).HasColumnName("iduniversidad");

                entity.Property(e => e.Precio)
                    .HasPrecision(9, 2)
                    .HasColumnName("precio");

                entity.Property(e => e.VisibleLanding).HasColumnName("visible_landing");

                entity.HasOne(d => d.IdmasterNavigation)
                    .WithMany(p => p.Ciclos)
                    .HasForeignKey(d => d.Idmaster)
                    .HasConstraintName("master_ciclos_constraint");

                entity.HasOne(d => d.IduniversidadNavigation)
                    .WithMany(p => p.Ciclos)
                    .HasForeignKey(d => d.Iduniversidad)
                    .HasConstraintName("ciclos_universidad_constraint");
            });

            modelBuilder.Entity<CursosCiclo>(entity =>
            {
                entity.HasKey(e => e.Idciclo)
                    .HasName("cursos_ciclos_pkey");

                entity.ToTable("cursos_ciclos");

                entity.Property(e => e.Idciclo).HasColumnName("idciclo");

                entity.Property(e => e.Idcurso).HasColumnName("idcurso");
            });

            modelBuilder.Entity<EstadoPago>(entity =>
            {
                entity.HasKey(e => e.Idestadopago)
                    .HasName("estado_pago_pkey");

                entity.ToTable("estado_pago");

                entity.Property(e => e.Idestadopago).HasColumnName("idestadopago");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Estadopago1)
                    .HasMaxLength(50)
                    .HasColumnName("estadopago");

                entity.Property(e => e.Fechabaja)
                    .HasColumnType("date")
                    .HasColumnName("fechabaja");

                entity.Property(e => e.Fechacreacion)
                    .HasColumnType("date")
                    .HasColumnName("fechacreacion")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("usuario")
                    .HasDefaultValueSql("'ADMIN'::character varying");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.Idestudiante)
                    .HasName("estudiantes_pkey");

                entity.ToTable("estudiantes");

                entity.Property(e => e.Idestudiante).HasColumnName("idestudiante");

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

                entity.Property(e => e.IdTipoDocumento).HasColumnName("id_tipo_documento");

                entity.Property(e => e.Idapoderado).HasColumnName("idapoderado");

                entity.Property(e => e.Idciclo).HasColumnName("idciclo");

                entity.Property(e => e.MedioInfo)
                    .HasMaxLength(15)
                    .HasColumnName("medio_info");

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
                    .HasConstraintName("apoderados_estudiantes_constraint");
            });

            modelBuilder.Entity<Keyapp>(entity =>
            {
                entity.ToTable("keyapp");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clave)
                    .HasMaxLength(50)
                    .HasColumnName("clave");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Fechabaja)
                    .HasColumnType("date")
                    .HasColumnName("fechabaja");

                entity.Property(e => e.Fechacreacion)
                    .HasColumnType("date")
                    .HasColumnName("fechacreacion")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .HasColumnName("usuario");

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("usuario_creacion")
                    .HasDefaultValueSql("'ADMIN'::character varying");
            });

            modelBuilder.Entity<Marketing>(entity =>
            {
                entity.HasKey(e => e.Idmarketing)
                    .HasName("marketing_pkey");

                entity.ToTable("marketing");

                entity.Property(e => e.Idmarketing).HasColumnName("idmarketing");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Fechabaja)
                    .HasColumnType("date")
                    .HasColumnName("fechabaja");

                entity.Property(e => e.Fechacreacion)
                    .HasColumnType("date")
                    .HasColumnName("fechacreacion")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Idmaster)
                    .HasMaxLength(50)
                    .HasColumnName("idmaster");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("usuario")
                    .HasDefaultValueSql("'ADMIN'::character varying");

                entity.Property(e => e.Valor)
                    .HasMaxLength(200)
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdmasterNavigation)
                    .WithMany(p => p.Marketings)
                    .HasForeignKey(d => d.Idmaster)
                    .HasConstraintName("master_marketing_constraint");
            });

            modelBuilder.Entity<Master>(entity =>
            {
                entity.HasKey(e => e.Idmaster)
                    .HasName("master_pkey");

                entity.ToTable("master");

                entity.Property(e => e.Idmaster)
                    .HasMaxLength(50)
                    .HasColumnName("idmaster");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Fechabaja)
                    .HasColumnType("date")
                    .HasColumnName("fechabaja");

                entity.Property(e => e.Fechacreacion)
                    .HasColumnType("date")
                    .HasColumnName("fechacreacion")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Propiedad)
                    .HasMaxLength(50)
                    .HasColumnName("propiedad");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("usuario")
                    .HasDefaultValueSql("'ADMIN'::character varying");

                entity.Property(e => e.Valor)
                    .HasMaxLength(200)
                    .HasColumnName("valor");
            });

            modelBuilder.Entity<Sede>(entity =>
            {
                entity.HasKey(e => e.Idsedes)
                    .HasName("sedes_pkey");

                entity.ToTable("sedes");

                entity.Property(e => e.Idsedes).HasColumnName("idsedes");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Fechabaja)
                    .HasColumnType("date")
                    .HasColumnName("fechabaja");

                entity.Property(e => e.Fechacreacion)
                    .HasColumnType("date")
                    .HasColumnName("fechacreacion")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Idmaster)
                    .HasMaxLength(50)
                    .HasColumnName("idmaster");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("usuario")
                    .HasDefaultValueSql("'ADMIN'::character varying");

                entity.Property(e => e.Valor)
                    .HasMaxLength(200)
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdmasterNavigation)
                    .WithMany(p => p.Sedes)
                    .HasForeignKey(d => d.Idmaster)
                    .HasConstraintName("master_sedes_constraint");
            });

            modelBuilder.Entity<Solicitude>(entity =>
            {
                entity.HasKey(e => e.Idsolicitud)
                    .HasName("solicitudes_pkey");

                entity.ToTable("solicitudes");

                entity.Property(e => e.Idsolicitud).HasColumnName("idsolicitud");

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

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");

                entity.Property(e => e.IdTipoDocumento).HasColumnName("id_tipo_documento");

                entity.Property(e => e.Idapoderado).HasColumnName("idapoderado");

                entity.Property(e => e.MedioInfo)
                    .HasMaxLength(15)
                    .HasColumnName("medio_info");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .HasColumnName("nombres");

                entity.Property(e => e.PerfilFacebook)
                    .HasMaxLength(100)
                    .HasColumnName("perfil_facebook");

                entity.Property(e => e.PoliticasFinesComerciales).HasColumnName("politicas_fines_comerciales");

                entity.Property(e => e.Politicasseguridad).HasColumnName("politicasseguridad");

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
                    .HasConstraintName("apoderados_constraint");
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.ToTable("tipo_documentos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Fechabaja)
                    .HasColumnType("date")
                    .HasColumnName("fechabaja");

                entity.Property(e => e.Fechacreacion)
                    .HasColumnType("date")
                    .HasColumnName("fechacreacion")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Idmaster)
                    .HasMaxLength(50)
                    .HasColumnName("idmaster");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("usuario")
                    .HasDefaultValueSql("'ADMIN'::character varying");

                entity.Property(e => e.Valor)
                    .HasMaxLength(200)
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdmasterNavigation)
                    .WithMany(p => p.TipoDocumentos)
                    .HasForeignKey(d => d.Idmaster)
                    .HasConstraintName("master_tipo_documentos_constraint");
            });

            modelBuilder.Entity<TipoPago>(entity =>
            {
                entity.HasKey(e => e.Idred)
                    .HasName("redsocial_pkey");

                entity.ToTable("tipo_pago");

                entity.Property(e => e.Idred)
                    .HasColumnName("idred")
                    .HasDefaultValueSql("nextval('redsocial_idred_seq'::regclass)");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Fechabaja)
                    .HasColumnType("date")
                    .HasColumnName("fechabaja");

                entity.Property(e => e.Fechacreacion)
                    .HasColumnType("date")
                    .HasColumnName("fechacreacion")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Idmaster)
                    .HasMaxLength(50)
                    .HasColumnName("idmaster");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("usuario")
                    .HasDefaultValueSql("'ADMIN'::character varying");

                entity.Property(e => e.Valor)
                    .HasMaxLength(200)
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdmasterNavigation)
                    .WithMany(p => p.TipoPagos)
                    .HasForeignKey(d => d.Idmaster)
                    .HasConstraintName("master_redsocial_constraint");
            });

            modelBuilder.Entity<TipoPagoDetalle>(entity =>
            {
                entity.HasKey(e => e.Idpagodetalle)
                    .HasName("tipo_pago_detalle_pkey");

                entity.ToTable("tipo_pago_detalle");

                entity.Property(e => e.Idpagodetalle).HasColumnName("idpagodetalle");

                entity.Property(e => e.Descuento)
                    .HasPrecision(9, 2)
                    .HasColumnName("descuento");

                entity.Property(e => e.Idciclo).HasColumnName("idciclo");

                entity.Property(e => e.Idtipopago).HasColumnName("idtipopago");

                entity.Property(e => e.Preciofinal)
                    .HasPrecision(9, 2)
                    .HasColumnName("preciofinal");

                entity.Property(e => e.Subtotal)
                    .HasPrecision(9, 2)
                    .HasColumnName("subtotal");
            });

            modelBuilder.Entity<TransaccionPago>(entity =>
            {
                entity.HasKey(e => e.IdTransaccionPago)
                    .HasName("transaccion_pago_pkey");

                entity.ToTable("transaccion_pago");

                entity.Property(e => e.IdTransaccionPago).HasColumnName("id_transaccion_pago");

                entity.Property(e => e.ApellidoTitular)
                    .HasMaxLength(100)
                    .HasColumnName("apellido_titular");

                entity.Property(e => e.CodPagoReferencia)
                    .HasMaxLength(50)
                    .HasColumnName("cod_pago_referencia");

                entity.Property(e => e.CuotasPago).HasColumnName("cuotas_pago");

                entity.Property(e => e.EmailTitular)
                    .HasMaxLength(50)
                    .HasColumnName("email_titular");

                entity.Property(e => e.EstadoPago)
                    .HasMaxLength(20)
                    .HasColumnName("estado_pago");

                entity.Property(e => e.EstadoPagoDetalle)
                    .HasMaxLength(20)
                    .HasColumnName("estado_pago_detalle");

                entity.Property(e => e.EstadoRegistro)
                    .HasColumnName("estado_registro")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.EstadoTransaccionPago)
                    .HasMaxLength(10)
                    .HasColumnName("estado_transaccion_pago");

                entity.Property(e => e.FechaAprovadaPago)
                    .HasMaxLength(20)
                    .HasColumnName("fecha_aprovada_pago");

                entity.Property(e => e.FechaBajaRegistro)
                    .HasColumnType("date")
                    .HasColumnName("fecha_baja_registro");

                entity.Property(e => e.FechaCreacionRegistro)
                    .HasColumnType("date")
                    .HasColumnName("fecha_creacion_registro")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.FechaCreadaPago)
                    .HasMaxLength(20)
                    .HasColumnName("fecha_creada_pago");

                entity.Property(e => e.FechaLiberacionDinero)
                    .HasMaxLength(20)
                    .HasColumnName("fecha_liberacion_dinero");

                entity.Property(e => e.FechaUltimaActualizacion)
                    .HasMaxLength(20)
                    .HasColumnName("fecha_ultima_actualizacion");

                entity.Property(e => e.IdComprobantePago).HasColumnName("id_comprobante_pago");

                entity.Property(e => e.IdTipoTarjeta)
                    .HasMaxLength(10)
                    .HasColumnName("id_tipo_tarjeta");

                entity.Property(e => e.MetodoPagoId)
                    .HasMaxLength(10)
                    .HasColumnName("metodo_pago_id");

                entity.Property(e => e.MontoTransaccion)
                    .HasPrecision(10, 2)
                    .HasColumnName("monto_transaccion");

                entity.Property(e => e.NombreTitular)
                    .HasMaxLength(100)
                    .HasColumnName("nombre_titular");

                entity.Property(e => e.NotificacionUrl)
                    .HasMaxLength(100)
                    .HasColumnName("notificacion_url");

                entity.Property(e => e.NumeroDocumentoTitular)
                    .HasMaxLength(50)
                    .HasColumnName("numero_documento_titular");

                entity.Property(e => e.Proveedor)
                    .HasMaxLength(15)
                    .HasColumnName("proveedor");

                entity.Property(e => e.TipoDocumentoTitularId).HasColumnName("tipo_documento_titular_id");

                entity.Property(e => e.TipoMoneda)
                    .HasMaxLength(10)
                    .HasColumnName("tipo_moneda");

                entity.Property(e => e.TokenCard)
                    .HasMaxLength(50)
                    .HasColumnName("token_card");
            });

            modelBuilder.Entity<Universidad>(entity =>
            {
                entity.HasKey(e => e.Iduniversidad)
                    .HasName("universidad_pkey");

                entity.ToTable("universidad");

                entity.Property(e => e.Iduniversidad).HasColumnName("iduniversidad");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.Idmaster)
                    .HasMaxLength(50)
                    .HasColumnName("idmaster");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdmasterNavigation)
                    .WithMany(p => p.Universidads)
                    .HasForeignKey(d => d.Idmaster)
                    .HasConstraintName("master__carreras_constraint");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
