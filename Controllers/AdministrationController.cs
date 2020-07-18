using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pmtct.Data;
using Pmtct.Models;
using Pmtct.Models.PmtctModelView;

namespace Pmtct.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly PmtctContext _context;

        public AdministrationController(PmtctContext context)
        {
            _context = context;
        }

        //// GET: Administration
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Pmt.ToListAsync());
        //}
        // GET: Instructors
        //public async Task<IActionResult> Index(string  idPmtF)
        //{
        //    var viewModel = new PmtctVM();
        //    viewModel.pmtctsdata = await _context.Pmt
        //          .Include(i => i.followup)
        //          .Include(i => i.careCascades)
        //          .OrderBy(i => i.Kituo04)
        //          .ToListAsync();

        //    if (idPmtF != null)
        //    {
        //        ViewData["NambaMshiriki01"] = idPmtF;
        //        PmtctData pmtcts = viewModel.pmtctsdata.Where(
        //            i => i.NambaMshiriki01 == idPmtF).Single();
        //        //viewModel.followUps = pmtcts.followup(s => s.);
        //    }

        //    if (idPmtF != null)
        //    {
        //        ViewData["CourseID"] = idPmtF;
        //        var selectedCourse = viewModel.Courses.Where(x => x.CourseID == courseID).Single();
        //        await _context.Entry(selectedCourse).Collection(x => x.Enrollments).LoadAsync();
        //        foreach (Enrollment enrollment in selectedCourse.Enrollments)
        //        {
        //            await _context.Entry(enrollment).Reference(x => x.Student).LoadAsync();
        //        }
        //        viewModel.Enrollments = selectedCourse.Enrollments;
        //    }

        //    return View(viewModel);
        //}


        // GET: Administration/Details/5
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

        // GET: Administration/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NambaMshiriki01,UserId,Wilaya02,TareheMahojiano03,Kituo04,JinaAnayehoji05,Ngazikituo06,MdaKuishiZanzibar109,KiwangoElimu102,Umri101,WilayaUnayoishi107,IdadiMimba106,HaliNdoa103,KipatoMwezi104,Kazi105,NjeZanzibar108,KilomitaKituo201,KilomitaUjazo202,HudumaUjauzito203,UgumuKliniki204a,HudumaHapa205,BasiMbaliAfya204b_1,UgumuUsafiriUmma204b_2,KukosaNauli204b_3,MsafaraMrefu204b_4,AnaishiMbaliBasi204b_5,AnaishiMbaliAfya204b_6,Mengine204b_7,TajaMengine204b,UmepataHapaHuduma206,UmriMimba301,MwakaVVU302,MdaVVU303,DawaVVU304a,LiniDawaVVU304b,CTC304c")] PmtctData pmtctData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pmtctData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pmtctData);
        }

        // GET: Administration/Edit/5
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

        // POST: Administration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NambaMshiriki01,UserId,Wilaya02,TareheMahojiano03,Kituo04,JinaAnayehoji05,Ngazikituo06,MdaKuishiZanzibar109,KiwangoElimu102,Umri101,WilayaUnayoishi107,IdadiMimba106,HaliNdoa103,KipatoMwezi104,Kazi105,NjeZanzibar108,KilomitaKituo201,KilomitaUjazo202,HudumaUjauzito203,UgumuKliniki204a,HudumaHapa205,BasiMbaliAfya204b_1,UgumuUsafiriUmma204b_2,KukosaNauli204b_3,MsafaraMrefu204b_4,AnaishiMbaliBasi204b_5,AnaishiMbaliAfya204b_6,Mengine204b_7,TajaMengine204b,UmepataHapaHuduma206,UmriMimba301,MwakaVVU302,MdaVVU303,DawaVVU304a,LiniDawaVVU304b,CTC304c")] PmtctData pmtctData)
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

        // GET: Administration/Delete/5
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

        // POST: Administration/Delete/5
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
