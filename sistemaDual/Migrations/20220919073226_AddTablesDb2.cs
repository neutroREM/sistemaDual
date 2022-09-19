using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaDual.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumnos_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "Alumnos");

            migrationBuilder.DropIndex(
                name: "IX_Alumnos_ProgramaEducativoCLAVE",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "CLAVE_PROGRAMA2",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "ProgramaEducativoCLAVE",
                table: "Alumnos");

            migrationBuilder.CreateTable(
                name: "Alumno_ProgramaEducativos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CURP_ALUMNO7 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CLAVE_PROGRAMA6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlumnoCURP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProgramaEducativoCLAVE = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno_ProgramaEducativos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Alumno_ProgramaEducativos_Alumnos_AlumnoCURP",
                        column: x => x.AlumnoCURP,
                        principalTable: "Alumnos",
                        principalColumn: "CURP",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alumno_ProgramaEducativos_ProgramaEducativos_ProgramaEducativoCLAVE",
                        column: x => x.ProgramaEducativoCLAVE,
                        principalTable: "ProgramaEducativos",
                        principalColumn: "CLAVE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_ProgramaEducativos_AlumnoCURP",
                table: "Alumno_ProgramaEducativos",
                column: "AlumnoCURP");

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "Alumno_ProgramaEducativos",
                column: "ProgramaEducativoCLAVE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumno_ProgramaEducativos");

            migrationBuilder.AddColumn<string>(
                name: "CLAVE_PROGRAMA2",
                table: "Alumnos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProgramaEducativoCLAVE",
                table: "Alumnos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_ProgramaEducativoCLAVE",
                table: "Alumnos",
                column: "ProgramaEducativoCLAVE");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumnos_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "Alumnos",
                column: "ProgramaEducativoCLAVE",
                principalTable: "ProgramaEducativos",
                principalColumn: "CLAVE",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
