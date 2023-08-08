﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuizAPI.Models;

#nullable disable

namespace QuizAPI.Migrations
{
    [DbContext(typeof(QuizDbContext))]
    partial class QuizDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuizAPI.Models.Prashanja", b =>
                {
                    b.Property<int>("PrashanjeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrashanjeId"));

                    b.Property<string>("ImeSlika")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Odgovor")
                        .HasColumnType("int");

                    b.Property<string>("Opcija1")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Opcija2")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Opcija3")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Opcija4")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Prashanje")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("PrashanjeId");

                    b.ToTable("Prashanja");
                });

            modelBuilder.Entity("QuizAPI.Models.Ucesnik", b =>
                {
                    b.Property<int>("UcesnikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UcesnikId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Lozinka")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Poeni")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Vreme")
                        .HasColumnType("int");

                    b.HasKey("UcesnikId");

                    b.ToTable("Ucesnici");
                });
#pragma warning restore 612, 618
        }
    }
}