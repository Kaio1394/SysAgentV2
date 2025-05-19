using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysAgentV2.Migrations
{
    /// <inheritdoc />
    public partial class AgentStatusMigration : Migration
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
                name: "t_status_agent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    status = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    edited_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_status_agent", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_collect_metrics");

            migrationBuilder.DropTable(
                name: "t_status_agent");
        }
    }
}
