using Microsoft.EntityFrameworkCore;

namespace SKL.Models
{
    public partial class SkldbMainContext : DbContext
    {
        public virtual DbSet<Cargos> Cargos { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<CursosCargos> CursosCargos { get; set; }
        public virtual DbSet<CursosDepartamentos> CursosDepartamentos { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<Empregados> Empregados { get; set; }
        public virtual DbSet<Historico> Historico { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Permissoes> Permissoes { get; set; }
        public virtual DbSet<Pessoas> Pessoas { get; set; }
        public virtual DbSet<Questoes> Questoes { get; set; }

        public SkldbMainContext(DbContextOptions<SkldbMainContext> options) 
            : base(options) { }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer(@"Server=CINTIANEVES\SQLEXPRESS;Database=skldb_main;Trusted_Connection=True;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargos>(entity =>
            {
                entity.HasKey(e => e.IdCargos);

                entity.ToTable("CARGOS");

                entity.Property(e => e.IdCargos).HasColumnName("ID_CARGOS");

                entity.Property(e => e.Frequencia)
                    .HasColumnName("FREQUENCIA")
                    .HasColumnType("datetime");

                entity.Property(e => e.TempoCursado)
                    .HasColumnName("TEMPO_CURSADO")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Cursos>(entity =>
            {
                entity.HasKey(e => e.IdCursos);

                entity.ToTable("CURSOS");

                entity.Property(e => e.IdCursos).HasColumnName("ID_CURSOS");

                entity.Property(e => e.LinkConteudo)
                    .HasColumnName("LINK_CONTEUDO")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasColumnName("NOME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeAutor)
                    .HasColumnName("NOME_AUTOR")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TempoEstimadoCurso)
                    .HasColumnName("TEMPO_ESTIMADO_CURSO")
                    .HasColumnType("datetime");

                entity.Property(e => e.TipoArquivo)
                    .HasColumnName("TIPO_ARQUIVO")
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CursosCargos>(entity =>
            {
                entity.HasKey(e => new { e.IdCursos, e.IdCargos });

                entity.ToTable("CURSOS_CARGOS");

                entity.Property(e => e.IdCursos).HasColumnName("ID_CURSOS");

                entity.Property(e => e.IdCargos).HasColumnName("ID_CARGOS");
            });

            modelBuilder.Entity<CursosDepartamentos>(entity =>
            {
                entity.HasKey(e => e.Frequencia);

                entity.ToTable("CURSOS_DEPARTAMENTOS");

                entity.Property(e => e.Frequencia)
                    .HasColumnName("FREQUENCIA")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCursos).HasColumnName("ID_CURSOS");

                entity.Property(e => e.IdDepartamentos).HasColumnName("ID_DEPARTAMENTOS");

                entity.HasOne(d => d.IdCursosNavigation)
                    .WithMany(p => p.CursosDepartamentos)
                    .HasForeignKey(d => d.IdCursos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TB_COURSES_COURSE_BY_DEPARTMENT");

                entity.HasOne(d => d.IdDepartamentosNavigation)
                    .WithMany(p => p.CursosDepartamentos)
                    .HasForeignKey(d => d.IdDepartamentos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TB_DEPARTMENTS_COURSE_BY_DEPARTMENT");
            });

            modelBuilder.Entity<Departamentos>(entity =>
            {
                entity.HasKey(e => e.IdDepartamentos);

                entity.ToTable("DEPARTAMENTOS");

                entity.Property(e => e.IdDepartamentos).HasColumnName("ID_DEPARTAMENTOS");

                entity.Property(e => e.IdEmpregados).HasColumnName("ID_EMPREGADOS");

                entity.Property(e => e.Nome)
                    .HasColumnName("NOME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpregadosNavigation)
                    .WithMany(p => p.Departamentos)
                    .HasForeignKey(d => d.IdEmpregados)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TB_EMPLOYEES");
            });

            modelBuilder.Entity<Empregados>(entity =>
            {
                entity.HasKey(e => e.IdEmpregados);

                entity.ToTable("EMPREGADOS");

                entity.Property(e => e.IdEmpregados).HasColumnName("ID_EMPREGADOS");

                entity.Property(e => e.Administrador).HasColumnName("ADMINISTRADOR");

                entity.Property(e => e.Curso)
                    .HasColumnName("CURSO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("DATA_NASCIMENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdCarogs).HasColumnName("ID_CAROGS");

                entity.Property(e => e.IdDepartamentos).HasColumnName("ID_DEPARTAMENTOS");

                entity.Property(e => e.Nome)
                    .HasColumnName("NOME")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasColumnName("SEXO")
                    .HasColumnType("char(1)");

                entity.HasOne(d => d.IdCarogsNavigation)
                    .WithMany(p => p.Empregados)
                    .HasForeignKey(d => d.IdCarogs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHARGES");

                entity.HasOne(d => d.IdDepartamentosNavigation)
                    .WithMany(p => p.Empregados)
                    .HasForeignKey(d => d.IdDepartamentos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TB_DEPARTMENTS");
            });

            modelBuilder.Entity<Historico>(entity =>
            {
                entity.HasKey(e => new { e.IdCursos, e.IdEmpregados });

                entity.ToTable("HISTORICO");

                entity.Property(e => e.IdCursos).HasColumnName("ID_CURSOS");

                entity.Property(e => e.IdEmpregados).HasColumnName("ID_EMPREGADOS");

                entity.Property(e => e.Datas)
                    .HasColumnName("DATAS")
                    .HasColumnType("datetime");

                entity.Property(e => e.Notas).HasColumnName("NOTAS");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.IdLogin);

                entity.ToTable("LOGIN");

                entity.Property(e => e.IdLogin).HasColumnName("ID_LOGIN");

                entity.Property(e => e.IdPermissao).HasColumnName("ID_PERMISSAO");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasColumnName("NOME_USUARIO")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPermissaoNavigation)
                    .WithMany(p => p.Login)
                    .HasForeignKey(d => d.IdPermissao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERMISSION_LOGIN");
            });

            modelBuilder.Entity<Permissoes>(entity =>
            {
                entity.HasKey(e => e.IdPermissoes);

                entity.ToTable("PERMISSOES");

                entity.Property(e => e.IdPermissoes).HasColumnName("ID_PERMISSOES");

                entity.Property(e => e.Admin)
                    .HasColumnName("ADMIN")
                    .HasColumnType("binary(1)");

                entity.Property(e => e.Gerente)
                    .HasColumnName("GERENTE")
                    .HasColumnType("binary(1)");

                entity.Property(e => e.Usuario)
                    .HasColumnName("USUARIO")
                    .HasColumnType("binary(1)");
            });

            modelBuilder.Entity<Pessoas>(entity =>
            {
                entity.HasKey(e => e.IdPessoas);

                entity.ToTable("PESSOAS");

                entity.Property(e => e.IdPessoas).HasColumnName("ID_PESSOAS");

                entity.Property(e => e.IdLogin).HasColumnName("ID_LOGIN");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdLoginNavigation)
                    .WithMany(p => p.Pessoas)
                    .HasForeignKey(d => d.IdLogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LOGIN_PERSON");
            });

            modelBuilder.Entity<Questoes>(entity =>
            {
                entity.HasKey(e => e.IdQuestions);

                entity.ToTable("QUESTOES");

                entity.Property(e => e.IdQuestions).HasColumnName("ID_QUESTIONS");

                entity.Property(e => e.A)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.B)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.C)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Correct)
                    .IsRequired()
                    .HasColumnName("CORRECT")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.D)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.E)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdCourses).HasColumnName("ID_COURSES");

                entity.HasOne(d => d.IdCoursesNavigation)
                    .WithMany(p => p.Questoes)
                    .HasForeignKey(d => d.IdCourses)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COURSES");
            });
        }
    }
}
