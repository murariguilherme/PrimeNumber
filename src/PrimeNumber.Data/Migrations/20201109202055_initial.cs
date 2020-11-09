using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrimeNumber.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrimeNums",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Index = table.Column<int>(nullable: false),
                    PrimeValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimeNums", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrimeNums_Index",
                table: "PrimeNums",
                column: "Index",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrimeNums");
        }
    }
}
