using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaDual.Migrations
{
    /// <inheritdoc />
    public partial class CatalagoProyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estatus",
                table: "AlumnoDual");

            migrationBuilder.CreateTable(
                name: "CatalagoProyecto",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Etapa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaConocimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumHoras = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaTermino = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: true),
                    FechaCambioEstatus = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AlumnoDualID = table.Column<int>(type: "int", nullable: false),
                    EmpresaID = table.Column<int>(type: "int", nullable: false),
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalagoProyecto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CatalagoProyecto_AlumnoDual_AlumnoDualID",
                        column: x => x.AlumnoDualID,
                        principalTable: "AlumnoDual",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatalagoProyecto_Empresa_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalagoProyecto_AlumnoDualID",
                table: "CatalagoProyecto",
                column: "AlumnoDualID");

            migrationBuilder.CreateIndex(
                name: "IX_CatalagoProyecto_EmpresaID",
                table: "CatalagoProyecto",
                column: "EmpresaID");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalagoProyecto");

            migrationBuilder.AddColumn<int>(
                name: "Estatus",
                table: "AlumnoDual",
                type: "int",
                nullable: true);
        }
    }
}
