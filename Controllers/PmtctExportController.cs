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

namespace Pmtct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PmtctExportController : ControllerBase
    {
        private readonly PmtctContext _context;

        public PmtctExportController(PmtctContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> CSV(bool csv=false)
            
        {
            List<Pmtct.Models.PmtctData> pmtctDatas = new List<PmtctData>();
            var builder = new StringBuilder();

            if (csv)
            {
                
                pmtctDatas = await _context.Pmt.ToListAsync();
              
                builder.AppendLine("NambaMshiriki01,Wilaya02,TareheMahojiano03,Kituo04,JinaAnayehoji05,Ngazikituo06,MdaKuishiZanzibar109,KiwangoElimu102,Umri101,WilayaUnayoishi107,IdadiMimba106,HaliNdoa103,KipatoMwezi104,Kazi105,NjeZanzibar108,KilomitaKituo201,KilomitaUjazo202,HudumaUjauzito203,UgumuKliniki204a,HudumaHapa205,BasiMbaliAfya204b_1,UgumuUsafiriUmma204b_2,KukosaNauli204b_3,MsafaraMrefu204b_4,AnaishiMbaliBasi204b_5,AnaishiMbaliAfya204b_6,Mengine204b_7,TajaMengine204b,UmepataHapaHuduma206,UmriMimba301,MwakaVVU302,MdaVVU303,DawaVVU304a,LiniDawaVVU304b,CTC304c");
                foreach (var item in pmtctDatas)
                {
                    builder.AppendLine($"{item.NambaMshiriki01},{item.Wilaya02},{item.TareheMahojiano03},{item.Kituo04},{item.JinaAnayehoji05},{item.Ngazikituo06},{item.MdaKuishiZanzibar109},{item.KiwangoElimu102},{item.Umri101},{item.WilayaUnayoishi107},{item.IdadiMimba106},{item.HaliNdoa103},{item.KipatoMwezi104},{item.Kazi105},{item.NjeZanzibar108},{item.KilomitaKituo201},{item.KilomitaUjazo202},{item.UgumuKliniki204a},{item.HudumaHapa205},{item.BasiMbaliAfya204b_1},{item.UgumuUsafiriUmma204b_2},{item.KukosaNauli204b_3},{item.MsafaraMrefu204b_4},{item.AnaishiMbaliBasi204b_5},{item.AnaishiMbaliAfya204b_6},{item.Mengine204b_7},{item.TajaMengine204b},{item.UmepataHapaHuduma206},{item.UmriMimba301},{item.MwakaVVU302},{item.MdaVVU303},{item.DawaVVU304a},{item.LiniDawaVVU304b},{item.CTC304c}");
                }
            }
           
            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Pmtct.csv");

        }
        [HttpGet]
        public async Task<ActionResult> ExcelDoc()

        {
            List<Pmtct.Models.PmtctData> pmtctDatas = new List<PmtctData>();
            pmtctDatas = await _context.Pmt.ToListAsync();


            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("pmtctDatas");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "NambaMshiriki01";
                worksheet.Cell(currentRow, 2).Value = "Wilaya02";
                worksheet.Cell(currentRow, 3).Value = "TareheMahojiano03";
                worksheet.Cell(currentRow, 4).Value = "Kituo04";
                worksheet.Cell(currentRow, 5).Value = "JinaAnayehoji05";
                worksheet.Cell(currentRow, 6).Value = "Ngazikituo06";
                worksheet.Cell(currentRow, 7).Value = "MdaKuishiZanzibar109";
                worksheet.Cell(currentRow, 8).Value = "KiwangoElimu102";
                worksheet.Cell(currentRow, 9).Value = "Umri101";
                worksheet.Cell(currentRow, 10).Value = "IdadiMimba106";
                worksheet.Cell(currentRow, 11).Value = "HaliNdoa103";
                worksheet.Cell(currentRow, 12).Value = "KipatoMwezi104";
                worksheet.Cell(currentRow, 13).Value = "Kazi105";
                worksheet.Cell(currentRow, 14).Value = "KilomitaUjazo202";
                worksheet.Cell(currentRow, 15).Value = "KilomitaKituo201";
                worksheet.Cell(currentRow, 16).Value = "UgumuKliniki204a";
                worksheet.Cell(currentRow, 17).Value = "HudumaHapa205";
                worksheet.Cell(currentRow, 18).Value = "BasiMbaliAfya204b_1";
                worksheet.Cell(currentRow, 19).Value = "UgumuUsafiriUmma204b_2";
                worksheet.Cell(currentRow, 20).Value = "MsafaraMrefu204b_4";
                worksheet.Cell(currentRow, 21).Value = "AnaishiMbaliBasi204b_5";
                worksheet.Cell(currentRow, 22).Value = "AnaishiMbaliAfya204b_6";
                worksheet.Cell(currentRow, 23).Value = "Mengine204b_7";
                worksheet.Cell(currentRow, 24).Value = "TajaMengine204b";
                worksheet.Cell(currentRow, 25).Value = "UmepataHapaHuduma206";
                worksheet.Cell(currentRow, 26).Value = "UmriMimba301";
                worksheet.Cell(currentRow, 27).Value = "MwakaVVU302";
                worksheet.Cell(currentRow, 28).Value = "MdaVVU303";
                worksheet.Cell(currentRow, 29).Value = "DawaVVU304a";
                worksheet.Cell(currentRow, 30).Value = "LiniDawaVVU304b";
                worksheet.Cell(currentRow, 31).Value = "CTC304c";


                foreach (var item in pmtctDatas)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item.NambaMshiriki01;
                    worksheet.Cell(currentRow, 2).Value = item.Wilaya02;
                    worksheet.Cell(currentRow, 3).Value = item.TareheMahojiano03;
                    worksheet.Cell(currentRow, 4).Value = item.Kituo04;
                    worksheet.Cell(currentRow, 5).Value = item.JinaAnayehoji05;
                    worksheet.Cell(currentRow, 6).Value = item.Ngazikituo06;
                    worksheet.Cell(currentRow, 7).Value = item.MdaKuishiZanzibar109;
                    worksheet.Cell(currentRow, 8).Value = item.KiwangoElimu102;
                    worksheet.Cell(currentRow, 9).Value = item.Umri101;
                    worksheet.Cell(currentRow, 10).Value = item.IdadiMimba106;
                    worksheet.Cell(currentRow, 11).Value = item.HaliNdoa103;
                    worksheet.Cell(currentRow, 12).Value = item.KipatoMwezi104;
                    worksheet.Cell(currentRow, 13).Value = item.Kazi105;
                    worksheet.Cell(currentRow, 14).Value = item.KilomitaUjazo202;
                    worksheet.Cell(currentRow, 15).Value = item.KilomitaKituo201;
                    worksheet.Cell(currentRow, 16).Value = item.UgumuKliniki204a;
                    worksheet.Cell(currentRow, 17).Value = item.HudumaHapa205;
                    worksheet.Cell(currentRow, 18).Value = item.BasiMbaliAfya204b_1;
                    worksheet.Cell(currentRow, 19).Value = item.UgumuUsafiriUmma204b_2;
                    worksheet.Cell(currentRow, 20).Value = item.MsafaraMrefu204b_4;
                    worksheet.Cell(currentRow, 21).Value = item.AnaishiMbaliBasi204b_5;
                    worksheet.Cell(currentRow, 22).Value = item.AnaishiMbaliAfya204b_6;
                    worksheet.Cell(currentRow, 23).Value = item.Mengine204b_7;
                    worksheet.Cell(currentRow, 24).Value = item.TajaMengine204b;
                    worksheet.Cell(currentRow, 25).Value = item.UmepataHapaHuduma206;
                    worksheet.Cell(currentRow, 26).Value = item.UmriMimba301;
                    worksheet.Cell(currentRow, 27).Value = item.MwakaVVU302;
                    worksheet.Cell(currentRow, 28).Value = item.MdaVVU303;
                    worksheet.Cell(currentRow, 29).Value = item.DawaVVU304a;
                    worksheet.Cell(currentRow, 30).Value = item.LiniDawaVVU304b;
                    worksheet.Cell(currentRow, 31).Value = item.CTC304c;


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
