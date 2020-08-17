using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProAgil.Infra.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(maxLength: 150, nullable: true),
                    Number = table.Column<string>(maxLength: 10, nullable: true),
                    Neigborhood = table.Column<string>(maxLength: 150, nullable: true),
                    City = table.Column<string>(maxLength: 150, nullable: true),
                    State = table.Column<string>(maxLength: 150, nullable: true),
                    Country = table.Column<string>(maxLength: 150, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 8, nullable: true),
                    DateEvent = table.Column<DateTime>(nullable: true),
                    Theme = table.Column<string>(maxLength: 150, nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Batches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 150, nullable: false),
                    EventId = table.Column<int>(nullable: true),
                    CurrentEvent = table.Column<bool>(nullable: true),
                    Active = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Batches_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Batches_EventId",
                table: "Batches",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Batches");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
