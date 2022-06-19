

using Microsoft.EntityFrameworkCore;

namespace ApiEvaluacion.Helpers
{
public partial class ApplicationDbContext : DbContext
{

        public ApplicationDbContext()
        {
        }

        public virtual DbSet<Cargo> Cargos { get; set; }
        public virtual DbSet<DepartamentoProyecto> DepartamentoProyectos { get; set; }
        public virtual DbSet<Detallepreguntum> Detallepregunta { get; set; }
        public virtual DbSet<Direccione> Direcciones { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Evaluaciodetalle> Evaluaciodetalles { get; set; }
        public virtual DbSet<Evaluacion> Evaluacions { get; set; }
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Movimiento> Movimientos { get; set; }
        public virtual DbSet<Ponderacion> Ponderacions { get; set; }
        public virtual DbSet<Preguntum> Pregunta { get; set; }
        public virtual DbSet<Tpevaluacion> Tpevaluacions { get; set; }
        public virtual DbSet<VwListQuestion> VwListQuestions { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.CarId)
                    .HasName("PK__Cargos__7D16AF2408EA5793");

                entity.Property(e => e.CarId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CAR_ID");

                entity.Property(e => e.CarDescripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CAR_Descripcion");

                entity.Property(e => e.CarFechaAud)
                    .HasColumnType("datetime")
                    .HasColumnName("CAR_FechaAud")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CarHomologado)
                    .IsRequired()
                    .HasColumnName("CAR_Homologado")
                    .HasDefaultValueSql("((1))")
                    .HasComment("Cargos que estan definidos en el Decreto 128-2005");

                entity.Property(e => e.CarNombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CAR_Nombre");

                entity.Property(e => e.CarUsuarioAud)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CAR_UsuarioAud")
                    .HasDefaultValueSql("(suser_sname())")
                    .HasComment("Usuario que agrega el cargo");
            });

            modelBuilder.Entity<DepartamentoProyecto>(entity =>
            {
                entity.HasKey(e => e.KeyDepartamentoProyecto)
                    .HasName("PK__Departam__463E2A670CBAE877");

                entity.ToTable("Departamento_Proyectos");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedUser)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("(suser_name())");

                entity.Property(e => e.DirId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Dir_id");

                entity.Property(e => e.DptCentroCosto)
                    .HasMaxLength(11)
                    .HasColumnName("DPT_Centro_Costo");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Observacion)
                    .HasMaxLength(150)
                    .HasColumnName("observacion");
            });

            modelBuilder.Entity<Detallepreguntum>(entity =>
            {
                entity.HasKey(e => e.KeyDtpreg)
                    .HasName("PK__Detallep__3214EC07737E2926");

                entity.Property(e => e.KeyDtpreg).HasComment("Key DetallePregunta");

                entity.Property(e => e.FkPreguntaId)
                    .HasColumnName("Fk_preguntaID")
                    .HasComment("Fk tabla pregunta");

                entity.Property(e => e.Fkdtevalua).HasComment("Fk tabla detalle evaluacion");

                entity.Property(e => e.Puntpregunta)
                    .HasColumnName("puntpregunta")
                    .HasComment("puntaje por cada pregunta del 1 al 4");

                entity.HasOne(d => d.FkPregunta)
                    .WithMany(p => p.Detallepregunta)
                    .HasForeignKey(d => d.FkPreguntaId)
                    .HasConstraintName("FK_Detallepregunta_Pregunta");

                entity.HasOne(d => d.FkdtevaluaNavigation)
                    .WithMany(p => p.Detallepregunta)
                    .HasForeignKey(d => d.Fkdtevalua)
                    .HasConstraintName("FK_Detallepregunta_Evaluaciodetalle");
            });

            modelBuilder.Entity<Direccione>(entity =>
            {
                entity.HasKey(e => e.DirId)
                    .HasName("PK__Direccio__B28024E21273C1CD");

                entity.Property(e => e.DirId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DIR_ID");

                entity.Property(e => e.DirActivo)
                    .HasColumnName("DIR_Activo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DirCentroCosto)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("DIR_Centro_Costo")
                    .IsFixedLength();

                entity.Property(e => e.DirDescripcion)
                    .HasColumnType("text")
                    .HasColumnName("DIR_Descripcion");

                entity.Property(e => e.DirFechaAud)
                    .HasColumnType("datetime")
                    .HasColumnName("DIR_FechaAUD")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DirNombre)
                    .IsRequired()
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("DIR_Nombre");

                entity.Property(e => e.DirUsuarioAud)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DIR_UsuarioAUD")
                    .HasDefaultValueSql("(suser_sname())");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.Designation).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Evaluaciodetalle>(entity =>
            {
                entity.HasKey(e => e.KeyEvdt)
                    .HasName("PK__Evaluaci__3214EC0707CAC434");

                entity.ToTable("Evaluaciodetalle");

                entity.Property(e => e.KeyEvdt).HasComment("Clave primaria evaluacion detalle");

                entity.Property(e => e.Blq1).HasComment("total bloque 1");

                entity.Property(e => e.Blq2).HasComment("total bloque 2");

                entity.Property(e => e.Blq3).HasComment("total bloque 3");

                entity.Property(e => e.Blq4).HasComment("total bloque 4");

                entity.Property(e => e.Bltotal).HasComment("puntaje total de evaluacion");

                entity.Property(e => e.CarId).HasComment("Fk cargo historial");

                entity.Property(e => e.DirId).HasComment("Fk direccion historial");

                entity.Property(e => e.Fkeva).HasComment("Fk tabla evaluaciones");

                entity.Property(e => e.Fkfunceval)
                    .HasColumnType("numeric(18, 0)")
                    .HasComment("Fk Funcionario que  evalua");

                entity.Property(e => e.Fktipoeva).HasComment("Fk tipo evaluacion");

                entity.Property(e => e.FunId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("FunID")
                    .HasComment("Fk Funcionario evaluado");

                entity.Property(e => e.Pntescala)
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasComment("Escala de puntaje tipo string");

                entity.Property(e => e.Rtcapc)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("capacitaciones");

                entity.Property(e => e.Rtcomp)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("compromisos");

                entity.Property(e => e.Rtdeb)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("debilidades");

                entity.Property(e => e.Rtfort)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("fortalezas");

                entity.HasOne(d => d.FkevaNavigation)
                    .WithMany(p => p.Evaluaciodetalles)
                    .HasForeignKey(d => d.Fkeva)
                    .HasConstraintName("FK_Evaluaciodetalle_Evaluacion1");

                entity.HasOne(d => d.FktipoevaNavigation)
                    .WithMany(p => p.Evaluaciodetalles)
                    .HasForeignKey(d => d.Fktipoeva)
                    .HasConstraintName("FK_Evaluaciodetalle_Tpevaluacion");

                entity.HasOne(d => d.Fun)
                    .WithMany(p => p.Evaluaciodetalles)
                    .HasForeignKey(d => d.FunId)
                    .HasConstraintName("FK_Evaluaciodetalle_Funcionarios");
            });

            modelBuilder.Entity<Evaluacion>(entity =>
            {
                entity.HasKey(e => e.KeyEval)
                    .HasName("PK__Evaluaci__09E809D4182C9B23");

                entity.ToTable("Evaluacion");

                entity.Property(e => e.KeyEval).HasComment("clave primaria tabla evaluacion Header");

                entity.Property(e => e.Estado).HasComment("Estado periodo para poder seleccionarlo en formulario crear evaluacion");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha")
                    .HasComment("fecha de evaluacion");

                entity.Property(e => e.Periodofinal)
                    .HasColumnType("date")
                    .HasComment("periodo final fecha");

                entity.Property(e => e.Periodoinicial)
                    .HasColumnType("date")
                    .HasComment("periodo inicial fecha");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("usuario del sistema ");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => e.FunId)
                    .HasName("PK__Funciona__C450C3101BFD2C07");

                entity.Property(e => e.FunId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("FUN_ID");

                entity.Property(e => e.CarId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("CAR_ID");

                entity.Property(e => e.DepId).HasColumnName("Dep_id");

                entity.Property(e => e.DirId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("DIR_ID");

                entity.Property(e => e.FunActivo).HasColumnName("FUN_Activo");

                entity.Property(e => e.FunApellidos)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FUN_Apellidos")
                    .IsFixedLength();

                entity.Property(e => e.FunCedula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("FUN_Cedula")
                    .IsFixedLength();

                entity.Property(e => e.FunCodigo)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("FUN_CODIGO");

                entity.Property(e => e.FunDireccion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FUN_Direccion")
                    .IsFixedLength();

                entity.Property(e => e.FunFechaIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("FUN_Fecha_Ingreso");

                entity.Property(e => e.FunFnac)
                    .HasColumnType("datetime")
                    .HasColumnName("FUN_FNac");

                entity.Property(e => e.FunIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("FUN_Ingreso");

                entity.Property(e => e.FunNombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FUN_Nombre")
                    .IsFixedLength();

                entity.Property(e => e.JefeId)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("JEFE_ID");

                entity.Property(e => e.KeyDepartamentoProyecto).HasDefaultValueSql("((0))");

                entity.Property(e => e.SexoId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("SEXO_ID");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK_Funcionarios_Cargos");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("FK_Funcionarios_Departamento_Proyectos");

                entity.HasOne(d => d.Dir)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.DirId)
                    .HasConstraintName("FK_Funcionarios_Direcciones");
            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("movimientos");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("createdBy");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(10)
                    .HasColumnName("createdDate")
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.DirIdNew).HasColumnName("dir_idNew");

                entity.Property(e => e.DirIdOld).HasColumnName("dir_idOld");

                entity.Property(e => e.FunId).HasColumnName("fun_id");

                entity.Property(e => e.MovId).HasColumnName("mov_id");
            });

            modelBuilder.Entity<Ponderacion>(entity =>
            {
                entity.ToTable("Ponderacion");

                entity.Property(e => e.Id).HasComment("clave primaria");

                entity.Property(e => e.Activo).HasComment("estado para eliminacion logica");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("detalle de agrupacion de pregunta");

                entity.Property(e => e.Valor).HasComment("valor de ponderacion");
            });

            modelBuilder.Entity<Preguntum>(entity =>
            {
                entity.Property(e => e.Id).HasComment("Key pregunta");

                entity.Property(e => e.Activo).HasComment("estado de pregunta");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("detalle de pregunta");

                entity.Property(e => e.FkPndId)
                    .HasColumnName("Fk_pndID")
                    .HasComment("Fk table ponderacion contiene bloques de preguntas");

                entity.HasOne(d => d.FkPnd)
                    .WithMany(p => p.Pregunta)
                    .HasForeignKey(d => d.FkPndId)
                    .HasConstraintName("FK_Pregunta_Ponderacion");
            });

            modelBuilder.Entity<Tpevaluacion>(entity =>
            {
                entity.ToTable("Tpevaluacion");

                entity.Property(e => e.Id).HasComment("clave primaria");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("Detalle de evaluacion");
            });

            modelBuilder.Entity<VwListQuestion>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_ListQuestions");

                entity.Property(e => e.Idpreg).HasColumnName("IDpreg");

                entity.Property(e => e.Ponderacion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ponderacion")
                    .IsFixedLength();

                entity.Property(e => e.Pregunta)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

          OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
