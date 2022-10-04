﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaDual.Migrations
{
    /// <inheritdoc />
    public partial class dualDB : Migration
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
                name: "Empresa",
                columns: table => new
                {
                    EmpresaID = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    RazonS = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NombreC = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SectorS = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RepresentanteL = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CorreoR = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.EmpresaID);
                });

            migrationBuilder.CreateTable(
                name: "Universidad",
                columns: table => new
                {
                    UniversidadID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NombreU = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universidad", x => x.UniversidadID);
                });

            migrationBuilder.CreateTable(
                name: "ProgramaEducativo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Version = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UniversidadID = table.Column<int>(type: "int", nullable: false),
                    UniversidadID1 = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramaEducativo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProgramaEducativo_Universidad_UniversidadID1",
                        column: x => x.UniversidadID1,
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
                    UniversidadID = table.Column<int>(type: "int", nullable: false),
                    UniversidadID1 = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsableInstitucional", x => x.ResponsableInstitucionalID);
                    table.ForeignKey(
                        name: "FK_ResponsableInstitucional_Universidad_UniversidadID1",
                        column: x => x.UniversidadID1,
                        principalTable: "Universidad",
                        principalColumn: "UniversidadID");
                });

            migrationBuilder.CreateTable(
                name: "AlumnoDual",
                columns: table => new
                {
                    AlumnoDualID = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    Matricula = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApellidoP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApellidoM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Telefono = table.Column<int>(type: "int", maxLength: 12, nullable: false),
                    Cuatrimestre = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Promedio = table.Column<double>(type: "float", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaReingreso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEgreso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaContratado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProgramaEducativoID = table.Column<int>(type: "int", nullable: true),
                    BecaDualID = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_AlumnoDual_ProgramaEducativo_ProgramaEducativoID",
                        column: x => x.ProgramaEducativoID,
                        principalTable: "ProgramaEducativo",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AsesorInstitucional",
                columns: table => new
                {
                    AsesorInstitucionalID = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApellidoP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApellidoM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProgramaEducativoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsesorInstitucional", x => x.AsesorInstitucionalID);
                    table.ForeignKey(
                        name: "FK_AsesorInstitucional_ProgramaEducativo_ProgramaEducativoID",
                        column: x => x.ProgramaEducativoID,
                        principalTable: "ProgramaEducativo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MentorAcademico",
                columns: table => new
                {
                    MentorAcademicoID = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApellidoP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApellidoM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProgramaEducativoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorAcademico", x => x.MentorAcademicoID);
                    table.ForeignKey(
                        name: "FK_MentorAcademico_ProgramaEducativo_ProgramaEducativoID",
                        column: x => x.ProgramaEducativoID,
                        principalTable: "ProgramaEducativo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MentorEmpresarial",
                columns: table => new
                {
                    MentorEmpresarialID = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    ApellidoP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApellidoM = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", maxLength: 12, nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EmpresaID = table.Column<int>(type: "int", nullable: false),
                    EmpresaID1 = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    ProgramaEducativoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorEmpresarial", x => x.MentorEmpresarialID);
                    table.ForeignKey(
                        name: "FK_MentorEmpresarial_Empresa_EmpresaID1",
                        column: x => x.EmpresaID1,
                        principalTable: "Empresa",
                        principalColumn: "EmpresaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MentorEmpresarial_ProgramaEducativo_ProgramaEducativoID",
                        column: x => x.ProgramaEducativoID,
                        principalTable: "ProgramaEducativo",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AlumnoAsignaturas",
                columns: table => new
                {
                    AlumnoDualID = table.Column<string>(type: "nvarchar(18)", nullable: false),
                    AsignaturaID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AsignaturaAmount = table.Column<double>(type: "float", nullable: false),
                    AsignaturaID1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoAsignaturas", x => new { x.AlumnoDualID, x.AsignaturaID });
                    table.ForeignKey(
                        name: "FK_AlumnoAsignaturas_AlumnoDual_AlumnoDualID",
                        column: x => x.AlumnoDualID,
                        principalTable: "AlumnoDual",
                        principalColumn: "AlumnoDualID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlumnoAsignaturas_Asignatura_AsignaturaID1",
                        column: x => x.AsignaturaID1,
                        principalTable: "Asignatura",
                        principalColumn: "AsignaturaID",
                        onDelete: ReferentialAction.Cascade);
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
                    Estatus = table.Column<int>(type: "int", nullable: true),
                    FechaCambioEstatus = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AlumnoDualID = table.Column<string>(type: "nvarchar(18)", nullable: false),
                    EmpresaID = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    ProgramaEducativoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalagoProyecto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CatalagoProyecto_AlumnoDual_AlumnoDualID",
                        column: x => x.AlumnoDualID,
                        principalTable: "AlumnoDual",
                        principalColumn: "AlumnoDualID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalagoProyecto_Empresa_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresa",
                        principalColumn: "EmpresaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalagoProyecto_ProgramaEducativo_ProgramaEducativoID",
                        column: x => x.ProgramaEducativoID,
                        principalTable: "ProgramaEducativo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Domicilio",
                columns: table => new
                {
                    DomicilioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Colonia = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Municipio = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Otros = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    AlumnoDualID = table.Column<string>(type: "nvarchar(18)", nullable: true),
                    UniversidadID = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    EmpresaID = table.Column<string>(type: "nvarchar(13)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domicilio", x => x.DomicilioID);
                    table.ForeignKey(
                        name: "FK_Domicilio_AlumnoDual_AlumnoDualID",
                        column: x => x.AlumnoDualID,
                        principalTable: "AlumnoDual",
                        principalColumn: "AlumnoDualID");
                    table.ForeignKey(
                        name: "FK_Domicilio_Empresa_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresa",
                        principalColumn: "EmpresaID");
                    table.ForeignKey(
                        name: "FK_Domicilio_Universidad_UniversidadID",
                        column: x => x.UniversidadID,
                        principalTable: "Universidad",
                        principalColumn: "UniversidadID");
                });

            migrationBuilder.CreateTable(
                name: "AlumnosMentores",
                columns: table => new
                {
                    AlumnoDualID = table.Column<string>(type: "nvarchar(18)", nullable: false),
                    MentorEmpresarialID = table.Column<string>(type: "nvarchar(18)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnosMentores", x => new { x.AlumnoDualID, x.MentorEmpresarialID });
                    table.ForeignKey(
                        name: "FK_AlumnosMentores_AlumnoDual_AlumnoDualID",
                        column: x => x.AlumnoDualID,
                        principalTable: "AlumnoDual",
                        principalColumn: "AlumnoDualID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlumnosMentores_MentorEmpresarial_MentorEmpresarialID",
                        column: x => x.MentorEmpresarialID,
                        principalTable: "MentorEmpresarial",
                        principalColumn: "MentorEmpresarialID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoAsignaturas_AsignaturaID1",
                table: "AlumnoAsignaturas",
                column: "AsignaturaID1");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoDual_BecaDualID",
                table: "AlumnoDual",
                column: "BecaDualID");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoDual_ProgramaEducativoID",
                table: "AlumnoDual",
                column: "ProgramaEducativoID");

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
                name: "IX_CatalagoProyecto_ProgramaEducativoID",
                table: "CatalagoProyecto",
                column: "ProgramaEducativoID");

            migrationBuilder.CreateIndex(
                name: "IX_Domicilio_AlumnoDualID",
                table: "Domicilio",
                column: "AlumnoDualID");

            migrationBuilder.CreateIndex(
                name: "IX_Domicilio_EmpresaID",
                table: "Domicilio",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_Domicilio_UniversidadID",
                table: "Domicilio",
                column: "UniversidadID");

            migrationBuilder.CreateIndex(
                name: "IX_MentorAcademico_ProgramaEducativoID",
                table: "MentorAcademico",
                column: "ProgramaEducativoID");

            migrationBuilder.CreateIndex(
                name: "IX_MentorEmpresarial_EmpresaID1",
                table: "MentorEmpresarial",
                column: "EmpresaID1");

            migrationBuilder.CreateIndex(
                name: "IX_MentorEmpresarial_ProgramaEducativoID",
                table: "MentorEmpresarial",
                column: "ProgramaEducativoID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramaEducativo_UniversidadID1",
                table: "ProgramaEducativo",
                column: "UniversidadID1");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsableInstitucional_UniversidadID1",
                table: "ResponsableInstitucional",
                column: "UniversidadID1");
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
                name: "Domicilio");

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
                name: "ProgramaEducativo");

            migrationBuilder.DropTable(
                name: "Universidad");
        }
    }
}
