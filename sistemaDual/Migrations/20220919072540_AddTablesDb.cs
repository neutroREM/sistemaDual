using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaDual.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BecaDuals",
                columns: table => new
                {
                    CLAVE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    fuente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipo_beca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    periocidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    duracion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BecaDuals", x => x.CLAVE);
                });

            migrationBuilder.CreateTable(
                name: "Domicilios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    colonia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    localidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    municipio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    otros = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domicilios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Estatus",
                columns: table => new
                {
                    CLAVE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    activo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    egresado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    baja_definitiva_med = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    baja_temporal_med = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    baja_definitiva_ies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    baja_temporal_ies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cambio_empresa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estatus", x => x.CLAVE);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    RFC = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    id_domicilio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    razon_social = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre_comercial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    representante_legal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_domicilio3 = table.Column<int>(type: "int", nullable: false),
                    Domicilioid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.RFC);
                    table.ForeignKey(
                        name: "FK_Empresas_Domicilios_Domicilioid",
                        column: x => x.Domicilioid,
                        principalTable: "Domicilios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Universidades",
                columns: table => new
                {
                    CCT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_domicilio2 = table.Column<int>(type: "int", nullable: false),
                    Domicilioid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universidades", x => x.CCT);
                    table.ForeignKey(
                        name: "FK_Universidades_Domicilios_Domicilioid",
                        column: x => x.Domicilioid,
                        principalTable: "Domicilios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramaEducativos",
                columns: table => new
                {
                    CLAVE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CCT3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniversidadCCT = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramaEducativos", x => x.CLAVE);
                    table.ForeignKey(
                        name: "FK_ProgramaEducativos_Universidades_UniversidadCCT",
                        column: x => x.UniversidadCCT,
                        principalTable: "Universidades",
                        principalColumn: "CCT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResponsableInstitucionals",
                columns: table => new
                {
                    CURP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido_p = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido_m = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CCT5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniversidadCCT = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsableInstitucionals", x => x.CURP);
                    table.ForeignKey(
                        name: "FK_ResponsableInstitucionals_Universidades_UniversidadCCT",
                        column: x => x.UniversidadCCT,
                        principalTable: "Universidades",
                        principalColumn: "CCT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    CURP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    matricula = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido_p = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido_m = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_nac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cuatrimentre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    promedio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipo_alumno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_ingreso_dual = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_ingreso_reingreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_egreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_contratado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    id_domicilio1 = table.Column<int>(type: "int", nullable: false),
                    CLAVE_PROGRAMA2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CLAVE_BECA1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CLAVE_ESTATUS1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstatusCLAVE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BecaDualCLAVE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProgramaEducativoCLAVE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Domicilioid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.CURP);
                    table.ForeignKey(
                        name: "FK_Alumnos_BecaDuals_BecaDualCLAVE",
                        column: x => x.BecaDualCLAVE,
                        principalTable: "BecaDuals",
                        principalColumn: "CLAVE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alumnos_Domicilios_Domicilioid",
                        column: x => x.Domicilioid,
                        principalTable: "Domicilios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alumnos_Estatus_EstatusCLAVE",
                        column: x => x.EstatusCLAVE,
                        principalTable: "Estatus",
                        principalColumn: "CLAVE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alumnos_ProgramaEducativos_ProgramaEducativoCLAVE",
                        column: x => x.ProgramaEducativoCLAVE,
                        principalTable: "ProgramaEducativos",
                        principalColumn: "CLAVE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AsesorInstitucionals",
                columns: table => new
                {
                    CURP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido_p = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido_m = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CLAVE_PROGRAMA3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramaEducativoCLAVE = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsesorInstitucionals", x => x.CURP);
                    table.ForeignKey(
                        name: "FK_AsesorInstitucionals_ProgramaEducativos_ProgramaEducativoCLAVE",
                        column: x => x.ProgramaEducativoCLAVE,
                        principalTable: "ProgramaEducativos",
                        principalColumn: "CLAVE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asignaturas",
                columns: table => new
                {
                    CLAVE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    periodo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    competencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    actividad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CLAVE_PROGRAMA6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramaEducativoCLAVE = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaturas", x => x.CLAVE);
                    table.ForeignKey(
                        name: "FK_Asignaturas_ProgramaEducativos_ProgramaEducativoCLAVE",
                        column: x => x.ProgramaEducativoCLAVE,
                        principalTable: "ProgramaEducativos",
                        principalColumn: "CLAVE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MentorAcademicos",
                columns: table => new
                {
                    CURP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido_p = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido_m = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CLAVE_PROGRAMA4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramaEducativoCLAVE = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorAcademicos", x => x.CURP);
                    table.ForeignKey(
                        name: "FK_MentorAcademicos_ProgramaEducativos_ProgramaEducativoCLAVE",
                        column: x => x.ProgramaEducativoCLAVE,
                        principalTable: "ProgramaEducativos",
                        principalColumn: "CLAVE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MentorEmpresarials",
                columns: table => new
                {
                    CURP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido_p = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido_m = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RFC_EMPRESA1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CLAVE_PROGRAMA5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramaEducativoCLAVE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmpresaRFC = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorEmpresarials", x => x.CURP);
                    table.ForeignKey(
                        name: "FK_MentorEmpresarials_Empresas_EmpresaRFC",
                        column: x => x.EmpresaRFC,
                        principalTable: "Empresas",
                        principalColumn: "RFC");
                    table.ForeignKey(
                        name: "FK_MentorEmpresarials_ProgramaEducativos_ProgramaEducativoCLAVE",
                        column: x => x.ProgramaEducativoCLAVE,
                        principalTable: "ProgramaEducativos",
                        principalColumn: "CLAVE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alumno_Asignaturas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CURP_ALUMNO3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CLAVE_ASIGNATURA1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlumnoCURP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AsignaturaCLAVE = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno_Asignaturas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Alumno_Asignaturas_Alumnos_AlumnoCURP",
                        column: x => x.AlumnoCURP,
                        principalTable: "Alumnos",
                        principalColumn: "CURP",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alumno_Asignaturas_Asignaturas_AsignaturaCLAVE",
                        column: x => x.AsignaturaCLAVE,
                        principalTable: "Asignaturas",
                        principalColumn: "CLAVE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alumno_MentorEmpresarials",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CURP_ALUMNO1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CURP_MENTOR_E1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlumnoCURP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MentorEmpresarialCURP = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno_MentorEmpresarials", x => x.id);
                    table.ForeignKey(
                        name: "FK_Alumno_MentorEmpresarials_Alumnos_AlumnoCURP",
                        column: x => x.AlumnoCURP,
                        principalTable: "Alumnos",
                        principalColumn: "CURP",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alumno_MentorEmpresarials_MentorEmpresarials_MentorEmpresarialCURP",
                        column: x => x.MentorEmpresarialCURP,
                        principalTable: "MentorEmpresarials",
                        principalColumn: "CURP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalagoProyectos",
                columns: table => new
                {
                    CLAVE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    etapa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    area_conocimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    num_hora_dual = table.Column<int>(type: "int", nullable: false),
                    CLAVE_PROGRAMA1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CURP_ASESOR_I = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CURP_MENTOR_E2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CURP_RESPONSABLE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CURP_ALUMNO2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RFC_EMPRESA2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpresaRFC = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AlumnoCURP = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ResponsableInstitucionalCURP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MentorEmpresarialCURP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AsesorInstitucionalCURP = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProgramaEducativoCLAVE = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalagoProyectos", x => x.CLAVE);
                    table.ForeignKey(
                        name: "FK_CatalagoProyectos_Alumnos_AlumnoCURP",
                        column: x => x.AlumnoCURP,
                        principalTable: "Alumnos",
                        principalColumn: "CURP");
                    table.ForeignKey(
                        name: "FK_CatalagoProyectos_AsesorInstitucionals_AsesorInstitucionalCURP",
                        column: x => x.AsesorInstitucionalCURP,
                        principalTable: "AsesorInstitucionals",
                        principalColumn: "CURP");
                    table.ForeignKey(
                        name: "FK_CatalagoProyectos_Empresas_EmpresaRFC",
                        column: x => x.EmpresaRFC,
                        principalTable: "Empresas",
                        principalColumn: "RFC",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalagoProyectos_MentorEmpresarials_MentorEmpresarialCURP",
                        column: x => x.MentorEmpresarialCURP,
                        principalTable: "MentorEmpresarials",
                        principalColumn: "CURP",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalagoProyectos_ProgramaEducativos_ProgramaEducativoCLAVE",
                        column: x => x.ProgramaEducativoCLAVE,
                        principalTable: "ProgramaEducativos",
                        principalColumn: "CLAVE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalagoProyectos_ResponsableInstitucionals_ResponsableInstitucionalCURP",
                        column: x => x.ResponsableInstitucionalCURP,
                        principalTable: "ResponsableInstitucionals",
                        principalColumn: "CURP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_Asignaturas_AlumnoCURP",
                table: "Alumno_Asignaturas",
                column: "AlumnoCURP");

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_Asignaturas_AsignaturaCLAVE",
                table: "Alumno_Asignaturas",
                column: "AsignaturaCLAVE");

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_MentorEmpresarials_AlumnoCURP",
                table: "Alumno_MentorEmpresarials",
                column: "AlumnoCURP");

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_MentorEmpresarials_MentorEmpresarialCURP",
                table: "Alumno_MentorEmpresarials",
                column: "MentorEmpresarialCURP");

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_BecaDualCLAVE",
                table: "Alumnos",
                column: "BecaDualCLAVE");

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_Domicilioid",
                table: "Alumnos",
                column: "Domicilioid");

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_EstatusCLAVE",
                table: "Alumnos",
                column: "EstatusCLAVE");

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_ProgramaEducativoCLAVE",
                table: "Alumnos",
                column: "ProgramaEducativoCLAVE");

            migrationBuilder.CreateIndex(
                name: "IX_AsesorInstitucionals_ProgramaEducativoCLAVE",
                table: "AsesorInstitucionals",
                column: "ProgramaEducativoCLAVE");

            migrationBuilder.CreateIndex(
                name: "IX_Asignaturas_ProgramaEducativoCLAVE",
                table: "Asignaturas",
                column: "ProgramaEducativoCLAVE");

            migrationBuilder.CreateIndex(
                name: "IX_CatalagoProyectos_AlumnoCURP",
                table: "CatalagoProyectos",
                column: "AlumnoCURP");

            migrationBuilder.CreateIndex(
                name: "IX_CatalagoProyectos_AsesorInstitucionalCURP",
                table: "CatalagoProyectos",
                column: "AsesorInstitucionalCURP");

            migrationBuilder.CreateIndex(
                name: "IX_CatalagoProyectos_EmpresaRFC",
                table: "CatalagoProyectos",
                column: "EmpresaRFC");

            migrationBuilder.CreateIndex(
                name: "IX_CatalagoProyectos_MentorEmpresarialCURP",
                table: "CatalagoProyectos",
                column: "MentorEmpresarialCURP");

            migrationBuilder.CreateIndex(
                name: "IX_CatalagoProyectos_ProgramaEducativoCLAVE",
                table: "CatalagoProyectos",
                column: "ProgramaEducativoCLAVE");

            migrationBuilder.CreateIndex(
                name: "IX_CatalagoProyectos_ResponsableInstitucionalCURP",
                table: "CatalagoProyectos",
                column: "ResponsableInstitucionalCURP");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_Domicilioid",
                table: "Empresas",
                column: "Domicilioid");

            migrationBuilder.CreateIndex(
                name: "IX_MentorAcademicos_ProgramaEducativoCLAVE",
                table: "MentorAcademicos",
                column: "ProgramaEducativoCLAVE");

            migrationBuilder.CreateIndex(
                name: "IX_MentorEmpresarials_EmpresaRFC",
                table: "MentorEmpresarials",
                column: "EmpresaRFC");

            migrationBuilder.CreateIndex(
                name: "IX_MentorEmpresarials_ProgramaEducativoCLAVE",
                table: "MentorEmpresarials",
                column: "ProgramaEducativoCLAVE");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramaEducativos_UniversidadCCT",
                table: "ProgramaEducativos",
                column: "UniversidadCCT");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsableInstitucionals_UniversidadCCT",
                table: "ResponsableInstitucionals",
                column: "UniversidadCCT");

            migrationBuilder.CreateIndex(
                name: "IX_Universidades_Domicilioid",
                table: "Universidades",
                column: "Domicilioid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumno_Asignaturas");

            migrationBuilder.DropTable(
                name: "Alumno_MentorEmpresarials");

            migrationBuilder.DropTable(
                name: "CatalagoProyectos");

            migrationBuilder.DropTable(
                name: "MentorAcademicos");

            migrationBuilder.DropTable(
                name: "Asignaturas");

            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "AsesorInstitucionals");

            migrationBuilder.DropTable(
                name: "MentorEmpresarials");

            migrationBuilder.DropTable(
                name: "ResponsableInstitucionals");

            migrationBuilder.DropTable(
                name: "BecaDuals");

            migrationBuilder.DropTable(
                name: "Estatus");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "ProgramaEducativos");

            migrationBuilder.DropTable(
                name: "Universidades");

            migrationBuilder.DropTable(
                name: "Domicilios");
        }
    }
}
