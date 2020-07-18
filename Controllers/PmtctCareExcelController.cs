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
    [Route("api/PmtctCareExcel")]
    [ApiController]
    [Authorize(Roles = "admin,analyst,dataentry,dataclerk")]
    public class PmtctCareExcelController : ControllerBase
    {
        private readonly PmtctContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public PmtctCareExcelController(PmtctContext context, RoleManager<IdentityRole> roleManager,
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

            List<Pmtct.Models.PmtctCareCascade> pmtctcare = new List<PmtctCareCascade>();
            var builder = new StringBuilder();
             
            if (isSuperUser)
            {
                pmtctcare = await _context.PmtctCareCascade.ToListAsync();

                
                builder.AppendLine("NambaMshiriki01,ID,UserId,SN,ServiceName,ResponseName,ServiceDate,RemarksName");
                foreach (var item in pmtctcare)
                {
                    builder.AppendLine($"{item.ID},{item.UserId},{item.SN}," +
                        $"{item.NambaMshiriki01},{item.SN},{item.ServiceDate},{item.ResponseName}," +
                        $"{item.ServiceName},{item.ResponseName},{item.ServiceDate}," +
                        $"{item.RemarksName}");
                }


                return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Pmtct_Care_Cascade.csv");


            }

            else

                pmtctcare = await _context.PmtctCareCascade.Where(p => p.UserId == _userManager.GetUserId(User)).ToListAsync();
           
            builder.AppendLine("NambaMshiriki01,ID,UserId,SN,ServiceName,ResponseName,ServiceDate,RemarksName");
            foreach (var item in pmtctcare)
            {
                builder.AppendLine($"{item.ID},{item.UserId},{item.SN}," +
                    $"{item.NambaMshiriki01},{item.SN},{item.ServiceDate},{item.ResponseName}," +
                    $"{item.ServiceName},{item.ResponseName},{item.ServiceDate}," +
                    $"{item.RemarksName}");
            }


            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Pmtct_Care_Cascade.csv");




        }



        [HttpGet]
        public async Task<ActionResult> ExcelDoc()
        {
            bool isSuperUser = User.IsInRole("admin") || User.IsInRole("analyst");

            List<Pmtct.Models.PmtctCareCascade> pmtctcare = new List<PmtctCareCascade>();


            if (isSuperUser)
            {
                pmtctcare = await _context.PmtctCareCascade.ToListAsync();
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("pmtctDatas");
                    var currentRow = 1;
                    worksheet.Cell(currentRow, 1).Value = "NambaMshiriki01";
                    worksheet.Cell(currentRow, 2).Value = "ID";
                    worksheet.Cell(currentRow, 3).Value = "UserId";
                    worksheet.Cell(currentRow, 4).Value = "SN";
                    worksheet.Cell(currentRow, 5).Value = "ServiceName";
                    worksheet.Cell(currentRow, 6).Value = "ResponseName";
                    worksheet.Cell(currentRow, 7).Value = "ServiceDate";
                    worksheet.Cell(currentRow, 8).Value = "RemarksName";

                    foreach (var item in pmtctcare)
                    {
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = item.NambaMshiriki01;
                        worksheet.Cell(currentRow, 2).Value = item.ID;
                        worksheet.Cell(currentRow, 3).Value = item.UserId;
                        worksheet.Cell(currentRow, 4).Value = item.SN;
                        worksheet.Cell(currentRow, 5).Value = item.ServiceName;
                        worksheet.Cell(currentRow, 6).Value = item.ResponseName;
                        worksheet.Cell(currentRow, 7).Value = item.ServiceDate;
                        worksheet.Cell(currentRow, 8).Value = item.RemarksName;

                    }
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, "application/vnd.openxlformats-officedocument.spreadsheetml.sheet"
                         , "Pmtct_Care_Cascade.xlsx");
                    }

                }


            }
            else
            {
                pmtctcare = await _context.PmtctCareCascade.Where(p => p.UserId == _userManager.GetUserId(User)).ToListAsync();

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("pmtctDatas");
                    var currentRow = 1;
                    worksheet.Cell(currentRow, 1).Value = "NambaMshiriki01";
                    worksheet.Cell(currentRow, 2).Value = "ID";
                    worksheet.Cell(currentRow, 3).Value = "UserId";
                    worksheet.Cell(currentRow, 4).Value = "SN";
                    worksheet.Cell(currentRow, 5).Value = "ServiceName";
                    worksheet.Cell(currentRow, 6).Value = "ResponseName";
                    worksheet.Cell(currentRow, 7).Value = "ServiceDate";
                    worksheet.Cell(currentRow, 8).Value = "RemarksName";

                    foreach (var item in pmtctcare)
                    {
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = item.NambaMshiriki01;
                        worksheet.Cell(currentRow, 2).Value = item.ID;
                        worksheet.Cell(currentRow, 3).Value = item.UserId;
                        worksheet.Cell(currentRow, 4).Value = item.SN;
                        worksheet.Cell(currentRow, 5).Value = item.ServiceName;
                        worksheet.Cell(currentRow, 6).Value = item.ResponseName;
                        worksheet.Cell(currentRow, 7).Value = item.ServiceDate;
                        worksheet.Cell(currentRow, 8).Value = item.RemarksName;

                    }
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, "application/vnd.openxlformats-officedocument.spreadsheetml.sheet"
                            , "Pmtct_Care_Cascade.xlsx");
                    }

                }

            }
        }
    }
}
