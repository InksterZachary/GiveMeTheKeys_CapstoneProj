using Microsoft.EntityFrameworkCore.Migrations;

namespace GMTK_Capstone.Migrations
{
    public partial class addedUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d79a3fd-6317-419c-bc4d-d22a526ce837");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1b628ce4-22f6-4f72-9c26-d06a5653062a", "8893a04c-7a46-4f74-b1cc-90532378e9e2", "Landlord", "LANDLORD" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bd66bf75-53da-4456-bccf-9d7d95be75ef", "75a5492b-0501-44f8-9df2-70c6b0846fef", "Renter", "RENTER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b628ce4-22f6-4f72-9c26-d06a5653062a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd66bf75-53da-4456-bccf-9d7d95be75ef");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8d79a3fd-6317-419c-bc4d-d22a526ce837", "503b80b5-d8f1-4e93-a8ef-73aff77876e0", "Admin", "ADMIN" });
        }
    }
}
