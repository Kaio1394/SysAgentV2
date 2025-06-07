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
                    collect_at = table.Column<DateTime>(type: "TEXT", nullable: false)
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
                    tag = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    script = table.Column<string>(type: "TEXT", nullable: false),
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
                    tag = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    file_path = table.Column<string>(type: "TEXT", nullable: false),
                    language = table.Column<string>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_repo_scripts_file", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "t_schedules",
                columns: table => new
                {
                    uuid = table.Column<string>(type: "TEXT", nullable: false),
                    tag_schedule = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    time = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    days_of_week = table.Column<string>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_schedules", x => x.uuid);
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

            migrationBuilder.CreateTable(
                name: "t_schedule_scripts_cmd",
                columns: table => new
                {
                    uuid = table.Column<string>(type: "TEXT", nullable: false),
                    schedule_uuid = table.Column<string>(type: "TEXT", nullable: false),
                    script_uuid = table.Column<string>(type: "TEXT", nullable: false),
                    execution_order = table.Column<int>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_schedule_scripts_cmd", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_t_schedule_scripts_cmd_t_repo_scripts_cmd_script_uuid",
                        column: x => x.script_uuid,
                        principalTable: "t_repo_scripts_cmd",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_schedule_scripts_cmd_t_schedules_schedule_uuid",
                        column: x => x.schedule_uuid,
                        principalTable: "t_schedules",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "t_status_agent",
                columns: new[] { "Id", "edited_at", "status" },
                values: new object[] { 1, new DateTime(2025, 6, 7, 13, 29, 49, 605, DateTimeKind.Utc).AddTicks(7200), "STOPPED" });

            migrationBuilder.InsertData(
                table: "t_status_health",
                columns: new[] { "Id", "edited_at", "health_status" },
                values: new object[] { 1, new DateTime(2025, 6, 7, 13, 29, 49, 605, DateTimeKind.Utc).AddTicks(7290), "DISABLED" });

            migrationBuilder.CreateIndex(
                name: "IX_t_schedule_scripts_cmd_schedule_uuid",
                table: "t_schedule_scripts_cmd",
                column: "schedule_uuid");

            migrationBuilder.CreateIndex(
                name: "IX_t_schedule_scripts_cmd_script_uuid",
                table: "t_schedule_scripts_cmd",
                column: "script_uuid");

            migrationBuilder.CreateIndex(
                name: "IX_t_schedules_tag_schedule",
                table: "t_schedules",
                column: "tag_schedule",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_collect_metrics");

            migrationBuilder.DropTable(
                name: "t_repo_scripts_file");

            migrationBuilder.DropTable(
                name: "t_schedule_scripts_cmd");

            migrationBuilder.DropTable(
                name: "t_status_agent");

            migrationBuilder.DropTable(
                name: "t_status_health");

            migrationBuilder.DropTable(
                name: "t_repo_scripts_cmd");

            migrationBuilder.DropTable(
                name: "t_schedules");
        }
    }
}
