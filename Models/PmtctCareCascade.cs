using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace Pmtct.Models
{
    public class PmtctCareCascade

    {   [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "User Name:")]
        public string UserId { get; set; }

        //[Required]
        //[Display(Name = "User Name:")]
        //public string Name { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [Display(Name = "Serial Number")]
        [StringLength(255)]
        public string SN { get; set; }

        //[Remote(action: "VerifyName", controller: "PmtctValidation", AdditionalFields = nameof(ServiceName))]
        [Required(ErrorMessage = "Jaza!")]
        [StringLength(255)]
        [Display(Name = "Service:")]
        public string ServiceName { get; set; }

        [Display(Name = "Response")]
        public bool ResponseName { get; set; }

        [Display(Name = "Date:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyyy}", ApplyFormatInEditMode = true)]
        public DateTime ServiceDate { get; set; }

        [StringLength(255)]
        [Display(Name = "Remarks:")]
        public string RemarksName { get; set; }

        //[Remote(action: "VerifyName", controller: "PmtctValidation", AdditionalFields = nameof(NambaMshiriki01))]
        [Required(ErrorMessage = "Jaza namba ya mteja LAZIMA!")]
        [Display(Name = "Namba ya Mteja:")]
        public string NambaMshiriki01 { get; set; }
        public PmtctData pmtctData { get; set; }

        

    }
}
