using Microsoft.EntityFrameworkCore.Migrations;

namespace GMTK_Capstone.Migrations
{
    public partial class ListListings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d758723-aaf6-479a-a3fa-77ddfeb8212d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f53e669-b982-40c6-bca2-df48096c3e2e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3edc2c1-a908-4d4e-91c3-70d1cfd5ba5d", "3ea2e618-fa8d-4ae7-8548-2234d363bd2c", "Landlord", "LANDLORD" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c18e202d-918e-42e6-98a2-f76c4a8f907c", "a7b13f06-a222-4cd0-9ab7-45b1fc6d7d03", "Renter", "RENTER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3edc2c1-a908-4d4e-91c3-70d1cfd5ba5d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c18e202d-918e-42e6-98a2-f76c4a8f907c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2d758723-aaf6-479a-a3fa-77ddfeb8212d", "0f1db3da-f565-4d6d-8358-a4e118dfd35f", "Landlord", "LANDLORD" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4f53e669-b982-40c6-bca2-df48096c3e2e", "65948826-213f-4640-bb04-c08bec3c7f8e", "Renter", "RENTER" });
        }
    }
}
