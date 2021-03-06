// <auto-generated />
using System;
using GerenciaProjeto.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GerenciaProjeto.Migrations
{
    [DbContext(typeof(GerenciaProjetoContext))]
    [Migration("20210602190805_ColunaCnpjAdicionadaEmEmpresas")]
    partial class ColunaCnpjAdicionadaEmEmpresas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ControleTarefas.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnName("telefone")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("empresa","tarefas");
                });

            modelBuilder.Entity("ControleTarefas.Models.TarefaCliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataFinal")
                        .HasColumnName("dataFinal")
                        .HasColumnType("datetime2(0)");

                    b.Property<DateTime?>("DataInicial")
                        .HasColumnName("dataInicial")
                        .HasColumnType("datetime2(0)");

                    b.Property<int>("EmpresaId")
                        .HasColumnName("empresaId")
                        .HasColumnType("int");

                    b.Property<string>("Erro")
                        .HasColumnName("erro")
                        .HasColumnType("nvarchar(1500)")
                        .HasMaxLength(1500);

                    b.Property<string>("Funcionario")
                        .HasColumnName("funcionario")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Motivo")
                        .HasColumnName("motivo")
                        .HasColumnType("nvarchar(1500)")
                        .HasMaxLength(1500);

                    b.Property<string>("Solucao")
                        .HasColumnName("solucao")
                        .HasColumnType("nvarchar(1500)")
                        .HasMaxLength(1500);

                    b.Property<int>("Status")
                        .HasColumnName("status")
                        .HasColumnType("int")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId")
                        .HasName("tarefacliente_ibfk_1");

                    b.ToTable("tarefacliente","tarefas");
                });

            modelBuilder.Entity("ControleTarefas.Models.TarefaEmpresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Acao")
                        .HasColumnName("acao")
                        .HasColumnType("nvarchar(1500)")
                        .HasMaxLength(1500);

                    b.Property<DateTime?>("DataFinal")
                        .HasColumnName("dataFinal")
                        .HasColumnType("datetime2(0)");

                    b.Property<DateTime?>("DataInicial")
                        .HasColumnName("dataInicial")
                        .HasColumnType("datetime2(0)");

                    b.Property<string>("Observacao")
                        .HasColumnName("observacao")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<int>("Status")
                        .HasColumnName("status")
                        .HasColumnType("int")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("Status")
                        .HasName("id_status");

                    b.ToTable("tarefaempresa","tarefas");
                });

            modelBuilder.Entity("ControleTarefas.Models.TarefaCliente", b =>
                {
                    b.HasOne("ControleTarefas.Models.Empresa", "Empresa")
                        .WithMany("TarefasCliente")
                        .HasForeignKey("EmpresaId")
                        .HasConstraintName("tarefacliente$tarefacliente_ibfk_1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
