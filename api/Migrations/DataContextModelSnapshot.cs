﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Persistence;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("GardeningTaskMonthWeek", b =>
                {
                    b.Property<Guid>("GardeningTasksId")
                        .HasColumnType("TEXT");

                    b.Property<string>("MonthWeeksMonth")
                        .HasColumnType("TEXT");

                    b.Property<int>("MonthWeeksWeek")
                        .HasColumnType("INTEGER");

                    b.HasKey("GardeningTasksId", "MonthWeeksMonth", "MonthWeeksWeek");

                    b.HasIndex("MonthWeeksMonth", "MonthWeeksWeek");

                    b.ToTable("GardeningTaskMonthWeek");
                });

            modelBuilder.Entity("MonthWeekPlant", b =>
                {
                    b.Property<Guid>("SewedPlantId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SewingMonthsMonth")
                        .HasColumnType("TEXT");

                    b.Property<int>("SewingMonthsWeek")
                        .HasColumnType("INTEGER");

                    b.HasKey("SewedPlantId", "SewingMonthsMonth", "SewingMonthsWeek");

                    b.HasIndex("SewingMonthsMonth", "SewingMonthsWeek");

                    b.ToTable("MonthWeekPlant");
                });

            modelBuilder.Entity("MonthWeekPlant1", b =>
                {
                    b.Property<Guid>("HarvestedPlantId")
                        .HasColumnType("TEXT");

                    b.Property<string>("HarvestMonthsMonth")
                        .HasColumnType("TEXT");

                    b.Property<int>("HarvestMonthsWeek")
                        .HasColumnType("INTEGER");

                    b.HasKey("HarvestedPlantId", "HarvestMonthsMonth", "HarvestMonthsWeek");

                    b.HasIndex("HarvestMonthsMonth", "HarvestMonthsWeek");

                    b.ToTable("MonthWeekPlant1");
                });

            modelBuilder.Entity("PestPlant", b =>
                {
                    b.Property<Guid>("PestsId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PlantsId")
                        .HasColumnType("TEXT");

                    b.HasKey("PestsId", "PlantsId");

                    b.HasIndex("PlantsId");

                    b.ToTable("PestPlant");
                });

            modelBuilder.Entity("PlantPlant", b =>
                {
                    b.Property<Guid>("AvoidPlantsId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CompanionPlantsId")
                        .HasColumnType("TEXT");

                    b.HasKey("AvoidPlantsId", "CompanionPlantsId");

                    b.HasIndex("CompanionPlantsId");

                    b.ToTable("PlantPlant");
                });

            modelBuilder.Entity("api.Model.Bed", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Length")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NumOfColumns")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumOfRows")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Width")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isDesign")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Beds");
                });

            modelBuilder.Entity("api.Model.Cell", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("BackgroundImage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("BedId")
                        .HasColumnType("TEXT");

                    b.Property<string>("GridArea")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PlantRecordId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("X")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Y")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BedId");

                    b.ToTable("Cells");
                });

            modelBuilder.Entity("api.Model.GardeningTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("WasSent")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("api.Model.MonthWeek", b =>
                {
                    b.Property<string>("Month")
                        .HasColumnType("TEXT");

                    b.Property<int>("Week")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MonthIndex")
                        .HasColumnType("INTEGER");

                    b.HasKey("Month", "Week");

                    b.ToTable("MonthWeeks");
                });

            modelBuilder.Entity("api.Model.Pest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Advice")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageSrc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Pests");
                });

            modelBuilder.Entity("api.Model.Plant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("CropRotation")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("DirectSewing")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GerminationTemp")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageSrc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsHybrid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RepeatedPlanting")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Plants");
                });

            modelBuilder.Entity("api.Model.PlantRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AmountPlanted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DatePlanted")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PlantId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PlantId");

                    b.ToTable("PlantRecords");
                });

            modelBuilder.Entity("GardeningTaskMonthWeek", b =>
                {
                    b.HasOne("api.Model.GardeningTask", null)
                        .WithMany()
                        .HasForeignKey("GardeningTasksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Model.MonthWeek", null)
                        .WithMany()
                        .HasForeignKey("MonthWeeksMonth", "MonthWeeksWeek")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MonthWeekPlant", b =>
                {
                    b.HasOne("api.Model.Plant", null)
                        .WithMany()
                        .HasForeignKey("SewedPlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Model.MonthWeek", null)
                        .WithMany()
                        .HasForeignKey("SewingMonthsMonth", "SewingMonthsWeek")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MonthWeekPlant1", b =>
                {
                    b.HasOne("api.Model.Plant", null)
                        .WithMany()
                        .HasForeignKey("HarvestedPlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Model.MonthWeek", null)
                        .WithMany()
                        .HasForeignKey("HarvestMonthsMonth", "HarvestMonthsWeek")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PestPlant", b =>
                {
                    b.HasOne("api.Model.Pest", null)
                        .WithMany()
                        .HasForeignKey("PestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Model.Plant", null)
                        .WithMany()
                        .HasForeignKey("PlantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                        .HasForeignKey("CompanionPlantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("api.Model.Cell", b =>
                {
                    b.HasOne("api.Model.Bed", null)
                        .WithMany("Cells")
                        .HasForeignKey("BedId");
                });

            modelBuilder.Entity("api.Model.PlantRecord", b =>
                {
                    b.HasOne("api.Model.Plant", "Plant")
                        .WithMany("PlantRecords")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("api.Model.Bed", b =>
                {
                    b.Navigation("Cells");
                });

            modelBuilder.Entity("api.Model.Plant", b =>
                {
                    b.Navigation("PlantRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
