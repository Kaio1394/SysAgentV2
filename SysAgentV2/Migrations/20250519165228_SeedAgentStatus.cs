using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysAgentV2.Migrations
{
    /// <inheritdoc />
    public partial class SeedAgentStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "t_status_agent",
                columns: new[] { "Id", "edited_at", "status" },
                values: new object[] { 1, new DateTime(2025, 5, 19, 16, 52, 28, 363, DateTimeKind.Utc).AddTicks(4905), "STOPPED" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "t_status_agent",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
