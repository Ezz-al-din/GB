using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class RolesSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09972439-180a-4547-a5b2-a7eca5e0cb5e", "3", "Supporter", "Supporter" },
                    { "0d488707-6499-4821-aec3-858af87c47ea", "1", "SuperAdmin", "SuperAdmin" },
                    { "1e574541-ddba-4e10-8438-fbc47f281c9e", "2", "Admin", "Admin" },
                    { "65bb25e4-9742-48ac-b272-5549b756db91", "4", "Parent", "Parent" },
                    { "fdf09287-4913-45bb-9836-f18ce9aac777", "5", "Student", "Student" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09972439-180a-4547-a5b2-a7eca5e0cb5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d488707-6499-4821-aec3-858af87c47ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e574541-ddba-4e10-8438-fbc47f281c9e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65bb25e4-9742-48ac-b272-5549b756db91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdf09287-4913-45bb-9836-f18ce9aac777");
        }
    }
}
