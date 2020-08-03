using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pmtct.Data;
using Pmtct.Models;

namespace Pmtct.Controllers
{
    [Route("api/PmtctUpExcel")]
    [ApiController]
    [Authorize(Roles = "admin,analyst,dataentry")]

    public class PmtctUpExcelController : ControllerBase
    {
        private readonly PmtctContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public PmtctUpExcelController(PmtctContext context, RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        [HttpGet]
        public async Task<ActionResult> ExcelDoc()
        {
            bool isSuperUser = User.IsInRole("admin") || User.IsInRole("analyst");
            List<Pmtct.Models.PmtctFollowUp> pmtctUp = new List<PmtctFollowUp>();
           
            if (isSuperUser)
            {
                pmtctUp = await _context.PmtctFollowUp.ToListAsync();

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("pmtctDatas");
                    var currentRow = 1;
                    worksheet.Cell(currentRow, 1).Value = "ID";
                    worksheet.Cell(currentRow, 2).Value = "NambaMshiriki01";
                    worksheet.Cell(currentRow, 3).Value = "TareheHudhurio";
                    worksheet.Cell(currentRow, 4).Value = "HaliYako305a";
                    worksheet.Cell(currentRow, 5).Value = "Mwenza305b1";
                    worksheet.Cell(currentRow, 6).Value = "Mwanafamiliaa305b2";
                    worksheet.Cell(currentRow, 7).Value = "Wazazi305b3";
                    worksheet.Cell(currentRow, 8).Value = "Rafiki305b1";
                    worksheet.Cell(currentRow, 9).Value = "Mfanyakazi305b5";
                    worksheet.Cell(currentRow, 10).Value = "Wengine305b6";
                    worksheet.Cell(currentRow, 11).Value = "Tajawengine305b7";
                    worksheet.Cell(currentRow, 12).Value = "Naogopakutengwa306a1";
                    worksheet.Cell(currentRow, 13).Value = "Naogopakuachwa306a2";
                    worksheet.Cell(currentRow, 14).Value = "kunyanyapaliwa306a2";
                    worksheet.Cell(currentRow, 15).Value = "BadosijaaminiVVUliwa306a4";
                    worksheet.Cell(currentRow, 16).Value = "Sinaninaemwamini306a6";
                    worksheet.Cell(currentRow, 17).Value = "Nyinginezo306a6";
                    worksheet.Cell(currentRow, 18).Value = "MpangoMtu306b";
                    worksheet.Cell(currentRow, 19).Value = "HaliMwenza307";
                    worksheet.Cell(currentRow, 20).Value = "KuhudumiwaTofautiVVU308a";
                    worksheet.Cell(currentRow, 21).Value = "Mwenza308b1";
                    worksheet.Cell(currentRow, 22).Value = "Mwanafamiliaa308b2";
                    worksheet.Cell(currentRow, 23).Value = "Wazazi308b3";
                    worksheet.Cell(currentRow, 24).Value = "Rafiki308b1";
                    worksheet.Cell(currentRow, 25).Value = "Mfanyakazi308b5";
                    worksheet.Cell(currentRow, 26).Value = "Mhudumu308b6";
                    worksheet.Cell(currentRow, 27).Value = "Wengine308b7";
                    worksheet.Cell(currentRow, 28).Value = "Tajawengine308b8";
                    worksheet.Cell(currentRow, 29).Value = "UmejiungaVVU309a";
                    worksheet.Cell(currentRow, 30).Value = "NdioTaja309b";
                    worksheet.Cell(currentRow, 31).Value = "MamaMwambata310a";
                    worksheet.Cell(currentRow, 32).Value = "Ushauri310b1";
                    worksheet.Cell(currentRow, 33).Value = "Elimuafya310b2";
                    worksheet.Cell(currentRow, 34).Value = "Ufuatiliaji310b3";
                    worksheet.Cell(currentRow, 35).Value = "Nyinginezo310b4";
                    worksheet.Cell(currentRow, 36).Value = "Rufaa";
                    worksheet.Cell(currentRow, 37).Value = "TareheHudhurioLijalo";
                    worksheet.Cell(currentRow, 38).Value = "Ufuatiliaji";
                    worksheet.Cell(currentRow, 39).Value = "JinaMtoHuduma";
                    worksheet.Cell(currentRow, 40).Value = "UserId";
                   




                    foreach (var item in pmtctUp)
                    {
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = item.ID;
                        worksheet.Cell(currentRow, 2).Value = item.NambaMshiriki01;
                        worksheet.Cell(currentRow, 3).Value = item.TareheHudhurio;
                        worksheet.Cell(currentRow, 4).Value = item.HaliYako305a;
                        worksheet.Cell(currentRow, 5).Value = item.Mwenza305b1;
                        worksheet.Cell(currentRow, 6).Value = item.Mwanafamiliaa305b2;
                        worksheet.Cell(currentRow, 7).Value = item.Wazazi305b3;
                        worksheet.Cell(currentRow, 8).Value = item.Rafiki305b1;
                        worksheet.Cell(currentRow, 9).Value = item.Mfanyakazi305b5;
                        worksheet.Cell(currentRow, 10).Value = item.Wengine305b6;
                        worksheet.Cell(currentRow, 11).Value = item.Tajawengine305b7;
                        worksheet.Cell(currentRow, 12).Value = item.Naogopakutengwa306a1;
                        worksheet.Cell(currentRow, 13).Value = item.Naogopakuachwa306a2;
                        worksheet.Cell(currentRow, 14).Value = item.kunyanyapaliwa306a2;
                        worksheet.Cell(currentRow, 15).Value = item.BadosijaaminiVVUliwa306a4;
                        worksheet.Cell(currentRow, 16).Value = item.Sinaninaemwamini306a6;
                        worksheet.Cell(currentRow, 17).Value = item.Nyinginezo306a6;
                        worksheet.Cell(currentRow, 18).Value = item.MpangoMtu306b;
                        worksheet.Cell(currentRow, 19).Value = item.HaliMwenza307;
                        worksheet.Cell(currentRow, 20).Value = item.KuhudumiwaTofautiVVU308a;
                        worksheet.Cell(currentRow, 21).Value = item.Mwenza308b1;
                        worksheet.Cell(currentRow, 22).Value = item.Mwanafamiliaa308b2;
                        worksheet.Cell(currentRow, 23).Value = item.Wazazi308b3;
                        worksheet.Cell(currentRow, 24).Value = item.Rafiki308b1;
                        worksheet.Cell(currentRow, 25).Value = item.Mfanyakazi308b5;
                        worksheet.Cell(currentRow, 26).Value = item.Mhudumu308b6;
                        worksheet.Cell(currentRow, 27).Value = item.Wengine308b7;
                        worksheet.Cell(currentRow, 28).Value = item.Tajawengine308b8;
                        worksheet.Cell(currentRow, 29).Value = item.UmejiungaVVU309a;
                        worksheet.Cell(currentRow, 30).Value = item.NdioTaja309b;
                        worksheet.Cell(currentRow, 31).Value = item.MamaMwambata310a;
                        worksheet.Cell(currentRow, 32).Value = item.Ushauri310b1;
                        worksheet.Cell(currentRow, 33).Value = item.Elimuafya310b2;
                        worksheet.Cell(currentRow, 34).Value = item.Ufuatiliaji310b3;
                        worksheet.Cell(currentRow, 35).Value = item.Nyinginezo310b4;
                        worksheet.Cell(currentRow, 36).Value = item.Rufaa;
                        worksheet.Cell(currentRow, 37).Value = item.TareheHudhurioLijalo;
                        worksheet.Cell(currentRow, 38).Value = item.Ufuatiliaji;
                        worksheet.Cell(currentRow, 39).Value = item.JinaMtoHuduma;
                        worksheet.Cell(currentRow, 40).Value = item.UserId;
                    }
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, "application/vnd.openxlformats-officedocument.spreadsheetml.sheet"
                            , "Pmtct_follow_up.xlsx");
                    }

                }
            }
            else
            {
                pmtctUp = await _context.PmtctFollowUp.Where(p => p.UserId == _userManager.GetUserId(User)).ToListAsync();

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("pmtctDatas");
                    var currentRow = 1;
                    worksheet.Cell(currentRow, 1).Value = "ID";
                    worksheet.Cell(currentRow, 2).Value = "NambaMshiriki01";
                    worksheet.Cell(currentRow, 3).Value = "TareheHudhurio";
                    worksheet.Cell(currentRow, 4).Value = "HaliYako305a";
                    worksheet.Cell(currentRow, 5).Value = "Mwenza305b1";
                    worksheet.Cell(currentRow, 6).Value = "Mwanafamiliaa305b2";
                    worksheet.Cell(currentRow, 7).Value = "Wazazi305b3";
                    worksheet.Cell(currentRow, 8).Value = "Rafiki305b1";
                    worksheet.Cell(currentRow, 9).Value = "Mfanyakazi305b5";
                    worksheet.Cell(currentRow, 10).Value = "Wengine305b6";
                    worksheet.Cell(currentRow, 11).Value = "Tajawengine305b7";
                    worksheet.Cell(currentRow, 12).Value = "Naogopakutengwa306a1";
                    worksheet.Cell(currentRow, 13).Value = "Naogopakuachwa306a2";
                    worksheet.Cell(currentRow, 14).Value = "kunyanyapaliwa306a2";
                    worksheet.Cell(currentRow, 15).Value = "BadosijaaminiVVUliwa306a4";
                    worksheet.Cell(currentRow, 16).Value = "Sinaninaemwamini306a6";
                    worksheet.Cell(currentRow, 17).Value = "Nyinginezo306a6";
                    worksheet.Cell(currentRow, 18).Value = "MpangoMtu306b";
                    worksheet.Cell(currentRow, 19).Value = "HaliMwenza307";
                    worksheet.Cell(currentRow, 20).Value = "KuhudumiwaTofautiVVU308a";
                    worksheet.Cell(currentRow, 21).Value = "Mwenza308b1";
                    worksheet.Cell(currentRow, 22).Value = "Mwanafamiliaa308b2";
                    worksheet.Cell(currentRow, 23).Value = "Wazazi308b3";
                    worksheet.Cell(currentRow, 24).Value = "Rafiki308b1";
                    worksheet.Cell(currentRow, 25).Value = "Mfanyakazi308b5";
                    worksheet.Cell(currentRow, 26).Value = "Mhudumu308b6";
                    worksheet.Cell(currentRow, 27).Value = "Wengine308b7";
                    worksheet.Cell(currentRow, 28).Value = "Tajawengine308b8";
                    worksheet.Cell(currentRow, 29).Value = "UmejiungaVVU309a";
                    worksheet.Cell(currentRow, 30).Value = "NdioTaja309b";
                    worksheet.Cell(currentRow, 31).Value = "MamaMwambata310a";
                    worksheet.Cell(currentRow, 32).Value = "Ushauri310b1";
                    worksheet.Cell(currentRow, 33).Value = "Elimuafya310b2";
                    worksheet.Cell(currentRow, 34).Value = "Ufuatiliaji310b3";
                    worksheet.Cell(currentRow, 35).Value = "Nyinginezo310b4";
                    worksheet.Cell(currentRow, 36).Value = "Rufaa";
                    worksheet.Cell(currentRow, 37).Value = "TareheHudhurioLijalo";
                    worksheet.Cell(currentRow, 38).Value = "Ufuatiliaji";
                    worksheet.Cell(currentRow, 39).Value = "JinaMtoHuduma";
                    worksheet.Cell(currentRow, 40).Value = "UserId";


                    foreach (var item in pmtctUp)
                    {
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = item.ID;
                        worksheet.Cell(currentRow, 2).Value = item.NambaMshiriki01;
                        worksheet.Cell(currentRow, 3).Value = item.TareheHudhurio;
                        worksheet.Cell(currentRow, 4).Value = item.HaliYako305a;
                        worksheet.Cell(currentRow, 5).Value = item.Mwenza305b1;
                        worksheet.Cell(currentRow, 6).Value = item.Mwanafamiliaa305b2;
                        worksheet.Cell(currentRow, 7).Value = item.Wazazi305b3;
                        worksheet.Cell(currentRow, 8).Value = item.Rafiki305b1;
                        worksheet.Cell(currentRow, 9).Value = item.Mfanyakazi305b5;
                        worksheet.Cell(currentRow, 10).Value = item.Wengine305b6;
                        worksheet.Cell(currentRow, 11).Value = item.Tajawengine305b7;
                        worksheet.Cell(currentRow, 12).Value = item.Naogopakutengwa306a1;
                        worksheet.Cell(currentRow, 13).Value = item.Naogopakuachwa306a2;
                        worksheet.Cell(currentRow, 14).Value = item.kunyanyapaliwa306a2;
                        worksheet.Cell(currentRow, 15).Value = item.BadosijaaminiVVUliwa306a4;
                        worksheet.Cell(currentRow, 16).Value = item.Sinaninaemwamini306a6;
                        worksheet.Cell(currentRow, 17).Value = item.Nyinginezo306a6;
                        worksheet.Cell(currentRow, 18).Value = item.MpangoMtu306b;
                        worksheet.Cell(currentRow, 19).Value = item.HaliMwenza307;
                        worksheet.Cell(currentRow, 20).Value = item.KuhudumiwaTofautiVVU308a;
                        worksheet.Cell(currentRow, 21).Value = item.Mwenza308b1;
                        worksheet.Cell(currentRow, 22).Value = item.Mwanafamiliaa308b2;
                        worksheet.Cell(currentRow, 23).Value = item.Wazazi308b3;
                        worksheet.Cell(currentRow, 24).Value = item.Rafiki308b1;
                        worksheet.Cell(currentRow, 25).Value = item.Mfanyakazi308b5;
                        worksheet.Cell(currentRow, 26).Value = item.Mhudumu308b6;
                        worksheet.Cell(currentRow, 27).Value = item.Wengine308b7;
                        worksheet.Cell(currentRow, 28).Value = item.Tajawengine308b8;
                        worksheet.Cell(currentRow, 29).Value = item.UmejiungaVVU309a;
                        worksheet.Cell(currentRow, 30).Value = item.NdioTaja309b;
                        worksheet.Cell(currentRow, 31).Value = item.MamaMwambata310a;
                        worksheet.Cell(currentRow, 32).Value = item.Ushauri310b1;
                        worksheet.Cell(currentRow, 33).Value = item.Elimuafya310b2;
                        worksheet.Cell(currentRow, 34).Value = item.Ufuatiliaji310b3;
                        worksheet.Cell(currentRow, 35).Value = item.Nyinginezo310b4;
                        worksheet.Cell(currentRow, 36).Value = item.Rufaa;
                        worksheet.Cell(currentRow, 37).Value = item.TareheHudhurioLijalo;
                        worksheet.Cell(currentRow, 38).Value = item.Ufuatiliaji;
                        worksheet.Cell(currentRow, 39).Value = item.JinaMtoHuduma;
                        worksheet.Cell(currentRow, 40).Value = item.UserId;
                    }
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, "application/vnd.openxlformats-officedocument.spreadsheetml.sheet"
                            , "Pmtct_follow_up.xlsx");
                    }

                }

            }

        }





    }
}
