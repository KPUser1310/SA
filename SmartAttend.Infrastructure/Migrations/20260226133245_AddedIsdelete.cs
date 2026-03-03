using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartAttend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsdelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "public",
                table: "SchedulerNotes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "public",
                table: "ReportValueType");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "public",
                table: "PlannedShutdownDescriptions");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "public",
                table: "PlannedShutdownDescriptionMasters");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "public",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "public",
                table: "NotificationOlds");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "public",
                table: "MachineTypeInputs");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "public",
                table: "CycleNotifications");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "public",
                table: "CycleMaintenances");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "public",
                table: "ContactSupportMails");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "ToolingIds",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "ServiceID",
                schema: "public",
                table: "ServiceType",
                newName: "ServiceId");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "ScrapTypes",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "ReportType",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "ReportNotificationTypes",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "QuickReportSettingID",
                schema: "public",
                table: "QuickReportSettings",
                newName: "QuickReportSettingId");

            migrationBuilder.RenameColumn(
                name: "ID",
                schema: "public",
                table: "PlannedShutdownDescriptionMasters",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GroupID",
                schema: "public",
                table: "PartsHistories",
                newName: "GroupId");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "DragAndDrops",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "DeviceUserReportMaps",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "DeviceDataMaps",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "CycleUserMaps",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "DowntimeDurationID",
                schema: "public",
                table: "AssignedPartsHistories",
                newName: "DowntimeDurationId");

            migrationBuilder.RenameColumn(
                name: "NotesID",
                schema: "public",
                table: "AssignedParts",
                newName: "NotesId");

            migrationBuilder.RenameColumn(
                name: "DowntimeDurationID",
                schema: "public",
                table: "AssignedParts",
                newName: "DowntimeDurationId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "TargetPMMs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "SmartSchedulerSplitPlans",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "SmartSchedulerPlans",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "SmartAuthentications",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "Skids",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "Shedulers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "SheduleDescriptions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "ServiceType",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "public",
                table: "ScrapTypes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "public",
                table: "ScrapTypes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedAt",
                schema: "public",
                table: "ScrapTypes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifiedBy",
                schema: "public",
                table: "ScrapTypes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "Scraps",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "ScrapHistories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "SchedulerUpdates",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "SchedulerNotes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "ReportValueType",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "ReportSettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "RemovedAssignedParts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "QuickReportSettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "PushNotificationDevices",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "PlannedShutdownDescriptions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "PlannedShutdownDescriptionMasters",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "PartsHistories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "Parts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "OrderByDevices",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotify",
                schema: "public",
                table: "Notifications",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "Notifications",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "NotificationOlds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "NotificationHistories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "IsUpdated",
                schema: "public",
                table: "MachineTypes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "MachineTypes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "MachineTypeInputs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "InputBasedCounters",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "InputBasedCounterHistories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "GraphDragAndDrops",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "EmailQueues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "EmailAttachments",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "DeviceUserReports",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "DeviceUserReportAccounts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "DeviceTrackingDaysHistories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "DeviceTrackingDays",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "Devices",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "DeviceDataUserMaps",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "DeviceDataTrackings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "DeviceDataTrackingHistories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "DeviceDatas",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "DeviceDataHistories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "IsUpdated",
                schema: "public",
                table: "DeviceConfigs",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "DeviceConfigs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "DeviceConfigDetails",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "CycleNotifications",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "CycleMaintenances",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "CustomerWeekDays",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "CustomerTypes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "CustomerShifts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "CustomerSetting",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "Customers",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "ContactSupportMails",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "CalendarShiftTimes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "CalendarEvents",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "AssignMultiParts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "AssignedPartsHistories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "AssignedParts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "Accounts",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "TargetPMMs");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "SmartSchedulerSplitPlans");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "SmartSchedulerPlans");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "SmartAuthentications");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "Skids");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "Shedulers");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "SheduleDescriptions");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "ServiceType");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "public",
                table: "ScrapTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "public",
                table: "ScrapTypes");

            migrationBuilder.DropColumn(
                name: "LastModifiedAt",
                schema: "public",
                table: "ScrapTypes");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                schema: "public",
                table: "ScrapTypes");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "Scraps");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "ScrapHistories");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "SchedulerUpdates");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "SchedulerNotes");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "ReportValueType");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "ReportSettings");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "RemovedAssignedParts");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "QuickReportSettings");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "PushNotificationDevices");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "PlannedShutdownDescriptions");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "PlannedShutdownDescriptionMasters");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "PartsHistories");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "OrderByDevices");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "NotificationOlds");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "NotificationHistories");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "MachineTypes");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "MachineTypeInputs");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "InputBasedCounters");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "InputBasedCounterHistories");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "GraphDragAndDrops");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "EmailQueues");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "EmailAttachments");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "DeviceUserReports");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "DeviceUserReportAccounts");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "DeviceTrackingDaysHistories");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "DeviceTrackingDays");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "DeviceDataUserMaps");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "DeviceDataTrackings");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "DeviceDataTrackingHistories");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "DeviceDatas");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "DeviceDataHistories");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "DeviceConfigs");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "DeviceConfigDetails");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "CycleNotifications");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "CycleMaintenances");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "CustomerWeekDays");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "CustomerTypes");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "CustomerShifts");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "CustomerSetting");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "ContactSupportMails");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "CalendarShiftTimes");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "CalendarEvents");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "AssignMultiParts");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "AssignedPartsHistories");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                schema: "public",
                table: "AssignedParts");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                schema: "public",
                table: "ToolingIds",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                schema: "public",
                table: "ServiceType",
                newName: "ServiceID");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                schema: "public",
                table: "ScrapTypes",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                schema: "public",
                table: "ReportType",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                schema: "public",
                table: "ReportNotificationTypes",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "QuickReportSettingId",
                schema: "public",
                table: "QuickReportSettings",
                newName: "QuickReportSettingID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "PlannedShutdownDescriptionMasters",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                schema: "public",
                table: "PartsHistories",
                newName: "GroupID");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                schema: "public",
                table: "DragAndDrops",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                schema: "public",
                table: "DeviceUserReportMaps",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                schema: "public",
                table: "DeviceDataMaps",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                schema: "public",
                table: "CycleUserMaps",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "DowntimeDurationId",
                schema: "public",
                table: "AssignedPartsHistories",
                newName: "DowntimeDurationID");

            migrationBuilder.RenameColumn(
                name: "NotesId",
                schema: "public",
                table: "AssignedParts",
                newName: "NotesID");

            migrationBuilder.RenameColumn(
                name: "DowntimeDurationId",
                schema: "public",
                table: "AssignedParts",
                newName: "DowntimeDurationID");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "public",
                table: "SchedulerNotes",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "public",
                table: "ReportValueType",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "public",
                table: "PlannedShutdownDescriptions",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "public",
                table: "PlannedShutdownDescriptionMasters",
                type: "boolean",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotify",
                schema: "public",
                table: "Notifications",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "public",
                table: "Notifications",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "public",
                table: "NotificationOlds",
                type: "boolean",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IsUpdated",
                schema: "public",
                table: "MachineTypes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<decimal>(
                name: "Active",
                schema: "public",
                table: "MachineTypeInputs",
                type: "numeric(3,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "IsUpdated",
                schema: "public",
                table: "DeviceConfigs",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "public",
                table: "CycleNotifications",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "public",
                table: "CycleMaintenances",
                type: "boolean",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "Customers",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "public",
                table: "ContactSupportMails",
                type: "boolean",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                schema: "public",
                table: "Accounts",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");
        }
    }
}
