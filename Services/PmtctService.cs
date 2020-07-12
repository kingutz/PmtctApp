using Microsoft.EntityFrameworkCore;
using Pmtct.Data;
using Pmtct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pmtct.Services
{
    public class PmtctService : IPmtctService
    {
        private readonly PmtctContext _context;

        public PmtctService(PmtctContext context)
        {
            _context = context;
        }
                

        public  bool VerifyName(string NambaMshiriki01, string ServiceName,int? id)
        {
          
                
             return  _context.PmtctCareCascade.
                Any(i=>i.ServiceName == ServiceName && i.NambaMshiriki01 == NambaMshiriki01 && i.ID !=id);

            
        }
    }
}
