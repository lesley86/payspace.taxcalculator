using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tax.Persistence.EF.Migrations
{
    public partial class CalculatedTaxTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculatedTaxEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    PostalCode = table.Column<string>(nullable: true),
                    AnnualIncome = table.Column<decimal>(nullable: false),
                    CalculatedTaxAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculatedTaxEntities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculatedTaxEntities");
        }
    }
}
