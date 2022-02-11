﻿// <auto-generated />
using System;
using ClassTrackerBRAPI22.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClassTrackerBRAPI22.Migrations
{
    [DbContext(typeof(ClassTrackerContext))]
    [Migration("20220211032414_add teacher seed data")]
    partial class addteacherseeddata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClassTrackerBRAPI22.Entities.TafeClass", b =>
                {
                    b.Property<int>("TafeClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DurationMinutes")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("TafeClassId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TafeClasses");
                });

            modelBuilder.Entity("ClassTrackerBRAPI22.Entities.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            TeacherId = 1,
                            Email = "Steve@email.com",
                            Name = "Steve",
                            Phone = "1234123412"
                        },
                        new
                        {
                            TeacherId = 2,
                            Email = "Jennifer@email.com",
                            Name = "Jennifer",
                            Phone = "5432234523"
                        });
                });

            modelBuilder.Entity("ClassTrackerBRAPI22.Entities.Unit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TafeClassId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UnitId");

                    b.HasIndex("TafeClassId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("ClassTrackerBRAPI22.Entities.TafeClass", b =>
                {
                    b.HasOne("ClassTrackerBRAPI22.Entities.Teacher", "Teacher")
                        .WithMany("TafeClasses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ClassTrackerBRAPI22.Entities.Unit", b =>
                {
                    b.HasOne("ClassTrackerBRAPI22.Entities.TafeClass", "TafeClass")
                        .WithMany("Units")
                        .HasForeignKey("TafeClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TafeClass");
                });

            modelBuilder.Entity("ClassTrackerBRAPI22.Entities.TafeClass", b =>
                {
                    b.Navigation("Units");
                });

            modelBuilder.Entity("ClassTrackerBRAPI22.Entities.Teacher", b =>
                {
                    b.Navigation("TafeClasses");
                });
#pragma warning restore 612, 618
        }
    }
}
