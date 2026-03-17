using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartAttend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class baseEntityforDeviceUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "public",
                table: "DeviceDataUserMaps");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                schema: "public",
                table: "DeviceDataUserMaps",
                newName: "LastModifiedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "public",
                table: "DeviceDataUserMaps",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "public",
                table: "DeviceDataUserMaps",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LastModifiedBy",
                schema: "public",
                table: "DeviceDataUserMaps",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "public",
                table: "DeviceDataUserMaps");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "public",
                table: "DeviceDataUserMaps");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                schema: "public",
                table: "DeviceDataUserMaps");

            migrationBuilder.RenameColumn(
                name: "LastModifiedAt",
                schema: "public",
                table: "DeviceDataUserMaps",
                newName: "UpdatedDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "public",
                table: "DeviceDataUserMaps",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
