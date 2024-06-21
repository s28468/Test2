﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Astronaut", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Astronauts");
                });

            modelBuilder.Entity("WebApplication1.Models.AstronautMission", b =>
                {
                    b.Property<int>("AstronautId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("MissionId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AstronautId", "MissionId");

                    b.HasIndex("MissionId");

                    b.ToTable("AstronautMissions");
                });

            modelBuilder.Entity("WebApplication1.Models.Mission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("LaunchDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("WebApplication1.Models.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("WebApplication1.Models.AstronautMission", b =>
                {
                    b.HasOne("WebApplication1.Models.Astronaut", "Astronaut")
                        .WithMany("AstronautMissions")
                        .HasForeignKey("AstronautId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Mission", "Mission")
                        .WithMany("AstronautMissions")
                        .HasForeignKey("MissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Astronaut");

                    b.Navigation("Mission");
                });

            modelBuilder.Entity("WebApplication1.Models.Mission", b =>
                {
                    b.HasOne("WebApplication1.Models.Organization", "Organization")
                        .WithMany("Missions")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("WebApplication1.Models.Astronaut", b =>
                {
                    b.Navigation("AstronautMissions");
                });

            modelBuilder.Entity("WebApplication1.Models.Mission", b =>
                {
                    b.Navigation("AstronautMissions");
                });

            modelBuilder.Entity("WebApplication1.Models.Organization", b =>
                {
                    b.Navigation("Missions");
                });
#pragma warning restore 612, 618
        }
    }
}
