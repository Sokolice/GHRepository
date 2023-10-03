﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Persistence;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230915174956_Migration_230915")]
    partial class Migration_230915
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("PlantPlant", b =>
                {
                    b.Property<Guid>("AvoidPlantsId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CompanionPlantId")
                        .HasColumnType("TEXT");

                    b.HasKey("AvoidPlantsId", "CompanionPlantId");

                    b.HasIndex("CompanionPlantId");

                    b.ToTable("PlantPlant");
                });

            modelBuilder.Entity("api.Model.Plant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DatePlanted")
                        .HasColumnType("TEXT");

                    b.Property<bool>("DirectSewing")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsHybrid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VegetationPeriod")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Plants");
                });

            modelBuilder.Entity("PlantPlant", b =>
                {
                    b.HasOne("api.Model.Plant", null)
                        .WithMany()
                        .HasForeignKey("AvoidPlantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Model.Plant", null)
                        .WithMany()
                        .HasForeignKey("CompanionPlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
