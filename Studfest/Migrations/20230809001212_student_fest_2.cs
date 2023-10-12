using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Studfest.Migrations
{
    public partial class student_fest_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ResidentalAddresses_VendorId",
                table: "ResidentalAddresses");

            migrationBuilder.AlterColumn<string>(
                name: "VendorIdNumber",
                table: "Vendor",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 13);

            migrationBuilder.CreateIndex(
                name: "IX_ResidentalAddresses_VendorId",
                table: "ResidentalAddresses",
                column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ResidentalAddresses_VendorId",
                table: "ResidentalAddresses");

            migrationBuilder.AlterColumn<long>(
                name: "VendorIdNumber",
                table: "Vendor",
                type: "bigint",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);

            migrationBuilder.CreateIndex(
                name: "IX_ResidentalAddresses_VendorId",
                table: "ResidentalAddresses",
                column: "VendorId",
                unique: true);
        }
    }
}
