using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SourceServerManager.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Game = table.Column<string>(type: "TEXT", nullable: false),
                    Hostname = table.Column<string>(type: "TEXT", maxLength: 63, nullable: false),
                    DirectoryName = table.Column<string>(type: "TEXT COLLATE NOCASE", maxLength: 255, nullable: false),
                    StartupMap = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    MaxPlayerCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Port = table.Column<int>(type: "INTEGER", nullable: false),
                    LoginToken = table.Column<string>(type: "TEXT", maxLength: 32, nullable: true),
                    LastSteamCmdRun = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    LastSrcdsRun = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servers_DirectoryName",
                table: "Servers",
                column: "DirectoryName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servers");
        }
    }
}
