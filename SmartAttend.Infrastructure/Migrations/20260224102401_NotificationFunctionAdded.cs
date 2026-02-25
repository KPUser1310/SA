using Microsoft.EntityFrameworkCore.Migrations;
using SmartAttend.Infrastructure.DbMigration.DbMigrationConstant;
using SmartAttend.Infrastructure.DbMigration;

#nullable disable

namespace SmartAttend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NotificationFunctionAdded : DbMigrationBase
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            ExecuteSqlScriptInFile(Path.Combine(ProceduresPath, MigrationConstants.USPGetDataTable), migrationBuilder);
            ExecuteSqlScriptInFile(Path.Combine(ProceduresPath, MigrationConstants.USPGetDataTableAcc1), migrationBuilder);
            ExecuteSqlScriptInFile(Path.Combine(ProceduresPath, MigrationConstants.USPGetDataTableAcc2), migrationBuilder);
            ExecuteSqlScriptInFile(Path.Combine(ProceduresPath, MigrationConstants.USPGetDataTableAccSearch1), migrationBuilder);
            ExecuteSqlScriptInFile(Path.Combine(ProceduresPath, MigrationConstants.USPGetDataTableAccSearch2), migrationBuilder);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
