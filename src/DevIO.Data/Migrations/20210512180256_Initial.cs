using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIO.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SUPPLIERS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SUP_NAME = table.Column<string>(type: "varchar(200)", nullable: false),
                    SUP_DOCUMENT = table.Column<string>(type: "varchar(14)", nullable: false),
                    SupplierType = table.Column<int>(type: "int", nullable: false),
                    SUP_ACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADRESSES",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ADR_PUBLIC_PLACE = table.Column<string>(type: "varchar(200)", nullable: false),
                    ADR_NUMBER = table.Column<string>(type: "varchar(50)", nullable: false),
                    ADR_COMPLEMENT = table.Column<string>(type: "varchar(250)", nullable: false),
                    ADR_CEP = table.Column<string>(type: "varchar(8)", nullable: false),
                    ADR_DISTRICT = table.Column<string>(type: "varchar(100)", nullable: false),
                    ADR_CITY = table.Column<string>(type: "varchar(100)", nullable: false),
                    ADR_STATE = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADRESSES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ADRESSES_SUPPLIERS_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "SUPPLIERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PRD_NAME = table.Column<string>(type: "varchar(200)", nullable: false),
                    PRD_DESCRIPTION = table.Column<string>(type: "varchar(1000)", nullable: false),
                    PRD_IMAGE = table.Column<string>(type: "varchar(100)", nullable: false),
                    PRD_VALUE = table.Column<decimal>(type: "decimal", nullable: false),
                    PRD_CREATE_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    PRD_ACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_SUPPLIERS_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "SUPPLIERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ADRESSES_SupplierId",
                table: "ADRESSES",
                column: "SupplierId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_SupplierId",
                table: "PRODUCTS",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ADRESSES");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "SUPPLIERS");
        }
    }
}
