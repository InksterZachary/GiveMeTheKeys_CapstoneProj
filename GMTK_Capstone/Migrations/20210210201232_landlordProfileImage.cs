using Microsoft.EntityFrameworkCore.Migrations;

namespace GMTK_Capstone.Migrations
{
    public partial class landlordProfileImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1eae4719-69ea-4d96-8c73-37dde3b879c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eec0816e-a004-4cdb-bfc9-f0f72f346f6e");

            migrationBuilder.AddColumn<string>(
                name: "ProfileImage",
                table: "Landlords",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4c11d934-e257-4037-bab9-fb94f460bf10", "66baa39b-a904-4421-8086-94a82f1cd3ee", "Landlord", "LANDLORD" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "72dd6d8f-4f46-4af9-a2a6-7407ea7297eb", "b87a04e6-c5b7-45d1-bb83-0723fafcbd29", "Renter", "RENTER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c11d934-e257-4037-bab9-fb94f460bf10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72dd6d8f-4f46-4af9-a2a6-7407ea7297eb");

            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "Landlords");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eec0816e-a004-4cdb-bfc9-f0f72f346f6e", "a19516a3-b91d-4099-ab6a-13ffc7a3166f", "Landlord", "LANDLORD" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1eae4719-69ea-4d96-8c73-37dde3b879c5", "46d4becb-b661-4f6b-9dc1-a996f16d121b", "Renter", "RENTER" });
        }
    }
}
