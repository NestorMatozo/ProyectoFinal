using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal_ParteAdmin.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asignaciones_act",
                columns: table => new
                {
                    id_asignacionesact = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_asignaciones = table.Column<int>(type: "int", nullable: false),
                    actividad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detalle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaciones_act", x => x.id_asignacionesact);
                });

            migrationBuilder.CreateTable(
                name: "Tikets",
                columns: table => new
                {
                    id_ticket = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_aplicativo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    archivos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prioridad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_cliente = table.Column<int>(type: "int", nullable: false),
                    comentario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tikets", x => x.id_ticket);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id_cliente);
                    table.ForeignKey(
                        name: "FK_Clientes_Usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tecnicos",
                columns: table => new
                {
                    id_tecnico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    rol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnicos", x => x.id_tecnico);
                    table.ForeignKey(
                        name: "FK_Tecnicos_Usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asignaciones",
                columns: table => new
                {
                    id_asignaciones = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_ticket = table.Column<int>(type: "int", nullable: false),
                    id_tecnico = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comentario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaciones", x => x.id_asignaciones);
                    table.ForeignKey(
                        name: "FK_Asignaciones_Clientes_id_ticket",
                        column: x => x.id_ticket,
                        principalTable: "Clientes",
                        principalColumn: "id_cliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asignaciones_Tecnicos_id_tecnico",
                        column: x => x.id_tecnico,
                        principalTable: "Tecnicos",
                        principalColumn: "id_tecnico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asignaciones_id_tecnico",
                table: "Asignaciones",
                column: "id_tecnico");

            migrationBuilder.CreateIndex(
                name: "IX_Asignaciones_id_ticket",
                table: "Asignaciones",
                column: "id_ticket");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_id_usuario",
                table: "Clientes",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Tecnicos_id_usuario",
                table: "Tecnicos",
                column: "id_usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asignaciones");

            migrationBuilder.DropTable(
                name: "Asignaciones_act");

            migrationBuilder.DropTable(
                name: "Tikets");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Tecnicos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
