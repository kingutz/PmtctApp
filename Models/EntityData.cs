using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pmtct.Models
{
    public class EntityData
    {
        public int ID { get; set; }
        [Display(Name = "Created By User")]
        public string CreatedByUser { get; set; }
        [Display(Name = "Created Date")]
        public DateTimeOffset CreatedDate { get; set; }

        [Display(Name = "Modified By User")]
        public string ModifiedByUser { get; set; }

        [Display(Name = "Modified Date")]
        public DateTimeOffset ModifiedDate { get; set; }
        [Display(Name = "Edited?")]
        public bool Edited { get; set; }
    }
}
