using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartAttend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAzureObjectIdToAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AzureObjectId",
                schema: "public",
                table: "Accounts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AzureObjectId",
                schema: "public",
                table: "Accounts");
        }
    }
}
