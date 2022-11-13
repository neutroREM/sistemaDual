using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaDual.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asignatura",
                columns: table => new
                {
                    AsignaturaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Periodo = table.Column<int>(type: "int", nullable: false),
                    Competencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Actividad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignatura", x => x.AsignaturaID);
                });

            migrationBuilder.CreateTable(
                name: "BecaDual",
                columns: table => new
                {
                    BecaDUalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fuente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoBeca = table.Column<int>(type: "int", nullable: false),
                    Periocidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BecaDual", x => x.BecaDUalID);
                });

            migrationBuilder.CreateTable(
                name: "Configuracion",
                columns: table => new
                {
                    ConfiguracionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Recurso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Propiedad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuracion", x => x.ConfiguracionID);
                });

            migrationBuilder.CreateTable(
                name: "Domicilio",
                columns: table => new
                {
                    DomicilioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colonia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Municipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Otros = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domicilio", x => x.DomicilioID);
                });

            migrationBuilder.CreateTable(
                name: "Estatus",
                columns: table => new
                {
                    EstatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estatus", x => x.EstatusID);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    RolID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.RolID);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    EmpresaID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RazonS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectorS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepresentanteL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorreoR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCambio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DomicilioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.EmpresaID);
                    table.ForeignKey(
                        name: "FK_Empresa_Domicilio_DomicilioID",
                        column: x => x.DomicilioID,
                        principalTable: "Domicilio",
                        principalColumn: "DomicilioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Universidad",
                columns: table => new
                {
                    UniversidadID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCambio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DomicilioID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universidad", x => x.UniversidadID);
                    table.ForeignKey(
                        name: "FK_Universidad_Domicilio_DomicilioID",
                        column: x => x.DomicilioID,
                        principalTable: "Domicilio",
                        principalColumn: "DomicilioID");
                });

            migrationBuilder.CreateTable(
                name: "MentorEmpresarial",
                columns: table => new
                {
                    MentorEmpresarialID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CURP = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ApellidoP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ApellidoM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    EmpresaID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorEmpresarial", x => x.MentorEmpresarialID);
                    table.ForeignKey(
                        name: "FK_MentorEmpresarial_Empresa_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresa",
                        principalColumn: "EmpresaID");
                });

            migrationBuilder.CreateTable(
                name: "ProgramaEducativo",
                columns: table => new
                {
                    ProgramaEducativoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreP = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Version = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    UniversidadID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramaEducativo", x => x.ProgramaEducativoID);
                    table.ForeignKey(
                        name: "FK_ProgramaEducativo_Universidad_UniversidadID",
                        column: x => x.UniversidadID,
                        principalTable: "Universidad",
                        principalColumn: "UniversidadID");
                });

            migrationBuilder.CreateTable(
                name: "ResponsableInstitucional",
                columns: table => new
                {
                    ResponsableInstitucionalID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApellidoP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApellidoM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", maxLength: 12, nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UniversidadID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsableInstitucional", x => x.ResponsableInstitucionalID);
                    table.ForeignKey(
                        name: "FK_ResponsableInstitucional_Universidad_UniversidadID",
                        column: x => x.UniversidadID,
                        principalTable: "Universidad",
                        principalColumn: "UniversidadID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlumnoDual",
                columns: table => new
                {
                    AlumnoDualID = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    Matricula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidoP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidoM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cuatrimestre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Promedio = table.Column<double>(type: "float", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: true),
                    ProgramaEducativoID = table.Column<int>(type: "int", nullable: true),
                    BecaDualID = table.Column<int>(type: "int", nullable: true),
                    DomicilioID = table.Column<int>(type: "int", nullable: true),
                    EstatusID = table.Column<int>(type: "int", nullable: true),
                    RolID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoDual", x => x.AlumnoDualID);
                    table.ForeignKey(
                        name: "FK_AlumnoDual_BecaDual_BecaDualID",
                        column: x => x.BecaDualID,
                        principalTable: "BecaDual",
                        principalColumn: "BecaDUalID");
                    table.ForeignKey(
                        name: "FK_AlumnoDual_Domicilio_DomicilioID",
                        column: x => x.DomicilioID,
                        principalTable: "Domicilio",
                        principalColumn: "DomicilioID");
                    table.ForeignKey(
                        name: "FK_AlumnoDual_Estatus_EstatusID",
                        column: x => x.EstatusID,
                        principalTable: "Estatus",
                        principalColumn: "EstatusID");
                    table.ForeignKey(
                        name: "FK_AlumnoDual_ProgramaEducativo_ProgramaEducativoID",
                        column: x => x.ProgramaEducativoID,
                        principalTable: "ProgramaEducativo",
                        principalColumn: "ProgramaEducativoID");
                    table.ForeignKey(
                        name: "FK_AlumnoDual_Rol_RolID",
                        column: x => x.RolID,
                        principalTable: "Rol",
                        principalColumn: "RolID");
                });

            migrationBuilder.CreateTable(
                name: "AsesorInstitucional",
                columns: table => new
                {
                    AsesorInstitucionalID = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApellidoP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApellidoM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProgramaEducativoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsesorInstitucional", x => x.AsesorInstitucionalID);
                    table.ForeignKey(
                        name: "FK_AsesorInstitucional_ProgramaEducativo_ProgramaEducativoID",
                        column: x => x.ProgramaEducativoID,
                        principalTable: "ProgramaEducativo",
                        principalColumn: "ProgramaEducativoID");
                });

            migrationBuilder.CreateTable(
                name: "MentorAcademico",
                columns: table => new
                {
                    MentorAcademicoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CURP = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ApellidoP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ApellidoM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramaEducativoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorAcademico", x => x.MentorAcademicoID);
                    table.ForeignKey(
                        name: "FK_MentorAcademico_ProgramaEducativo_ProgramaEducativoID",
                        column: x => x.ProgramaEducativoID,
                        principalTable: "ProgramaEducativo",
                        principalColumn: "ProgramaEducativoID");
                });

            migrationBuilder.CreateTable(
                name: "AlumnoAsignaturas",
                columns: table => new
                {
                    AlumnoDualID = table.Column<string>(type: "nvarchar(18)", nullable: false),
                    AsignaturaID = table.Column<int>(type: "int", nullable: false),
                    AsignaturaAmount = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoAsignaturas", x => new { x.AlumnoDualID, x.AsignaturaID });
                    table.ForeignKey(
                        name: "FK_AlumnoAsignaturas_AlumnoDual_AlumnoDualID",
                        column: x => x.AlumnoDualID,
                        principalTable: "AlumnoDual",
                        principalColumn: "AlumnoDualID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlumnoAsignaturas_Asignatura_AsignaturaID",
                        column: x => x.AsignaturaID,
                        principalTable: "Asignatura",
                        principalColumn: "AsignaturaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlumnosMentores",
                columns: table => new
                {
                    AlumnoDualID = table.Column<string>(type: "nvarchar(18)", nullable: false),
                    MentorEmpresarialID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnosMentores", x => new { x.AlumnoDualID, x.MentorEmpresarialID });
                    table.ForeignKey(
                        name: "FK_AlumnosMentores_AlumnoDual_AlumnoDualID",
                        column: x => x.AlumnoDualID,
                        principalTable: "AlumnoDual",
                        principalColumn: "AlumnoDualID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlumnosMentores_MentorEmpresarial_MentorEmpresarialID",
                        column: x => x.MentorEmpresarialID,
                        principalTable: "MentorEmpresarial",
                        principalColumn: "MentorEmpresarialID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CatalagoProyecto",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Etapa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AreaConocimiento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NumHoras = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaTermino = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCambioEstatus = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AlumnoDualID = table.Column<string>(type: "nvarchar(18)", nullable: true),
                    EmpresaID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalagoProyecto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CatalagoProyecto_AlumnoDual_AlumnoDualID",
                        column: x => x.AlumnoDualID,
                        principalTable: "AlumnoDual",
                        principalColumn: "AlumnoDualID");
                    table.ForeignKey(
                        name: "FK_CatalagoProyecto_Empresa_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresa",
                        principalColumn: "EmpresaID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoAsignaturas_AsignaturaID",
                table: "AlumnoAsignaturas",
                column: "AsignaturaID");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoDual_BecaDualID",
                table: "AlumnoDual",
                column: "BecaDualID");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoDual_DomicilioID",
                table: "AlumnoDual",
                column: "DomicilioID");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoDual_EstatusID",
                table: "AlumnoDual",
                column: "EstatusID");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoDual_ProgramaEducativoID",
                table: "AlumnoDual",
                column: "ProgramaEducativoID");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoDual_RolID",
                table: "AlumnoDual",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnosMentores_MentorEmpresarialID",
                table: "AlumnosMentores",
                column: "MentorEmpresarialID");

            migrationBuilder.CreateIndex(
                name: "IX_AsesorInstitucional_ProgramaEducativoID",
                table: "AsesorInstitucional",
                column: "ProgramaEducativoID");

            migrationBuilder.CreateIndex(
                name: "IX_CatalagoProyecto_AlumnoDualID",
                table: "CatalagoProyecto",
                column: "AlumnoDualID");

            migrationBuilder.CreateIndex(
                name: "IX_CatalagoProyecto_EmpresaID",
                table: "CatalagoProyecto",
                column: "EmpresaID");

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
                name: "IX_ProgramaEducativo_UniversidadID",
                table: "ProgramaEducativo",
                column: "UniversidadID");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsableInstitucional_UniversidadID",
                table: "ResponsableInstitucional",
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
                name: "AlumnoAsignaturas");

            migrationBuilder.DropTable(
                name: "AlumnosMentores");

            migrationBuilder.DropTable(
                name: "AsesorInstitucional");

            migrationBuilder.DropTable(
                name: "CatalagoProyecto");

            migrationBuilder.DropTable(
                name: "Configuracion");

            migrationBuilder.DropTable(
                name: "MentorAcademico");

            migrationBuilder.DropTable(
                name: "ResponsableInstitucional");

            migrationBuilder.DropTable(
                name: "Asignatura");

            migrationBuilder.DropTable(
                name: "MentorEmpresarial");

            migrationBuilder.DropTable(
                name: "AlumnoDual");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "BecaDual");

            migrationBuilder.DropTable(
                name: "Estatus");

            migrationBuilder.DropTable(
                name: "ProgramaEducativo");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Universidad");

            migrationBuilder.DropTable(
                name: "Domicilio");
        }
    }
}
