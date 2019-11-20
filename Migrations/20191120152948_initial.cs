using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbConnectionDemo.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntityOne",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FieldOne = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityOne", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityOne");
        }
    }
}
