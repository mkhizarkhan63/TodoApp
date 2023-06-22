using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoAPI.Migrations
{
    public partial class changeinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Task = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    createdDateTime = table.Column<DateTime>(nullable: false),
                    updatedDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Tasks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Tasks");
        }
    }
}
