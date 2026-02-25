using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SmartAttend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "ContactSupportMails",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactSupportMails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTypes",
                schema: "public",
                columns: table => new
                {
                    CustomerTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerTypeName = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTypes", x => x.CustomerTypeId);
                });

            migrationBuilder.CreateTable(
                name: "PlannedShutdownDescriptionMasters",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    EntityType = table.Column<int>(type: "integer", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedShutdownDescriptionMasters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PushNotificationDevices",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    DeviceToken = table.Column<string>(type: "text", nullable: false),
                    DeviceType = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PushNotificationDevices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportNotificationTypes",
                schema: "public",
                columns: table => new
                {
                    ReportNotificationTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportNotificationTypes", x => x.ReportNotificationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ReportType",
                schema: "public",
                columns: table => new
                {
                    ReportTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportType", x => x.ReportTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ReportValueType",
                schema: "public",
                columns: table => new
                {
                    ReportValueTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportValueType", x => x.ReportValueTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ScrapTypes",
                schema: "public",
                columns: table => new
                {
                    ScrapTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrapTypes", x => x.ScrapTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceType",
                schema: "public",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServiceTypeName = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceType", x => x.ServiceID);
                });

            migrationBuilder.CreateTable(
                name: "SheduleDescriptions",
                schema: "public",
                columns: table => new
                {
                    ScheduleDescriptionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CustomerIDs = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheduleDescriptions", x => x.ScheduleDescriptionId);
                });

            migrationBuilder.CreateTable(
                name: "Shedulers",
                schema: "public",
                columns: table => new
                {
                    ShedulerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shedulers", x => x.ShedulerId);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "public",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Role = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.UserRoleId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "public",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Customer_Id = table.Column<string>(type: "text", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    CustomerEmail = table.Column<string>(type: "text", nullable: false),
                    CustomerPassword = table.Column<string>(type: "text", nullable: false),
                    ContactNo = table.Column<string>(type: "text", nullable: false),
                    Website = table.Column<string>(type: "text", nullable: false),
                    ServiceId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: true),
                    Address1 = table.Column<string>(type: "text", nullable: false),
                    Address2 = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Zip = table.Column<string>(type: "text", nullable: false),
                    CustomerImage = table.Column<string>(type: "text", nullable: false),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: true),
                    TimeOffset = table.Column<int>(type: "integer", nullable: true),
                    TimeZone = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_ServiceType_ServiceId",
                        column: x => x.ServiceId,
                        principalSchema: "public",
                        principalTable: "ServiceType",
                        principalColumn: "ServiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                schema: "public",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: true),
                    UserRoleId = table.Column<int>(type: "integer", nullable: false),
                    ContactPerson = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    ContactNo = table.Column<string>(type: "text", nullable: false),
                    EmailAddress = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    IsTempPassword = table.Column<bool>(type: "boolean", nullable: true),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    IsVocationMode = table.Column<bool>(type: "boolean", nullable: true),
                    VacationDateFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    VacationDateTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsEmailNotification = table.Column<bool>(type: "boolean", nullable: false),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: false),
                    IsDragAndDrop = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "public",
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_Accounts_UserRole_UserRoleId",
                        column: x => x.UserRoleId,
                        principalSchema: "public",
                        principalTable: "UserRole",
                        principalColumn: "UserRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalendarEvents",
                schema: "public",
                columns: table => new
                {
                    CalendarEventId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarEvents", x => x.CalendarEventId);
                    table.ForeignKey(
                        name: "FK_CalendarEvents_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "public",
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "CustomerSetting",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: true),
                    IsGrossQuantity = table.Column<bool>(type: "boolean", nullable: false),
                    MachineType = table.Column<int>(type: "integer", nullable: false),
                    IsDownTimeDuration = table.Column<bool>(type: "boolean", nullable: false),
                    IsResolvedNotification = table.Column<bool>(type: "boolean", nullable: false),
                    IsCycletimeMilliSeconds = table.Column<bool>(type: "boolean", nullable: false),
                    CheckMachineType = table.Column<bool>(type: "boolean", nullable: false),
                    CycleTolerance = table.Column<int>(type: "integer", nullable: false),
                    DowntimeTolerance = table.Column<int>(type: "integer", nullable: true),
                    MachineTargetPMM = table.Column<int>(type: "integer", nullable: false),
                    DowntimeCount = table.Column<bool>(type: "boolean", nullable: false),
                    EnableCavity = table.Column<bool>(type: "boolean", nullable: false),
                    Drift = table.Column<bool>(type: "boolean", nullable: false),
                    Scheduler = table.Column<bool>(type: "boolean", nullable: false),
                    DashboardBlink = table.Column<bool>(type: "boolean", nullable: false),
                    ThousandSeperator = table.Column<bool>(type: "boolean", nullable: false),
                    LastCounterCycleTime = table.Column<bool>(type: "boolean", nullable: false),
                    ResetAssingnedPartDate = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerSetting_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "public",
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "CustomerShifts",
                schema: "public",
                columns: table => new
                {
                    ShiftId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: true),
                    ShiftName = table.Column<string>(type: "text", nullable: false),
                    ShiftFrom = table.Column<string>(type: "text", nullable: false),
                    ShiftTo = table.Column<string>(type: "text", nullable: false),
                    Days = table.Column<int>(type: "integer", nullable: false),
                    ScheduleDescriptionID = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Monday = table.Column<bool>(type: "boolean", nullable: true),
                    Tuesday = table.Column<bool>(type: "boolean", nullable: true),
                    Wednesday = table.Column<bool>(type: "boolean", nullable: true),
                    Thursday = table.Column<bool>(type: "boolean", nullable: true),
                    Friday = table.Column<bool>(type: "boolean", nullable: true),
                    Saturday = table.Column<bool>(type: "boolean", nullable: true),
                    Sunday = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerShifts", x => x.ShiftId);
                    table.ForeignKey(
                        name: "FK_CustomerShifts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "public",
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "CustomerWeekDays",
                schema: "public",
                columns: table => new
                {
                    CustomerWeekDayId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: true),
                    Days = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: true),
                    IsChanges = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerWeekDays", x => x.CustomerWeekDayId);
                    table.ForeignKey(
                        name: "FK_CustomerWeekDays_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "public",
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeviceId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    DeviceName = table.Column<string>(type: "text", nullable: false),
                    MachineID = table.Column<int>(type: "integer", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<string>(type: "text", nullable: false),
                    Input7Active = table.Column<bool>(type: "boolean", nullable: true),
                    MachineTime = table.Column<int>(type: "integer", nullable: true),
                    Running = table.Column<bool>(type: "boolean", nullable: true),
                    Alarm = table.Column<bool>(type: "boolean", nullable: true),
                    IsCommunicating = table.Column<bool>(type: "boolean", nullable: true),
                    IsPlanned = table.Column<int>(type: "integer", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsEmailNotification = table.Column<bool>(type: "boolean", nullable: true),
                    TimeZone = table.Column<string>(type: "text", nullable: false),
                    OffsetDifference = table.Column<int>(type: "integer", nullable: true),
                    IsOffSet = table.Column<bool>(type: "boolean", nullable: false),
                    IsMachineType = table.Column<bool>(type: "boolean", nullable: true),
                    IsMassShutdown = table.Column<bool>(type: "boolean", nullable: false),
                    IsCycleTimeRequiredToShow = table.Column<bool>(type: "boolean", nullable: false),
                    Incidents = table.Column<int>(type: "integer", nullable: false),
                    PartNumber = table.Column<string>(type: "text", nullable: false),
                    CalculatedCycleTime = table.Column<string>(type: "text", nullable: false),
                    CompletedQuantity = table.Column<int>(type: "integer", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ETA = table.Column<string>(type: "text", nullable: false),
                    Efficiency = table.Column<int>(type: "integer", nullable: true),
                    RunningDuration = table.Column<string>(type: "text", nullable: false),
                    QtyPercentage = table.Column<int>(type: "integer", nullable: true),
                    DescriptionId = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsChangeOver = table.Column<int>(type: "integer", nullable: false),
                    ChangeOverClr = table.Column<string>(type: "text", nullable: false),
                    DowntimeDurationID = table.Column<int>(type: "integer", nullable: true),
                    DowntimeDuration = table.Column<string>(type: "text", nullable: false),
                    DowntimePercentage = table.Column<int>(type: "integer", nullable: true),
                    SinglePlannedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MassPlannedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DownTimeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ScheduleMaxDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsScheduled = table.Column<bool>(type: "boolean", nullable: false),
                    PressRate = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ShowCheck = table.Column<bool>(type: "boolean", nullable: false),
                    LastCounterCycleTime = table.Column<string>(type: "text", nullable: false),
                    LastCounterEfficiency = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "public",
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineTypes",
                schema: "public",
                columns: table => new
                {
                    MachineId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MachineTypeName = table.Column<string>(type: "text", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: true),
                    WLAN_SSId = table.Column<string>(type: "text", nullable: false),
                    WLAN_Password = table.Column<string>(type: "text", nullable: false),
                    Pulse_Freq = table.Column<bool>(type: "boolean", nullable: true),
                    IsUpdated = table.Column<int>(type: "integer", nullable: true),
                    FTP_UserName = table.Column<string>(type: "text", nullable: false),
                    FTP_Password = table.Column<string>(type: "text", nullable: false),
                    Firm_Update_Required = table.Column<bool>(type: "boolean", nullable: true),
                    Pulse_Values = table.Column<string>(type: "text", nullable: false),
                    ServerIPFirst = table.Column<string>(type: "text", nullable: false),
                    ServerIPSecond = table.Column<string>(type: "text", nullable: false),
                    PortFirst = table.Column<string>(type: "text", nullable: false),
                    PortSecond = table.Column<string>(type: "text", nullable: false),
                    HostName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineTypes", x => x.MachineId);
                    table.ForeignKey(
                        name: "FK_MachineTypes_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "public",
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                schema: "public",
                columns: table => new
                {
                    PartId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GroupID = table.Column<string>(type: "text", nullable: false),
                    PartNumber = table.Column<string>(type: "text", nullable: false),
                    Cavity = table.Column<int>(type: "integer", nullable: true),
                    CycleTime = table.Column<decimal>(type: "numeric", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PartPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    QtyPerSkid = table.Column<int>(type: "integer", nullable: true),
                    ScrapPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    CustomerId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.PartId);
                    table.ForeignKey(
                        name: "FK_Parts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "public",
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "TargetPMMs",
                schema: "public",
                columns: table => new
                {
                    TargetId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HourlyTarget = table.Column<long>(type: "bigint", nullable: true),
                    DailyTarget = table.Column<long>(type: "bigint", nullable: true),
                    MonthlyTarget = table.Column<long>(type: "bigint", nullable: true),
                    YearlyTarget = table.Column<long>(type: "bigint", nullable: true),
                    DownTimeTarget = table.Column<int>(type: "integer", nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CustomerId = table.Column<int>(type: "integer", nullable: true),
                    Shift = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetPMMs", x => x.TargetId);
                    table.ForeignKey(
                        name: "FK_TargetPMMs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "public",
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "DeviceUserReports",
                schema: "public",
                columns: table => new
                {
                    DeviceUserReportId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceUserReports", x => x.DeviceUserReportId);
                    table.ForeignKey(
                        name: "FK_DeviceUserReports_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "public",
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceUserReports_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "public",
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderByDevices",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    Ascending = table.Column<bool>(type: "boolean", nullable: false),
                    Descending = table.Column<bool>(type: "boolean", nullable: false),
                    Customize = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderByDevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderByDevices_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "public",
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuickReportSettings",
                schema: "public",
                columns: table => new
                {
                    QuickReportSettingID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<bool>(type: "boolean", nullable: false),
                    ProductionHours = table.Column<bool>(type: "boolean", nullable: false),
                    PartsProduced = table.Column<bool>(type: "boolean", nullable: false),
                    AvgCycle = table.Column<bool>(type: "boolean", nullable: false),
                    Target = table.Column<bool>(type: "boolean", nullable: false),
                    NoOfIncidents = table.Column<bool>(type: "boolean", nullable: false),
                    Scrap = table.Column<bool>(type: "boolean", nullable: false),
                    TotalCost = table.Column<bool>(type: "boolean", nullable: false),
                    TotalValue = table.Column<bool>(type: "boolean", nullable: false),
                    CycleEfficiency = table.Column<bool>(type: "boolean", nullable: false),
                    ScrapValue = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuickReportSettings", x => x.QuickReportSettingID);
                    table.ForeignKey(
                        name: "FK_QuickReportSettings_Accounts_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportSettings",
                schema: "public",
                columns: table => new
                {
                    ReportSettingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    QuickReport = table.Column<bool>(type: "boolean", nullable: true),
                    PartReport = table.Column<bool>(type: "boolean", nullable: true),
                    ScrapReport = table.Column<bool>(type: "boolean", nullable: true),
                    TrackingReport = table.Column<bool>(type: "boolean", nullable: true),
                    PartProducedReport = table.Column<bool>(type: "boolean", nullable: true),
                    CycleReport = table.Column<bool>(type: "boolean", nullable: true),
                    OverallReport = table.Column<bool>(type: "boolean", nullable: true),
                    DowntimeReasonReport = table.Column<bool>(type: "boolean", nullable: true),
                    DetailedDowntimeReport = table.Column<bool>(type: "boolean", nullable: true),
                    ProductionReportM2 = table.Column<bool>(type: "boolean", nullable: true),
                    ProductionDetailReport = table.Column<bool>(type: "boolean", nullable: true),
                    DailyRevenueReport = table.Column<bool>(type: "boolean", nullable: true),
                    MonthlyRevenueReport = table.Column<bool>(type: "boolean", nullable: true),
                    ProductionReport = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportSettings", x => x.ReportSettingId);
                    table.ForeignKey(
                        name: "FK_ReportSettings_Accounts_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "Accounts",
                        principalColumn: "AccountId");
                });

            migrationBuilder.CreateTable(
                name: "SmartAuthentications",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuthId = table.Column<int>(type: "integer", nullable: true),
                    AccountId = table.Column<int>(type: "integer", nullable: true),
                    AuthToken = table.Column<string>(type: "text", nullable: true),
                    ExpirtDays = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartAuthentications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmartAuthentications_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "public",
                        principalTable: "Accounts",
                        principalColumn: "AccountId");
                });

            migrationBuilder.CreateTable(
                name: "WorkingDays",
                schema: "public",
                columns: table => new
                {
                    WorkDaysId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountId = table.Column<int>(type: "integer", nullable: true),
                    Days = table.Column<string>(type: "text", nullable: true),
                    IsSelected = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingDays", x => x.WorkDaysId);
                    table.ForeignKey(
                        name: "FK_WorkingDays_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "public",
                        principalTable: "Accounts",
                        principalColumn: "AccountId");
                });

            migrationBuilder.CreateTable(
                name: "CalendarShiftTimes",
                schema: "public",
                columns: table => new
                {
                    CalendarShiftTimeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CalendarEventId = table.Column<int>(type: "integer", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: true),
                    ScheduleDescriptionId = table.Column<int>(type: "integer", nullable: true),
                    ShiftId = table.Column<int>(type: "integer", nullable: true),
                    IsApplied = table.Column<int>(type: "integer", nullable: false),
                    IsResetPartDate = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarShiftTimes", x => x.CalendarShiftTimeId);
                    table.ForeignKey(
                        name: "FK_CalendarShiftTimes_CalendarEvents_CalendarEventId",
                        column: x => x.CalendarEventId,
                        principalSchema: "public",
                        principalTable: "CalendarEvents",
                        principalColumn: "CalendarEventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CycleNotifications",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeviceId = table.Column<long>(type: "bigint", nullable: true),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    CustomMessage = table.Column<string>(type: "text", nullable: false),
                    Reminder = table.Column<int>(type: "integer", nullable: true),
                    SentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsNotify = table.Column<bool>(type: "boolean", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CycleNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CycleNotifications_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "public",
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CycleNotifications_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeviceDataMaps",
                schema: "public",
                columns: table => new
                {
                    DevicedataMapId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeviceId = table.Column<long>(type: "bigint", nullable: false),
                    Input = table.Column<string>(type: "text", nullable: false),
                    InputName = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceDataMaps", x => x.DevicedataMapId);
                    table.ForeignKey(
                        name: "FK_DeviceDataMaps_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceDatas",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeviceId = table.Column<long>(type: "bigint", nullable: false),
                    Time = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    PowerOn = table.Column<int>(type: "integer", nullable: false),
                    Ping = table.Column<int>(type: "integer", nullable: false),
                    Offline = table.Column<int>(type: "integer", nullable: false),
                    Counter = table.Column<int>(type: "integer", nullable: false),
                    Input1 = table.Column<int>(type: "integer", nullable: false),
                    Input2 = table.Column<int>(type: "integer", nullable: false),
                    Input3 = table.Column<int>(type: "integer", nullable: false),
                    Input4 = table.Column<int>(type: "integer", nullable: false),
                    Input5 = table.Column<int>(type: "integer", nullable: false),
                    Input6 = table.Column<int>(type: "integer", nullable: false),
                    Input7 = table.Column<int>(type: "integer", nullable: false),
                    Input8 = table.Column<int>(type: "integer", nullable: false),
                    IsProcessed = table.Column<bool>(type: "boolean", nullable: false),
                    CheckDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Scrap = table.Column<int>(type: "integer", nullable: false),
                    GrossQty = table.Column<int>(type: "integer", nullable: false),
                    IsTrackingDay = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceDatas_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceDataTrackings",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeviceId = table.Column<long>(type: "bigint", nullable: false),
                    InputName = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Duration = table.Column<double>(type: "double precision", nullable: true),
                    Reasoncurrent = table.Column<string>(type: "text", nullable: false),
                    Reasonprevious = table.Column<string>(type: "text", nullable: false),
                    Stopduration = table.Column<double>(type: "double precision", nullable: true),
                    IsManual = table.Column<bool>(type: "boolean", nullable: false),
                    CurrentShutdownMasterId = table.Column<int>(type: "integer", nullable: true),
                    PlannedShutdownMasterId = table.Column<int>(type: "integer", nullable: true),
                    TotalCycle = table.Column<int>(type: "integer", nullable: true),
                    CompletedQuantity = table.Column<int>(type: "integer", nullable: true),
                    CycleDuration = table.Column<double>(type: "double precision", nullable: true),
                    Efficiency = table.Column<int>(type: "integer", nullable: true),
                    DowntimeReason = table.Column<string>(type: "text", nullable: false),
                    DtUpdatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceDataTrackings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceDataTrackings_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DragAndDrops",
                schema: "public",
                columns: table => new
                {
                    DragDropId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    XPostion = table.Column<int>(name: "X-Postion", type: "integer", nullable: true),
                    YPostion = table.Column<int>(name: "Y-Postion", type: "integer", nullable: true),
                    ShowId = table.Column<int>(type: "integer", nullable: true),
                    DeviceId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DoubleClick = table.Column<bool>(type: "boolean", nullable: false),
                    DeviceName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DragAndDrops", x => x.DragDropId);
                    table.ForeignKey(
                        name: "FK_DragAndDrops_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "public",
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DragAndDrops_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmailQueues",
                schema: "public",
                columns: table => new
                {
                    EmailQueueId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountId = table.Column<int>(type: "integer", nullable: true),
                    DeviceId = table.Column<long>(type: "bigint", nullable: true),
                    ReasonName = table.Column<string>(type: "text", nullable: true),
                    FromEmail = table.Column<string>(type: "text", nullable: false),
                    ToEmail = table.Column<string>(type: "text", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: true),
                    IsSend = table.Column<bool>(type: "boolean", nullable: true),
                    IsAttachment = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailQueues", x => x.EmailQueueId);
                    table.ForeignKey(
                        name: "FK_EmailQueues_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "public",
                        principalTable: "Accounts",
                        principalColumn: "AccountId");
                    table.ForeignKey(
                        name: "FK_EmailQueues_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GraphDragAndDrops",
                schema: "public",
                columns: table => new
                {
                    GraphDragDropId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    XPosition = table.Column<int>(name: "X-Position", type: "integer", nullable: true),
                    YPosition = table.Column<int>(name: "Y-Position", type: "integer", nullable: true),
                    ShowId = table.Column<int>(type: "integer", nullable: true),
                    DeviceId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    GraphId = table.Column<int>(type: "integer", nullable: true),
                    GraphName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraphDragAndDrops", x => x.GraphDragDropId);
                    table.ForeignKey(
                        name: "FK_GraphDragAndDrops_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "public",
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GraphDragAndDrops_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NotificationHistories",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeviceId = table.Column<long>(type: "bigint", nullable: false),
                    ContactId = table.Column<int>(type: "integer", nullable: false),
                    InputName = table.Column<string>(type: "text", nullable: false),
                    ReasonId = table.Column<int>(type: "integer", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NotificationHistories_Accounts_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "public",
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotificationHistories_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotificationHistories_ScrapTypes_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "public",
                        principalTable: "ScrapTypes",
                        principalColumn: "ScrapTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlannedShutdownDescriptions",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlannedShutdownMasterId = table.Column<int>(type: "integer", nullable: true),
                    DeviceId = table.Column<long>(type: "bigint", nullable: true),
                    EntityType = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedShutdownDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannedShutdownDescriptions_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlannedShutdownDescriptions_PlannedShutdownDescriptionMaste~",
                        column: x => x.PlannedShutdownMasterId,
                        principalSchema: "public",
                        principalTable: "PlannedShutdownDescriptionMasters",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "SchedulerUpdates",
                schema: "public",
                columns: table => new
                {
                    SchedulerUpdateId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: true),
                    AccountId = table.Column<int>(type: "integer", nullable: true),
                    IsSchedulerUpdate = table.Column<bool>(type: "boolean", nullable: false),
                    IsChanges = table.Column<bool>(type: "boolean", nullable: false),
                    IsUpdated = table.Column<bool>(type: "boolean", nullable: false),
                    DeviceId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulerUpdates", x => x.SchedulerUpdateId);
                    table.ForeignKey(
                        name: "FK_SchedulerUpdates_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "public",
                        principalTable: "Accounts",
                        principalColumn: "AccountId");
                    table.ForeignKey(
                        name: "FK_SchedulerUpdates_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "public",
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_SchedulerUpdates_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeviceConfigs",
                schema: "public",
                columns: table => new
                {
                    DeviceConfigId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeviceId = table.Column<long>(type: "bigint", nullable: true),
                    MachineId = table.Column<int>(type: "integer", nullable: true),
                    WLAN_SSID = table.Column<string>(type: "text", nullable: false),
                    WLAN_Password = table.Column<string>(type: "text", nullable: false),
                    Pulse_Values = table.Column<string>(type: "text", nullable: false),
                    Pulse_Freq = table.Column<bool>(type: "boolean", nullable: true),
                    IsUpdated = table.Column<int>(type: "integer", nullable: true),
                    FTP_UserName = table.Column<string>(type: "text", nullable: false),
                    FTP_Password = table.Column<string>(type: "text", nullable: false),
                    ServerIPFirst = table.Column<string>(type: "text", nullable: false),
                    ServerIPSecond = table.Column<string>(type: "text", nullable: false),
                    PortFirst = table.Column<string>(type: "text", nullable: false),
                    PortSecond = table.Column<string>(type: "text", nullable: false),
                    ConfigPortOne = table.Column<string>(type: "text", nullable: false),
                    ConfigPortTwo = table.Column<string>(type: "text", nullable: false),
                    HostName = table.Column<string>(type: "text", nullable: false),
                    FtpFolder = table.Column<string>(type: "text", nullable: false),
                    ConfigIp1Address = table.Column<string>(type: "text", nullable: false),
                    ConfigIp2Address = table.Column<string>(type: "text", nullable: false),
                    Firm_Update_Required = table.Column<bool>(type: "boolean", nullable: false),
                    ClientIPAddress = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeviceUpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ErrorLog = table.Column<string>(type: "text", nullable: false),
                    FirmwareUpdateNo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceConfigs", x => x.DeviceConfigId);
                    table.ForeignKey(
                        name: "FK_DeviceConfigs_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeviceConfigs_MachineTypes_MachineId",
                        column: x => x.MachineId,
                        principalSchema: "public",
                        principalTable: "MachineTypes",
                        principalColumn: "MachineId");
                });

            migrationBuilder.CreateTable(
                name: "MachineTypeInputs",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MachineTypeId = table.Column<int>(type: "integer", nullable: false),
                    InputNo = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<decimal>(type: "numeric(3,0)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Priority = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    FlashSpeed = table.Column<string>(type: "text", nullable: false),
                    Sound = table.Column<string>(type: "text", nullable: false),
                    Delay = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineTypeInputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineTypeInputs_MachineTypes_MachineTypeId",
                        column: x => x.MachineTypeId,
                        principalSchema: "public",
                        principalTable: "MachineTypes",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssignedParts",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PartId = table.Column<int>(type: "integer", nullable: true),
                    DeviceId = table.Column<long>(type: "bigint", nullable: true),
                    Cavity = table.Column<int>(type: "integer", nullable: true),
                    CycleTime = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    RequiredQuantity = table.Column<int>(type: "integer", nullable: true),
                    CompletedQuantity = table.Column<int>(type: "integer", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RunningDuration = table.Column<string>(type: "text", nullable: false),
                    ETA = table.Column<string>(type: "text", nullable: false),
                    Scrap = table.Column<int>(type: "integer", nullable: true),
                    CurrentScrap = table.Column<int>(type: "integer", nullable: true),
                    CalculatedCycleTime = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: true),
                    AssignedPartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Efficiency = table.Column<int>(type: "integer", nullable: true),
                    QtyPercentage = table.Column<int>(type: "integer", nullable: true),
                    DowntimeDurationID = table.Column<int>(type: "integer", nullable: true),
                    DowntimeDuration = table.Column<string>(type: "text", nullable: false),
                    DowntimePercentage = table.Column<int>(type: "integer", nullable: true),
                    GrossQty = table.Column<int>(type: "integer", nullable: false),
                    NotesID = table.Column<int>(type: "integer", nullable: true),
                    ResetAssignedPardDate = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignedParts_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AssignedParts_Parts_PartId",
                        column: x => x.PartId,
                        principalSchema: "public",
                        principalTable: "Parts",
                        principalColumn: "PartId");
                });

            migrationBuilder.CreateTable(
                name: "AssignedPartsHistories",
                schema: "public",
                columns: table => new
                {
                    HistoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PartId = table.Column<int>(type: "integer", nullable: true),
                    DeviceId = table.Column<long>(type: "bigint", nullable: true),
                    Cavity = table.Column<int>(type: "integer", nullable: true),
                    CycleTime = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    RequiredQuantity = table.Column<int>(type: "integer", nullable: true),
                    CompletedQuantity = table.Column<int>(type: "integer", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RunningDuration = table.Column<string>(type: "text", nullable: false),
                    ETA = table.Column<string>(type: "text", nullable: false),
                    Scrap = table.Column<int>(type: "integer", nullable: true),
                    CurrentScrap = table.Column<int>(type: "integer", nullable: true),
                    CalculatedCycleTime = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: true),
                    AssignedPartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Efficiency = table.Column<int>(type: "integer", nullable: true),
                    QtyPercentage = table.Column<int>(type: "integer", nullable: true),
                    DowntimeDurationID = table.Column<int>(type: "integer", nullable: true),
                    DowntimeDuration = table.Column<string>(type: "text", nullable: false),
                    DowntimePercentage = table.Column<int>(type: "integer", nullable: true),
                    GrossQty = table.Column<int>(type: "integer", nullable: false),
                    BackupData = table.Column<int>(type: "integer", nullable: true),
                    NotesId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedPartsHistories", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_AssignedPartsHistories_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AssignedPartsHistories_Parts_PartId",
                        column: x => x.PartId,
                        principalSchema: "public",
                        principalTable: "Parts",
                        principalColumn: "PartId");
                });

            migrationBuilder.CreateTable(
                name: "CycleMaintenances",
                schema: "public",
                columns: table => new
                {
                    CycleMaintenanceId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeviceId = table.Column<long>(type: "bigint", nullable: false),
                    PartId = table.Column<int>(type: "integer", nullable: false),
                    MachineTypeId = table.Column<int>(type: "integer", nullable: true),
                    CustomerId = table.Column<int>(type: "integer", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MaintenanceCount = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CycleMaintenances", x => x.CycleMaintenanceId);
                    table.ForeignKey(
                        name: "FK_CycleMaintenances_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "public",
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_CycleMaintenances_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CycleMaintenances_Parts_PartId",
                        column: x => x.PartId,
                        principalSchema: "public",
                        principalTable: "Parts",
                        principalColumn: "PartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceTrackingDays",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeviceId = table.Column<long>(type: "bigint", nullable: false),
                    PartId = table.Column<int>(type: "integer", nullable: true),
                    PartNumber = table.Column<string>(type: "text", nullable: true),
                    InputName = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Duration = table.Column<double>(type: "double precision", nullable: true),
                    Reasoncurrent = table.Column<string>(type: "text", nullable: false),
                    Reasonprevious = table.Column<string>(type: "text", nullable: false),
                    CurrentShutdownMasterID = table.Column<int>(type: "integer", nullable: true),
                    PlannedShutdownMasterID = table.Column<int>(type: "integer", nullable: true),
                    Stopduration = table.Column<double>(type: "double precision", nullable: true),
                    IsManual = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTrackingDays", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DeviceTrackingDays_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceTrackingDays_Parts_PartId",
                        column: x => x.PartId,
                        principalSchema: "public",
                        principalTable: "Parts",
                        principalColumn: "PartId");
                });

            migrationBuilder.CreateTable(
                name: "PartsHistories",
                schema: "public",
                columns: table => new
                {
                    PartsHistoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PartId = table.Column<int>(type: "integer", nullable: false),
                    GroupID = table.Column<string>(type: "text", nullable: false),
                    PartNumber = table.Column<string>(type: "text", nullable: false),
                    Cavity = table.Column<int>(type: "integer", nullable: true),
                    CycleTime = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PartPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    QtyPerSkid = table.Column<int>(type: "integer", nullable: true),
                    ScrapPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsHistories", x => x.PartsHistoryId);
                    table.ForeignKey(
                        name: "FK_PartsHistories_Parts_PartId",
                        column: x => x.PartId,
                        principalSchema: "public",
                        principalTable: "Parts",
                        principalColumn: "PartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RemovedAssignedParts",
                schema: "public",
                columns: table => new
                {
                    RemoveId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PartId = table.Column<int>(type: "integer", nullable: true),
                    DeviceId = table.Column<long>(type: "bigint", nullable: true),
                    Cavity = table.Column<int>(type: "integer", nullable: true),
                    CycleTime = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    RequiredQuantity = table.Column<int>(type: "integer", nullable: true),
                    CompletedQuantity = table.Column<int>(type: "integer", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RunningDuration = table.Column<string>(type: "text", nullable: true),
                    ETA = table.Column<string>(type: "text", nullable: true),
                    Scrap = table.Column<int>(type: "integer", nullable: true),
                    CurrentScrap = table.Column<int>(type: "integer", nullable: true),
                    CalculatedCycleTime = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<bool>(type: "boolean", nullable: true),
                    AssignedPartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Efficiency = table.Column<int>(type: "integer", nullable: true),
                    QtyPercentage = table.Column<int>(type: "integer", nullable: true),
                    DownTimeDurationId = table.Column<int>(type: "integer", nullable: true),
                    DowntimeDuration = table.Column<string>(type: "text", nullable: true),
                    DownTimePercentage = table.Column<int>(type: "integer", nullable: true),
                    GrossQty = table.Column<int>(type: "integer", nullable: false),
                    BackupData = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemovedAssignedParts", x => x.RemoveId);
                    table.ForeignKey(
                        name: "FK_RemovedAssignedParts_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RemovedAssignedParts_Parts_PartId",
                        column: x => x.PartId,
                        principalSchema: "public",
                        principalTable: "Parts",
                        principalColumn: "PartId");
                });

            migrationBuilder.CreateTable(
                name: "SchedulerNotes",
                schema: "public",
                columns: table => new
                {
                    NotesId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeviceId = table.Column<long>(type: "bigint", nullable: true),
                    PartId = table.Column<int>(type: "integer", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    CustomerId = table.Column<int>(type: "integer", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulerNotes", x => x.NotesId);
                    table.ForeignKey(
                        name: "FK_SchedulerNotes_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SchedulerNotes_Parts_PartId",
                        column: x => x.PartId,
                        principalSchema: "public",
                        principalTable: "Parts",
                        principalColumn: "PartId");
                });

            migrationBuilder.CreateTable(
                name: "ScrapHistories",
                schema: "public",
                columns: table => new
                {
                    ScrapHistoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PartId = table.Column<int>(type: "integer", nullable: false),
                    DeviceId = table.Column<long>(type: "bigint", nullable: true),
                    ScrapCount = table.Column<int>(type: "integer", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ScrapReason = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrapHistories", x => x.ScrapHistoryId);
                    table.ForeignKey(
                        name: "FK_ScrapHistories_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScrapHistories_Parts_PartId",
                        column: x => x.PartId,
                        principalSchema: "public",
                        principalTable: "Parts",
                        principalColumn: "PartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scraps",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PartId = table.Column<int>(type: "integer", nullable: false),
                    DeviceId = table.Column<long>(type: "bigint", nullable: true),
                    ScrapCount = table.Column<int>(type: "integer", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ScrapReason = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scraps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scraps_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Scraps_Parts_PartId",
                        column: x => x.PartId,
                        principalSchema: "public",
                        principalTable: "Parts",
                        principalColumn: "PartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skids",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PartId = table.Column<int>(type: "integer", nullable: false),
                    DeviceId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skids_Accounts_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "Accounts",
                        principalColumn: "AccountId");
                    table.ForeignKey(
                        name: "FK_Skids_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skids_Parts_PartId",
                        column: x => x.PartId,
                        principalSchema: "public",
                        principalTable: "Parts",
                        principalColumn: "PartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SmartSchedulerPlans",
                schema: "public",
                columns: table => new
                {
                    SmartSchedulerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PartNumber = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RequiredQuantity = table.Column<int>(type: "integer", nullable: false),
                    IsUpdated = table.Column<bool>(type: "boolean", nullable: false),
                    IsShutdown = table.Column<int>(type: "integer", nullable: false),
                    ShutdownName = table.Column<string>(type: "text", nullable: true),
                    IsUpdatePartNumber = table.Column<int>(type: "integer", nullable: false),
                    ScheduleMaxDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsSplited = table.Column<bool>(type: "boolean", nullable: false),
                    NotesId = table.Column<int>(type: "integer", nullable: true),
                    DeviceId = table.Column<long>(type: "bigint", nullable: false),
                    PartId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartSchedulerPlans", x => x.SmartSchedulerId);
                    table.ForeignKey(
                        name: "FK_SmartSchedulerPlans_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SmartSchedulerPlans_Parts_PartId",
                        column: x => x.PartId,
                        principalSchema: "public",
                        principalTable: "Parts",
                        principalColumn: "PartId");
                });

            migrationBuilder.CreateTable(
                name: "ToolingIds",
                schema: "public",
                columns: table => new
                {
                    ToolingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ToolingNumber = table.Column<string>(type: "text", nullable: true),
                    PartId = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolingIds", x => x.ToolingId);
                    table.ForeignKey(
                        name: "FK_ToolingIds_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "public",
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToolingIds_Parts_PartId",
                        column: x => x.PartId,
                        principalSchema: "public",
                        principalTable: "Parts",
                        principalColumn: "PartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceUserReportAccounts",
                schema: "public",
                columns: table => new
                {
                    DeviceUserReportAccountId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeviceUserReportId = table.Column<int>(type: "integer", nullable: false),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedDae = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceUserReportAccounts", x => x.DeviceUserReportAccountId);
                    table.ForeignKey(
                        name: "FK_DeviceUserReportAccounts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "public",
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceUserReportAccounts_DeviceUserReports_DeviceUserReport~",
                        column: x => x.DeviceUserReportId,
                        principalSchema: "public",
                        principalTable: "DeviceUserReports",
                        principalColumn: "DeviceUserReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceUserReportMaps",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeviceUserReportId = table.Column<int>(type: "integer", nullable: true),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    DeviceId = table.Column<long>(type: "bigint", nullable: false),
                    ReportTypeId = table.Column<int>(type: "integer", nullable: false),
                    ReportNotificationTypeId = table.Column<int>(type: "integer", nullable: false),
                    ReportValueTypeId = table.Column<int>(type: "integer", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: false),
                    ContactHourFrom = table.Column<string>(type: "text", nullable: true),
                    ContactHourTo = table.Column<string>(type: "text", nullable: true),
                    ReceiveAt = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ReportFormat = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceUserReportMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceUserReportMaps_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "public",
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceUserReportMaps_DeviceUserReports_DeviceUserReportId",
                        column: x => x.DeviceUserReportId,
                        principalSchema: "public",
                        principalTable: "DeviceUserReports",
                        principalColumn: "DeviceUserReportId");
                    table.ForeignKey(
                        name: "FK_DeviceUserReportMaps_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceUserReportMaps_ReportNotificationTypes_ReportNotifica~",
                        column: x => x.ReportNotificationTypeId,
                        principalSchema: "public",
                        principalTable: "ReportNotificationTypes",
                        principalColumn: "ReportNotificationTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceUserReportMaps_ReportType_ReportTypeId",
                        column: x => x.ReportTypeId,
                        principalSchema: "public",
                        principalTable: "ReportType",
                        principalColumn: "ReportTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceUserReportMaps_ReportValueType_ReportValueTypeId",
                        column: x => x.ReportValueTypeId,
                        principalSchema: "public",
                        principalTable: "ReportValueType",
                        principalColumn: "ReportValueTypeId");
                });

            migrationBuilder.CreateTable(
                name: "DeviceDataUserMaps",
                schema: "public",
                columns: table => new
                {
                    DeviceDataUserMapId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeviceDataMapId = table.Column<int>(type: "integer", nullable: true),
                    Contact = table.Column<int>(type: "integer", nullable: true),
                    ContactHourFrom = table.Column<string>(type: "text", nullable: true),
                    ContactHourTo = table.Column<string>(type: "text", nullable: true),
                    TimeDelay = table.Column<int>(type: "integer", nullable: true),
                    Remainder = table.Column<int>(type: "integer", nullable: true),
                    IsNotification = table.Column<int>(type: "integer", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceDataUserMaps", x => x.DeviceDataUserMapId);
                    table.ForeignKey(
                        name: "FK_DeviceDataUserMaps_DeviceDataMaps_DeviceDataMapId",
                        column: x => x.DeviceDataMapId,
                        principalSchema: "public",
                        principalTable: "DeviceDataMaps",
                        principalColumn: "DevicedataMapId");
                });

            migrationBuilder.CreateTable(
                name: "DeviceDataHistories",
                schema: "public",
                columns: table => new
                {
                    HistoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeviceDataId = table.Column<int>(type: "integer", nullable: false),
                    DeviceID = table.Column<long>(type: "bigint", nullable: false),
                    Time = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    PowerOn = table.Column<int>(type: "integer", nullable: false),
                    Ping = table.Column<int>(type: "integer", nullable: false),
                    Offline = table.Column<int>(type: "integer", nullable: false),
                    Counter = table.Column<int>(type: "integer", nullable: false),
                    Input1 = table.Column<int>(type: "integer", nullable: false),
                    Input2 = table.Column<int>(type: "integer", nullable: false),
                    Input3 = table.Column<int>(type: "integer", nullable: false),
                    Input4 = table.Column<int>(type: "integer", nullable: false),
                    Input5 = table.Column<int>(type: "integer", nullable: false),
                    Input6 = table.Column<int>(type: "integer", nullable: false),
                    Input7 = table.Column<int>(type: "integer", nullable: false),
                    Input8 = table.Column<int>(type: "integer", nullable: false),
                    IsProcessed = table.Column<bool>(type: "boolean", nullable: false),
                    CheckDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Scrap = table.Column<int>(type: "integer", nullable: false),
                    GrossQty = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceDataHistories", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_DeviceDataHistories_DeviceDatas_DeviceDataId",
                        column: x => x.DeviceDataId,
                        principalSchema: "public",
                        principalTable: "DeviceDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceDataHistories_Devices_DeviceID",
                        column: x => x.DeviceID,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceDataTrackingHistories",
                schema: "public",
                columns: table => new
                {
                    HistoryID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeviceDataId = table.Column<int>(type: "integer", nullable: false),
                    DeviceID = table.Column<long>(type: "bigint", nullable: false),
                    InputName = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Duration = table.Column<double>(type: "double precision", nullable: true),
                    Reasoncurrent = table.Column<string>(type: "text", nullable: false),
                    Reasonprevious = table.Column<string>(type: "text", nullable: true),
                    Stopduration = table.Column<double>(type: "double precision", nullable: true),
                    IsManual = table.Column<bool>(type: "boolean", nullable: false),
                    CurrentShutdownMasterID = table.Column<int>(type: "integer", nullable: true),
                    PlannedShutdownMasterID = table.Column<int>(type: "integer", nullable: true),
                    TotalCycle = table.Column<int>(type: "integer", nullable: true),
                    CompletedQuantity = table.Column<int>(type: "integer", nullable: true),
                    CycleDuration = table.Column<double>(type: "double precision", nullable: true),
                    Efficiency = table.Column<int>(type: "integer", nullable: true),
                    DowntimeReason = table.Column<string>(type: "text", nullable: true),
                    DtUpdatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceDataTrackingHistories", x => x.HistoryID);
                    table.ForeignKey(
                        name: "FK_DeviceDataTrackingHistories_DeviceDatas_DeviceDataId",
                        column: x => x.DeviceDataId,
                        principalSchema: "public",
                        principalTable: "DeviceDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceDataTrackingHistories_Devices_DeviceID",
                        column: x => x.DeviceID,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailAttachments",
                schema: "public",
                columns: table => new
                {
                    EmailAttachmentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmailQueueId = table.Column<int>(type: "integer", nullable: false),
                    EntityType = table.Column<string>(type: "text", nullable: true),
                    EntityId = table.Column<int>(type: "integer", nullable: true),
                    AttachmentPath = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAttachments", x => x.EmailAttachmentId);
                    table.ForeignKey(
                        name: "FK_EmailAttachments_EmailQueues_EmailQueueId",
                        column: x => x.EmailQueueId,
                        principalSchema: "public",
                        principalTable: "EmailQueues",
                        principalColumn: "EmailQueueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceConfigDetails",
                schema: "public",
                columns: table => new
                {
                    DeviceConfigDetailsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeviceConfigId = table.Column<long>(type: "bigint", nullable: true),
                    Input_No = table.Column<string>(type: "text", nullable: false),
                    Priority = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    Flash_Speed = table.Column<string>(type: "text", nullable: false),
                    Sound = table.Column<string>(type: "text", nullable: false),
                    Delay = table.Column<string>(type: "text", nullable: false),
                    ChangeOver = table.Column<bool>(type: "boolean", nullable: false),
                    Scrap = table.Column<bool>(type: "boolean", nullable: false),
                    HexColor = table.Column<string>(type: "text", nullable: false),
                    OFFDelay = table.Column<string>(type: "text", nullable: false),
                    Backtrack = table.Column<bool>(type: "boolean", nullable: false),
                    ChangeOverButton = table.Column<bool>(type: "boolean", nullable: false),
                    DowntimeIncident = table.Column<bool>(type: "boolean", nullable: false),
                    ScrapFullCycle = table.Column<bool>(type: "boolean", nullable: false),
                    InputPartReset = table.Column<bool>(type: "boolean", nullable: false),
                    DefaultTime = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceConfigDetails", x => x.DeviceConfigDetailsId);
                    table.ForeignKey(
                        name: "FK_DeviceConfigDetails_DeviceConfigs_DeviceConfigId",
                        column: x => x.DeviceConfigId,
                        principalSchema: "public",
                        principalTable: "DeviceConfigs",
                        principalColumn: "DeviceConfigId");
                });

            migrationBuilder.CreateTable(
                name: "AssignMultiParts",
                schema: "public",
                columns: table => new
                {
                    AssignMultiPartId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AssignPartId = table.Column<int>(type: "integer", nullable: true),
                    PartId = table.Column<int>(type: "integer", nullable: true),
                    RequiredQuantity = table.Column<int>(type: "integer", nullable: true),
                    CycleTime = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    Cavity = table.Column<int>(type: "integer", nullable: true),
                    DeviceId = table.Column<long>(type: "bigint", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<bool>(type: "boolean", nullable: true),
                    NoOfSkids = table.Column<int>(type: "integer", nullable: true),
                    IsJobUpdated = table.Column<bool>(type: "boolean", nullable: true),
                    JobUpdatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    QtyPerSkid = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignMultiParts", x => x.AssignMultiPartId);
                    table.ForeignKey(
                        name: "FK_AssignMultiParts_AssignedParts_AssignPartId",
                        column: x => x.AssignPartId,
                        principalSchema: "public",
                        principalTable: "AssignedParts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AssignMultiParts_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AssignMultiParts_Parts_PartId",
                        column: x => x.PartId,
                        principalSchema: "public",
                        principalTable: "Parts",
                        principalColumn: "PartId");
                });

            migrationBuilder.CreateTable(
                name: "InputBasedCounterHistories",
                schema: "public",
                columns: table => new
                {
                    HistoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AssignedPartId = table.Column<int>(type: "integer", nullable: true),
                    DeviceId = table.Column<long>(type: "bigint", nullable: true),
                    Input = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Counter = table.Column<int>(type: "integer", nullable: true),
                    DefaultTime = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputBasedCounterHistories", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_InputBasedCounterHistories_AssignedParts_AssignedPartId",
                        column: x => x.AssignedPartId,
                        principalSchema: "public",
                        principalTable: "AssignedParts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InputBasedCounterHistories_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InputBasedCounters",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AssignedPartId = table.Column<int>(type: "integer", nullable: true),
                    DeviceId = table.Column<long>(type: "bigint", nullable: true),
                    Input = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Counter = table.Column<int>(type: "integer", nullable: true),
                    DefaultTime = table.Column<long>(type: "bigint", nullable: true),
                    IsProcessed = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputBasedCounters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputBasedCounters_AssignedParts_AssignedPartId",
                        column: x => x.AssignedPartId,
                        principalSchema: "public",
                        principalTable: "AssignedParts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InputBasedCounters_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CycleUserMaps",
                schema: "public",
                columns: table => new
                {
                    CycleUserMapId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CycleMaintenanceId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ReportValueTypeId = table.Column<int>(type: "integer", nullable: true),
                    ReportValue = table.Column<int>(type: "integer", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: true),
                    Remainder = table.Column<int>(type: "integer", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CycleUserMaps", x => x.CycleUserMapId);
                    table.ForeignKey(
                        name: "FK_CycleUserMaps_Accounts_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CycleUserMaps_CycleMaintenances_CycleMaintenanceId",
                        column: x => x.CycleMaintenanceId,
                        principalSchema: "public",
                        principalTable: "CycleMaintenances",
                        principalColumn: "CycleMaintenanceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceTrackingDaysHistories",
                schema: "public",
                columns: table => new
                {
                    HistoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeviceTrackingDaysId = table.Column<int>(type: "integer", nullable: false),
                    DeviceId = table.Column<long>(type: "bigint", nullable: false),
                    PartId = table.Column<int>(type: "integer", nullable: true),
                    PartNumber = table.Column<string>(type: "text", nullable: false),
                    InputName = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Duration = table.Column<double>(type: "double precision", nullable: true),
                    Reasoncurrent = table.Column<string>(type: "text", nullable: false),
                    Reasonprevious = table.Column<string>(type: "text", nullable: false),
                    CurrentShutdownMasterID = table.Column<int>(type: "integer", nullable: true),
                    PlannedShutdownMasterID = table.Column<int>(type: "integer", nullable: true),
                    StopDuration = table.Column<double>(type: "double precision", nullable: true),
                    IsManual = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTrackingDaysHistories", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_DeviceTrackingDaysHistories_DeviceTrackingDays_DeviceTracki~",
                        column: x => x.DeviceTrackingDaysId,
                        principalSchema: "public",
                        principalTable: "DeviceTrackingDays",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceTrackingDaysHistories_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceTrackingDaysHistories_Parts_PartId",
                        column: x => x.PartId,
                        principalSchema: "public",
                        principalTable: "Parts",
                        principalColumn: "PartId");
                });

            migrationBuilder.CreateTable(
                name: "SmartSchedulerSplitPlans",
                schema: "public",
                columns: table => new
                {
                    SmartSchedulerSplitId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SmartSchedulerId = table.Column<int>(type: "integer", nullable: false),
                    DeviceId = table.Column<long>(type: "bigint", nullable: false),
                    PartId = table.Column<int>(type: "integer", nullable: true),
                    PartNumber = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RequiredQuantity = table.Column<int>(type: "integer", nullable: false),
                    IsUpdated = table.Column<bool>(type: "boolean", nullable: false),
                    IsShutdown = table.Column<int>(type: "integer", nullable: false),
                    ShutdownName = table.Column<string>(type: "text", nullable: true),
                    IsUpdatePartNumber = table.Column<int>(type: "integer", nullable: false),
                    ScheduleMaxDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsSplited = table.Column<bool>(type: "boolean", nullable: false),
                    NotesId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartSchedulerSplitPlans", x => x.SmartSchedulerSplitId);
                    table.ForeignKey(
                        name: "FK_SmartSchedulerSplitPlans_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SmartSchedulerSplitPlans_Parts_PartId",
                        column: x => x.PartId,
                        principalSchema: "public",
                        principalTable: "Parts",
                        principalColumn: "PartId");
                    table.ForeignKey(
                        name: "FK_SmartSchedulerSplitPlans_SmartSchedulerPlans_SmartScheduler~",
                        column: x => x.SmartSchedulerId,
                        principalSchema: "public",
                        principalTable: "SmartSchedulerPlans",
                        principalColumn: "SmartSchedulerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificationOlds",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeviceId = table.Column<long>(type: "bigint", nullable: true),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    DeviceDataUserMapId = table.Column<int>(type: "integer", nullable: true),
                    InputName = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: true),
                    CustomMessage = table.Column<string>(type: "text", nullable: true),
                    ContactFromHours = table.Column<string>(type: "text", nullable: true),
                    ContactToHours = table.Column<string>(type: "text", nullable: true),
                    Reminder = table.Column<int>(type: "integer", nullable: true),
                    SentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsNotify = table.Column<bool>(type: "boolean", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    EntityType = table.Column<int>(type: "integer", nullable: true),
                    CompletedReason = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RowNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationOlds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationOlds_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "public",
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotificationOlds_DeviceDataUserMaps_DeviceDataUserMapId",
                        column: x => x.DeviceDataUserMapId,
                        principalSchema: "public",
                        principalTable: "DeviceDataUserMaps",
                        principalColumn: "DeviceDataUserMapId");
                    table.ForeignKey(
                        name: "FK_NotificationOlds_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeviceId = table.Column<long>(type: "bigint", nullable: true),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    DeviceDataUserMapId = table.Column<int>(type: "integer", nullable: true),
                    InputName = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: true),
                    CustomMessage = table.Column<string>(type: "text", nullable: true),
                    ContactFromHours = table.Column<string>(type: "text", nullable: true),
                    ContactToHours = table.Column<string>(type: "text", nullable: true),
                    Reminder = table.Column<int>(type: "integer", nullable: true),
                    SentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsNotify = table.Column<bool>(type: "boolean", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    EntityType = table.Column<int>(type: "integer", nullable: true),
                    CompletedReason = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RowNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "public",
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_DeviceDataUserMaps_DeviceDataUserMapId",
                        column: x => x.DeviceDataUserMapId,
                        principalSchema: "public",
                        principalTable: "DeviceDataUserMaps",
                        principalColumn: "DeviceDataUserMapId");
                    table.ForeignKey(
                        name: "FK_Notifications_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "public",
                        principalTable: "Devices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CustomerId",
                schema: "public",
                table: "Accounts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserRoleId",
                schema: "public",
                table: "Accounts",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedParts_DeviceId",
                schema: "public",
                table: "AssignedParts",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedParts_PartId",
                schema: "public",
                table: "AssignedParts",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedPartsHistories_DeviceId",
                schema: "public",
                table: "AssignedPartsHistories",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedPartsHistories_PartId",
                schema: "public",
                table: "AssignedPartsHistories",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignMultiParts_AssignPartId",
                schema: "public",
                table: "AssignMultiParts",
                column: "AssignPartId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignMultiParts_DeviceId",
                schema: "public",
                table: "AssignMultiParts",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignMultiParts_PartId",
                schema: "public",
                table: "AssignMultiParts",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEvents_CustomerId",
                schema: "public",
                table: "CalendarEvents",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarShiftTimes_CalendarEventId",
                schema: "public",
                table: "CalendarShiftTimes",
                column: "CalendarEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ServiceId",
                schema: "public",
                table: "Customers",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSetting_CustomerId",
                schema: "public",
                table: "CustomerSetting",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerShifts_CustomerId",
                schema: "public",
                table: "CustomerShifts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerWeekDays_CustomerId",
                schema: "public",
                table: "CustomerWeekDays",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CycleMaintenances_CustomerId",
                schema: "public",
                table: "CycleMaintenances",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CycleMaintenances_DeviceId",
                schema: "public",
                table: "CycleMaintenances",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_CycleMaintenances_PartId",
                schema: "public",
                table: "CycleMaintenances",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_CycleNotifications_AccountId",
                schema: "public",
                table: "CycleNotifications",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CycleNotifications_DeviceId",
                schema: "public",
                table: "CycleNotifications",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_CycleUserMaps_CycleMaintenanceId",
                schema: "public",
                table: "CycleUserMaps",
                column: "CycleMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_CycleUserMaps_UserId",
                schema: "public",
                table: "CycleUserMaps",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceConfigDetails_DeviceConfigId",
                schema: "public",
                table: "DeviceConfigDetails",
                column: "DeviceConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceConfigs_DeviceId",
                schema: "public",
                table: "DeviceConfigs",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceConfigs_MachineId",
                schema: "public",
                table: "DeviceConfigs",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDataHistories_DeviceDataId",
                schema: "public",
                table: "DeviceDataHistories",
                column: "DeviceDataId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDataHistories_DeviceID",
                schema: "public",
                table: "DeviceDataHistories",
                column: "DeviceID");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDataMaps_DeviceId",
                schema: "public",
                table: "DeviceDataMaps",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDatas_DeviceId",
                schema: "public",
                table: "DeviceDatas",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDataTrackingHistories_DeviceDataId",
                schema: "public",
                table: "DeviceDataTrackingHistories",
                column: "DeviceDataId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDataTrackingHistories_DeviceID",
                schema: "public",
                table: "DeviceDataTrackingHistories",
                column: "DeviceID");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDataTrackings_DeviceId",
                schema: "public",
                table: "DeviceDataTrackings",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceDataUserMaps_DeviceDataMapId",
                schema: "public",
                table: "DeviceDataUserMaps",
                column: "DeviceDataMapId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_CustomerId",
                schema: "public",
                table: "Devices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceTrackingDays_DeviceId",
                schema: "public",
                table: "DeviceTrackingDays",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceTrackingDays_PartId",
                schema: "public",
                table: "DeviceTrackingDays",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceTrackingDaysHistories_DeviceId",
                schema: "public",
                table: "DeviceTrackingDaysHistories",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceTrackingDaysHistories_DeviceTrackingDaysId",
                schema: "public",
                table: "DeviceTrackingDaysHistories",
                column: "DeviceTrackingDaysId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceTrackingDaysHistories_PartId",
                schema: "public",
                table: "DeviceTrackingDaysHistories",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceUserReportAccounts_AccountId",
                schema: "public",
                table: "DeviceUserReportAccounts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceUserReportAccounts_DeviceUserReportId",
                schema: "public",
                table: "DeviceUserReportAccounts",
                column: "DeviceUserReportId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceUserReportMaps_AccountId",
                schema: "public",
                table: "DeviceUserReportMaps",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceUserReportMaps_DeviceId",
                schema: "public",
                table: "DeviceUserReportMaps",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceUserReportMaps_DeviceUserReportId",
                schema: "public",
                table: "DeviceUserReportMaps",
                column: "DeviceUserReportId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceUserReportMaps_ReportNotificationTypeId",
                schema: "public",
                table: "DeviceUserReportMaps",
                column: "ReportNotificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceUserReportMaps_ReportTypeId",
                schema: "public",
                table: "DeviceUserReportMaps",
                column: "ReportTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceUserReportMaps_ReportValueTypeId",
                schema: "public",
                table: "DeviceUserReportMaps",
                column: "ReportValueTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceUserReports_AccountId",
                schema: "public",
                table: "DeviceUserReports",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceUserReports_CustomerId",
                schema: "public",
                table: "DeviceUserReports",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DragAndDrops_AccountId",
                schema: "public",
                table: "DragAndDrops",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_DragAndDrops_DeviceId",
                schema: "public",
                table: "DragAndDrops",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAttachments_EmailQueueId",
                schema: "public",
                table: "EmailAttachments",
                column: "EmailQueueId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailQueues_AccountId",
                schema: "public",
                table: "EmailQueues",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailQueues_DeviceId",
                schema: "public",
                table: "EmailQueues",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_GraphDragAndDrops_AccountId",
                schema: "public",
                table: "GraphDragAndDrops",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_GraphDragAndDrops_DeviceId",
                schema: "public",
                table: "GraphDragAndDrops",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_InputBasedCounterHistories_AssignedPartId",
                schema: "public",
                table: "InputBasedCounterHistories",
                column: "AssignedPartId");

            migrationBuilder.CreateIndex(
                name: "IX_InputBasedCounterHistories_DeviceId",
                schema: "public",
                table: "InputBasedCounterHistories",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_InputBasedCounters_AssignedPartId",
                schema: "public",
                table: "InputBasedCounters",
                column: "AssignedPartId");

            migrationBuilder.CreateIndex(
                name: "IX_InputBasedCounters_DeviceId",
                schema: "public",
                table: "InputBasedCounters",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineTypeInputs_MachineTypeId",
                schema: "public",
                table: "MachineTypeInputs",
                column: "MachineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineTypes_CustomerId",
                schema: "public",
                table: "MachineTypes",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationHistories_ContactId",
                schema: "public",
                table: "NotificationHistories",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationHistories_DeviceId",
                schema: "public",
                table: "NotificationHistories",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationOlds_AccountId",
                schema: "public",
                table: "NotificationOlds",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationOlds_DeviceDataUserMapId",
                schema: "public",
                table: "NotificationOlds",
                column: "DeviceDataUserMapId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationOlds_DeviceId",
                schema: "public",
                table: "NotificationOlds",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_AccountId",
                schema: "public",
                table: "Notifications",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_DeviceDataUserMapId",
                schema: "public",
                table: "Notifications",
                column: "DeviceDataUserMapId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_DeviceId",
                schema: "public",
                table: "Notifications",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderByDevices_AccountId",
                schema: "public",
                table: "OrderByDevices",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_CustomerId",
                schema: "public",
                table: "Parts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PartsHistories_PartId",
                schema: "public",
                table: "PartsHistories",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedShutdownDescriptions_DeviceId",
                schema: "public",
                table: "PlannedShutdownDescriptions",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedShutdownDescriptions_PlannedShutdownMasterId",
                schema: "public",
                table: "PlannedShutdownDescriptions",
                column: "PlannedShutdownMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_QuickReportSettings_UserId",
                schema: "public",
                table: "QuickReportSettings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RemovedAssignedParts_DeviceId",
                schema: "public",
                table: "RemovedAssignedParts",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_RemovedAssignedParts_PartId",
                schema: "public",
                table: "RemovedAssignedParts",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportSettings_UserId",
                schema: "public",
                table: "ReportSettings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulerNotes_DeviceId",
                schema: "public",
                table: "SchedulerNotes",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulerNotes_PartId",
                schema: "public",
                table: "SchedulerNotes",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulerUpdates_AccountId",
                schema: "public",
                table: "SchedulerUpdates",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulerUpdates_CustomerId",
                schema: "public",
                table: "SchedulerUpdates",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulerUpdates_DeviceId",
                schema: "public",
                table: "SchedulerUpdates",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrapHistories_DeviceId",
                schema: "public",
                table: "ScrapHistories",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrapHistories_PartId",
                schema: "public",
                table: "ScrapHistories",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_Scraps_DeviceId",
                schema: "public",
                table: "Scraps",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Scraps_PartId",
                schema: "public",
                table: "Scraps",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_Skids_DeviceId",
                schema: "public",
                table: "Skids",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Skids_PartId",
                schema: "public",
                table: "Skids",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_Skids_UserId",
                schema: "public",
                table: "Skids",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SmartAuthentications_AccountId",
                schema: "public",
                table: "SmartAuthentications",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SmartSchedulerPlans_DeviceId",
                schema: "public",
                table: "SmartSchedulerPlans",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_SmartSchedulerPlans_PartId",
                schema: "public",
                table: "SmartSchedulerPlans",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_SmartSchedulerSplitPlans_DeviceId",
                schema: "public",
                table: "SmartSchedulerSplitPlans",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_SmartSchedulerSplitPlans_PartId",
                schema: "public",
                table: "SmartSchedulerSplitPlans",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_SmartSchedulerSplitPlans_SmartSchedulerId",
                schema: "public",
                table: "SmartSchedulerSplitPlans",
                column: "SmartSchedulerId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetPMMs_CustomerId",
                schema: "public",
                table: "TargetPMMs",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ToolingIds_CustomerId",
                schema: "public",
                table: "ToolingIds",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ToolingIds_PartId",
                schema: "public",
                table: "ToolingIds",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingDays_AccountId",
                schema: "public",
                table: "WorkingDays",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedPartsHistories",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AssignMultiParts",
                schema: "public");

            migrationBuilder.DropTable(
                name: "CalendarShiftTimes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ContactSupportMails",
                schema: "public");

            migrationBuilder.DropTable(
                name: "CustomerSetting",
                schema: "public");

            migrationBuilder.DropTable(
                name: "CustomerShifts",
                schema: "public");

            migrationBuilder.DropTable(
                name: "CustomerTypes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "CustomerWeekDays",
                schema: "public");

            migrationBuilder.DropTable(
                name: "CycleNotifications",
                schema: "public");

            migrationBuilder.DropTable(
                name: "CycleUserMaps",
                schema: "public");

            migrationBuilder.DropTable(
                name: "DeviceConfigDetails",
                schema: "public");

            migrationBuilder.DropTable(
                name: "DeviceDataHistories",
                schema: "public");

            migrationBuilder.DropTable(
                name: "DeviceDataTrackingHistories",
                schema: "public");

            migrationBuilder.DropTable(
                name: "DeviceDataTrackings",
                schema: "public");

            migrationBuilder.DropTable(
                name: "DeviceTrackingDaysHistories",
                schema: "public");

            migrationBuilder.DropTable(
                name: "DeviceUserReportAccounts",
                schema: "public");

            migrationBuilder.DropTable(
                name: "DeviceUserReportMaps",
                schema: "public");

            migrationBuilder.DropTable(
                name: "DragAndDrops",
                schema: "public");

            migrationBuilder.DropTable(
                name: "EmailAttachments",
                schema: "public");

            migrationBuilder.DropTable(
                name: "GraphDragAndDrops",
                schema: "public");

            migrationBuilder.DropTable(
                name: "InputBasedCounterHistories",
                schema: "public");

            migrationBuilder.DropTable(
                name: "InputBasedCounters",
                schema: "public");

            migrationBuilder.DropTable(
                name: "MachineTypeInputs",
                schema: "public");

            migrationBuilder.DropTable(
                name: "NotificationHistories",
                schema: "public");

            migrationBuilder.DropTable(
                name: "NotificationOlds",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Notifications",
                schema: "public");

            migrationBuilder.DropTable(
                name: "OrderByDevices",
                schema: "public");

            migrationBuilder.DropTable(
                name: "PartsHistories",
                schema: "public");

            migrationBuilder.DropTable(
                name: "PlannedShutdownDescriptions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "PushNotificationDevices",
                schema: "public");

            migrationBuilder.DropTable(
                name: "QuickReportSettings",
                schema: "public");

            migrationBuilder.DropTable(
                name: "RemovedAssignedParts",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ReportSettings",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SchedulerNotes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SchedulerUpdates",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ScrapHistories",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Scraps",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SheduleDescriptions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Shedulers",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Skids",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SmartAuthentications",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SmartSchedulerSplitPlans",
                schema: "public");

            migrationBuilder.DropTable(
                name: "TargetPMMs",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ToolingIds",
                schema: "public");

            migrationBuilder.DropTable(
                name: "WorkingDays",
                schema: "public");

            migrationBuilder.DropTable(
                name: "CalendarEvents",
                schema: "public");

            migrationBuilder.DropTable(
                name: "CycleMaintenances",
                schema: "public");

            migrationBuilder.DropTable(
                name: "DeviceConfigs",
                schema: "public");

            migrationBuilder.DropTable(
                name: "DeviceDatas",
                schema: "public");

            migrationBuilder.DropTable(
                name: "DeviceTrackingDays",
                schema: "public");

            migrationBuilder.DropTable(
                name: "DeviceUserReports",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ReportNotificationTypes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ReportType",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ReportValueType",
                schema: "public");

            migrationBuilder.DropTable(
                name: "EmailQueues",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AssignedParts",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ScrapTypes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "DeviceDataUserMaps",
                schema: "public");

            migrationBuilder.DropTable(
                name: "PlannedShutdownDescriptionMasters",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SmartSchedulerPlans",
                schema: "public");

            migrationBuilder.DropTable(
                name: "MachineTypes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Accounts",
                schema: "public");

            migrationBuilder.DropTable(
                name: "DeviceDataMaps",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Parts",
                schema: "public");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Devices",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ServiceType",
                schema: "public");
        }
    }
}
