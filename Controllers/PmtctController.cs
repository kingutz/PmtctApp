using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pmtct.Data;
using Pmtct.Models;

namespace Pmtct.Controllers
{
    [Authorize(Roles = "Admin,Analyst")]
     
    public class PmtctController : Controller
    {
        private readonly PmtctContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public PmtctController(PmtctContext context, RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Pmtct
        public async Task<IActionResult> Index()
        {
            bool isAdmin = User.IsInRole("Admin");

            if (isAdmin)
            {
                return View(await _context.Pmt.ToListAsync());
            }
            else
            return View(await _context.Pmt.Where(p=>p.UserId==_userManager.GetUserId(User)).ToListAsync());
            }

        // GET: Pmtct/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pmtctData = await _context.Pmt
                .FirstOrDefaultAsync(m => m.NambaMshiriki01 == id);
            if (pmtctData == null)
            {
                return NotFound();
            }

            return View(pmtctData);
        }

        // GET: Pmtct/Create
        public IActionResult Create()
        {
            ViewBag.UserId = _userManager.GetUserId(User);
            return View();
        }

        // POST: Pmtct/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NambaMshiriki01,UserId,Wilaya02,TareheMahojiano03,Kituo04,JinaAnayehoji05,Ngazikituo06,MdaKuishiZanzibar109,KiwangoElimu102,Umri101,WilayaUnayoishi107,IdadiMimba106,HaliNdoa103,KipatoMwezi104,Kazi105,NjeZanzibar108,KilomitaKituo201,KilomitaUjazo202,HudumaUjauzito203,UgumuKliniki204a,HudumaHapa205,BasiMbaliAfya204b_1,UgumuUsafiriUmma204b_2,KukosaNauli204b_3,MsafaraMrefu204b_4,AnaishiMbaliBasi204b_5,AnaishiMbaliAfya204b_6,Mengine204b_7,TajaMengine204b,UmepataHapaHuduma206,UmriMimba301,MwakaVVU302,MdaVVU303,DawaVVU304a,LiniDawaVVU304b,CTC304c")] PmtctData pmtctData)
        {
            
           

            //pmtctData.UserId = _userManager.GetUserId(User);
           

            if (ModelState.IsValid)
            {
                _context.Add(pmtctData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(pmtctData);
        }

        // GET: Pmtct/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pmtctData = await _context.Pmt.FindAsync(id);
            if (pmtctData == null)
            {
                return NotFound();
            }
            return View(pmtctData);
        }

        // POST: Pmtct/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NambaMshiriki01,Wilaya02,TareheMahojiano03,Kituo04,JinaAnayehoji05,Ngazikituo06,MdaKuishiZanzibar109,KiwangoElimu102,Umri101,WilayaUnayoishi107,IdadiMimba106,HaliNdoa103,KipatoMwezi104,Kazi105,NjeZanzibar108,KilomitaKituo201,KilomitaUjazo202,HudumaUjauzito203,UgumuKliniki204a,HudumaHapa205,BasiMbaliAfya204b_1,UgumuUsafiriUmma204b_2,KukosaNauli204b_3,MsafaraMrefu204b_4,AnaishiMbaliBasi204b_5,AnaishiMbaliAfya204b_6,Mengine204b_7,TajaMengine204b,UmepataHapaHuduma206,UmriMimba301,MwakaVVU302,MdaVVU303,DawaVVU304a,LiniDawaVVU304b,CTC304c")] PmtctData pmtctData)
        {
            if (id != pmtctData.NambaMshiriki01)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pmtctData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PmtctDataExists(pmtctData.NambaMshiriki01))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pmtctData);
        }

        // GET: Pmtct/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pmtctData = await _context.Pmt
                .FirstOrDefaultAsync(m => m.NambaMshiriki01 == id);
            if (pmtctData == null)
            {
                return NotFound();
            }

            return View(pmtctData);
        }

        // POST: Pmtct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var pmtctData = await _context.Pmt.FindAsync(id);
            _context.Pmt.Remove(pmtctData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PmtctDataExists(string id)
        {
            return _context.Pmt.Any(e => e.NambaMshiriki01 == id);
        }
    }
}
