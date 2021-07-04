using System;
using GerenciaProjeto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GerenciaProjeto.Data
{
    public partial class GerenciaProjetoContext : DbContext
    {
        public GerenciaProjetoContext()
        {
        }

        public GerenciaProjetoContext(DbContextOptions<GerenciaProjetoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<AtualizacaoCliente> AtualizacaoCliente { get; set; }
        public virtual DbSet<Sistema> Sistema { get; set; }
        public virtual DbSet<TarefaCliente> TarefaCliente { get; set; }
        public virtual DbSet<TarefaEmpresa> TarefaEmpresa { get; set; }
        public virtual DbSet<Versao> Versao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=projetoinformatica.ddns.net;Initial Catalog=GerenciaProjeto;Persist Security Info=True;User ID=sa;Password=cobrafox@321");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("empresa", "tarefas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(100);

                entity.Property(e => e.Telefone)
                    .IsRequired(required: false)
                    .HasColumnName("telefone")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TarefaCliente>(entity =>
            {
                entity.ToTable("tarefacliente", "tarefas");

                entity.HasIndex(e => e.EmpresaId);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmpresaId).HasColumnName("empresaId");

                entity.Property(e => e.Erro)
                    .HasColumnName("erro")
                    .HasMaxLength(1500);

                entity.Property(e => e.Funcionario)
                    .HasColumnName("funcionario")
                    .HasMaxLength(20);

                entity.Property(e => e.DataFinal)
                    .HasColumnName("dataFinal")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.DataInicial)
                    .HasColumnName("dataInicial")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.Motivo)
                    .HasColumnName("motivo")
                    .HasMaxLength(1500);

                entity.Property(e => e.Solucao)
                    .HasColumnName("solucao")
                    .HasMaxLength(1500);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(15);

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.TarefasCliente)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("tarefacliente$tarefacliente_ibfk_1");
            });

            modelBuilder.Entity<TarefaEmpresa>(entity =>
            {
                entity.ToTable("tarefaempresa", "tarefas");

                entity.HasIndex(e => e.Status);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Acao)
                    .HasColumnName("acao")
                    .HasMaxLength(1500);

                entity.Property(e => e.DataFinal)
                    .HasColumnName("dataFinal")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.DataInicial)
                    .HasColumnName("dataInicial")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.Observacao)
                    .HasColumnName("observacao")
                    .HasMaxLength(2000);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(15);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
