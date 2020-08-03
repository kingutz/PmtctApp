using Microsoft.EntityFrameworkCore;
using Pmtct.Data;
using Pmtct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pmtct.Services
{
    public class PmtctService 
    {
        private readonly PmtctContext _context;

        public PmtctService(PmtctContext context)
        {
            _context = context;
        }
                

       
    }
}
