﻿// <auto-generated />
using System;
using GerenciaProjeto.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GerenciaProjeto.Migrations
{
    [DbContext(typeof(GerenciaProjetoContext))]
    partial class GerenciaProjetoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmpresaSistema", b =>
                {
                    b.Property<int>("EmpresasId")
                        .HasColumnType("int");

                    b.Property<int>("SistemasId")
                        .HasColumnType("int");

                    b.HasKey("EmpresasId", "SistemasId");

                    b.HasIndex("SistemasId");

                    b.ToTable("EmpresaSistema");
                });

            modelBuilder.Entity("GerenciaProjeto.Models.AtualizacaoCliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<int>("SistemaId")
                        .HasColumnType("int");

                    b.Property<int?>("VersaoAnteriorId")
                        .HasColumnType("int");

                    b.Property<int>("VersaoAtualizadaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("SistemaId");

                    b.HasIndex("VersaoAnteriorId");

                    b.HasIndex("VersaoAtualizadaId");

                    b.ToTable("AtualizacaoCliente");
                });

            modelBuilder.Entity("GerenciaProjeto.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nome");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("telefone");

                    b.HasKey("Id");

                    b.ToTable("empresa", "tarefas");
                });

            modelBuilder.Entity("GerenciaProjeto.Models.Sistema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sistema");
                });

            modelBuilder.Entity("GerenciaProjeto.Models.TarefaCliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataFinal")
                        .HasColumnType("datetime2(0)")
                        .HasColumnName("dataFinal");

                    b.Property<DateTime?>("DataInicial")
                        .HasColumnType("datetime2(0)")
                        .HasColumnName("dataInicial");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int")
                        .HasColumnName("empresaId");

                    b.Property<string>("Erro")
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)")
                        .HasColumnName("erro");

                    b.Property<string>("Funcionario")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("funcionario");

                    b.Property<string>("Motivo")
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)")
                        .HasColumnName("motivo");

                    b.Property<string>("Solucao")
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)")
                        .HasColumnName("solucao");

                    b.Property<int>("Status")
                        .HasMaxLength(15)
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("tarefacliente", "tarefas");
                });

            modelBuilder.Entity("GerenciaProjeto.Models.TarefaEmpresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Acao")
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)")
                        .HasColumnName("acao");

                    b.Property<DateTime?>("DataFinal")
                        .HasColumnType("datetime2(0)")
                        .HasColumnName("dataFinal");

                    b.Property<DateTime?>("DataInicial")
                        .HasColumnType("datetime2(0)")
                        .HasColumnName("dataInicial");

                    b.Property<string>("Observacao")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasColumnName("observacao");

                    b.Property<int>("Status")
                        .HasMaxLength(15)
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("Status");

                    b.ToTable("tarefaempresa", "tarefas");
                });

            modelBuilder.Entity("GerenciaProjeto.Models.Versao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SistemaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SistemaId");

                    b.ToTable("Versao");
                });

            modelBuilder.Entity("EmpresaSistema", b =>
                {
                    b.HasOne("GerenciaProjeto.Models.Empresa", null)
                        .WithMany()
                        .HasForeignKey("EmpresasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GerenciaProjeto.Models.Sistema", null)
                        .WithMany()
                        .HasForeignKey("SistemasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GerenciaProjeto.Models.AtualizacaoCliente", b =>
                {
                    b.HasOne("GerenciaProjeto.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GerenciaProjeto.Models.Sistema", "Sistema")
                        .WithMany()
                        .HasForeignKey("SistemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GerenciaProjeto.Models.Versao", "VersaoAnterior")
                        .WithMany()
                        .HasForeignKey("VersaoAnteriorId");

                    b.HasOne("GerenciaProjeto.Models.Versao", "VersaoAtualizada")
                        .WithMany()
                        .HasForeignKey("VersaoAtualizadaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Sistema");

                    b.Navigation("VersaoAnterior");

                    b.Navigation("VersaoAtualizada");
                });

            modelBuilder.Entity("GerenciaProjeto.Models.TarefaCliente", b =>
                {
                    b.HasOne("GerenciaProjeto.Models.Empresa", "Empresa")
                        .WithMany("TarefasCliente")
                        .HasForeignKey("EmpresaId")
                        .HasConstraintName("tarefacliente$tarefacliente_ibfk_1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("GerenciaProjeto.Models.Versao", b =>
                {
                    b.HasOne("GerenciaProjeto.Models.Sistema", "Sistema")
                        .WithMany("Versoes")
                        .HasForeignKey("SistemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sistema");
                });

            modelBuilder.Entity("GerenciaProjeto.Models.Empresa", b =>
                {
                    b.Navigation("TarefasCliente");
                });

            modelBuilder.Entity("GerenciaProjeto.Models.Sistema", b =>
                {
                    b.Navigation("Versoes");
                });
#pragma warning restore 612, 618
        }
    }
}
