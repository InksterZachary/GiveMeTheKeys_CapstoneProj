using Microsoft.EntityFrameworkCore.Migrations;

namespace GMTK_Capstone.Migrations
{
    public partial class ListingsProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a62e6dc-b8d4-4990-86d8-ce3968d325eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d028f5ef-7ff3-4b03-99f4-b7cc1cb5ec84");

            migrationBuilder.AddColumn<int>(
                name: "ListingId1",
                table: "Listings",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2d758723-aaf6-479a-a3fa-77ddfeb8212d", "0f1db3da-f565-4d6d-8358-a4e118dfd35f", "Landlord", "LANDLORD" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4f53e669-b982-40c6-bca2-df48096c3e2e", "65948826-213f-4640-bb04-c08bec3c7f8e", "Renter", "RENTER" });

            migrationBuilder.CreateIndex(
                name: "IX_Listings_ListingId1",
                table: "Listings",
                column: "ListingId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Listings_ListingId1",
                table: "Listings",
                column: "ListingId1",
                principalTable: "Listings",
                principalColumn: "ListingId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Listings_ListingId1",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_ListingId1",
                table: "Listings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d758723-aaf6-479a-a3fa-77ddfeb8212d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f53e669-b982-40c6-bca2-df48096c3e2e");

            migrationBuilder.DropColumn(
                name: "ListingId1",
                table: "Listings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d028f5ef-7ff3-4b03-99f4-b7cc1cb5ec84", "06c56937-325b-48c4-9c1f-672efeb360d2", "Landlord", "LANDLORD" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0a62e6dc-b8d4-4990-86d8-ce3968d325eb", "b48b0c1a-0307-463c-a7b0-cbb9c595689a", "Renter", "RENTER" });
        }
    }
}
