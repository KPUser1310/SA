using Microsoft.EntityFrameworkCore.Migrations;
using SmartAttend.Infrastructure.DbMigration.DbMigrationConstant;

namespace SmartAttend.Infrastructure.DbMigration
{
    public abstract class DbMigrationBase : Migration
    {
        protected static string RootMigrationPath =>
            Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "DbMigration",
                MigrationConstants.ScriptsFolderName,
                MigrationConstants.FinalVersionDBObjectsFolderName
            );

        protected static string ProceduresPath =>
            Path.Combine(RootMigrationPath, MigrationConstants.FunctionsFolderName);

        protected static void ExecuteSqlScriptInFile(
            string fileName,
            MigrationBuilder migrationBuilder)
        {
            var fullPath = Path.Combine(ProceduresPath, fileName);

            #if DEBUG
            Console.WriteLine($"Executing SQL file: {fullPath}");
            #endif

            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"SQL file not found: {fullPath}");

            var sqlScript = File.ReadAllText(fullPath);

            if (!string.IsNullOrWhiteSpace(sqlScript))
            {
                migrationBuilder.Sql(sqlScript);
            }
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // intentionally empty
        }
    }
}