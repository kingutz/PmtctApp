using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pmtct.Migrations
{
    public partial class TMData : Migration
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
                    NambaMshiriki01 = table.Column<string>(maxLength: 255, nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Wilaya02 = table.Column<string>(nullable: false),
                    TareheMahojiano03 = table.Column<DateTime>(nullable: false),
                    Kituo04 = table.Column<string>(maxLength: 255, nullable: false),
                    JinaAnayehoji05 = table.Column<string>(maxLength: 255, nullable: true),
                    Ngazikituo06 = table.Column<string>(maxLength: 255, nullable: false),
                    MdaKuishiZanzibar109 = table.Column<string>(maxLength: 255, nullable: false),
                    KiwangoElimu102 = table.Column<string>(maxLength: 255, nullable: false),
                    Umri101 = table.Column<double>(nullable: false),
                    WilayaUnayoishi107 = table.Column<string>(maxLength: 255, nullable: false),
                    IdadiMimba106 = table.Column<string>(maxLength: 255, nullable: false),
                    HaliNdoa103 = table.Column<string>(maxLength: 255, nullable: false),
                    KipatoMwezi104 = table.Column<double>(nullable: true),
                    Kazi105 = table.Column<string>(maxLength: 255, nullable: false),
                    NjeZanzibar108 = table.Column<string>(maxLength: 255, nullable: false),
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
                    LiniDawaVVU304b = table.Column<string>(maxLength: 255, nullable: false),
                    CTC304c = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pmt", x => x.NambaMshiriki01);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                name: "PmtctCareCascade",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    NambaMshiriki01 = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    SN = table.Column<string>(maxLength: 255, nullable: false),
                    ServiceName = table.Column<string>(maxLength: 255, nullable: false),
                    ResponseName = table.Column<bool>(nullable: false),
                    ServiceDate = table.Column<DateTime>(nullable: false),
                    RemarksName = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmtctCareCascade", x => new { x.ID, x.NambaMshiriki01 });
                    table.ForeignKey(
                        name: "FK_PmtctCareCascade_Pmt_NambaMshiriki01",
                        column: x => x.NambaMshiriki01,
                        principalTable: "Pmt",
                        principalColumn: "NambaMshiriki01",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PmtctFollowUp",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    NambaMshiriki01 = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    TareheHudhurio = table.Column<DateTime>(nullable: false),
                    HaliYako305a = table.Column<string>(maxLength: 255, nullable: false),
                    KamaHapana305a = table.Column<string>(maxLength: 255, nullable: false),
                    KamaNdio305b = table.Column<string>(maxLength: 255, nullable: false),
                    MpangoMtu306b = table.Column<string>(maxLength: 255, nullable: false),
                    HaliMwenza307 = table.Column<string>(maxLength: 255, nullable: false),
                    KuhudumiwaTofautiVVU308a = table.Column<string>(maxLength: 255, nullable: false),
                    NaniKutendea308b = table.Column<string>(maxLength: 255, nullable: false),
                    UmejiungaVVU309a = table.Column<string>(maxLength: 255, nullable: false),
                    NdioTaja309b = table.Column<string>(maxLength: 255, nullable: false),
                    MamaMwambata310a = table.Column<string>(maxLength: 255, nullable: false),
                    HudumaHulipatiwa310b = table.Column<string>(maxLength: 255, nullable: false),
                    Rufaa = table.Column<string>(maxLength: 255, nullable: true),
                    TareheHudhurioLijalo = table.Column<DateTime>(nullable: false),
                    Ufuatiliaji = table.Column<string>(maxLength: 255, nullable: false),
                    JinaMtoHuduma = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmtctFollowUp", x => new { x.ID, x.NambaMshiriki01 });
                    table.ForeignKey(
                        name: "FK_PmtctFollowUp_Pmt_NambaMshiriki01",
                        column: x => x.NambaMshiriki01,
                        principalTable: "Pmt",
                        principalColumn: "NambaMshiriki01",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PmtctCareCascade_NambaMshiriki01",
                table: "PmtctCareCascade",
                column: "NambaMshiriki01");

            migrationBuilder.CreateIndex(
                name: "IX_PmtctFollowUp_NambaMshiriki01",
                table: "PmtctFollowUp",
                column: "NambaMshiriki01");
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
                name: "PmtctCareCascade");

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
