﻿// <auto-generated />
using System;
using Locacoes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Locacoes.Migrations
{
    [DbContext(typeof(LocacoesContext))]
    [Migration("20241021164846_AddVeiculoToLocacao")]
    partial class AddVeiculoToLocacao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Locacoes.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Locacoes.Models.Fabricante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fabricantes");
                });

            modelBuilder.Entity("Locacoes.Models.Locacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DataLocacao")
                        .HasColumnType("date");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("VeiculoId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Locacoes");
                });

            modelBuilder.Entity("Locacoes.Models.Modelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<int>("FabricanteId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FabricanteId");

                    b.ToTable("Modelos");
                });

            modelBuilder.Entity("Locacoes.Models.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnoFabricacao")
                        .HasColumnType("int");

                    b.Property<string>("Combustivel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Kilometragem")
                        .HasColumnType("bigint");

                    b.Property<int>("ModeloId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModeloId");

                    b.ToTable("Veiculo");
                });

            modelBuilder.Entity("Locacoes.Models.VeiculoLocado", b =>
                {
                    b.Property<int>("LocacaoId")
                        .HasColumnType("int");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DataDevolucao")
                        .HasColumnType("date");

                    b.Property<long>("KilometragemFinal")
                        .HasColumnType("bigint");

                    b.Property<long>("KilometragemInicial")
                        .HasColumnType("bigint");

                    b.Property<decimal>("ValorDiaria")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("LocacaoId", "VeiculoId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("VeiculosLocados");
                });

            modelBuilder.Entity("Locacoes.Models.Locacao", b =>
                {
                    b.HasOne("Locacoes.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Locacoes.Models.Modelo", b =>
                {
                    b.HasOne("Locacoes.Models.Fabricante", "Fabricante")
                        .WithMany("Modelos")
                        .HasForeignKey("FabricanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fabricante");
                });

            modelBuilder.Entity("Locacoes.Models.Veiculo", b =>
                {
                    b.HasOne("Locacoes.Models.Modelo", "Modelo")
                        .WithMany()
                        .HasForeignKey("ModeloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("Locacoes.Models.VeiculoLocado", b =>
                {
                    b.HasOne("Locacoes.Models.Locacao", "Locacao")
                        .WithMany("VeiculosLocados")
                        .HasForeignKey("LocacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Locacoes.Models.Veiculo", "Veiculo")
                        .WithMany("VeiculosLocados")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Locacao");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("Locacoes.Models.Fabricante", b =>
                {
                    b.Navigation("Modelos");
                });

            modelBuilder.Entity("Locacoes.Models.Locacao", b =>
                {
                    b.Navigation("VeiculosLocados");
                });

            modelBuilder.Entity("Locacoes.Models.Veiculo", b =>
                {
                    b.Navigation("VeiculosLocados");
                });
#pragma warning restore 612, 618
        }
    }
}