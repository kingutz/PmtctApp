using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventSource;
using Microsoft.VisualBasic;
using Pmtct.Data;
using Pmtct.Models;
using Pmtct.Services;

namespace Pmtct.Controllers
{
    [Authorize(Roles = "admin,analyst")]
    public class UserAction : Controller
    {
        private readonly PmtctContext _context;
        private readonly ILogger<PmtctController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ICurrentUserService currentUserService;

        public UserAction(PmtctContext context, RoleManager<IdentityRole> roleManager,
           UserManager<ApplicationUser> userManager, ILogger<PmtctController> logger, ICurrentUserService currentUserService)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            this.currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));

        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pmt.ToListAsync());
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


        public IActionResult Create()
        {
            var cout = new List<UserMgt>();

            var h = _context.Pmt.GroupBy(i => i.CreatedByUser).Select(g=> new
            {
                username = g.Key,
                edit = g.Sum(i=>i.Edited ? 1:0),
                create = g.Count()
            }).OrderByDescending(p=>p.create);

            
            //var a1 = _context.Pmt.Select(i => new { username = i.CreatedByUser,
            //  edit=i.Edited.Equals(true).ToString() , create = i.CreatedByUser.Count()});
            
            foreach (var ct in h)
            {
                cout.Add(new UserMgt
                {
                    UserName = ct.username,
                    Created = ct.create,
                    Edited =  ct.edit

                });
            }
            
            return View(cout);
        }
    }
}
