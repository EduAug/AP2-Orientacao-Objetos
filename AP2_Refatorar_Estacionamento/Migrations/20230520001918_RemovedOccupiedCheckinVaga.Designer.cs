﻿// <auto-generated />
using System;
using AP2_Refatorar_Estacionamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AP2_Refatorar_Estacionamento.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230520001918_RemovedOccupiedCheckinVaga")]
    partial class RemovedOccupiedCheckinVaga
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("AP2_Refatorar_Estacionamento.Vaga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("VeiculoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VeiculoId");

                    b.ToTable("Vagas");
                });

            modelBuilder.Entity("AP2_Refatorar_Estacionamento.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Combustivel")
                        .HasColumnType("REAL");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Placa")
                        .IsUnique();

                    b.ToTable("Veiculo");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Veiculo");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("AP2_Refatorar_Estacionamento.Carro", b =>
                {
                    b.HasBaseType("AP2_Refatorar_Estacionamento.Veiculo");

                    b.HasDiscriminator().HasValue("Carro");
                });

            modelBuilder.Entity("AP2_Refatorar_Estacionamento.Moto", b =>
                {
                    b.HasBaseType("AP2_Refatorar_Estacionamento.Veiculo");

                    b.HasDiscriminator().HasValue("Moto");
                });

            modelBuilder.Entity("AP2_Refatorar_Estacionamento.Vaga", b =>
                {
                    b.HasOne("AP2_Refatorar_Estacionamento.Veiculo", "Estacionado")
                        .WithMany()
                        .HasForeignKey("VeiculoId");

                    b.Navigation("Estacionado");
                });
#pragma warning restore 612, 618
        }
    }
}
