using System;
using System.Collections.Generic;
using System.Linq;
using ClosedXML.Excel;

using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pmtct.Data;
using Microsoft.EntityFrameworkCore;
using Pmtct.Models;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Pmtct.Services;

namespace Pmtct.Controllers
{
    [Route("api/PmtctExcel")]
    [ApiController]
    [Authorize(Roles = "admin,analyst,dataentry")]
    public class PmtctExportController : ControllerBase
    {
        private readonly PmtctContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ICurrentUserService currentUserService;

        public PmtctExportController(PmtctContext context, RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager, ICurrentUserService currentUserService)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            this.currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
        }



        [HttpGet]
        public async Task<ActionResult> ExcelDoc()

        {
            bool isSuperUser = User.IsInRole("admin") || User.IsInRole("analyst");
            List<Pmtct.Models.PmtctData> pmtctDatas = new List<PmtctData>();

            if (isSuperUser)
            {
                pmtctDatas = await _context.Pmt.ToListAsync();

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("pmtctDatas");
                    var currentRow = 1;


                    worksheet.Cell(currentRow, 1).Value = "ID";
                    worksheet.Cell(currentRow,2).Value = "InitiatedART401";
                    worksheet.Cell(currentRow, 3).Value = "InitiatedARTDate401";
                    worksheet.Cell(currentRow, 4).Value = "DeliveryFacility402";
                    worksheet.Cell(currentRow, 5).Value = "DeliveryFacilityDate402";
                    worksheet.Cell(currentRow, 6).Value = "EarlyBirth403a";
                    worksheet.Cell(currentRow, 7).Value = "EarlyBirthDate403a";
                    worksheet.Cell(currentRow, 8).Value = "InfantHIVstatus403b";
                    worksheet.Cell(currentRow, 9).Value = "InfantHIVstatusDate403b";
                    worksheet.Cell(currentRow, 10).Value = "MotherResults403c";
                    worksheet.Cell(currentRow, 11).Value = "MotherResultsDate403c";
                    worksheet.Cell(currentRow, 12).Value = "InfantBreastfeeding404a";
                    worksheet.Cell(currentRow, 13).Value = "InfantBreastfeedingDate404a";
                    worksheet.Cell(currentRow, 14).Value = "RemarksName";
                    worksheet.Cell(currentRow, 15).Value = "NambaMshiriki01";
                    worksheet.Cell(currentRow, 16).Value = "Wilaya02";
                    worksheet.Cell(currentRow, 17).Value = "TareheMahojiano03";
                    worksheet.Cell(currentRow, 18).Value = "Kituo04";
                    worksheet.Cell(currentRow, 19).Value = "JinaAnayehoji05";
                    worksheet.Cell(currentRow, 20).Value = "Ngazikituo06";
                    worksheet.Cell(currentRow, 21).Value = "MdaKuishiZanzibar109";
                    worksheet.Cell(currentRow, 22).Value = "KiwangoElimu102";
                    worksheet.Cell(currentRow, 23).Value = "Umri101";
                    worksheet.Cell(currentRow, 24).Value = "IdadiMimba106";
                    worksheet.Cell(currentRow, 25).Value = "HaliNdoa103";
                    worksheet.Cell(currentRow, 26).Value = "KipatoMwezi104";
                    worksheet.Cell(currentRow, 27).Value = "Kazi105";
                    worksheet.Cell(currentRow, 28).Value = "KilomitaUjazo202";
                    worksheet.Cell(currentRow, 29).Value = "KilomitaKituo201";
                    worksheet.Cell(currentRow, 30).Value = "UgumuKliniki204a";
                    worksheet.Cell(currentRow, 31).Value = "HudumaHapa205";
                    worksheet.Cell(currentRow, 32).Value = "BasiMbaliAfya204b_1";
                    worksheet.Cell(currentRow, 33).Value = "UgumuUsafiriUmma204b_2";
                    worksheet.Cell(currentRow, 34).Value = "MsafaraMrefu204b_4";
                    worksheet.Cell(currentRow, 35).Value = "AnaishiMbaliBasi204b_5";
                    worksheet.Cell(currentRow, 36).Value = "AnaishiMbaliAfya204b_6";
                    worksheet.Cell(currentRow, 37).Value = "Mengine204b_7";
                    worksheet.Cell(currentRow, 38).Value = "TajaMengine204b";
                    worksheet.Cell(currentRow, 39).Value = "UmepataHapaHuduma206";
                    worksheet.Cell(currentRow, 40).Value = "UmriMimba301";
                    worksheet.Cell(currentRow, 41).Value = "MwakaVVU302";
                    worksheet.Cell(currentRow, 42).Value = "MdaVVU303";
                    worksheet.Cell(currentRow, 43).Value = "DawaVVU304a";
                    worksheet.Cell(currentRow, 44).Value = "LiniDawaVVU304b";
                    worksheet.Cell(currentRow, 45).Value = "CTC304c";
                    worksheet.Cell(currentRow, 46).Value = "CreatedByUser";
                    worksheet.Cell(currentRow, 47).Value = "CreatedDate";
                    worksheet.Cell(currentRow, 48).Value = "ModifiedByUser";
                    worksheet.Cell(currentRow, 49).Value = "ModifiedDate";
                    worksheet.Cell(currentRow, 50).Value = "Edited";


                    foreach (var item in pmtctDatas)
                    {
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = item.ID;
                        worksheet.Cell(currentRow, 2).Value = item.InitiatedART401;
                        worksheet.Cell(currentRow, 3).Value = item.InitiatedARTDate401;
                        worksheet.Cell(currentRow, 4).Value = item.DeliveryFacility402;
                        worksheet.Cell(currentRow, 5).Value = item.DeliveryFacilityDate402;
                        worksheet.Cell(currentRow, 6).Value = item.EarlyBirth403a;
                        worksheet.Cell(currentRow, 7).Value = item.EarlyBirthDate403a;
                        worksheet.Cell(currentRow, 8).Value = item.InfantHIVstatus403b;
                        worksheet.Cell(currentRow, 9).Value = item.InfantHIVstatusDate403b;
                        worksheet.Cell(currentRow, 10).Value = item.MotherResults403c;
                        worksheet.Cell(currentRow, 11).Value = item.MotherResultsDate403c;
                        worksheet.Cell(currentRow, 12).Value = item.InfantBreastfeeding404a;
                        worksheet.Cell(currentRow, 13).Value = item.InfantBreastfeedingDate404a;
                        worksheet.Cell(currentRow, 14).Value = item.RemarksName;
                        worksheet.Cell(currentRow, 15).Value = item.NambaMshiriki01;
                        worksheet.Cell(currentRow, 16).Value = item.Wilaya02;
                        worksheet.Cell(currentRow, 17).Value = item.TareheMahojiano03;
                        worksheet.Cell(currentRow, 18).Value = item.Kituo04;
                        worksheet.Cell(currentRow, 19).Value = item.JinaAnayehoji05;
                        worksheet.Cell(currentRow, 20).Value = item.Ngazikituo06;
                        worksheet.Cell(currentRow, 21).Value = item.MdaKuishiZanzibar109;
                        worksheet.Cell(currentRow, 22).Value = item.KiwangoElimu102;
                        worksheet.Cell(currentRow, 23).Value = item.Umri101;
                        worksheet.Cell(currentRow, 24).Value = item.IdadiMimba106;
                        worksheet.Cell(currentRow, 25).Value = item.HaliNdoa103;
                        worksheet.Cell(currentRow, 26).Value = item.KipatoMwezi104;
                        worksheet.Cell(currentRow, 27).Value = item.Kazi105;
                        worksheet.Cell(currentRow, 28).Value = item.KilomitaUjazo202;
                        worksheet.Cell(currentRow, 29).Value = item.KilomitaKituo201;
                        worksheet.Cell(currentRow, 30).Value = item.UgumuKliniki204a;
                        worksheet.Cell(currentRow, 31).Value = item.HudumaHapa205;
                        worksheet.Cell(currentRow, 32).Value = item.BasiMbaliAfya204b_1;
                        worksheet.Cell(currentRow, 33).Value = item.UgumuUsafiriUmma204b_2;
                        worksheet.Cell(currentRow, 34).Value = item.MsafaraMrefu204b_4;
                        worksheet.Cell(currentRow, 35).Value = item.AnaishiMbaliBasi204b_5;
                        worksheet.Cell(currentRow, 36).Value = item.AnaishiMbaliAfya204b_6;
                        worksheet.Cell(currentRow, 37).Value = item.Mengine204b_7;
                        worksheet.Cell(currentRow, 38).Value = item.TajaMengine204b;
                        worksheet.Cell(currentRow, 39).Value = item.UmepataHapaHuduma206;
                        worksheet.Cell(currentRow, 40).Value = item.UmriMimba301;
                        worksheet.Cell(currentRow, 41).Value = item.MwakaVVU302;
                        worksheet.Cell(currentRow, 42).Value = item.MdaVVU303;
                        worksheet.Cell(currentRow, 43).Value = item.DawaVVU304a;
                        worksheet.Cell(currentRow, 44).Value = item.LiniDawaVVU304b;
                        worksheet.Cell(currentRow, 45).Value = item.CTC304c;
                        worksheet.Cell(currentRow, 46).Value = item.CreatedByUser;
                        worksheet.Cell(currentRow, 47).Value = item.CreatedDate;
                        worksheet.Cell(currentRow, 48).Value = item.ModifiedByUser;
                        worksheet.Cell(currentRow, 49).Value = item.ModifiedDate;
                        worksheet.Cell(currentRow, 50).Value = item.Edited;

                    }
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, "application/vnd.openxlformats-officedocument.spreadsheetml.sheet"
                            , "PmtctInfo.xlsx");
                    }
                }
            }
            else
            {
                pmtctDatas = await _context.Pmt.Where(p => p.CreatedByUser == currentUserService.GetCurrentUsername()).ToListAsync();

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("pmtctDatas");
                    var currentRow = 1;
                    worksheet.Cell(currentRow, 1).Value = "ID";
                    worksheet.Cell(currentRow, 2).Value = "InitiatedART401";
                    worksheet.Cell(currentRow, 3).Value = "InitiatedARTDate401";
                    worksheet.Cell(currentRow, 4).Value = "DeliveryFacility402";
                    worksheet.Cell(currentRow, 5).Value = "DeliveryFacilityDate402";
                    worksheet.Cell(currentRow, 6).Value = "EarlyBirth403a";
                    worksheet.Cell(currentRow, 7).Value = "EarlyBirthDate403a";
                    worksheet.Cell(currentRow, 8).Value = "InfantHIVstatus403b";
                    worksheet.Cell(currentRow, 9).Value = "InfantHIVstatusDate403b";
                    worksheet.Cell(currentRow, 10).Value = "MotherResults403c";
                    worksheet.Cell(currentRow, 11).Value = "MotherResultsDate403c";
                    worksheet.Cell(currentRow, 12).Value = "InfantBreastfeeding404a";
                    worksheet.Cell(currentRow, 13).Value = "InfantBreastfeedingDate404a";
                    worksheet.Cell(currentRow, 14).Value = "RemarksName";
                    worksheet.Cell(currentRow, 15).Value = "NambaMshiriki01";
                    worksheet.Cell(currentRow, 16).Value = "Wilaya02";
                    worksheet.Cell(currentRow, 17).Value = "TareheMahojiano03";
                    worksheet.Cell(currentRow, 18).Value = "Kituo04";
                    worksheet.Cell(currentRow, 19).Value = "JinaAnayehoji05";
                    worksheet.Cell(currentRow, 20).Value = "Ngazikituo06";
                    worksheet.Cell(currentRow, 21).Value = "MdaKuishiZanzibar109";
                    worksheet.Cell(currentRow, 22).Value = "KiwangoElimu102";
                    worksheet.Cell(currentRow, 23).Value = "Umri101";
                    worksheet.Cell(currentRow, 24).Value = "IdadiMimba106";
                    worksheet.Cell(currentRow, 25).Value = "HaliNdoa103";
                    worksheet.Cell(currentRow, 26).Value = "KipatoMwezi104";
                    worksheet.Cell(currentRow, 27).Value = "Kazi105";
                    worksheet.Cell(currentRow, 28).Value = "KilomitaUjazo202";
                    worksheet.Cell(currentRow, 29).Value = "KilomitaKituo201";
                    worksheet.Cell(currentRow, 30).Value = "UgumuKliniki204a";
                    worksheet.Cell(currentRow, 31).Value = "HudumaHapa205";
                    worksheet.Cell(currentRow, 32).Value = "BasiMbaliAfya204b_1";
                    worksheet.Cell(currentRow, 33).Value = "UgumuUsafiriUmma204b_2";
                    worksheet.Cell(currentRow, 34).Value = "MsafaraMrefu204b_4";
                    worksheet.Cell(currentRow, 35).Value = "AnaishiMbaliBasi204b_5";
                    worksheet.Cell(currentRow, 36).Value = "AnaishiMbaliAfya204b_6";
                    worksheet.Cell(currentRow, 37).Value = "Mengine204b_7";
                    worksheet.Cell(currentRow, 38).Value = "TajaMengine204b";
                    worksheet.Cell(currentRow, 39).Value = "UmepataHapaHuduma206";
                    worksheet.Cell(currentRow, 40).Value = "UmriMimba301";
                    worksheet.Cell(currentRow, 41).Value = "MwakaVVU302";
                    worksheet.Cell(currentRow, 42).Value = "MdaVVU303";
                    worksheet.Cell(currentRow, 43).Value = "DawaVVU304a";
                    worksheet.Cell(currentRow, 44).Value = "LiniDawaVVU304b";
                    worksheet.Cell(currentRow, 45).Value = "CTC304c";
                    worksheet.Cell(currentRow, 46).Value = "CreatedByUser";
                    worksheet.Cell(currentRow, 47).Value = "CreatedDate";
                    worksheet.Cell(currentRow, 48).Value = "ModifiedByUser";
                    worksheet.Cell(currentRow, 49).Value = "ModifiedDate";
                    worksheet.Cell(currentRow, 50).Value = "Edited";



                    foreach (var item in pmtctDatas)
                    {
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = item.ID;
                        worksheet.Cell(currentRow, 2).Value = item.InitiatedART401;
                        worksheet.Cell(currentRow, 3).Value = item.InitiatedARTDate401;
                        worksheet.Cell(currentRow, 4).Value = item.DeliveryFacility402;
                        worksheet.Cell(currentRow, 5).Value = item.DeliveryFacilityDate402;
                        worksheet.Cell(currentRow, 6).Value = item.EarlyBirth403a;
                        worksheet.Cell(currentRow, 7).Value = item.EarlyBirthDate403a;
                        worksheet.Cell(currentRow, 8).Value = item.InfantHIVstatus403b;
                        worksheet.Cell(currentRow, 9).Value = item.InfantHIVstatusDate403b;
                        worksheet.Cell(currentRow, 10).Value = item.MotherResults403c;
                        worksheet.Cell(currentRow, 11).Value = item.MotherResultsDate403c;
                        worksheet.Cell(currentRow, 12).Value = item.InfantBreastfeeding404a;
                        worksheet.Cell(currentRow, 13).Value = item.InfantBreastfeedingDate404a;
                        worksheet.Cell(currentRow, 14).Value = item.RemarksName;
                        worksheet.Cell(currentRow, 15).Value = item.NambaMshiriki01;
                        worksheet.Cell(currentRow, 16).Value = item.Wilaya02;
                        worksheet.Cell(currentRow, 17).Value = item.TareheMahojiano03;
                        worksheet.Cell(currentRow, 18).Value = item.Kituo04;
                        worksheet.Cell(currentRow, 19).Value = item.JinaAnayehoji05;
                        worksheet.Cell(currentRow, 20).Value = item.Ngazikituo06;
                        worksheet.Cell(currentRow, 21).Value = item.MdaKuishiZanzibar109;
                        worksheet.Cell(currentRow, 22).Value = item.KiwangoElimu102;
                        worksheet.Cell(currentRow, 23).Value = item.Umri101;
                        worksheet.Cell(currentRow, 24).Value = item.IdadiMimba106;
                        worksheet.Cell(currentRow, 25).Value = item.HaliNdoa103;
                        worksheet.Cell(currentRow, 26).Value = item.KipatoMwezi104;
                        worksheet.Cell(currentRow, 27).Value = item.Kazi105;
                        worksheet.Cell(currentRow, 28).Value = item.KilomitaUjazo202;
                        worksheet.Cell(currentRow, 29).Value = item.KilomitaKituo201;
                        worksheet.Cell(currentRow, 30).Value = item.UgumuKliniki204a;
                        worksheet.Cell(currentRow, 31).Value = item.HudumaHapa205;
                        worksheet.Cell(currentRow, 32).Value = item.BasiMbaliAfya204b_1;
                        worksheet.Cell(currentRow, 33).Value = item.UgumuUsafiriUmma204b_2;
                        worksheet.Cell(currentRow, 34).Value = item.MsafaraMrefu204b_4;
                        worksheet.Cell(currentRow, 35).Value = item.AnaishiMbaliBasi204b_5;
                        worksheet.Cell(currentRow, 36).Value = item.AnaishiMbaliAfya204b_6;
                        worksheet.Cell(currentRow, 37).Value = item.Mengine204b_7;
                        worksheet.Cell(currentRow, 38).Value = item.TajaMengine204b;
                        worksheet.Cell(currentRow, 39).Value = item.UmepataHapaHuduma206;
                        worksheet.Cell(currentRow, 40).Value = item.UmriMimba301;
                        worksheet.Cell(currentRow, 41).Value = item.MwakaVVU302;
                        worksheet.Cell(currentRow, 42).Value = item.MdaVVU303;
                        worksheet.Cell(currentRow, 43).Value = item.DawaVVU304a;
                        worksheet.Cell(currentRow, 44).Value = item.LiniDawaVVU304b;
                        worksheet.Cell(currentRow, 45).Value = item.CTC304c;
                        worksheet.Cell(currentRow, 46).Value = item.CreatedByUser;
                        worksheet.Cell(currentRow, 47).Value = item.CreatedDate;
                        worksheet.Cell(currentRow, 48).Value = item.ModifiedByUser;
                        worksheet.Cell(currentRow, 49).Value = item.ModifiedDate;
                        worksheet.Cell(currentRow, 50).Value = item.Edited;

                    }
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, "application/vnd.openxlformats-officedocument.spreadsheetml.sheet"
                            , "PmtctInfo.xlsx");
                    }
                }


            }


        }



   







    }
}
