using Microsoft.EntityFrameworkCore.Migrations;

namespace Pmtct.Migrations
{
    public partial class DamianHIVstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InfantHIVstatus403b",
                table: "Pmt",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "InfantHIVstatus403b",
                table: "Pmt",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
