using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Studfest.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryHouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryStreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deliverysuburb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiptContactNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApprovedDeliveryTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryTeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovedDeliveryTeams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApprovedVendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovedVendors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<int>(type: "int", nullable: false),
                    AlternativeNumber = table.Column<int>(type: "int", nullable: false),
                    AlternativeEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VenderId = table.Column<int>(type: "int", nullable: false),
                    DeliveryTeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryTeam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleRegistrationNumber = table.Column<int>(type: "int", nullable: false),
                    DriversLicence = table.Column<int>(type: "int", nullable: false),
                    DriverProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehileImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceProvidersDocumentsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryTeam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatedDeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryTeamId = table.Column<int>(type: "int", nullable: false),
                    DeliverInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_DeliveryInformation_DeliverInfoId",
                        column: x => x.DeliverInfoId,
                        principalTable: "DeliveryInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_DeliveryTeam_DeliveryTeamId",
                        column: x => x.DeliveryTeamId,
                        principalTable: "DeliveryTeam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: false),
                    ProductPrice = table.Column<double>(type: "float", nullable: false),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Warranty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoxItems = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResidentalAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    suburb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentalAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServicesDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUploaded = table.Column<bool>(type: "bit", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VendorFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VendorLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VendorEmailAddresss = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VendorIdNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    DriverProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceProvidersDocumentsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendor_ServicesDocuments_ServiceProvidersDocumentsId",
                        column: x => x.ServiceProvidersDocumentsId,
                        principalTable: "ServicesDocuments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovedDeliveryTeams_DeliveryTeamId",
                table: "ApprovedDeliveryTeams",
                column: "DeliveryTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovedVendors_VendorId",
                table: "ApprovedVendors",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_DeliveryTeamId",
                table: "ContactDetails",
                column: "DeliveryTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_VenderId",
                table: "ContactDetails",
                column: "VenderId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryTeam_ServiceProvidersDocumentsId",
                table: "DeliveryTeam",
                column: "ServiceProvidersDocumentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliverInfoId",
                table: "Orders",
                column: "DeliverInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryTeamId",
                table: "Orders",
                column: "DeliveryTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_VendorId",
                table: "Products",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentalAddresses_VendorId",
                table: "ResidentalAddresses",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_VendorId",
                table: "Services",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesDocuments_VendorId",
                table: "ServicesDocuments",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_ServiceProvidersDocumentsId",
                table: "Vendor",
                column: "ServiceProvidersDocumentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovedDeliveryTeams_DeliveryTeam_DeliveryTeamId",
                table: "ApprovedDeliveryTeams",
                column: "DeliveryTeamId",
                principalTable: "DeliveryTeam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovedVendors_Vendor_VendorId",
                table: "ApprovedVendors",
                column: "VendorId",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_DeliveryTeam_DeliveryTeamId",
                table: "ContactDetails",
                column: "DeliveryTeamId",
                principalTable: "DeliveryTeam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_Vendor_VenderId",
                table: "ContactDetails",
                column: "VenderId",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryTeam_ServicesDocuments_ServiceProvidersDocumentsId",
                table: "DeliveryTeam",
                column: "ServiceProvidersDocumentsId",
                principalTable: "ServicesDocuments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Vendor_VendorId",
                table: "Products",
                column: "VendorId",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentalAddresses_Vendor_VendorId",
                table: "ResidentalAddresses",
                column: "VendorId",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Vendor_VendorId",
                table: "Services",
                column: "VendorId",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesDocuments_Vendor_VendorId",
                table: "ServicesDocuments",
                column: "VendorId",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicesDocuments_Vendor_VendorId",
                table: "ServicesDocuments");

            migrationBuilder.DropTable(
                name: "ApprovedDeliveryTeams");

            migrationBuilder.DropTable(
                name: "ApprovedVendors");

            migrationBuilder.DropTable(
                name: "ContactDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ResidentalAddresses");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "DeliveryInformation");

            migrationBuilder.DropTable(
                name: "DeliveryTeam");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "ServicesDocuments");
        }
    }
}
