﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoFinal_ParteAdmin.Models;

#nullable disable

namespace ProyectoFinal_ParteAdmin.Migrations
{
    [DbContext(typeof(adminDbContext))]
    [Migration("20240605220250_UpdateModels")]
    partial class UpdateModels
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProyectoFinal_ParteAdmin.Models.Asignaciones", b =>
                {
                    b.Property<int>("id_asignaciones")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_asignaciones"));

                    b.Property<string>("comentario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("id_tecnico")
                        .HasColumnType("int");

                    b.Property<int>("id_ticket")
                        .HasColumnType("int");

                    b.HasKey("id_asignaciones");

                    b.HasIndex("id_tecnico");

                    b.HasIndex("id_ticket");

                    b.ToTable("Asignaciones");
                });

            modelBuilder.Entity("ProyectoFinal_ParteAdmin.Models.Asignaciones_act", b =>
                {
                    b.Property<int>("id_asignacionesact")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_asignacionesact"));

                    b.Property<string>("actividad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("detalle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id_asignaciones")
                        .HasColumnType("int");

                    b.HasKey("id_asignacionesact");

                    b.ToTable("Asignaciones_act");
                });

            modelBuilder.Entity("ProyectoFinal_ParteAdmin.Models.Clientes", b =>
                {
                    b.Property<int>("id_cliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_cliente"));

                    b.Property<int>("id_usuario")
                        .HasColumnType("int");

                    b.HasKey("id_cliente");

                    b.HasIndex("id_usuario");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ProyectoFinal_ParteAdmin.Models.Tecnicos", b =>
                {
                    b.Property<int>("id_tecnico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_tecnico"));

                    b.Property<string>("area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id_usuario")
                        .HasColumnType("int");

                    b.Property<int>("numero")
                        .HasColumnType("int");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_tecnico");

                    b.HasIndex("id_usuario");

                    b.ToTable("Tecnicos");
                });

            modelBuilder.Entity("ProyectoFinal_ParteAdmin.Models.Tikets", b =>
                {
                    b.Property<int>("id_ticket")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_ticket"));

                    b.Property<string>("archivos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("comentario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id_cliente")
                        .HasColumnType("int");

                    b.Property<string>("nombre_aplicativo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prioridad")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_ticket");

                    b.ToTable("Tikets");
                });

            modelBuilder.Entity("ProyectoFinal_ParteAdmin.Models.Usuarios", b =>
                {
                    b.Property<int>("id_usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_usuario"));

                    b.Property<string>("correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numero")
                        .HasColumnType("int");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_usuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ProyectoFinal_ParteAdmin.Models.Asignaciones", b =>
                {
                    b.HasOne("ProyectoFinal_ParteAdmin.Models.Tecnicos", "Tecnico")
                        .WithMany("Asignaciones")
                        .HasForeignKey("id_tecnico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoFinal_ParteAdmin.Models.Clientes", "Cliente")
                        .WithMany("Asignaciones")
                        .HasForeignKey("id_ticket")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Tecnico");
                });

            modelBuilder.Entity("ProyectoFinal_ParteAdmin.Models.Clientes", b =>
                {
                    b.HasOne("ProyectoFinal_ParteAdmin.Models.Usuarios", "Usuario")
                        .WithMany()
                        .HasForeignKey("id_usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ProyectoFinal_ParteAdmin.Models.Tecnicos", b =>
                {
                    b.HasOne("ProyectoFinal_ParteAdmin.Models.Usuarios", "Usuario")
                        .WithMany()
                        .HasForeignKey("id_usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ProyectoFinal_ParteAdmin.Models.Clientes", b =>
                {
                    b.Navigation("Asignaciones");
                });

            modelBuilder.Entity("ProyectoFinal_ParteAdmin.Models.Tecnicos", b =>
                {
                    b.Navigation("Asignaciones");
                });
#pragma warning restore 612, 618
        }
    }
}
