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

namespace Pmtct.Controllers
{
    [Route("api/PmtctUpCSV")]
    [ApiController]
    [Authorize(Roles = "admin,analyst,dataentry")]
    public class PmtctUpCSVController : ControllerBase
    {
        private readonly PmtctContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public PmtctUpCSVController(PmtctContext context, RoleManager<IdentityRole> roleManager,
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

                builder.AppendLine("ID,NambaMshiriki01,TareheHudhurio,HaliYako305a,Mwenza305b1," +
            "Mwanafamiliaa305b2,Wazazi305b3,Rafiki305b1,Mfanyakazi305b5,Wengine305b6,Tajawengine305b7," +
            "Naogopakutengwa306a1,Naogopakuachwa306a2,kunyanyapaliwa306a2,BadosijaaminiVVUliwa306a4," +
            "Sinaninaemwamini306a6,Nyinginezo306a6,MpangoMtu306b,HaliMwenza307,KuhudumiwaTofautiVVU308a," +
            "Mwenza308b1,Mwanafamiliaa308b2,Wazazi308b3,Rafiki308b1,Mfanyakazi308b5,Mhudumu308b6,Wengine308b7," +
            "Tajawengine308b8,UmejiungaVVU309a,NdioTaja309b,MamaMwambata310a,Ushauri310b1,Elimuafya310b2," +
            "Ufuatiliaji310b3,Nyinginezo310b4,Rufaa,TareheHudhurioLijalo,Ufuatiliaji,JinaMtoHuduma," +
            "UserId");
                foreach (var item in pmtctUp)
                {
                    builder.AppendLine($"{item.ID},{item.NambaMshiriki01},{item.TareheHudhurio}," +
                        $"{item.HaliYako305a},{item.Mwenza305b1},{item.Mwanafamiliaa305b2}," +
                        $"{item.Wazazi305b3},{item.Rafiki305b1},{item.Mfanyakazi305b5}," +
                        $"{item.Wengine305b6},{item.Tajawengine305b7},{item.Naogopakutengwa306a1}," +
                        $"{item.Naogopakuachwa306a2},{item.kunyanyapaliwa306a2},{item.BadosijaaminiVVUliwa306a4}," +
                        $"{item.Sinaninaemwamini306a6},{item.Nyinginezo306a6},{item.MpangoMtu306b}," +
                        $"{item.HaliMwenza307},{item.KuhudumiwaTofautiVVU308a},{item.Mwenza308b1}," +
                        $"{item.Mwanafamiliaa308b2},{item.Wazazi308b3},{item.Rafiki308b1}," +
                        $"{item.Mfanyakazi308b5},{item.Mhudumu308b6},{item.Wengine308b7},{item.Tajawengine308b8}" +
                        $"{item.UmejiungaVVU309a},{item.NdioTaja309b},{item.MamaMwambata310a}," +
                        $"{item.Ushauri310b1},{item.Elimuafya310b2},{item.Ufuatiliaji},{item.Nyinginezo310b4}" +
                        $"{item.Rufaa},{item.TareheHudhurioLijalo},{item.Ufuatiliaji}," +
                        $"{item.JinaMtoHuduma},{item.UserId}");
                }


                return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Pmtct_follow_up.csv");

            }

            else

                pmtctUp = await _context.PmtctFollowUp.Where(p => p.UserId == _userManager.GetUserId(User)).ToListAsync();

            builder.AppendLine("ID,NambaMshiriki01,TareheHudhurio,HaliYako305a,Mwenza305b1," +
            "Mwanafamiliaa305b2,Wazazi305b3,Rafiki305b1,Mfanyakazi305b5,Wengine305b6,Tajawengine305b7," +
            "Naogopakutengwa306a1,Naogopakuachwa306a2,kunyanyapaliwa306a2,BadosijaaminiVVUliwa306a4," +
            "Sinaninaemwamini306a6,Nyinginezo306a6,MpangoMtu306b,HaliMwenza307,KuhudumiwaTofautiVVU308a," +
            "Mwenza308b1,Mwanafamiliaa308b2,Wazazi308b3,Rafiki308b1,Mfanyakazi308b5,Mhudumu308b6,Wengine308b7," +
            "Tajawengine308b8,UmejiungaVVU309a,NdioTaja309b,MamaMwambata310a,Ushauri310b1,Elimuafya310b2," +
            "Ufuatiliaji310b3,Nyinginezo310b4,Rufaa,TareheHudhurioLijalo,Ufuatiliaji,JinaMtoHuduma," +
            "UserId");
            foreach (var item in pmtctUp)
            {
                builder.AppendLine($"{item.ID},{item.NambaMshiriki01},{item.TareheHudhurio}," +
                         $"{item.HaliYako305a},{item.Mwenza305b1},{item.Mwanafamiliaa305b2}," +
                         $"{item.Wazazi305b3},{item.Rafiki305b1},{item.Mfanyakazi305b5}," +
                         $"{item.Wengine305b6},{item.Tajawengine305b7},{item.Naogopakutengwa306a1}," +
                         $"{item.Naogopakuachwa306a2},{item.kunyanyapaliwa306a2},{item.BadosijaaminiVVUliwa306a4}," +
                         $"{item.Sinaninaemwamini306a6},{item.Nyinginezo306a6},{item.MpangoMtu306b}," +
                         $"{item.HaliMwenza307},{item.KuhudumiwaTofautiVVU308a},{item.Mwenza308b1}," +
                         $"{item.Mwanafamiliaa308b2},{item.Wazazi308b3},{item.Rafiki308b1}," +
                         $"{item.Mfanyakazi308b5},{item.Mhudumu308b6},{item.Wengine308b7},{item.Tajawengine308b8}" +
                         $"{item.UmejiungaVVU309a},{item.NdioTaja309b},{item.MamaMwambata310a}," +
                         $"{item.Ushauri310b1},{item.Elimuafya310b2},{item.Ufuatiliaji},{item.Nyinginezo310b4}" +
                         $"{item.Rufaa},{item.TareheHudhurioLijalo},{item.Ufuatiliaji}," +
                         $"{item.JinaMtoHuduma},{item.UserId}");
            }


            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Pmtct_follow_up.csv");


        }
    }
}
