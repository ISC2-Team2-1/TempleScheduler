﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace TempleScheduler.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvailableTime",
                columns: table => new
                {
                    TimeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Timeslots = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableTime", x => x.TimeId);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GroupName = table.Column<string>(nullable: false),
                    GroupSize = table.Column<int>(nullable: false),
                    EmailAddr = table.Column<string>(nullable: false),
                    PhoneNum = table.Column<string>(nullable: true),
                    TimeslotsTimeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_Groups_AvailableTime_TimeslotsTimeId",
                        column: x => x.TimeslotsTimeId,
                        principalTable: "AvailableTime",
                        principalColumn: "TimeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_TimeslotsTimeId",
                table: "Groups",
                column: "TimeslotsTimeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "AvailableTime");
        }
    }
}