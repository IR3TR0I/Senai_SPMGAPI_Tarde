using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Senai_SPMGAPI_Tarde.Domains;

#nullable disable

namespace Senai_SPMGAPI_Tarde.Contexts
{
    public partial class SPMGContext : DbContext
    {
        public SPMGContext()
        {
        }

        public SPMGContext(DbContextOptions<SPMGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinica> Clinicas { get; set; }
        public virtual DbSet<Consulta> Consultas { get; set; }
        public virtual DbSet<Especialidade> Especialidades { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Prontuarios { get; set; }
        public virtual DbSet<Situações> Situações { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-9VU6KVN\\SqlExpress; Initial Catalog= SP_MedicalGroups; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica)
                    .HasName("PK__Clinicas__52A90951421AED5A");

                entity.HasIndex(e => e.Cnpj, "UQ__Clinicas__35BD3E48789C2F09")
                    .IsUnique();

                entity.HasIndex(e => e.Endereço, "UQ__Clinicas__946AEB1D197C28FC")
                    .IsUnique();

                entity.HasIndex(e => e.NomeFantasia, "UQ__Clinicas__E7ADFC706E8A8FEA")
                    .IsUnique();

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("cnpj")
                    .IsFixedLength(true);

                entity.Property(e => e.Endereço)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("endereço");

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nomeFantasia");

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("razaoSocial");
            });

            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("PK__Consulta__9B2AD1D8D41C5829");

                entity.Property(e => e.DataConsulta).HasColumnType("date");

                entity.Property(e => e.Relatorio)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Relatorio não Informado...')");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdMedico)
                    .HasConstraintName("FK__Consultas__IdMed__534D60F1");

                entity.HasOne(d => d.IdProntuarioNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdProntuario)
                    .HasConstraintName("FK__Consultas__IdPro__5441852A");

                entity.HasOne(d => d.IdSituaçãoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdSituação)
                    .HasConstraintName("FK__Consultas__IdSit__5535A963");
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidade)
                    .HasName("PK__Especial__5676CEFFE0067A71");

                entity.HasIndex(e => e.TitulosEspecialidades, "UQ__Especial__35E62BEA5341163D")
                    .IsUnique();

                entity.Property(e => e.TitulosEspecialidades)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("titulosEspecialidades");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK__Medicos__C326E65283ED55FE");

                entity.HasIndex(e => e.Crm, "UQ__Medicos__D836F7D19B2E8832")
                    .IsUnique();

                entity.Property(e => e.Crm)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("crm")
                    .IsFixedLength(true);

                entity.Property(e => e.NomeMedico)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeMedico");

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK__Medicos__IdClini__4CA06362");

                entity.HasOne(d => d.IdEspecialidadesNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdEspecialidades)
                    .HasConstraintName("FK__Medicos__IdEspec__4D94879B");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("FK__Medicos__Idusuar__4BAC3F29");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PK__Prontuar__3AB81E66EC9DA82B");

                entity.HasIndex(e => e.Rg, "UQ__Prontuar__321537C89B34D21E")
                    .IsUnique();

                entity.HasIndex(e => e.TelefonePaciente, "UQ__Prontuar__B70E53B64BB83596")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "UQ__Prontuar__C1F8973162FDDD47")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.Endereço)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomePaciente)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RG");

                entity.Property(e => e.TelefonePaciente)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Prontuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Prontuari__IdUsu__47DBAE45");
            });

            modelBuilder.Entity<Situações>(entity =>
            {
                entity.HasKey(e => e.IdSituação)
                    .HasName("PK__Situaçõe__ADF4C48622D8D875");

                entity.HasIndex(e => e.TituloSituação, "UQ__Situaçõe__E89D33F856EE1DFC")
                    .IsUnique();

                entity.Property(e => e.TituloSituação)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tituloSituação");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__CA04062BE0A83C69");

                entity.HasIndex(e => e.TituloTipoUsuario, "UQ__TipoUsua__C6B29FC3DEC55422")
                    .IsUnique();

                entity.Property(e => e.TituloTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("tituloTipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__5B65BF97C49E59BE");

                entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D10534E5023B62")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuarios__IdTipo__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
