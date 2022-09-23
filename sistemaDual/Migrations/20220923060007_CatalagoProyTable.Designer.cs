﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sistemaDual.Data;

#nullable disable

namespace sistemaDual.Migrations
{
    [DbContext(typeof(ProgramaDualContext))]
    [Migration("20220923060007_CatalagoProyTable")]
    partial class CatalagoProyTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc.1.22426.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("sistemaDual.Models.AlumnoDual", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ApellidoM")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("ApellidoMaterno");

                    b.Property<string>("ApellidoP")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("ApellidoPaterno");

                    b.Property<int>("BecaDualID")
                        .HasColumnType("int");

                    b.Property<int>("Cuatrimestre")
                        .HasColumnType("int");

                    b.Property<string>("Curp")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<int>("DomicilioID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaContratado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaEgreso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaReingreso")
                        .HasColumnType("datetime2");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("NombreCompleto");

                    b.Property<int>("ProgramaEducativoID")
                        .HasColumnType("int");

                    b.Property<double>("Promedio")
                        .HasColumnType("float");

                    b.Property<int>("Telefono")
                        .HasMaxLength(12)
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BecaDualID");

                    b.HasIndex("DomicilioID");

                    b.HasIndex("ProgramaEducativoID");

                    b.ToTable("AlumnoDual", (string)null);
                });

            modelBuilder.Entity("sistemaDual.Models.AlumnoMentor", b =>
                {
                    b.Property<int>("AlumnoDualID")
                        .HasColumnType("int");

                    b.Property<int>("MentorEmpresarialID")
                        .HasColumnType("int");

                    b.HasKey("AlumnoDualID", "MentorEmpresarialID");

                    b.HasIndex("MentorEmpresarialID");

                    b.ToTable("AlumnosMentores");
                });

            modelBuilder.Entity("sistemaDual.Models.AsesorInstitucional", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ApellidoM")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("ApellidoMaterno");

                    b.Property<string>("ApellidoP")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("ApellidoPaterno");

                    b.Property<string>("Curp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("NombreCompleto");

                    b.Property<int>("ProgramaEducativoID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProgramaEducativoID");

                    b.ToTable("AsesorInstitucional", (string)null);
                });

            modelBuilder.Entity("sistemaDual.Models.Asignatura", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Actividad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Competencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Periodo")
                        .HasColumnType("int");

                    b.Property<int>("ProgramaEducativoID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProgramaEducativoID");

                    b.ToTable("Asignatura", (string)null);
                });

            modelBuilder.Entity("sistemaDual.Models.BecaDual", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Duracion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fuente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Periocidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoBeca")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("BecaDual", (string)null);
                });

            modelBuilder.Entity("sistemaDual.Models.CatalagoProyecto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AlumnoDualID")
                        .HasColumnType("int");

                    b.Property<string>("AreaConocimiento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpresaID")
                        .HasColumnType("int");

                    b.Property<int?>("Estatus")
                        .HasColumnType("int");

                    b.Property<string>("Etapa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaCambioEstatus")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaTermino")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumHoras")
                        .HasColumnType("int");

                    b.Property<int?>("ProgramaEducativoID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AlumnoDualID");

                    b.HasIndex("EmpresaID");

                    b.HasIndex("ProgramaEducativoID");

                    b.ToTable("CatalagoProyecto", (string)null);
                });

            modelBuilder.Entity("sistemaDual.Models.Domicilio", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Colonia")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Municipio")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Otros")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("Domicilio", (string)null);
                });

            modelBuilder.Entity("sistemaDual.Models.Empresa", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CorreoRepresentante");

                    b.Property<int>("DomicilioID")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("NombreComercial");

                    b.Property<string>("Razon")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("RazonSocial");

                    b.Property<string>("Representante")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("RepresentanteLegal");

                    b.Property<string>("Rfc")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Sector")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.HasIndex("DomicilioID");

                    b.ToTable("Empresa", (string)null);
                });

            modelBuilder.Entity("sistemaDual.Models.MentorAcademico", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ApellidoM")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("ApellidoMaterno");

                    b.Property<string>("ApellidoP")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("ApellidoPaterno");

                    b.Property<string>("Curp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("NombreCompleto");

                    b.Property<int>("ProgramaEducativoID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProgramaEducativoID");

                    b.ToTable("MentorAcademico", (string)null);
                });

            modelBuilder.Entity("sistemaDual.Models.MentorEmpresarial", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ApellidoM")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("ApellidoMaterno");

                    b.Property<string>("ApellidoP")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("ApellidoPaterno");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CorreoMentor");

                    b.Property<int>("EmpresaID")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("NombreCompleto");

                    b.Property<int>("ProgramaEducativoID")
                        .HasColumnType("int");

                    b.Property<int>("Telefono")
                        .HasMaxLength(12)
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EmpresaID");

                    b.HasIndex("ProgramaEducativoID");

                    b.ToTable("MentorEmpresarial", (string)null);
                });

            modelBuilder.Entity("sistemaDual.Models.ProgramaEducativo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("UniversidadID")
                        .HasColumnType("int");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ID");

                    b.HasIndex("UniversidadID");

                    b.ToTable("ProgramaEducativo", (string)null);
                });

            modelBuilder.Entity("sistemaDual.Models.ResponsableInstitucional", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ApellidoM")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("ApellidoMaterno");

                    b.Property<string>("ApellidoP")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("ApellidoPaterno");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CorreoMentor");

                    b.Property<string>("Curp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("NombreCompleto");

                    b.Property<int>("Telefono")
                        .HasMaxLength(12)
                        .HasColumnType("int");

                    b.Property<int>("UniversidadID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UniversidadID");

                    b.ToTable("ResponsableInstitucional", (string)null);
                });

            modelBuilder.Entity("sistemaDual.Models.Universidad", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CCT")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("DomicilioID")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("ID");

                    b.HasIndex("DomicilioID");

                    b.ToTable("Universidad", (string)null);
                });

            modelBuilder.Entity("sistemaDual.Models.AlumnoDual", b =>
                {
                    b.HasOne("sistemaDual.Models.BecaDual", "BecaDual")
                        .WithMany("AlumnosDuales")
                        .HasForeignKey("BecaDualID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sistemaDual.Models.Domicilio", "Domicilio")
                        .WithMany("AlumnosDuales")
                        .HasForeignKey("DomicilioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sistemaDual.Models.ProgramaEducativo", "ProgramaEducativo")
                        .WithMany("AlumnosDuales")
                        .HasForeignKey("ProgramaEducativoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BecaDual");

                    b.Navigation("Domicilio");

                    b.Navigation("ProgramaEducativo");
                });

            modelBuilder.Entity("sistemaDual.Models.AlumnoMentor", b =>
                {
                    b.HasOne("sistemaDual.Models.AlumnoDual", "AlumnoDual")
                        .WithMany("AlumnoMentores")
                        .HasForeignKey("AlumnoDualID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sistemaDual.Models.MentorEmpresarial", "MentorEmpresarial")
                        .WithMany("AlumnoMentores")
                        .HasForeignKey("MentorEmpresarialID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AlumnoDual");

                    b.Navigation("MentorEmpresarial");
                });

            modelBuilder.Entity("sistemaDual.Models.AsesorInstitucional", b =>
                {
                    b.HasOne("sistemaDual.Models.ProgramaEducativo", "ProgramaEducativo")
                        .WithMany("AsesoresInstitucionales")
                        .HasForeignKey("ProgramaEducativoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProgramaEducativo");
                });

            modelBuilder.Entity("sistemaDual.Models.Asignatura", b =>
                {
                    b.HasOne("sistemaDual.Models.ProgramaEducativo", "ProgramaEducativo")
                        .WithMany("Asignaturas")
                        .HasForeignKey("ProgramaEducativoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProgramaEducativo");
                });

            modelBuilder.Entity("sistemaDual.Models.CatalagoProyecto", b =>
                {
                    b.HasOne("sistemaDual.Models.AlumnoDual", "AlumnoDual")
                        .WithMany("CatalagoProyectos")
                        .HasForeignKey("AlumnoDualID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sistemaDual.Models.Empresa", "Empresa")
                        .WithMany("CatalagoProyectos")
                        .HasForeignKey("EmpresaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sistemaDual.Models.ProgramaEducativo", null)
                        .WithMany("CatalagoProyectos")
                        .HasForeignKey("ProgramaEducativoID");

                    b.Navigation("AlumnoDual");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("sistemaDual.Models.Empresa", b =>
                {
                    b.HasOne("sistemaDual.Models.Domicilio", "Domicilio")
                        .WithMany("Empresas")
                        .HasForeignKey("DomicilioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Domicilio");
                });

            modelBuilder.Entity("sistemaDual.Models.MentorAcademico", b =>
                {
                    b.HasOne("sistemaDual.Models.ProgramaEducativo", "ProgramaEducativo")
                        .WithMany("MentoresAcademicos")
                        .HasForeignKey("ProgramaEducativoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProgramaEducativo");
                });

            modelBuilder.Entity("sistemaDual.Models.MentorEmpresarial", b =>
                {
                    b.HasOne("sistemaDual.Models.Empresa", "Empresa")
                        .WithMany("MentoresEmpresariales")
                        .HasForeignKey("EmpresaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sistemaDual.Models.ProgramaEducativo", "ProgramaEducativo")
                        .WithMany("MentoresEmpresariales")
                        .HasForeignKey("ProgramaEducativoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("ProgramaEducativo");
                });

            modelBuilder.Entity("sistemaDual.Models.ProgramaEducativo", b =>
                {
                    b.HasOne("sistemaDual.Models.Universidad", "Universidad")
                        .WithMany("ProgramaEducativos")
                        .HasForeignKey("UniversidadID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Universidad");
                });

            modelBuilder.Entity("sistemaDual.Models.ResponsableInstitucional", b =>
                {
                    b.HasOne("sistemaDual.Models.Universidad", "Universidad")
                        .WithMany("ResponsablesInstitucionales")
                        .HasForeignKey("UniversidadID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Universidad");
                });

            modelBuilder.Entity("sistemaDual.Models.Universidad", b =>
                {
                    b.HasOne("sistemaDual.Models.Domicilio", "Domicilio")
                        .WithMany("Universidades")
                        .HasForeignKey("DomicilioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Domicilio");
                });

            modelBuilder.Entity("sistemaDual.Models.AlumnoDual", b =>
                {
                    b.Navigation("AlumnoMentores");

                    b.Navigation("CatalagoProyectos");
                });

            modelBuilder.Entity("sistemaDual.Models.BecaDual", b =>
                {
                    b.Navigation("AlumnosDuales");
                });

            modelBuilder.Entity("sistemaDual.Models.Domicilio", b =>
                {
                    b.Navigation("AlumnosDuales");

                    b.Navigation("Empresas");

                    b.Navigation("Universidades");
                });

            modelBuilder.Entity("sistemaDual.Models.Empresa", b =>
                {
                    b.Navigation("CatalagoProyectos");

                    b.Navigation("MentoresEmpresariales");
                });

            modelBuilder.Entity("sistemaDual.Models.MentorEmpresarial", b =>
                {
                    b.Navigation("AlumnoMentores");
                });

            modelBuilder.Entity("sistemaDual.Models.ProgramaEducativo", b =>
                {
                    b.Navigation("AlumnosDuales");

                    b.Navigation("AsesoresInstitucionales");

                    b.Navigation("Asignaturas");

                    b.Navigation("CatalagoProyectos");

                    b.Navigation("MentoresAcademicos");

                    b.Navigation("MentoresEmpresariales");
                });

            modelBuilder.Entity("sistemaDual.Models.Universidad", b =>
                {
                    b.Navigation("ProgramaEducativos");

                    b.Navigation("ResponsablesInstitucionales");
                });
#pragma warning restore 612, 618
        }
    }
}
