﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.Service.Models;

namespace Project.Service.Migrations
{
    [DbContext(typeof(VehicleContext))]
    [Migration("20200823125106_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Project.Service.Entities.VehicleMakeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abrv");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("VehicleMakes");
                });

            modelBuilder.Entity("Project.Service.Entities.VehicleModelEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abrv");

                    b.Property<Guid?>("MakeId");

                    b.Property<string>("Name");

                    b.Property<Guid>("VehicleMakeId");

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.ToTable("VehicleModels");
                });

            modelBuilder.Entity("Project.Service.Entities.VehicleModelEntity", b =>
                {
                    b.HasOne("Project.Service.Entities.VehicleMakeEntity", "Make")
                        .WithMany()
                        .HasForeignKey("MakeId");
                });
#pragma warning restore 612, 618
        }
    }
}
