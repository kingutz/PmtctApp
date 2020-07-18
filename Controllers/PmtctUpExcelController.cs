using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
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
        public async Task<ActionResult> CSV()
        {
            bool isSuperUser = User.IsInRole("admin") || User.IsInRole("analyst");

            List<Pmtct.Models.PmtctFollowUp> pmtctUp = new List<PmtctFollowUp>();
            var builder = new StringBuilder();

            if (isSuperUser)
            {
                pmtctUp = await _context.PmtctFollowUp.ToListAsync();

                builder.AppendLine("ID,NambaMshiriki01,UserId,TareheHudhurio," +
                    "HaliYako305a,KamaHapana305a,KamaNdio305b,MpangoMtu306b,HaliMwenza307," +
                    "KuhudumiwaTofautiVVU308a,NaniKutendea308b,UmejiungaVVU309a," +
                    "NdioTaja309b,MamaMwambata310a,HudumaHulipatiwa310b,Rufaa," +
                    "TareheHudhurioLijalo,Ufuatiliaji,JinaMtoHuduma");
                foreach (var item in pmtctUp)
                {
                    builder.AppendLine($"{item.ID},{item.NambaMshiriki01},{item.UserId}," +
                        $"{item.TareheHudhurio},{item.HaliYako305a},{item.KamaHapana305a}," +
                        $"{item.KamaNdio305b},{item.MpangoMtu306b},{item.HaliMwenza307}," +
                        $"{item.KuhudumiwaTofautiVVU308a},{item.NaniKutendea308b},{item.UmejiungaVVU309a}," +
                        $"{item.NdioTaja309b},{item.MamaMwambata310a},{item.HudumaHulipatiwa310b}," +
                        $"{item.Rufaa},{item.TareheHudhurioLijalo},{item.Ufuatiliaji},{item.JinaMtoHuduma}");
                }


                return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Pmtct_follow_up.csv");

            }

            else

                pmtctUp = await _context.PmtctFollowUp.Where(p => p.UserId == _userManager.GetUserId(User)).ToListAsync();

            builder.AppendLine("ID,NambaMshiriki01,UserId,TareheHudhurio," +
                "HaliYako305a,KamaHapana305a,KamaNdio305b,MpangoMtu306b,HaliMwenza307," +
                "KuhudumiwaTofautiVVU308a,NaniKutendea308b,UmejiungaVVU309a," +
                "NdioTaja309b,MamaMwambata310a,HudumaHulipatiwa310b,Rufaa," +
                "TareheHudhurioLijalo,Ufuatiliaji,JinaMtoHuduma");
            foreach (var item in pmtctUp)
            {
                builder.AppendLine($"{item.ID},{item.NambaMshiriki01},{item.UserId}," +
                    $"{item.TareheHudhurio},{item.HaliYako305a},{item.KamaHapana305a}," +
                    $"{item.KamaNdio305b},{item.MpangoMtu306b},{item.HaliMwenza307}," +
                    $"{item.KuhudumiwaTofautiVVU308a},{item.NaniKutendea308b},{item.UmejiungaVVU309a}," +
                    $"{item.NdioTaja309b},{item.MamaMwambata310a},{item.HudumaHulipatiwa310b}," +
                    $"{item.Rufaa},{item.TareheHudhurioLijalo},{item.Ufuatiliaji},{item.JinaMtoHuduma}");
            }


            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Pmtct_follow_up.csv");


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
                    worksheet.Cell(currentRow, 3).Value = "UserId";
                    worksheet.Cell(currentRow, 4).Value = "TareheHudhurio";
                    worksheet.Cell(currentRow, 5).Value = "HaliYako305a";
                    worksheet.Cell(currentRow, 6).Value = "KamaHapana305a";
                    worksheet.Cell(currentRow, 7).Value = "KamaNdio305b";
                    worksheet.Cell(currentRow, 8).Value = "MpangoMtu306b";
                    worksheet.Cell(currentRow, 9).Value = "HaliMwenza307";
                    worksheet.Cell(currentRow, 11).Value = "KuhudumiwaTofautiVVU308a";
                    worksheet.Cell(currentRow, 12).Value = "NaniKutendea308b";
                    worksheet.Cell(currentRow, 13).Value = "UmejiungaVVU309a";
                    worksheet.Cell(currentRow, 14).Value = "NdioTaja309b";
                    worksheet.Cell(currentRow, 15).Value = "MamaMwambata310a";
                    worksheet.Cell(currentRow, 16).Value = "HudumaHulipatiwa310b";
                    worksheet.Cell(currentRow, 17).Value = "Rufaa";
                    worksheet.Cell(currentRow, 18).Value = "TareheHudhurioLijalo";
                    worksheet.Cell(currentRow, 19).Value = "Ufuatiliaji";
                    worksheet.Cell(currentRow, 20).Value = "JinaMtoHuduma";




                    foreach (var item in pmtctUp)
                    {
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = item.ID;
                        worksheet.Cell(currentRow, 2).Value = item.NambaMshiriki01;
                        worksheet.Cell(currentRow, 3).Value = item.UserId;
                        worksheet.Cell(currentRow, 4).Value = item.TareheHudhurio;
                        worksheet.Cell(currentRow, 5).Value = item.HaliYako305a;
                        worksheet.Cell(currentRow, 6).Value = item.KamaHapana305a;
                        worksheet.Cell(currentRow, 7).Value = item.KamaNdio305b;
                        worksheet.Cell(currentRow, 8).Value = item.MpangoMtu306b;
                        worksheet.Cell(currentRow, 9).Value = item.HaliMwenza307;
                        worksheet.Cell(currentRow, 10).Value = item.KuhudumiwaTofautiVVU308a;
                        worksheet.Cell(currentRow, 11).Value = item.NaniKutendea308b;
                        worksheet.Cell(currentRow, 12).Value = item.UmejiungaVVU309a;
                        worksheet.Cell(currentRow, 13).Value = item.NdioTaja309b;
                        worksheet.Cell(currentRow, 14).Value = item.MamaMwambata310a;
                        worksheet.Cell(currentRow, 15).Value = item.HudumaHulipatiwa310b;
                        worksheet.Cell(currentRow, 16).Value = item.Rufaa;
                        worksheet.Cell(currentRow, 17).Value = item.TareheHudhurioLijalo;
                        worksheet.Cell(currentRow, 18).Value = item.Ufuatiliaji;
                        worksheet.Cell(currentRow, 19).Value = item.JinaMtoHuduma;
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
                    worksheet.Cell(currentRow, 3).Value = "UserId";
                    worksheet.Cell(currentRow, 4).Value = "TareheHudhurio";
                    worksheet.Cell(currentRow, 5).Value = "HaliYako305a";
                    worksheet.Cell(currentRow, 6).Value = "KamaHapana305a";
                    worksheet.Cell(currentRow, 7).Value = "KamaNdio305b";
                    worksheet.Cell(currentRow, 8).Value = "MpangoMtu306b";
                    worksheet.Cell(currentRow, 9).Value = "HaliMwenza307";
                    worksheet.Cell(currentRow, 11).Value = "KuhudumiwaTofautiVVU308a";
                    worksheet.Cell(currentRow, 12).Value = "NaniKutendea308b";
                    worksheet.Cell(currentRow, 13).Value = "UmejiungaVVU309a";
                    worksheet.Cell(currentRow, 14).Value = "NdioTaja309b";
                    worksheet.Cell(currentRow, 15).Value = "MamaMwambata310a";
                    worksheet.Cell(currentRow, 16).Value = "HudumaHulipatiwa310b";
                    worksheet.Cell(currentRow, 17).Value = "Rufaa";
                    worksheet.Cell(currentRow, 18).Value = "TareheHudhurioLijalo";
                    worksheet.Cell(currentRow, 19).Value = "Ufuatiliaji";
                    worksheet.Cell(currentRow, 20).Value = "JinaMtoHuduma";

                    foreach (var item in pmtctUp)
                    {
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = item.ID;
                        worksheet.Cell(currentRow, 2).Value = item.NambaMshiriki01;
                        worksheet.Cell(currentRow, 3).Value = item.UserId;
                        worksheet.Cell(currentRow, 4).Value = item.TareheHudhurio;
                        worksheet.Cell(currentRow, 5).Value = item.HaliYako305a;
                        worksheet.Cell(currentRow, 6).Value = item.KamaHapana305a;
                        worksheet.Cell(currentRow, 7).Value = item.KamaNdio305b;
                        worksheet.Cell(currentRow, 8).Value = item.MpangoMtu306b;
                        worksheet.Cell(currentRow, 9).Value = item.HaliMwenza307;
                        worksheet.Cell(currentRow, 10).Value = item.KuhudumiwaTofautiVVU308a;
                        worksheet.Cell(currentRow, 11).Value = item.NaniKutendea308b;
                        worksheet.Cell(currentRow, 12).Value = item.UmejiungaVVU309a;
                        worksheet.Cell(currentRow, 13).Value = item.NdioTaja309b;
                        worksheet.Cell(currentRow, 14).Value = item.MamaMwambata310a;
                        worksheet.Cell(currentRow, 15).Value = item.HudumaHulipatiwa310b;
                        worksheet.Cell(currentRow, 16).Value = item.Rufaa;
                        worksheet.Cell(currentRow, 17).Value = item.TareheHudhurioLijalo;
                        worksheet.Cell(currentRow, 18).Value = item.Ufuatiliaji;
                        worksheet.Cell(currentRow, 19).Value = item.JinaMtoHuduma;
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
