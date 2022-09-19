using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaDual.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesDb5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Asignaturas_Alumnos_AlumnoCURP",
                table: "Alumno_Asignaturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Asignaturas_Asignaturas_AsignaturaCLAVE",
                table: "Alumno_Asignaturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_MentorEmpresarials_Alumnos_AlumnoCURP",
                table: "Alumno_MentorEmpresarials");

            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_MentorEmpresarials_MentorEmpresarials_MentorEmpresarialCURP",
                table: "Alumno_MentorEmpresarials");

            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_ProgramaEducativos_Alumnos_AlumnoCURP",
                table: "Alumno_ProgramaEducativos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_ProgramaEducativos_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "Alumno_ProgramaEducativos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alumnos_BecaDuals_BecaDualCLAVE",
                table: "Alumnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alumnos_Domicilios_Domicilioid",
                table: "Alumnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alumnos_Estatus_EstatusCLAVE",
                table: "Alumnos");

            migrationBuilder.DropForeignKey(
                name: "FK_AsesorInstitucionals_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "AsesorInstitucionals");

            migrationBuilder.DropForeignKey(
                name: "FK_Asignaturas_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "Asignaturas");

            migrationBuilder.DropForeignKey(
                name: "FK_CatalagoProyectos_Empresas_EmpresaRFC",
                table: "CatalagoProyectos");

            migrationBuilder.DropForeignKey(
                name: "FK_CatalagoProyectos_MentorEmpresarials_MentorEmpresarialCURP",
                table: "CatalagoProyectos");

            migrationBuilder.DropForeignKey(
                name: "FK_CatalagoProyectos_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "CatalagoProyectos");

            migrationBuilder.DropForeignKey(
                name: "FK_CatalagoProyectos_ResponsableInstitucionals_ResponsableInstitucionalCURP",
                table: "CatalagoProyectos");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Domicilios_Domicilioid",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_MentorAcademicos_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "MentorAcademicos");

            migrationBuilder.DropForeignKey(
                name: "FK_MentorEmpresarials_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "MentorEmpresarials");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramaEducativos_Universidades_UniversidadCCT",
                table: "ProgramaEducativos");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponsableInstitucionals_Universidades_UniversidadCCT",
                table: "ResponsableInstitucionals");

            migrationBuilder.DropForeignKey(
                name: "FK_Universidades_Domicilios_Domicilioid",
                table: "Universidades");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_Asignaturas_Alumnos_AlumnoCURP",
                table: "Alumno_Asignaturas",
                column: "AlumnoCURP",
                principalTable: "Alumnos",
                principalColumn: "CURP",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_Asignaturas_Asignaturas_AsignaturaCLAVE",
                table: "Alumno_Asignaturas",
                column: "AsignaturaCLAVE",
                principalTable: "Asignaturas",
                principalColumn: "CLAVE",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_MentorEmpresarials_Alumnos_AlumnoCURP",
                table: "Alumno_MentorEmpresarials",
                column: "AlumnoCURP",
                principalTable: "Alumnos",
                principalColumn: "CURP",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_MentorEmpresarials_MentorEmpresarials_MentorEmpresarialCURP",
                table: "Alumno_MentorEmpresarials",
                column: "MentorEmpresarialCURP",
                principalTable: "MentorEmpresarials",
                principalColumn: "CURP",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_ProgramaEducativos_Alumnos_AlumnoCURP",
                table: "Alumno_ProgramaEducativos",
                column: "AlumnoCURP",
                principalTable: "Alumnos",
                principalColumn: "CURP",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_ProgramaEducativos_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "Alumno_ProgramaEducativos",
                column: "ProgramaEducativoCLAVE",
                principalTable: "ProgramaEducativos",
                principalColumn: "CLAVE",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alumnos_BecaDuals_BecaDualCLAVE",
                table: "Alumnos",
                column: "BecaDualCLAVE",
                principalTable: "BecaDuals",
                principalColumn: "CLAVE",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alumnos_Domicilios_Domicilioid",
                table: "Alumnos",
                column: "Domicilioid",
                principalTable: "Domicilios",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alumnos_Estatus_EstatusCLAVE",
                table: "Alumnos",
                column: "EstatusCLAVE",
                principalTable: "Estatus",
                principalColumn: "CLAVE",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AsesorInstitucionals_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "AsesorInstitucionals",
                column: "ProgramaEducativoCLAVE",
                principalTable: "ProgramaEducativos",
                principalColumn: "CLAVE",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Asignaturas_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "Asignaturas",
                column: "ProgramaEducativoCLAVE",
                principalTable: "ProgramaEducativos",
                principalColumn: "CLAVE",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CatalagoProyectos_Empresas_EmpresaRFC",
                table: "CatalagoProyectos",
                column: "EmpresaRFC",
                principalTable: "Empresas",
                principalColumn: "RFC",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CatalagoProyectos_MentorEmpresarials_MentorEmpresarialCURP",
                table: "CatalagoProyectos",
                column: "MentorEmpresarialCURP",
                principalTable: "MentorEmpresarials",
                principalColumn: "CURP",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CatalagoProyectos_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "CatalagoProyectos",
                column: "ProgramaEducativoCLAVE",
                principalTable: "ProgramaEducativos",
                principalColumn: "CLAVE",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CatalagoProyectos_ResponsableInstitucionals_ResponsableInstitucionalCURP",
                table: "CatalagoProyectos",
                column: "ResponsableInstitucionalCURP",
                principalTable: "ResponsableInstitucionals",
                principalColumn: "CURP",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Domicilios_Domicilioid",
                table: "Empresas",
                column: "Domicilioid",
                principalTable: "Domicilios",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MentorAcademicos_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "MentorAcademicos",
                column: "ProgramaEducativoCLAVE",
                principalTable: "ProgramaEducativos",
                principalColumn: "CLAVE",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MentorEmpresarials_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "MentorEmpresarials",
                column: "ProgramaEducativoCLAVE",
                principalTable: "ProgramaEducativos",
                principalColumn: "CLAVE",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramaEducativos_Universidades_UniversidadCCT",
                table: "ProgramaEducativos",
                column: "UniversidadCCT",
                principalTable: "Universidades",
                principalColumn: "CCT",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsableInstitucionals_Universidades_UniversidadCCT",
                table: "ResponsableInstitucionals",
                column: "UniversidadCCT",
                principalTable: "Universidades",
                principalColumn: "CCT",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Universidades_Domicilios_Domicilioid",
                table: "Universidades",
                column: "Domicilioid",
                principalTable: "Domicilios",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Asignaturas_Alumnos_AlumnoCURP",
                table: "Alumno_Asignaturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_Asignaturas_Asignaturas_AsignaturaCLAVE",
                table: "Alumno_Asignaturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_MentorEmpresarials_Alumnos_AlumnoCURP",
                table: "Alumno_MentorEmpresarials");

            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_MentorEmpresarials_MentorEmpresarials_MentorEmpresarialCURP",
                table: "Alumno_MentorEmpresarials");

            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_ProgramaEducativos_Alumnos_AlumnoCURP",
                table: "Alumno_ProgramaEducativos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alumno_ProgramaEducativos_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "Alumno_ProgramaEducativos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alumnos_BecaDuals_BecaDualCLAVE",
                table: "Alumnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alumnos_Domicilios_Domicilioid",
                table: "Alumnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alumnos_Estatus_EstatusCLAVE",
                table: "Alumnos");

            migrationBuilder.DropForeignKey(
                name: "FK_AsesorInstitucionals_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "AsesorInstitucionals");

            migrationBuilder.DropForeignKey(
                name: "FK_Asignaturas_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "Asignaturas");

            migrationBuilder.DropForeignKey(
                name: "FK_CatalagoProyectos_Empresas_EmpresaRFC",
                table: "CatalagoProyectos");

            migrationBuilder.DropForeignKey(
                name: "FK_CatalagoProyectos_MentorEmpresarials_MentorEmpresarialCURP",
                table: "CatalagoProyectos");

            migrationBuilder.DropForeignKey(
                name: "FK_CatalagoProyectos_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "CatalagoProyectos");

            migrationBuilder.DropForeignKey(
                name: "FK_CatalagoProyectos_ResponsableInstitucionals_ResponsableInstitucionalCURP",
                table: "CatalagoProyectos");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Domicilios_Domicilioid",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_MentorAcademicos_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "MentorAcademicos");

            migrationBuilder.DropForeignKey(
                name: "FK_MentorEmpresarials_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "MentorEmpresarials");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramaEducativos_Universidades_UniversidadCCT",
                table: "ProgramaEducativos");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponsableInstitucionals_Universidades_UniversidadCCT",
                table: "ResponsableInstitucionals");

            migrationBuilder.DropForeignKey(
                name: "FK_Universidades_Domicilios_Domicilioid",
                table: "Universidades");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_Asignaturas_Alumnos_AlumnoCURP",
                table: "Alumno_Asignaturas",
                column: "AlumnoCURP",
                principalTable: "Alumnos",
                principalColumn: "CURP",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_Asignaturas_Asignaturas_AsignaturaCLAVE",
                table: "Alumno_Asignaturas",
                column: "AsignaturaCLAVE",
                principalTable: "Asignaturas",
                principalColumn: "CLAVE",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_MentorEmpresarials_Alumnos_AlumnoCURP",
                table: "Alumno_MentorEmpresarials",
                column: "AlumnoCURP",
                principalTable: "Alumnos",
                principalColumn: "CURP",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_MentorEmpresarials_MentorEmpresarials_MentorEmpresarialCURP",
                table: "Alumno_MentorEmpresarials",
                column: "MentorEmpresarialCURP",
                principalTable: "MentorEmpresarials",
                principalColumn: "CURP",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_ProgramaEducativos_Alumnos_AlumnoCURP",
                table: "Alumno_ProgramaEducativos",
                column: "AlumnoCURP",
                principalTable: "Alumnos",
                principalColumn: "CURP",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alumno_ProgramaEducativos_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "Alumno_ProgramaEducativos",
                column: "ProgramaEducativoCLAVE",
                principalTable: "ProgramaEducativos",
                principalColumn: "CLAVE",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alumnos_BecaDuals_BecaDualCLAVE",
                table: "Alumnos",
                column: "BecaDualCLAVE",
                principalTable: "BecaDuals",
                principalColumn: "CLAVE",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alumnos_Domicilios_Domicilioid",
                table: "Alumnos",
                column: "Domicilioid",
                principalTable: "Domicilios",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alumnos_Estatus_EstatusCLAVE",
                table: "Alumnos",
                column: "EstatusCLAVE",
                principalTable: "Estatus",
                principalColumn: "CLAVE",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AsesorInstitucionals_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "AsesorInstitucionals",
                column: "ProgramaEducativoCLAVE",
                principalTable: "ProgramaEducativos",
                principalColumn: "CLAVE",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Asignaturas_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "Asignaturas",
                column: "ProgramaEducativoCLAVE",
                principalTable: "ProgramaEducativos",
                principalColumn: "CLAVE",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CatalagoProyectos_Empresas_EmpresaRFC",
                table: "CatalagoProyectos",
                column: "EmpresaRFC",
                principalTable: "Empresas",
                principalColumn: "RFC",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CatalagoProyectos_MentorEmpresarials_MentorEmpresarialCURP",
                table: "CatalagoProyectos",
                column: "MentorEmpresarialCURP",
                principalTable: "MentorEmpresarials",
                principalColumn: "CURP",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CatalagoProyectos_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "CatalagoProyectos",
                column: "ProgramaEducativoCLAVE",
                principalTable: "ProgramaEducativos",
                principalColumn: "CLAVE",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CatalagoProyectos_ResponsableInstitucionals_ResponsableInstitucionalCURP",
                table: "CatalagoProyectos",
                column: "ResponsableInstitucionalCURP",
                principalTable: "ResponsableInstitucionals",
                principalColumn: "CURP",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Domicilios_Domicilioid",
                table: "Empresas",
                column: "Domicilioid",
                principalTable: "Domicilios",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MentorAcademicos_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "MentorAcademicos",
                column: "ProgramaEducativoCLAVE",
                principalTable: "ProgramaEducativos",
                principalColumn: "CLAVE",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MentorEmpresarials_ProgramaEducativos_ProgramaEducativoCLAVE",
                table: "MentorEmpresarials",
                column: "ProgramaEducativoCLAVE",
                principalTable: "ProgramaEducativos",
                principalColumn: "CLAVE",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramaEducativos_Universidades_UniversidadCCT",
                table: "ProgramaEducativos",
                column: "UniversidadCCT",
                principalTable: "Universidades",
                principalColumn: "CCT",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsableInstitucionals_Universidades_UniversidadCCT",
                table: "ResponsableInstitucionals",
                column: "UniversidadCCT",
                principalTable: "Universidades",
                principalColumn: "CCT",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Universidades_Domicilios_Domicilioid",
                table: "Universidades",
                column: "Domicilioid",
                principalTable: "Domicilios",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
