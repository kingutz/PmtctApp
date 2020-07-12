using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pmtct.Data;
using Pmtct.Models;
using Pmtct.Services;

namespace Pmtct.Controllers
{
    public class PmtctValidation : Controller
    {
        private readonly PmtctContext _context;
        private readonly IPmtctService _pmtctService;

        public PmtctValidation(PmtctContext context, IPmtctService pmtctService)
        {
            _context = context;
            _pmtctService = pmtctService;
        }
       
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyName(string ServiceName, string NambaMshiriki01,int? id)
        
        {
           
                if (!_pmtctService.VerifyName(ServiceName,NambaMshiriki01,id))
            {
                return Json($"Taarifa hii{NambaMshiriki01} {ServiceName} ipo.");
            }

            return Json(true);
        }
    }
}
