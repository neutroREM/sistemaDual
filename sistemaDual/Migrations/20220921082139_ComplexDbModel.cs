using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaDual.Migrations
{
    /// <inheritdoc />
    public partial class ComplexDbModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "AlumnoDual",
                newName: "NombreCompleto");

            migrationBuilder.RenameColumn(
                name: "ApellidoP",
                table: "AlumnoDual",
                newName: "ApellidoPaterno");

            migrationBuilder.RenameColumn(
                name: "ApellidoM",
                table: "AlumnoDual",
                newName: "ApellidoMaterno");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaReingreso",
                table: "AlumnoDual",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaIngreso",
                table: "AlumnoDual",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaEgreso",
                table: "AlumnoDual",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaContratado",
                table: "AlumnoDual",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "BecaDualID",
                table: "AlumnoDual",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Estatus",
                table: "AlumnoDual",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AsesorInstitucional",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Curp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProgramaEducativoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsesorInstitucional", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AsesorInstitucional_ProgramaEducativo_ProgramaEducativoID",
                        column: x => x.ProgramaEducativoID,
                        principalTable: "ProgramaEducativo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asignatura",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Periodo = table.Column<int>(type: "int", nullable: false),
                    Competencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Actividad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramaEducativoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignatura", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Asignatura_ProgramaEducativo_ProgramaEducativoID",
                        column: x => x.ProgramaEducativoID,
                        principalTable: "ProgramaEducativo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BecaDual",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fuente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoBeca = table.Column<int>(type: "int", nullable: false),
                    Periocidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BecaDual", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rfc = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NombreComercial = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Sector = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RepresentanteLegal = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CorreoRepresentante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DomicilioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Empresa_Domicilio_DomicilioID",
                        column: x => x.DomicilioID,
                        principalTable: "Domicilio",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MentorAcademico",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Curp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProgramaEducativoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorAcademico", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MentorAcademico_ProgramaEducativo_ProgramaEducativoID",
                        column: x => x.ProgramaEducativoID,
                        principalTable: "ProgramaEducativo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResponsableInstitucional",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Curp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CorreoMentor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", maxLength: 12, nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UniversidadID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsableInstitucional", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ResponsableInstitucional_Universidad_UniversidadID",
                        column: x => x.UniversidadID,
                        principalTable: "Universidad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MentorEmpresarial",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CorreoMentor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", maxLength: 12, nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EmpresaID = table.Column<int>(type: "int", nullable: false),
                    ProgramaEducativoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorEmpresarial", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MentorEmpresarial_Empresa_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MentorEmpresarial_ProgramaEducativo_ProgramaEducativoID",
                        column: x => x.ProgramaEducativoID,
                        principalTable: "ProgramaEducativo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlumnosMentores",
                columns: table => new
                {
                    AlumnoDualID = table.Column<int>(type: "int", nullable: false),
                    MentorEmpresarialID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnosMentores", x => new { x.AlumnoDualID, x.MentorEmpresarialID });
                    table.ForeignKey(
                        name: "FK_AlumnosMentores_AlumnoDual_AlumnoDualID",
                        column: x => x.AlumnoDualID,
                        principalTable: "AlumnoDual",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlumnosMentores_MentorEmpresarial_MentorEmpresarialID",
                        column: x => x.MentorEmpresarialID,
                        principalTable: "MentorEmpresarial",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoDual_BecaDualID",
                table: "AlumnoDual",
                column: "BecaDualID");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnosMentores_MentorEmpresarialID",
                table: "AlumnosMentores",
                column: "MentorEmpresarialID");

            migrationBuilder.CreateIndex(
                name: "IX_AsesorInstitucional_ProgramaEducativoID",
                table: "AsesorInstitucional",
                column: "ProgramaEducativoID");

            migrationBuilder.CreateIndex(
                name: "IX_Asignatura_ProgramaEducativoID",
                table: "Asignatura",
                column: "ProgramaEducativoID");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_DomicilioID",
                table: "Empresa",
                column: "DomicilioID");

            migrationBuilder.CreateIndex(
                name: "IX_MentorAcademico_ProgramaEducativoID",
                table: "MentorAcademico",
                column: "ProgramaEducativoID");

            migrationBuilder.CreateIndex(
                name: "IX_MentorEmpresarial_EmpresaID",
                table: "MentorEmpresarial",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_MentorEmpresarial_ProgramaEducativoID",
                table: "MentorEmpresarial",
                column: "ProgramaEducativoID");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsableInstitucional_UniversidadID",
                table: "ResponsableInstitucional",
                column: "UniversidadID");

            migrationBuilder.AddForeignKey(
                name: "FK_AlumnoDual_BecaDual_BecaDualID",
                table: "AlumnoDual",
                column: "BecaDualID",
                principalTable: "BecaDual",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlumnoDual_BecaDual_BecaDualID",
                table: "AlumnoDual");

            migrationBuilder.DropTable(
                name: "AlumnosMentores");

            migrationBuilder.DropTable(
                name: "AsesorInstitucional");

            migrationBuilder.DropTable(
                name: "Asignatura");

            migrationBuilder.DropTable(
                name: "BecaDual");

            migrationBuilder.DropTable(
                name: "MentorAcademico");

            migrationBuilder.DropTable(
                name: "ResponsableInstitucional");

            migrationBuilder.DropTable(
                name: "MentorEmpresarial");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropIndex(
                name: "IX_AlumnoDual_BecaDualID",
                table: "AlumnoDual");

            migrationBuilder.DropColumn(
                name: "BecaDualID",
                table: "AlumnoDual");

            migrationBuilder.DropColumn(
                name: "Estatus",
                table: "AlumnoDual");

            migrationBuilder.RenameColumn(
                name: "NombreCompleto",
                table: "AlumnoDual",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "ApellidoPaterno",
                table: "AlumnoDual",
                newName: "ApellidoP");

            migrationBuilder.RenameColumn(
                name: "ApellidoMaterno",
                table: "AlumnoDual",
                newName: "ApellidoM");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaReingreso",
                table: "AlumnoDual",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaIngreso",
                table: "AlumnoDual",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaEgreso",
                table: "AlumnoDual",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaContratado",
                table: "AlumnoDual",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
