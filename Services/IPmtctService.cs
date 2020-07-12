using Pmtct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pmtct.Services
{
    public interface IPmtctService
    {

        //bool VerifyEmail(string email);
        //bool VerifyName(DateTime ServiceDate,string ID, string SN, bool ResponseName,string NambaMshiriki01, string ServiceName, string RemarksName);
        bool VerifyName(string NambaMshiriki01, string ServiceName, int? id);
        
    }
}
