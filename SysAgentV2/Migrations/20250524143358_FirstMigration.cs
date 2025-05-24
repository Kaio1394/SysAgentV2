using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysAgentV2.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_collect_metrics",
                columns: table => new
                {
                    uuid = table.Column<string>(type: "TEXT", nullable: false),
                    json_result = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_collect_metrics", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "t_repo_scripts_cmd",
                columns: table => new
                {
                    uuid = table.Column<string>(type: "TEXT", nullable: false),
                    script = table.Column<string>(type: "TEXT", nullable: false),
                    output = table.Column<string>(type: "TEXT", nullable: false),
                    is_chained = table.Column<bool>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_repo_scripts_cmd", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "t_repo_scripts_file",
                columns: table => new
                {
                    uuid = table.Column<string>(type: "TEXT", nullable: false),
                    file_path = table.Column<string>(type: "TEXT", nullable: false),
                    language = table.Column<string>(type: "TEXT", nullable: false),
                    output = table.Column<string>(type: "TEXT", nullable: false),
                    is_chained = table.Column<bool>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_repo_scripts_file", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "t_status_agent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    status = table.Column<string>(type: "TEXT", nullable: false),
                    edited_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_status_agent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_status_health",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    health_status = table.Column<string>(type: "TEXT", nullable: false),
                    edited_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_status_health", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "t_status_agent",
                columns: new[] { "Id", "edited_at", "status" },
                values: new object[] { 1, new DateTime(2025, 5, 24, 14, 33, 58, 872, DateTimeKind.Utc).AddTicks(904), "STOPPED" });

            migrationBuilder.InsertData(
                table: "t_status_health",
                columns: new[] { "Id", "edited_at", "health_status" },
                values: new object[] { 1, new DateTime(2025, 5, 24, 14, 33, 58, 872, DateTimeKind.Utc).AddTicks(5016), "DISABLED" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_collect_metrics");

            migrationBuilder.DropTable(
                name: "t_repo_scripts_cmd");

            migrationBuilder.DropTable(
                name: "t_repo_scripts_file");

            migrationBuilder.DropTable(
                name: "t_status_agent");

            migrationBuilder.DropTable(
                name: "t_status_health");
        }
    }
}
