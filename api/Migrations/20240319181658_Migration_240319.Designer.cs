﻿// <auto-generated />
using System;
using API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240319181658_Migration_240319")]
    partial class Migration_240319
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("API.Domain.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("API.Model.Bed", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("CropRotation")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDesign")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Length")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NumOfColumns")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumOfRows")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Width")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Beds");
                });

            modelBuilder.Entity("API.Model.Cell", b =>
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

                    b.Property<string>("ObjectID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PlantRecordId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("X")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Y")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isHidden")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BedId");

                    b.ToTable("Cells");
                });

            modelBuilder.Entity("API.Model.GardeningTask", b =>
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

            modelBuilder.Entity("API.Model.Harvest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PlantId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlantId");

                    b.ToTable("Harvests");
                });

            modelBuilder.Entity("API.Model.MonthWeek", b =>
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

            modelBuilder.Entity("API.Model.Pest", b =>
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

            modelBuilder.Entity("API.Model.Plant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("BedId")
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

                    b.HasIndex("BedId");

                    b.ToTable("Plants");
                });

            modelBuilder.Entity("API.Model.PlantRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AmountPlanted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DatePlanted")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PlantId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PresumedHarvest")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PlantId");

                    b.ToTable("PlantRecords");
                });

            modelBuilder.Entity("API.Model.Stats", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CanBeSowedRepeatedly")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CanBeSowedRepeatedlyAmount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CanBeSowedThisWeek")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<bool>("FreezeAlert")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HighTemperatureAlert")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MissingSowingThisWeekAmount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MissingTaskThisWeekAmount")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RainPeriodAlert")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReadyToHarvest")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ReadyToHarvestAmount")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("WeatherChecked")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Stats");
                });

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
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
                    b.Property<Guid>("CompanionPlants2Id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CompanionPlantsId")
                        .HasColumnType("TEXT");

                    b.HasKey("CompanionPlants2Id", "CompanionPlantsId");

                    b.HasIndex("CompanionPlantsId");

                    b.ToTable("PlantCompanionPlant", (string)null);
                });

            modelBuilder.Entity("PlantPlant1", b =>
                {
                    b.Property<Guid>("AvoidPlants2Id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AvoidPlantsId")
                        .HasColumnType("TEXT");

                    b.HasKey("AvoidPlants2Id", "AvoidPlantsId");

                    b.HasIndex("AvoidPlantsId");

                    b.ToTable("PlantAvoidPlant", (string)null);
                });

            modelBuilder.Entity("API.Model.Cell", b =>
                {
                    b.HasOne("API.Model.Bed", null)
                        .WithMany("Cells")
                        .HasForeignKey("BedId");
                });

            modelBuilder.Entity("API.Model.Harvest", b =>
                {
                    b.HasOne("API.Model.Plant", "Plant")
                        .WithMany()
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("API.Model.Plant", b =>
                {
                    b.HasOne("API.Model.Bed", null)
                        .WithMany("Plants")
                        .HasForeignKey("BedId");
                });

            modelBuilder.Entity("API.Model.PlantRecord", b =>
                {
                    b.HasOne("API.Model.Plant", "Plant")
                        .WithMany("PlantRecords")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("GardeningTaskMonthWeek", b =>
                {
                    b.HasOne("API.Model.GardeningTask", null)
                        .WithMany()
                        .HasForeignKey("GardeningTasksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Model.MonthWeek", null)
                        .WithMany()
                        .HasForeignKey("MonthWeeksMonth", "MonthWeeksWeek")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("API.Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("API.Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("API.Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MonthWeekPlant", b =>
                {
                    b.HasOne("API.Model.Plant", null)
                        .WithMany()
                        .HasForeignKey("SewedPlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Model.MonthWeek", null)
                        .WithMany()
                        .HasForeignKey("SewingMonthsMonth", "SewingMonthsWeek")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MonthWeekPlant1", b =>
                {
                    b.HasOne("API.Model.Plant", null)
                        .WithMany()
                        .HasForeignKey("HarvestedPlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Model.MonthWeek", null)
                        .WithMany()
                        .HasForeignKey("HarvestMonthsMonth", "HarvestMonthsWeek")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PestPlant", b =>
                {
                    b.HasOne("API.Model.Pest", null)
                        .WithMany()
                        .HasForeignKey("PestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Model.Plant", null)
                        .WithMany()
                        .HasForeignKey("PlantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlantPlant", b =>
                {
                    b.HasOne("API.Model.Plant", null)
                        .WithMany()
                        .HasForeignKey("CompanionPlants2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Model.Plant", null)
                        .WithMany()
                        .HasForeignKey("CompanionPlantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlantPlant1", b =>
                {
                    b.HasOne("API.Model.Plant", null)
                        .WithMany()
                        .HasForeignKey("AvoidPlants2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Model.Plant", null)
                        .WithMany()
                        .HasForeignKey("AvoidPlantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Model.Bed", b =>
                {
                    b.Navigation("Cells");

                    b.Navigation("Plants");
                });

            modelBuilder.Entity("API.Model.Plant", b =>
                {
                    b.Navigation("PlantRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
