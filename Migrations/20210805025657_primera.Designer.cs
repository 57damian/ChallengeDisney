﻿// <auto-generated />
using System;
using ChallengeDisney.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChallengeDisney.Migrations
{
    [DbContext(typeof(ChallengeContext))]
    [Migration("20210805025657_primera")]
    partial class primera
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChallengeDisney.Entities.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("ChallengeDisney.Entities.Pelicula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Calificacion")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GeneroId")
                        .HasColumnType("int");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GeneroId");

                    b.ToTable("Peliculas");
                });

            modelBuilder.Entity("ChallengeDisney.Entities.Personaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Historia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Peso")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Personajes");
                });

            modelBuilder.Entity("PeliculaPersonaje", b =>
                {
                    b.Property<int>("peliculasId")
                        .HasColumnType("int");

                    b.Property<int>("personajesId")
                        .HasColumnType("int");

                    b.HasKey("peliculasId", "personajesId");

                    b.HasIndex("personajesId");

                    b.ToTable("PeliculaPersonaje");
                });

            modelBuilder.Entity("ChallengeDisney.Entities.Pelicula", b =>
                {
                    b.HasOne("ChallengeDisney.Entities.Genero", "Genero")
                        .WithMany("Peliculas")
                        .HasForeignKey("GeneroId");

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("PeliculaPersonaje", b =>
                {
                    b.HasOne("ChallengeDisney.Entities.Pelicula", null)
                        .WithMany()
                        .HasForeignKey("peliculasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChallengeDisney.Entities.Personaje", null)
                        .WithMany()
                        .HasForeignKey("personajesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChallengeDisney.Entities.Genero", b =>
                {
                    b.Navigation("Peliculas");
                });
#pragma warning restore 612, 618
        }
    }
}
