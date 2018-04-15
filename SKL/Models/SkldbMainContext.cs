using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SKL.Models
{
    public partial class SkldbMainContext : DbContext
    {
        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<CursosPorCargo> CursosPorCargo { get; set; }
        public virtual DbSet<CursosPorDepartamento> CursosPorDepartamento { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Empregado> Empregado { get; set; }
        public virtual DbSet<Historico> Historico { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Permissao> Permissao { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Questao> Questao { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Server=MURALIS-09\SQLEXPRESS;Database=skldb_main;Trusted_Connection=True;");
//            }
//        }

        public SkldbMainContext(DbContextOptions<SkldbMainContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.IdCargo);

                entity.ToTable("CARGO");

                entity.Property(e => e.IdCargo).HasColumnName("ID_CARGO");

                entity.Property(e => e.Frequencia)
                    .HasColumnName("FREQUENCIA")
                    .HasColumnType("datetime");

                entity.Property(e => e.TempoCursado)
                    .HasColumnName("TEMPO_CURSADO")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso);

                entity.ToTable("CURSO");

                entity.Property(e => e.IdCurso).HasColumnName("ID_CURSO");

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

            modelBuilder.Entity<CursosPorCargo>(entity =>
            {
                entity.HasKey(e => new { e.IdCurso, e.IdCargo });

                entity.ToTable("CURSOS_POR_CARGO");

                entity.Property(e => e.IdCurso).HasColumnName("ID_CURSO");

                entity.Property(e => e.IdCargo).HasColumnName("ID_CARGO");
            });

            modelBuilder.Entity<CursosPorDepartamento>(entity =>
            {
                entity.HasKey(e => new { e.IdCurso, e.IdDepartamento });

                entity.ToTable("CURSOS_POR_DEPARTAMENTO");

                entity.Property(e => e.IdCurso).HasColumnName("ID_CURSO");

                entity.Property(e => e.IdDepartamento).HasColumnName("ID_DEPARTAMENTO");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.CursosPorDepartamento)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CURSOS_POR_DEPARTAMENTO_ID_CURSO");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.CursosPorDepartamento)
                    .HasForeignKey(d => d.IdDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CURSOS_POR_DEPARTAMENTO_ID_DEPARTAMENTO");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento);

                entity.ToTable("DEPARTAMENTO");

                entity.Property(e => e.IdDepartamento).HasColumnName("ID_DEPARTAMENTO");

                entity.Property(e => e.IdEmpregado).HasColumnName("ID_EMPREGADO");

                entity.Property(e => e.Nome)
                    .HasColumnName("NOME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpregadoNavigation)
                    .WithMany(p => p.Departamento)
                    .HasForeignKey(d => d.IdEmpregado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DEPARTAMENTO_EMPREGADO");
            });

            modelBuilder.Entity<Empregado>(entity =>
            {
                entity.HasKey(e => e.IdEmpregado);

                entity.ToTable("EMPREGADO");

                entity.Property(e => e.IdEmpregado).HasColumnName("ID_EMPREGADO");

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

                entity.Property(e => e.IdCargo).HasColumnName("ID_CARGO");

                entity.Property(e => e.IdDepartamento).HasColumnName("ID_DEPARTAMENTO");

                entity.Property(e => e.Nome)
                    .HasColumnName("NOME")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasColumnName("SEXO")
                    .HasColumnType("char(1)");

                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.Empregado)
                    .HasForeignKey(d => d.IdCargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPREGADO_CARGO");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Empregado)
                    .HasForeignKey(d => d.IdDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPREGADO_DEPARTAMENTO");
            });

            modelBuilder.Entity<Historico>(entity =>
            {
                entity.HasKey(e => e.IdHistorico);

                entity.ToTable("HISTORICO");

                entity.Property(e => e.IdHistorico).HasColumnName("ID_HISTORICO");

                entity.Property(e => e.Data)
                    .HasColumnName("DATA")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCurso).HasColumnName("ID_CURSO");

                entity.Property(e => e.IdEmpregado).HasColumnName("ID_EMPREGADO");

                entity.Property(e => e.Nota).HasColumnName("NOTA");
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
                    .HasConstraintName("FK_LOGIN_PERMISSAO");
            });

            modelBuilder.Entity<Permissao>(entity =>
            {
                entity.HasKey(e => e.IdPermissao);

                entity.ToTable("PERMISSAO");

                entity.Property(e => e.IdPermissao).HasColumnName("ID_PERMISSAO");

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

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.IdPessoa);

                entity.ToTable("PESSOA");

                entity.Property(e => e.IdPessoa).HasColumnName("ID_PESSOA");

                entity.Property(e => e.IdLogin).HasColumnName("ID_LOGIN");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdLoginNavigation)
                    .WithMany(p => p.Pessoa)
                    .HasForeignKey(d => d.IdLogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PESSOA_LOGIN");
            });

            modelBuilder.Entity<Questao>(entity =>
            {
                entity.HasKey(e => e.IdQuestao);

                entity.ToTable("QUESTAO");

                entity.Property(e => e.IdQuestao).HasColumnName("ID_QUESTAO");

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

                entity.Property(e => e.IdCurso).HasColumnName("ID_CURSO");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Questao)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QUESTAO_CURSO");
            });
        }
    }
}
