﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyPersonalWeb.Web.Data;

namespace MyPersonalWeb.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20191108155036_completeDB")]
    partial class completeDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyPersonalWeb.Web.Data.Entities.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("MyPersonalWeb.Web.Data.Entities.League", b =>
                {
                    b.Property<int>("LeagueId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("LeagueId");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("MyPersonalWeb.Web.Data.Entities.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Champions");

                    b.Property<int>("CountryId");

                    b.Property<int>("LeagueId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int>("Occurrence");

                    b.Property<int>("PlayerTypeId");

                    b.Property<int>("PositionId");

                    b.Property<int>("PositionRolId");

                    b.Property<bool>("Rare");

                    b.Property<int>("Rating");

                    b.Property<bool>("Select");

                    b.Property<int>("TeamId");

                    b.HasKey("PlayerId");

                    b.HasIndex("CountryId");

                    b.HasIndex("LeagueId");

                    b.HasIndex("PlayerTypeId");

                    b.HasIndex("PositionId");

                    b.HasIndex("PositionRolId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("MyPersonalWeb.Web.Data.Entities.PlayerType", b =>
                {
                    b.Property<int>("PlayerTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("PlayerTypeId");

                    b.ToTable("PlayerTypes");
                });

            modelBuilder.Entity("MyPersonalWeb.Web.Data.Entities.Position", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("PositionId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("MyPersonalWeb.Web.Data.Entities.PositionRol", b =>
                {
                    b.Property<int>("PositionRolId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("PositionId");

                    b.HasKey("PositionRolId");

                    b.HasIndex("PositionId");

                    b.ToTable("PositionRols");
                });

            modelBuilder.Entity("MyPersonalWeb.Web.Data.Entities.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LeagueId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("TeamId");

                    b.HasIndex("LeagueId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("MyPersonalWeb.Web.Data.Entities.UserManager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("UserManagers");
                });

            modelBuilder.Entity("MyPersonalWeb.Web.Data.Entities.Player", b =>
                {
                    b.HasOne("MyPersonalWeb.Web.Data.Entities.Country", "Country")
                        .WithMany("Players")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyPersonalWeb.Web.Data.Entities.League", "League")
                        .WithMany("Players")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyPersonalWeb.Web.Data.Entities.PlayerType", "PlayerType")
                        .WithMany("Players")
                        .HasForeignKey("PlayerTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyPersonalWeb.Web.Data.Entities.Position", "Position")
                        .WithMany("Players")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyPersonalWeb.Web.Data.Entities.PositionRol", "PositionRol")
                        .WithMany("Players")
                        .HasForeignKey("PositionRolId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyPersonalWeb.Web.Data.Entities.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyPersonalWeb.Web.Data.Entities.PositionRol", b =>
                {
                    b.HasOne("MyPersonalWeb.Web.Data.Entities.Position", "Position")
                        .WithMany("PositionRols")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyPersonalWeb.Web.Data.Entities.Team", b =>
                {
                    b.HasOne("MyPersonalWeb.Web.Data.Entities.League", "League")
                        .WithMany("Teams")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
