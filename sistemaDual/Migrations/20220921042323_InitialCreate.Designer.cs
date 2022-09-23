﻿// <auto-generated />
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
    [Migration("20220921042323_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc.1.22426.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("sistemaDual.Models.Domicilio", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Colonia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Municipio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Otros")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Domicilio", (string)null);
                });

            modelBuilder.Entity("sistemaDual.Models.ProgramaEducativo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UniversidadID")
                        .HasColumnType("int");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("UniversidadID");

                    b.ToTable("ProgramaEducativo", (string)null);
                });

            modelBuilder.Entity("sistemaDual.Models.Universidad", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CCT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DomicilioID")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DomicilioID");

                    b.ToTable("Universidad", (string)null);
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

            modelBuilder.Entity("sistemaDual.Models.Universidad", b =>
                {
                    b.HasOne("sistemaDual.Models.Domicilio", "Domicilio")
                        .WithMany("Universidades")
                        .HasForeignKey("DomicilioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Domicilio");
                });

            modelBuilder.Entity("sistemaDual.Models.Domicilio", b =>
                {
                    b.Navigation("Universidades");
                });

            modelBuilder.Entity("sistemaDual.Models.Universidad", b =>
                {
                    b.Navigation("ProgramaEducativos");
                });
#pragma warning restore 612, 618
        }
    }
}