using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pmtct.Migrations
{
    public partial class DamianHIV2020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InfantHIVstatusDate403b",
                table: "Pmt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InfantHIVstatusDate403b",
                table: "Pmt",
                type: "datetime2",
                nullable: true);
        }
    }
}
