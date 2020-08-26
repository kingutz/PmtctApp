using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pmtct.Data;
using Pmtct.Models;
using Pmtct.Services;

namespace Pmtct.Controllers
{
    [Route("api/PmtctCSV")]
    [ApiController]
    [Authorize(Roles = "admin,analyst,dataentry")]
    public class PmtctCSVController : Controller
    {
        private readonly PmtctContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ICurrentUserService currentUserService;

        public PmtctCSVController(PmtctContext context, RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager, ICurrentUserService currentUserService)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            this.currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));


        }

        [HttpGet]
        public async Task<ActionResult> CSV()

        {
            bool isSuperUser = User.IsInRole("admin") || User.IsInRole("analyst");
            List<Pmtct.Models.PmtctData> pmtctDatas = new List<PmtctData>();
            var builder = new StringBuilder();

            if (isSuperUser)
            {
                pmtctDatas = await _context.Pmt.ToListAsync();

            builder.AppendLine("ID,InitiatedART401,InitiatedARTDate401," +
            "DeliveryFacility402,DeliveryFacilityDate402," +
            "EarlyBirth403a,EarlyBirthDate403a,InfantHIVstatus403b,InfantHIVstatusDate403b,MotherResults403c," +
            "MotherResultsDate403c,InfantBreastfeeding404a,InfantBreastfeedingDate404a," +
            "RemarksName,NambaMshiriki01,Wilaya02,TareheMahojiano03," +
            "Kituo04,JinaAnayehoji05,Ngazikituo06,MdaKuishiZanzibar109,KiwangoElimu102,Umri101," +
            "WilayaUnayoishi107,IdadiMimba106,HaliNdoa103,KipatoMwezi104,Kazi105,NjeZanzibar108," +
            "KilomitaKituo201,KilomitaUjazo202,HudumaUjauzito203,UgumuKliniki204a,HudumaHapa205," +
            "BasiMbaliAfya204b_1,UgumuUsafiriUmma204b_2,KukosaNauli204b_3,MsafaraMrefu204b_4," +
            "AnaishiMbaliBasi204b_5,AnaishiMbaliAfya204b_6,Mengine204b_7,TajaMengine204b," +
            "UmepataHapaHuduma206,UmriMimba301,MwakaVVU302,MdaVVU303,DawaVVU304a,LiniDawaVVU304b,CTC304c,CreatedByUser," +
            "CreatedDate,ModifiedByUser,ModifiedDate,Edited");

                foreach (var item in pmtctDatas)
                {
                    builder.AppendLine($"{item.ID},{item.InitiatedART401},{item.InitiatedARTDate401}," +
                    $"{item.DeliveryFacility402},{item.DeliveryFacilityDate402},{item.EarlyBirth403a}," +
                    $"{item.EarlyBirthDate403a},{item.InfantHIVstatus403b},{item.InfantHIVstatusDate403b}," +
                    $"{item.MotherResults403c},{item.MotherResultsDate403c}," +
                    $"{item.InfantBreastfeeding404a},{item.InfantBreastfeedingDate404a}," +
                    $"{item.RemarksName},{item.NambaMshiriki01},{item.Wilaya02},{item.TareheMahojiano03}," +
                    $"{item.Kituo04},{item.JinaAnayehoji05},{item.Ngazikituo06},{item.MdaKuishiZanzibar109}," +
                    $"{item.KiwangoElimu102},{item.Umri101},{item.WilayaUnayoishi107},{item.IdadiMimba106}," +
                    $"{item.HaliNdoa103},{item.KipatoMwezi104},{item.Kazi105},{item.NjeZanzibar108}," +
                    $"{item.KilomitaKituo201},{item.KilomitaUjazo202},{item.HudumaUjauzito203},{item.UgumuKliniki204a}," +
                    $"{item.HudumaHapa205},{item.BasiMbaliAfya204b_1},{item.UgumuUsafiriUmma204b_2}," +
                    $"{item.KukosaNauli204b_3},{item.MsafaraMrefu204b_4},{item.AnaishiMbaliBasi204b_5}," +
                    $"{item.AnaishiMbaliAfya204b_6},{item.Mengine204b_7},{item.TajaMengine204b}," +
                    $"{item.UmepataHapaHuduma206},{item.UmriMimba301},{item.MwakaVVU302},{item.MdaVVU303}," +
                    $"{item.DawaVVU304a},{item.LiniDawaVVU304b},{item.CTC304c},{item.CreatedByUser},{ item.CreatedDate}," +
                    $"{ item.ModifiedByUser},{ item.ModifiedDate}," +
                    $"{item.Edited}");
                }
                return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Pmtct.csv");
            }

            else

                pmtctDatas = await _context.Pmt.Where(p => p.CreatedByUser == currentUserService.GetCurrentUsername()).ToListAsync();

            builder.AppendLine("ID,InitiatedART401,InitiatedARTDate401," +
             "DeliveryFacility402,DeliveryFacilityDate402," +
             "EarlyBirth403a,EarlyBirthDate403a,InfantHIVstatus403b,InfantHIVstatusDate403b,MotherResults403c," +
             "MotherResultsDate403c,InfantBreastfeeding404a,InfantBreastfeedingDate404a," +
             "RemarksName,NambaMshiriki01,Wilaya02,TareheMahojiano03," +
             "Kituo04,JinaAnayehoji05,Ngazikituo06,MdaKuishiZanzibar109,KiwangoElimu102,Umri101," +
             "WilayaUnayoishi107,IdadiMimba106,HaliNdoa103,KipatoMwezi104,Kazi105,NjeZanzibar108," +
             "KilomitaKituo201,KilomitaUjazo202,HudumaUjauzito203,UgumuKliniki204a,HudumaHapa205," +
             "BasiMbaliAfya204b_1,UgumuUsafiriUmma204b_2,KukosaNauli204b_3,MsafaraMrefu204b_4," +
             "AnaishiMbaliBasi204b_5,AnaishiMbaliAfya204b_6,Mengine204b_7,TajaMengine204b," +
             "UmepataHapaHuduma206,UmriMimba301,MwakaVVU302,MdaVVU303,DawaVVU304a,LiniDawaVVU304b,CTC304c,CreatedByUser," +
             "CreatedDate,ModifiedByUser,ModifiedDate,Edited");

            foreach (var item in pmtctDatas)
            {
                builder.AppendLine($"{item.ID},{item.InitiatedART401},{item.InitiatedARTDate401}," +
                    $"{item.DeliveryFacility402},{item.DeliveryFacilityDate402},{item.EarlyBirth403a}," +
                    $"{item.EarlyBirthDate403a},{item.InfantHIVstatus403b},{item.InfantHIVstatusDate403b}," +
                    $"{item.MotherResults403c},{item.MotherResultsDate403c}," +
                    $"{item.InfantBreastfeeding404a},{item.InfantBreastfeedingDate404a}," +
                    $"{item.RemarksName},{item.NambaMshiriki01},{item.Wilaya02},{item.TareheMahojiano03}," +
                    $"{item.Kituo04},{item.JinaAnayehoji05},{item.Ngazikituo06},{item.MdaKuishiZanzibar109}," +
                    $"{item.KiwangoElimu102},{item.Umri101},{item.WilayaUnayoishi107},{item.IdadiMimba106}," +
                    $"{item.HaliNdoa103},{item.KipatoMwezi104},{item.Kazi105},{item.NjeZanzibar108}," +
                    $"{item.KilomitaKituo201},{item.KilomitaUjazo202},{item.HudumaUjauzito203},{item.UgumuKliniki204a}," +
                    $"{item.HudumaHapa205},{item.BasiMbaliAfya204b_1},{item.UgumuUsafiriUmma204b_2}," +
                    $"{item.KukosaNauli204b_3},{item.MsafaraMrefu204b_4},{item.AnaishiMbaliBasi204b_5}," +
                    $"{item.AnaishiMbaliAfya204b_6},{item.Mengine204b_7},{item.TajaMengine204b}," +
                    $"{item.UmepataHapaHuduma206},{item.UmriMimba301},{item.MwakaVVU302},{item.MdaVVU303}," +
                    $"{item.DawaVVU304a},{item.LiniDawaVVU304b},{item.CTC304c},{item.CreatedByUser},{ item.CreatedDate}," +
                    $"{ item.ModifiedByUser},{ item.ModifiedDate}," +
                    $"{item.Edited}");
            }
            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Pmtct.csv");

        }
    }
}