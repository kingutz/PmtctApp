using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pmtct.Migrations
{
    public partial class PMTData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pmt",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InitiatedART401 = table.Column<bool>(nullable: false),
                    InitiatedARTDate401 = table.Column<DateTime>(nullable: true),
                    DeliveryFacility402 = table.Column<bool>(nullable: false),
                    DeliveryFacilityDate402 = table.Column<DateTime>(nullable: true),
                    EarlyBirth403a = table.Column<bool>(nullable: false),
                    EarlyBirthDate403a = table.Column<DateTime>(nullable: true),
                    InfantHIVstatus403b = table.Column<bool>(nullable: false),
                    InfantHIVstatusDate403b = table.Column<DateTime>(nullable: true),
                    MotherResults403c = table.Column<bool>(nullable: false),
                    MotherResultsDate403c = table.Column<DateTime>(nullable: true),
                    InfantBreastfeeding404a = table.Column<bool>(nullable: false),
                    InfantBreastfeedingDate404a = table.Column<DateTime>(nullable: true),
                    RemarksName = table.Column<string>(maxLength: 255, nullable: true),
                    NambaMshiriki01 = table.Column<string>(maxLength: 255, nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Wilaya02 = table.Column<string>(nullable: false),
                    TareheMahojiano03 = table.Column<DateTime>(nullable: false),
                    Kituo04 = table.Column<string>(maxLength: 255, nullable: false),
                    JinaAnayehoji05 = table.Column<string>(maxLength: 255, nullable: true),
                    Ngazikituo06 = table.Column<string>(maxLength: 255, nullable: false),
                    MdaKuishiZanzibar109 = table.Column<string>(maxLength: 255, nullable: false),
                    NjeZanzibar108 = table.Column<string>(maxLength: 255, nullable: true),
                    KiwangoElimu102 = table.Column<string>(maxLength: 255, nullable: false),
                    Umri101 = table.Column<double>(nullable: false),
                    WilayaUnayoishi107 = table.Column<string>(maxLength: 255, nullable: false),
                    IdadiMimba106 = table.Column<string>(maxLength: 255, nullable: false),
                    HaliNdoa103 = table.Column<string>(maxLength: 255, nullable: false),
                    KipatoMwezi104 = table.Column<double>(nullable: true),
                    Kazi105 = table.Column<string>(maxLength: 255, nullable: false),
                    KilomitaKituo201 = table.Column<string>(maxLength: 255, nullable: false),
                    KilomitaUjazo202 = table.Column<string>(maxLength: 255, nullable: false),
                    HudumaUjauzito203 = table.Column<string>(maxLength: 255, nullable: false),
                    UgumuKliniki204a = table.Column<string>(maxLength: 255, nullable: false),
                    HudumaHapa205 = table.Column<string>(maxLength: 255, nullable: false),
                    BasiMbaliAfya204b_1 = table.Column<bool>(nullable: false),
                    UgumuUsafiriUmma204b_2 = table.Column<bool>(nullable: false),
                    KukosaNauli204b_3 = table.Column<bool>(nullable: false),
                    MsafaraMrefu204b_4 = table.Column<bool>(nullable: false),
                    AnaishiMbaliBasi204b_5 = table.Column<bool>(nullable: false),
                    AnaishiMbaliAfya204b_6 = table.Column<bool>(nullable: false),
                    Mengine204b_7 = table.Column<bool>(nullable: false),
                    TajaMengine204b = table.Column<string>(maxLength: 255, nullable: true),
                    UmepataHapaHuduma206 = table.Column<string>(maxLength: 255, nullable: false),
                    UmriMimba301 = table.Column<double>(nullable: false),
                    MwakaVVU302 = table.Column<string>(maxLength: 255, nullable: false),
                    MdaVVU303 = table.Column<string>(maxLength: 255, nullable: false),
                    DawaVVU304a = table.Column<string>(maxLength: 255, nullable: false),
                    LiniDawaVVU304b = table.Column<string>(maxLength: 255, nullable: true),
                    CTC304c = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pmt", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PmtctFollowUp",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    TareheHudhurio = table.Column<DateTime>(nullable: false),
                    HaliYako305a = table.Column<string>(maxLength: 255, nullable: false),
                    Mwenza305b1 = table.Column<bool>(nullable: false),
                    Mwanafamiliaa305b2 = table.Column<bool>(nullable: false),
                    Wazazi305b3 = table.Column<bool>(nullable: false),
                    Rafiki305b1 = table.Column<bool>(nullable: false),
                    Mfanyakazi305b5 = table.Column<bool>(nullable: false),
                    Wengine305b6 = table.Column<bool>(nullable: false),
                    Tajawengine305b7 = table.Column<string>(maxLength: 255, nullable: true),
                    Naogopakutengwa306a1 = table.Column<bool>(nullable: false),
                    Naogopakuachwa306a2 = table.Column<bool>(nullable: false),
                    kunyanyapaliwa306a2 = table.Column<bool>(nullable: false),
                    BadosijaaminiVVUliwa306a4 = table.Column<bool>(nullable: false),
                    Sinaninaemwamini306a6 = table.Column<bool>(nullable: false),
                    Nyinginezo306a6 = table.Column<bool>(nullable: false),
                    MpangoMtu306b = table.Column<string>(maxLength: 255, nullable: true),
                    HaliMwenza307 = table.Column<string>(maxLength: 255, nullable: false),
                    KuhudumiwaTofautiVVU308a = table.Column<string>(maxLength: 255, nullable: false),
                    Mwenza308b1 = table.Column<bool>(nullable: false),
                    Mwanafamiliaa308b2 = table.Column<bool>(nullable: false),
                    Wazazi308b3 = table.Column<bool>(nullable: false),
                    Rafiki308b1 = table.Column<bool>(nullable: false),
                    Mfanyakazi308b5 = table.Column<bool>(nullable: false),
                    Mhudumu308b6 = table.Column<bool>(nullable: false),
                    Wengine308b7 = table.Column<bool>(nullable: false),
                    Tajawengine308b8 = table.Column<string>(maxLength: 255, nullable: true),
                    UmejiungaVVU309a = table.Column<string>(maxLength: 255, nullable: false),
                    NdioTaja309b = table.Column<string>(maxLength: 255, nullable: true),
                    MamaMwambata310a = table.Column<string>(maxLength: 255, nullable: false),
                    Ushauri310b1 = table.Column<bool>(nullable: false),
                    Elimuafya310b2 = table.Column<bool>(nullable: false),
                    Ufuatiliaji310b3 = table.Column<bool>(nullable: false),
                    Nyinginezo310b4 = table.Column<bool>(nullable: false),
                    Rufaa = table.Column<string>(maxLength: 255, nullable: true),
                    TareheHudhurioLijalo = table.Column<DateTime>(nullable: false),
                    Ufuatiliaji = table.Column<string>(maxLength: 255, nullable: false),
                    JinaMtoHuduma = table.Column<string>(maxLength: 255, nullable: true),
                    NambaMshiriki01 = table.Column<long>(nullable: false),
                    pmtctDataID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmtctFollowUp", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PmtctFollowUp_Pmt_pmtctDataID",
                        column: x => x.pmtctDataID,
                        principalTable: "Pmt",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PmtctFollowUp_pmtctDataID",
                table: "PmtctFollowUp",
                column: "pmtctDataID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "PmtctFollowUp");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Pmt");
        }
    }
}
