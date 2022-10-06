using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaDual.Migrations
{
    /// <inheritdoc />
    public partial class changeDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResponsableInstitucional_Universidad_UniversidadID1",
                table: "ResponsableInstitucional");

            migrationBuilder.DropIndex(
                name: "IX_ResponsableInstitucional_UniversidadID1",
                table: "ResponsableInstitucional");

            migrationBuilder.DropColumn(
                name: "UniversidadID1",
                table: "ResponsableInstitucional");

            migrationBuilder.AlterColumn<string>(
                name: "UniversidadID",
                table: "ResponsableInstitucional",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResponsableInstitucional_UniversidadID",
                table: "ResponsableInstitucional",
                column: "UniversidadID");

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsableInstitucional_Universidad_UniversidadID",
                table: "ResponsableInstitucional",
                column: "UniversidadID",
                principalTable: "Universidad",
                principalColumn: "UniversidadID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResponsableInstitucional_Universidad_UniversidadID",
                table: "ResponsableInstitucional");

            migrationBuilder.DropIndex(
                name: "IX_ResponsableInstitucional_UniversidadID",
                table: "ResponsableInstitucional");

            migrationBuilder.AlterColumn<int>(
                name: "UniversidadID",
                table: "ResponsableInstitucional",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UniversidadID1",
                table: "ResponsableInstitucional",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResponsableInstitucional_UniversidadID1",
                table: "ResponsableInstitucional",
                column: "UniversidadID1");

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsableInstitucional_Universidad_UniversidadID1",
                table: "ResponsableInstitucional",
                column: "UniversidadID1",
                principalTable: "Universidad",
                principalColumn: "UniversidadID");
        }
    }
}
