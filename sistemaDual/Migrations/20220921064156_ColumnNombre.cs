using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaDual.Migrations
{
    /// <inheritdoc />
    public partial class ColumnNombre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "AlumnoDual",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "AlumnoDual");
        }
    }
}
