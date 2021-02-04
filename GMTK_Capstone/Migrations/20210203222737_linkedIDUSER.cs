using Microsoft.EntityFrameworkCore.Migrations;

namespace GMTK_Capstone.Migrations
{
    public partial class linkedIDUSER : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Landlords_LandlordId",
                table: "Listings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aace6f03-2f5b-4916-8856-f07edbbaba2f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9c3a097-f31b-4611-932a-461cb2b8c292");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Renters",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LandlordId",
                table: "Listings",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Landlords",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd94c1b1-ceb3-4e37-b14a-8daa9dad8837", "052bfd39-601e-4535-8f3d-bd3a491d1e91", "Landlord", "LANDLORD" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8812ae69-d0ea-4df2-812f-9f4546a8cb53", "870a79ec-6779-4c18-943d-71081d0979f9", "Renter", "RENTER" });

            migrationBuilder.CreateIndex(
                name: "IX_Renters_IdentityUserId",
                table: "Renters",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Landlords_IdentityUserId",
                table: "Landlords",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Landlords_AspNetUsers_IdentityUserId",
                table: "Landlords",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Landlords_LandlordId",
                table: "Listings",
                column: "LandlordId",
                principalTable: "Landlords",
                principalColumn: "LandlordId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Renters_AspNetUsers_IdentityUserId",
                table: "Renters",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Landlords_AspNetUsers_IdentityUserId",
                table: "Landlords");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Landlords_LandlordId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Renters_AspNetUsers_IdentityUserId",
                table: "Renters");

            migrationBuilder.DropIndex(
                name: "IX_Renters_IdentityUserId",
                table: "Renters");

            migrationBuilder.DropIndex(
                name: "IX_Landlords_IdentityUserId",
                table: "Landlords");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8812ae69-d0ea-4df2-812f-9f4546a8cb53");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd94c1b1-ceb3-4e37-b14a-8daa9dad8837");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Renters");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Landlords");

            migrationBuilder.AlterColumn<int>(
                name: "LandlordId",
                table: "Listings",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d9c3a097-f31b-4611-932a-461cb2b8c292", "26a793f6-7eef-4371-a5cd-3626bea7d060", "Landlord", "LANDLORD" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aace6f03-2f5b-4916-8856-f07edbbaba2f", "4ccfac27-7b40-42f9-98f0-90c58448587c", "Renter", "RENTER" });

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Landlords_LandlordId",
                table: "Listings",
                column: "LandlordId",
                principalTable: "Landlords",
                principalColumn: "LandlordId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
