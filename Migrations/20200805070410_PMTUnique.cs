using Microsoft.EntityFrameworkCore.Migrations;

namespace Pmtct.Migrations
{
    public partial class PMTUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pmt_NambaMshiriki01",
                table: "Pmt",
                column: "NambaMshiriki01",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pmt_NambaMshiriki01",
                table: "Pmt");
        }
    }
}
