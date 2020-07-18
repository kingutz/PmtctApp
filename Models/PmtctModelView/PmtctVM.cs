using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pmtct.Models.PmtctModelView
{
    public class PmtctVM
    {
        public IEnumerable<PmtctFollowUp> followUps { get; set; }
        public IEnumerable<PmtctCareCascade> cascades { get; set; }
        public IEnumerable<PmtctData> pmtctsdata { get; set; }
    }
}
