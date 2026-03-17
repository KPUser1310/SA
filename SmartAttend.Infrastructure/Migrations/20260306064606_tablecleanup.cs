using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartAttend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class tablecleanup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedParts_Devices_DeviceId",
                schema: "public",
                table: "AssignedParts");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignedParts_Parts_PartId",
                schema: "public",
                table: "AssignedParts");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceConfigDetails_DeviceConfigs_DeviceConfigId",
                schema: "public",
                table: "DeviceConfigDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceConfigs_Devices_DeviceId",
                schema: "public",
                table: "DeviceConfigs");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "public",
                table: "ScrapTypes");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                schema: "public",
                table: "UserRole",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                schema: "public",
                table: "Parts",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                schema: "public",
                table: "Devices",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DeviceId",
                schema: "public",
                table: "DeviceConfigs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "public",
                table: "DeviceConfigs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "public",
                table: "DeviceConfigs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedAt",
                schema: "public",
                table: "DeviceConfigs",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifiedBy",
                schema: "public",
                table: "DeviceConfigs",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DeviceConfigId",
                schema: "public",
                table: "DeviceConfigDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PartId",
                schema: "public",
                table: "AssignedParts",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DeviceId",
                schema: "public",
                table: "AssignedParts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "public",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Logo = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Location_Customers_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "public",
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_LocationId",
                schema: "public",
                table: "UserRole",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_LocationId",
                schema: "public",
                table: "Parts",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_LocationId",
                schema: "public",
                table: "Devices",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedParts_Devices_DeviceId",
                schema: "public",
                table: "AssignedParts",
                column: "DeviceId",
                principalSchema: "public",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedParts_Parts_PartId",
                schema: "public",
                table: "AssignedParts",
                column: "PartId",
                principalSchema: "public",
                principalTable: "Parts",
                principalColumn: "PartId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceConfigDetails_DeviceConfigs_DeviceConfigId",
                schema: "public",
                table: "DeviceConfigDetails",
                column: "DeviceConfigId",
                principalSchema: "public",
                principalTable: "DeviceConfigs",
                principalColumn: "DeviceConfigId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceConfigs_Devices_DeviceId",
                schema: "public",
                table: "DeviceConfigs",
                column: "DeviceId",
                principalSchema: "public",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Location_LocationId",
                schema: "public",
                table: "Devices",
                column: "LocationId",
                principalSchema: "public",
                principalTable: "Location",
                principalColumn: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Location_LocationId",
                schema: "public",
                table: "Parts",
                column: "LocationId",
                principalSchema: "public",
                principalTable: "Location",
                principalColumn: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Location_LocationId",
                schema: "public",
                table: "UserRole",
                column: "LocationId",
                principalSchema: "public",
                principalTable: "Location",
                principalColumn: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedParts_Devices_DeviceId",
                schema: "public",
                table: "AssignedParts");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignedParts_Parts_PartId",
                schema: "public",
                table: "AssignedParts");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceConfigDetails_DeviceConfigs_DeviceConfigId",
                schema: "public",
                table: "DeviceConfigDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceConfigs_Devices_DeviceId",
                schema: "public",
                table: "DeviceConfigs");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Location_LocationId",
                schema: "public",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Location_LocationId",
                schema: "public",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Location_LocationId",
                schema: "public",
                table: "UserRole");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_UserRole_LocationId",
                schema: "public",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_Parts_LocationId",
                schema: "public",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Devices_LocationId",
                schema: "public",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "LocationId",
                schema: "public",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "LocationId",
                schema: "public",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "LocationId",
                schema: "public",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "public",
                table: "DeviceConfigs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "public",
                table: "DeviceConfigs");

            migrationBuilder.DropColumn(
                name: "LastModifiedAt",
                schema: "public",
                table: "DeviceConfigs");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                schema: "public",
                table: "DeviceConfigs");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "public",
                table: "ScrapTypes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DeviceId",
                schema: "public",
                table: "DeviceConfigs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DeviceConfigId",
                schema: "public",
                table: "DeviceConfigDetails",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "PartId",
                schema: "public",
                table: "AssignedParts",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "DeviceId",
                schema: "public",
                table: "AssignedParts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedParts_Devices_DeviceId",
                schema: "public",
                table: "AssignedParts",
                column: "DeviceId",
                principalSchema: "public",
                principalTable: "Devices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedParts_Parts_PartId",
                schema: "public",
                table: "AssignedParts",
                column: "PartId",
                principalSchema: "public",
                principalTable: "Parts",
                principalColumn: "PartId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceConfigDetails_DeviceConfigs_DeviceConfigId",
                schema: "public",
                table: "DeviceConfigDetails",
                column: "DeviceConfigId",
                principalSchema: "public",
                principalTable: "DeviceConfigs",
                principalColumn: "DeviceConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceConfigs_Devices_DeviceId",
                schema: "public",
                table: "DeviceConfigs",
                column: "DeviceId",
                principalSchema: "public",
                principalTable: "Devices",
                principalColumn: "Id");
        }
    }
}
