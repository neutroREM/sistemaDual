using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaDual.Migrations
{
    /// <inheritdoc />
    public partial class changeDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Domicilio_DomicilioID",
                table: "Empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_MentorEmpresarial_Empresa_EmpresaID",
                table: "MentorEmpresarial");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponsableInstitucional_Universidad_UniversidadID",
                table: "ResponsableInstitucional");

            migrationBuilder.AlterColumn<string>(
                name: "UniversidadID",
                table: "ResponsableInstitucional",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmpresaID",
                table: "MentorEmpresarial",
                type: "nvarchar(13)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DomicilioID",
                table: "Empresa",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Domicilio_DomicilioID",
                table: "Empresa",
                column: "DomicilioID",
                principalTable: "Domicilio",
                principalColumn: "DomicilioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MentorEmpresarial_Empresa_EmpresaID",
                table: "MentorEmpresarial",
                column: "EmpresaID",
                principalTable: "Empresa",
                principalColumn: "EmpresaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsableInstitucional_Universidad_UniversidadID",
                table: "ResponsableInstitucional",
                column: "UniversidadID",
                principalTable: "Universidad",
                principalColumn: "UniversidadID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Domicilio_DomicilioID",
                table: "Empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_MentorEmpresarial_Empresa_EmpresaID",
                table: "MentorEmpresarial");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponsableInstitucional_Universidad_UniversidadID",
                table: "ResponsableInstitucional");

            migrationBuilder.AlterColumn<string>(
                name: "UniversidadID",
                table: "ResponsableInstitucional",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AlterColumn<string>(
                name: "EmpresaID",
                table: "MentorEmpresarial",
                type: "nvarchar(13)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)");

            migrationBuilder.AlterColumn<int>(
                name: "DomicilioID",
                table: "Empresa",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Domicilio_DomicilioID",
                table: "Empresa",
                column: "DomicilioID",
                principalTable: "Domicilio",
                principalColumn: "DomicilioID");

            migrationBuilder.AddForeignKey(
                name: "FK_MentorEmpresarial_Empresa_EmpresaID",
                table: "MentorEmpresarial",
                column: "EmpresaID",
                principalTable: "Empresa",
                principalColumn: "EmpresaID");

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsableInstitucional_Universidad_UniversidadID",
                table: "ResponsableInstitucional",
                column: "UniversidadID",
                principalTable: "Universidad",
                principalColumn: "UniversidadID");
        }
    }
}
