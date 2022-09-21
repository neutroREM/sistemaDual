using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaDual.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Domicilio",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colonia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Municipio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Otros = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domicilio", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Universidad",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CCT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DomicilioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universidad", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Universidad_Domicilio_DomicilioID",
                        column: x => x.DomicilioID,
                        principalTable: "Domicilio",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramaEducativo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniversidadID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramaEducativo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProgramaEducativo_Universidad_UniversidadID",
                        column: x => x.UniversidadID,
                        principalTable: "Universidad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramaEducativo_UniversidadID",
                table: "ProgramaEducativo",
                column: "UniversidadID");

            migrationBuilder.CreateIndex(
                name: "IX_Universidad_DomicilioID",
                table: "Universidad",
                column: "DomicilioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramaEducativo");

            migrationBuilder.DropTable(
                name: "Universidad");

            migrationBuilder.DropTable(
                name: "Domicilio");
        }
    }
}
