using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FFM.DataAccess.Migrations
{
    public partial class InitialCreationOfDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customerPartsHeader",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    changeKey = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true),
                    isActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    isDeleted = table.Column<bool>(type: "INTEGER", nullable: true),
                    lastModifiedOnDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    lastModifiedByUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    lastModifiedByIp = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    deletedOnDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    deletedByUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    deletedByIp = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    approvedRejectedOnDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    approvedRejectedByUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    approvedRejectedByIp = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerPartsHeader", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orderPartsHeader",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ordersHeaderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    lineNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    changeKey = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true),
                    isActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    isDeleted = table.Column<bool>(type: "INTEGER", nullable: true),
                    lastModifiedOnDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    lastModifiedByUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    lastModifiedByIp = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    deletedOnDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    deletedByUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    deletedByIp = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    approvedRejectedOnDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    approvedRejectedByUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    approvedRejectedByIp = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderPartsHeader", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customerParts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    customerPartsHeaderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    userfriendlyName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    changeKey = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true),
                    createdOnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    createdByUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    createdByIp = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerParts", x => x.id);
                    table.ForeignKey(
                        name: "FK_customerParts_customerPartsHeader_customerPartsHeaderId",
                        column: x => x.customerPartsHeaderId,
                        principalTable: "customerPartsHeader",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderParts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    orderPartsHeaderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    customerPartsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    userfriendlyName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    orderQty = table.Column<int>(type: "INTEGER", nullable: true),
                    orderWt = table.Column<decimal>(type: "decimal(18, 3)", nullable: true),
                    changeKey = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true),
                    createdOnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    createdByUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    createdByIp = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderParts", x => x.id);
                    table.ForeignKey(
                        name: "FK_orderParts_customerParts_customerPartsId",
                        column: x => x.customerPartsId,
                        principalTable: "customerParts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderParts_orderPartsHeader_orderPartsHeaderId",
                        column: x => x.orderPartsHeaderId,
                        principalTable: "orderPartsHeader",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "customerPartsHeader",
                columns: new[] { "id", "approvedRejectedByIp", "approvedRejectedByUserId", "approvedRejectedOnDate", "deletedByIp", "deletedByUserId", "deletedOnDate", "isActive", "isDeleted", "lastModifiedByIp", "lastModifiedByUserId", "lastModifiedOnDate" },
                values: new object[] { new Guid("596efbff-8c30-4b75-bfdb-ef7e05b5f96d"), "", null, null, null, null, null, true, false, null, null, null });

            migrationBuilder.InsertData(
                table: "orderPartsHeader",
                columns: new[] { "id", "approvedRejectedByIp", "approvedRejectedByUserId", "approvedRejectedOnDate", "deletedByIp", "deletedByUserId", "deletedOnDate", "isActive", "isDeleted", "lastModifiedByIp", "lastModifiedByUserId", "lastModifiedOnDate", "lineNumber", "ordersHeaderId" },
                values: new object[] { new Guid("5ab4cb69-7982-44fa-97cd-03e1d386e5e6"), "", null, null, null, null, null, true, false, null, null, null, 1, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "customerParts",
                columns: new[] { "id", "createdByIp", "createdByUserId", "createdOnDate", "customerPartsHeaderId", "description", "name", "userfriendlyName" },
                values: new object[] { new Guid("bf4349a0-2cba-4646-baa7-0bafeeba9f8c"), "", new Guid("31a1793a-9453-48cd-9909-7c157dae6a8a"), new DateTime(2018, 12, 17, 9, 32, 20, 426, DateTimeKind.Unspecified), new Guid("596efbff-8c30-4b75-bfdb-ef7e05b5f96d"), "desc 1", "name 1", "Part Revision 1" });

            migrationBuilder.InsertData(
                table: "customerParts",
                columns: new[] { "id", "createdByIp", "createdByUserId", "createdOnDate", "customerPartsHeaderId", "description", "name", "userfriendlyName" },
                values: new object[] { new Guid("d13195c6-2d9e-46b0-b633-aa9e074ea15f"), "", new Guid("31a1793a-9453-48cd-9909-7c157dae6a8a"), new DateTime(2019, 6, 17, 9, 32, 20, 426, DateTimeKind.Unspecified), new Guid("596efbff-8c30-4b75-bfdb-ef7e05b5f96d"), "New Description", "Name Changed", "Part Revision 2" });

            migrationBuilder.InsertData(
                table: "orderParts",
                columns: new[] { "id", "createdByIp", "createdByUserId", "createdOnDate", "customerPartsId", "orderPartsHeaderId", "orderQty", "orderWt", "userfriendlyName" },
                values: new object[] { new Guid("bf4349a0-2cba-4646-baa7-0bafeeba9f8c"), "", new Guid("31a1793a-9453-48cd-9909-7c157dae6a8a"), new DateTime(2018, 12, 17, 9, 32, 20, 426, DateTimeKind.Unspecified), new Guid("bf4349a0-2cba-4646-baa7-0bafeeba9f8c"), new Guid("5ab4cb69-7982-44fa-97cd-03e1d386e5e6"), 100, 2.3m, "Order Part 1" });

            migrationBuilder.CreateIndex(
                name: "IX_customerParts_createdOnDate",
                table: "customerParts",
                column: "createdOnDate");

            migrationBuilder.CreateIndex(
                name: "IX_customerParts_customerPartsHeaderId",
                table: "customerParts",
                column: "customerPartsHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_customerParts_userfriendlyName",
                table: "customerParts",
                column: "userfriendlyName");

            migrationBuilder.CreateIndex(
                name: "IX_customerPartsHeader_isDeleted",
                table: "customerPartsHeader",
                column: "isDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_orderParts_createdOnDate",
                table: "orderParts",
                column: "createdOnDate");

            migrationBuilder.CreateIndex(
                name: "IX_orderParts_customerPartsId",
                table: "orderParts",
                column: "customerPartsId");

            migrationBuilder.CreateIndex(
                name: "IX_orderParts_orderPartsHeaderId",
                table: "orderParts",
                column: "orderPartsHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_orderParts_orderQty",
                table: "orderParts",
                column: "orderQty");

            migrationBuilder.CreateIndex(
                name: "IX_orderParts_orderWt",
                table: "orderParts",
                column: "orderWt");

            migrationBuilder.CreateIndex(
                name: "IX_orderParts_userfriendlyName",
                table: "orderParts",
                column: "userfriendlyName");

            migrationBuilder.CreateIndex(
                name: "IX_orderPartsHeader_isDeleted",
                table: "orderPartsHeader",
                column: "isDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderParts");

            migrationBuilder.DropTable(
                name: "customerParts");

            migrationBuilder.DropTable(
                name: "orderPartsHeader");

            migrationBuilder.DropTable(
                name: "customerPartsHeader");
        }
    }
}
