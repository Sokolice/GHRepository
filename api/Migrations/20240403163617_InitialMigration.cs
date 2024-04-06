using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonthWeeks",
                columns: table => new
                {
                    Month = table.Column<string>(type: "TEXT", nullable: false),
                    Week = table.Column<int>(type: "INTEGER", nullable: false),
                    MonthIndex = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthWeeks", x => new { x.Month, x.Week });
                });

            migrationBuilder.CreateTable(
                name: "Pests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Advice = table.Column<string>(type: "TEXT", nullable: false),
                    ImageSrc = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DirectSewing = table.Column<bool>(type: "INTEGER", nullable: false),
                    PreCultivation = table.Column<bool>(type: "INTEGER", nullable: false),
                    GerminationTemp = table.Column<int>(type: "INTEGER", nullable: false),
                    CropRotation = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImageSrc = table.Column<string>(type: "TEXT", nullable: false),
                    RepeatedPlanting = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Width = table.Column<decimal>(type: "TEXT", nullable: false),
                    Length = table.Column<decimal>(type: "TEXT", nullable: false),
                    NumOfColumns = table.Column<int>(type: "INTEGER", nullable: false),
                    NumOfRows = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDesign = table.Column<bool>(type: "INTEGER", nullable: false),
                    CropRotation = table.Column<int>(type: "INTEGER", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beds_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WeatherChecked = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FreezeAlert = table.Column<bool>(type: "INTEGER", nullable: false),
                    HighTemperatureAlert = table.Column<bool>(type: "INTEGER", nullable: false),
                    RainPeriodAlert = table.Column<bool>(type: "INTEGER", nullable: false),
                    MissingSowingThisWeekAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    MissingTaskThisWeekAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    CanBeSowedRepeatedlyAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    ReadyToHarvestAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    CanBeSowedThisWeek = table.Column<string>(type: "TEXT", nullable: false),
                    CanBeSowedRepeatedly = table.Column<string>(type: "TEXT", nullable: false),
                    ReadyToHarvest = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stats_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    WasSent = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MonthWeekPlantType",
                columns: table => new
                {
                    SewedPlantTypesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SewingMonthsMonth = table.Column<string>(type: "TEXT", nullable: false),
                    SewingMonthsWeek = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthWeekPlantType", x => new { x.SewedPlantTypesId, x.SewingMonthsMonth, x.SewingMonthsWeek });
                    table.ForeignKey(
                        name: "FK_MonthWeekPlantType_MonthWeeks_SewingMonthsMonth_SewingMonthsWeek",
                        columns: x => new { x.SewingMonthsMonth, x.SewingMonthsWeek },
                        principalTable: "MonthWeeks",
                        principalColumns: new[] { "Month", "Week" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonthWeekPlantType_PlantTypes_SewedPlantTypesId",
                        column: x => x.SewedPlantTypesId,
                        principalTable: "PlantTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonthWeekPlantType1",
                columns: table => new
                {
                    HarvestedPlantTypesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    HarvestMonthsMonth = table.Column<string>(type: "TEXT", nullable: false),
                    HarvestMonthsWeek = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthWeekPlantType1", x => new { x.HarvestedPlantTypesId, x.HarvestMonthsMonth, x.HarvestMonthsWeek });
                    table.ForeignKey(
                        name: "FK_MonthWeekPlantType1_MonthWeeks_HarvestMonthsMonth_HarvestMonthsWeek",
                        columns: x => new { x.HarvestMonthsMonth, x.HarvestMonthsWeek },
                        principalTable: "MonthWeeks",
                        principalColumns: new[] { "Month", "Week" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonthWeekPlantType1_PlantTypes_HarvestedPlantTypesId",
                        column: x => x.HarvestedPlantTypesId,
                        principalTable: "PlantTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PestPlantType",
                columns: table => new
                {
                    PestsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlantsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PestPlantType", x => new { x.PestsId, x.PlantsId });
                    table.ForeignKey(
                        name: "FK_PestPlantType_Pests_PestsId",
                        column: x => x.PestsId,
                        principalTable: "Pests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PestPlantType_PlantTypes_PlantsId",
                        column: x => x.PlantsId,
                        principalTable: "PlantTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantTypeAvoidPlant",
                columns: table => new
                {
                    AvoidPlantTypes2Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AvoidPlantTypesId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantTypeAvoidPlant", x => new { x.AvoidPlantTypes2Id, x.AvoidPlantTypesId });
                    table.ForeignKey(
                        name: "FK_PlantTypeAvoidPlant_PlantTypes_AvoidPlantTypes2Id",
                        column: x => x.AvoidPlantTypes2Id,
                        principalTable: "PlantTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantTypeAvoidPlant_PlantTypes_AvoidPlantTypesId",
                        column: x => x.AvoidPlantTypesId,
                        principalTable: "PlantTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantTypeCompanionPlant",
                columns: table => new
                {
                    CompanionPlantTypes2Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CompanionPlantTypesId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantTypeCompanionPlant", x => new { x.CompanionPlantTypes2Id, x.CompanionPlantTypesId });
                    table.ForeignKey(
                        name: "FK_PlantTypeCompanionPlant_PlantTypes_CompanionPlantTypes2Id",
                        column: x => x.CompanionPlantTypes2Id,
                        principalTable: "PlantTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantTypeCompanionPlant_PlantTypes_CompanionPlantTypesId",
                        column: x => x.CompanionPlantTypesId,
                        principalTable: "PlantTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cells",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    X = table.Column<int>(type: "INTEGER", nullable: false),
                    Y = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    GridArea = table.Column<string>(type: "TEXT", nullable: false),
                    BackgroundImage = table.Column<string>(type: "TEXT", nullable: false),
                    PlantRecordId = table.Column<string>(type: "TEXT", nullable: false),
                    isHidden = table.Column<bool>(type: "INTEGER", nullable: false),
                    ObjectID = table.Column<string>(type: "TEXT", nullable: false),
                    BedId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cells_Beds_BedId",
                        column: x => x.BedId,
                        principalTable: "Beds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsHybrid = table.Column<bool>(type: "INTEGER", nullable: false),
                    DirectSewing = table.Column<bool>(type: "INTEGER", nullable: false),
                    PreCultivation = table.Column<bool>(type: "INTEGER", nullable: false),
                    GerminationTemp = table.Column<int>(type: "INTEGER", nullable: false),
                    CropRotation = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImageSrc = table.Column<string>(type: "TEXT", nullable: false),
                    RepeatedPlanting = table.Column<int>(type: "INTEGER", nullable: false),
                    PlantTypeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BedId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plants_Beds_BedId",
                        column: x => x.BedId,
                        principalTable: "Beds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Plants_PlantTypes_PlantTypeId",
                        column: x => x.PlantTypeId,
                        principalTable: "PlantTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GardeningTaskMonthWeek",
                columns: table => new
                {
                    GardeningTasksId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MonthWeeksMonth = table.Column<string>(type: "TEXT", nullable: false),
                    MonthWeeksWeek = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardeningTaskMonthWeek", x => new { x.GardeningTasksId, x.MonthWeeksMonth, x.MonthWeeksWeek });
                    table.ForeignKey(
                        name: "FK_GardeningTaskMonthWeek_MonthWeeks_MonthWeeksMonth_MonthWeeksWeek",
                        columns: x => new { x.MonthWeeksMonth, x.MonthWeeksWeek },
                        principalTable: "MonthWeeks",
                        principalColumns: new[] { "Month", "Week" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GardeningTaskMonthWeek_Tasks_GardeningTasksId",
                        column: x => x.GardeningTasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Harvests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlantId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harvests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Harvests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Harvests_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonthWeekPlant",
                columns: table => new
                {
                    SewedPlantsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SewingMonthsMonth = table.Column<string>(type: "TEXT", nullable: false),
                    SewingMonthsWeek = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthWeekPlant", x => new { x.SewedPlantsId, x.SewingMonthsMonth, x.SewingMonthsWeek });
                    table.ForeignKey(
                        name: "FK_MonthWeekPlant_MonthWeeks_SewingMonthsMonth_SewingMonthsWeek",
                        columns: x => new { x.SewingMonthsMonth, x.SewingMonthsWeek },
                        principalTable: "MonthWeeks",
                        principalColumns: new[] { "Month", "Week" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonthWeekPlant_Plants_SewedPlantsId",
                        column: x => x.SewedPlantsId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonthWeekPlant1",
                columns: table => new
                {
                    HarvestedPlantsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    HarvestMonthsMonth = table.Column<string>(type: "TEXT", nullable: false),
                    HarvestMonthsWeek = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthWeekPlant1", x => new { x.HarvestedPlantsId, x.HarvestMonthsMonth, x.HarvestMonthsWeek });
                    table.ForeignKey(
                        name: "FK_MonthWeekPlant1_MonthWeeks_HarvestMonthsMonth_HarvestMonthsWeek",
                        columns: x => new { x.HarvestMonthsMonth, x.HarvestMonthsWeek },
                        principalTable: "MonthWeeks",
                        principalColumns: new[] { "Month", "Week" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonthWeekPlant1_Plants_HarvestedPlantsId",
                        column: x => x.HarvestedPlantsId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlantId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DatePlanted = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AmountPlanted = table.Column<int>(type: "INTEGER", nullable: false),
                    PresumedHarvest = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantRecords_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlantRecords_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantUser",
                columns: table => new
                {
                    PlantsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UsersId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantUser", x => new { x.PlantsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_PlantUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantUser_Plants_PlantsId",
                        column: x => x.PlantsId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beds_UserId",
                table: "Beds",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cells_BedId",
                table: "Cells",
                column: "BedId");

            migrationBuilder.CreateIndex(
                name: "IX_GardeningTaskMonthWeek_MonthWeeksMonth_MonthWeeksWeek",
                table: "GardeningTaskMonthWeek",
                columns: new[] { "MonthWeeksMonth", "MonthWeeksWeek" });

            migrationBuilder.CreateIndex(
                name: "IX_Harvests_PlantId",
                table: "Harvests",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Harvests_UserId",
                table: "Harvests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthWeekPlant_SewingMonthsMonth_SewingMonthsWeek",
                table: "MonthWeekPlant",
                columns: new[] { "SewingMonthsMonth", "SewingMonthsWeek" });

            migrationBuilder.CreateIndex(
                name: "IX_MonthWeekPlant1_HarvestMonthsMonth_HarvestMonthsWeek",
                table: "MonthWeekPlant1",
                columns: new[] { "HarvestMonthsMonth", "HarvestMonthsWeek" });

            migrationBuilder.CreateIndex(
                name: "IX_MonthWeekPlantType_SewingMonthsMonth_SewingMonthsWeek",
                table: "MonthWeekPlantType",
                columns: new[] { "SewingMonthsMonth", "SewingMonthsWeek" });

            migrationBuilder.CreateIndex(
                name: "IX_MonthWeekPlantType1_HarvestMonthsMonth_HarvestMonthsWeek",
                table: "MonthWeekPlantType1",
                columns: new[] { "HarvestMonthsMonth", "HarvestMonthsWeek" });

            migrationBuilder.CreateIndex(
                name: "IX_PestPlantType_PlantsId",
                table: "PestPlantType",
                column: "PlantsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantRecords_PlantId",
                table: "PlantRecords",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantRecords_UserId",
                table: "PlantRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_BedId",
                table: "Plants",
                column: "BedId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_PlantTypeId",
                table: "Plants",
                column: "PlantTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantTypeAvoidPlant_AvoidPlantTypesId",
                table: "PlantTypeAvoidPlant",
                column: "AvoidPlantTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantTypeCompanionPlant_CompanionPlantTypesId",
                table: "PlantTypeCompanionPlant",
                column: "CompanionPlantTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantUser_UsersId",
                table: "PlantUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_UserId",
                table: "Stats",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Cells");

            migrationBuilder.DropTable(
                name: "GardeningTaskMonthWeek");

            migrationBuilder.DropTable(
                name: "Harvests");

            migrationBuilder.DropTable(
                name: "MonthWeekPlant");

            migrationBuilder.DropTable(
                name: "MonthWeekPlant1");

            migrationBuilder.DropTable(
                name: "MonthWeekPlantType");

            migrationBuilder.DropTable(
                name: "MonthWeekPlantType1");

            migrationBuilder.DropTable(
                name: "PestPlantType");

            migrationBuilder.DropTable(
                name: "PlantRecords");

            migrationBuilder.DropTable(
                name: "PlantTypeAvoidPlant");

            migrationBuilder.DropTable(
                name: "PlantTypeCompanionPlant");

            migrationBuilder.DropTable(
                name: "PlantUser");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "MonthWeeks");

            migrationBuilder.DropTable(
                name: "Pests");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Beds");

            migrationBuilder.DropTable(
                name: "PlantTypes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
