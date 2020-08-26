using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventSource;
using Microsoft.VisualBasic;
using Pmtct.Data;
using Pmtct.Models;
using Pmtct.Services;

namespace Pmtct.Controllers
{
    [Authorize(Roles = "admin,analyst,dataentry,dataclerk")]
    public class PmtctController : Controller
    {
        private readonly PmtctContext _context;
        private readonly ILogger<PmtctController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ICurrentUserService currentUserService;

        public PmtctController(PmtctContext context, RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager, ILogger<PmtctController> logger,ICurrentUserService currentUserService)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
             this.currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
       
        }

        // GET: Pmtct
        public async Task<IActionResult> Index()
        {
            using (_logger.BeginScope("Message {HoleValue}", DateTime.Now))
            { 
                bool isAdmin = User.IsInRole("admin") || User.IsInRole("analyst");

            if (isAdmin)
            {
                _logger.LogInformation(LoggingEvents.GetItem, "Listing all items");
                return View(await _context.Pmt.ToListAsync());
            }
            else

                _logger.LogInformation(LoggingEvents.GetItem, "Listing all items");
            return View(await _context.Pmt.Where(p => p.CreatedByUser == currentUserService.GetCurrentUsername()).ToListAsync());

        }
        }

        // GET: Pmtct/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            _logger.LogInformation(LoggingEvents.GetItem, "Getting item {Id}", id);
            if (id == null)
            {
                _logger.LogWarning(LoggingEvents.GetItemNotFound, "GetById({Id}) NOT FOUND", id);
                return NotFound();
            }

            var pmtctData = await _context.Pmt
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pmtctData == null)
            {
                return NotFound();
            }

            return View(pmtctData);
        }

        // GET: Pmtct/Create
        public IActionResult Create()
        {
           // ViewBag.CreatedByUser = currentUserService.GetCurrentUsername();
            return View();
        }

        // POST: Pmtct/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,InitiatedART401,InitiatedARTDate401," +
            "DeliveryFacility402,DeliveryFacilityDate402," +
            "EarlyBirth403a,EarlyBirthDate403a,InfantHIVstatus403b,InfantHIVstatusDate403b,MotherResults403c," +
            "MotherResultsDate403c,InfantBreastfeeding404a,InfantBreastfeedingDate404a," +
            "RemarksName,NambaMshiriki01,UserId,Wilaya02,TareheMahojiano03," +
            "Kituo04,JinaAnayehoji05,Ngazikituo06,MdaKuishiZanzibar109,KiwangoElimu102,Umri101," +
            "WilayaUnayoishi107,IdadiMimba106,HaliNdoa103,KipatoMwezi104,Kazi105,NjeZanzibar108," +
            "KilomitaKituo201,KilomitaUjazo202,HudumaUjauzito203,UgumuKliniki204a,HudumaHapa205," +
            "BasiMbaliAfya204b_1,UgumuUsafiriUmma204b_2,KukosaNauli204b_3,MsafaraMrefu204b_4," +
            "AnaishiMbaliBasi204b_5,AnaishiMbaliAfya204b_6,Mengine204b_7,TajaMengine204b," +
            "UmepataHapaHuduma206,UmriMimba301,MwakaVVU302,MdaVVU303,DawaVVU304a,LiniDawaVVU304b,CTC304c")] PmtctData pmtctData)
        {


            try
            {

                if (ModelState.IsValid)
                {
                    pmtctData.CreatedDate = DateTime.Now;

                    _context.Add(pmtctData);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation(LoggingEvents.InsertItem, "Mteja {Id} Created by {user}", pmtctData.ID, User.Identity.Name);

                    return RedirectToAction(nameof(Create));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save a record. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator, Watch 'Namba ya Mshiriki' Must be unique.");
            }
            return View(pmtctData);
        }
        // public int  getId()
        // {
        //     int ID=0;
        //     var NambaID = from d in _context.Pmt orderby d.ID descending
        //                                select d.ID;
        //     if (NambaID==null)
        //     {
        //      return  ID = 1;
        //     }
        //     else
        //     {
        //       return  ID = NambaID.FirstOrDefault() + 1;
        //     }
        // }
        // GET: Pmtct/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                _logger.LogWarning(LoggingEvents.GetItemNotFound, "Update({Id}) NOT FOUND", id);
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
        public async Task<IActionResult> Edit(int id, [Bind("ID,InitiatedART401,InitiatedARTDate401," +
            "DeliveryFacility402,DeliveryFacilityDate402," +
            "EarlyBirth403a,EarlyBirthDate403a,InfantHIVstatus403b,InfantHIVstatusDate403b,MotherResults403c," +
            "MotherResultsDate403c,InfantBreastfeeding404a,InfantBreastfeedingDate404a," +
            "RemarksName,NambaMshiriki01,UserId,Wilaya02,TareheMahojiano03,Kituo04,JinaAnayehoji05,Ngazikituo06,MdaKuishiZanzibar109,KiwangoElimu102,Umri101,WilayaUnayoishi107,IdadiMimba106,HaliNdoa103,KipatoMwezi104,Kazi105,NjeZanzibar108,KilomitaKituo201,KilomitaUjazo202,HudumaUjauzito203,UgumuKliniki204a,HudumaHapa205,BasiMbaliAfya204b_1,UgumuUsafiriUmma204b_2,KukosaNauli204b_3,MsafaraMrefu204b_4,AnaishiMbaliBasi204b_5,AnaishiMbaliAfya204b_6,Mengine204b_7,TajaMengine204b,UmepataHapaHuduma206,UmriMimba301,MwakaVVU302,MdaVVU303,DawaVVU304a,LiniDawaVVU304b,CTC304c")] PmtctData pmtctData)
        {
            if (id != pmtctData.ID)
            {
                _logger.LogWarning(LoggingEvents.GetItemNotFound, "Update({Id}) NOT FOUND", id);
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pmtctData);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation(LoggingEvents.UpdateItem, "Item {Id} Updated", pmtctData.ID);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PmtctDataExists(pmtctData.ID))
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
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                _logger.LogWarning(LoggingEvents.GetItemNotFound, "Delete({Id}) NOT FOUND", id);
                return NotFound();
            }

            var pmtctData = await _context.Pmt.AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pmtctData == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }
            return View(pmtctData);
        }

        // POST: Pmtct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pmtctData = await _context.Pmt.FindAsync(id);
            if (pmtctData == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Pmt.Remove(pmtctData);
                await _context.SaveChangesAsync();
                //_logger.LogInformation(LoggingEvents.DeleteItem, "Item {Id} Deleted", id);
                _logger.LogCritical(LoggingEvents.DeleteItem, "Mteja  {mteja} Deleted by user {user}", pmtctData, User.Identity.Name);
                return RedirectToAction(nameof(Index));
            }

            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }
            private bool PmtctDataExists(int id)
        {
            return _context.Pmt.Any(e => e.ID == id);
        }
    }
}
