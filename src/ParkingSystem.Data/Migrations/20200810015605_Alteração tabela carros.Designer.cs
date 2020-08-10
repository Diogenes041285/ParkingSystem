﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkingSystem.Data.Context;

namespace ParkingSystem.Data.Migrations
{
    [DbContext(typeof(SystemDbContext))]
    [Migration("20200810015605_Alteração tabela carros")]
    partial class Alteraçãotabelacarros
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ParkingSystem.Model.Carro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<DateTime?>("DataAlterado");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime?>("DataHoraEntrada");

                    b.Property<DateTime?>("DataHoraSaida");

                    b.Property<Guid>("ManobristaEntradaId");

                    b.Property<Guid?>("ManobristaSaidaId");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("varchar(7)");

                    b.HasKey("Id");

                    b.HasIndex("ManobristaEntradaId");

                    b.HasIndex("ManobristaSaidaId");

                    b.ToTable("Carros");
                });

            modelBuilder.Entity("ParkingSystem.Model.Manobra", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<Guid>("CarroId");

                    b.Property<DateTime?>("DataAlterado");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime?>("DataHoraEntrada");

                    b.Property<DateTime?>("DataHoraSaida");

                    b.Property<Guid>("ManobristaId");

                    b.HasKey("Id");

                    b.HasIndex("CarroId");

                    b.HasIndex("ManobristaId");

                    b.ToTable("Manobras");
                });

            modelBuilder.Entity("ParkingSystem.Model.Manobrista", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<DateTime?>("DataAlterado");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Manobristas");
                });

            modelBuilder.Entity("ParkingSystem.Model.Carro", b =>
                {
                    b.HasOne("ParkingSystem.Model.Manobrista", "ManobristaEntrada")
                        .WithMany("CarrosEntrada")
                        .HasForeignKey("ManobristaEntradaId");

                    b.HasOne("ParkingSystem.Model.Manobrista", "ManobristaSaida")
                        .WithMany("CarrosSaida")
                        .HasForeignKey("ManobristaSaidaId");
                });

            modelBuilder.Entity("ParkingSystem.Model.Manobra", b =>
                {
                    b.HasOne("ParkingSystem.Model.Carro", "Carro")
                        .WithMany()
                        .HasForeignKey("CarroId");

                    b.HasOne("ParkingSystem.Model.Manobrista", "Manobrista")
                        .WithMany()
                        .HasForeignKey("ManobristaId");
                });
#pragma warning restore 612, 618
        }
    }
}
