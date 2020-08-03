using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pmtct.Models
{
    public class PmtctAllData
    {

        public IEnumerable<PmtctData> pmtcts { get; set; }
       
        public IEnumerable<PmtctFollowUp> pmtctFollows { get; set; }
    }
}
