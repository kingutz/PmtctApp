using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Pmtct.Models
{
    public class PmtctFollowUp
    {   
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "User Name:")]
        public string UserId { get; set; }

        //[Required]
        //[Display(Name = "User Name:")]
        //public string Name { get; set; }

        [Required(ErrorMessage = "Jaza Tarehe!")]
        [Display(Name = "Tarehe ya Hudhurio:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyyy}", ApplyFormatInEditMode = true)]
        public DateTime TareheHudhurio { get; set; }
        [Required(ErrorMessage ="Jaza!")]
        [Display(Name = "305a.Je,Kuna mtu anafahamu hali yako:")]
        [StringLength(255)]
        public string HaliYako305a { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [Display(Name = "305a.Kama hapana taja sababu")]
        [StringLength(255)]
        public string KamaHapana305a { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [Display(Name = "305b.Kama ndio nani anafahamu?:")]
        [StringLength(255)]
        public string KamaNdio305b { get; set; }
        [Required(ErrorMessage = "Jaza!")]

        [Display(Name = "306b.Kama hapana je una mpango wa kumwambia mtu:")]
        [StringLength(255)]
        public string MpangoMtu306b { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [Display(Name = "307.Je,hali ya maambukizi kwa mwenza wako ikoje kwa sasa?")]
        [StringLength(255)]
        public string HaliMwenza307 { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [Display(Name = "308a.Je,umewahi kuhudumiwa kutendewa tofauti kwa sababu una VVU")]
        [StringLength(255)]
        public string KuhudumiwaTofautiVVU308a { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [Display(Name = "308b.Kama ndio nani aliekufanyia/kutendea?")]
        [StringLength(255)]
        public string NaniKutendea308b { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [Display(Name = "309a.Je,Umejiunga kwenye kikundi chochote cha watu wanaoishi na VVU??")]
        [StringLength(255)]
        public string UmejiungaVVU309a { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [Display(Name = "309a.Kama ndio  taja:")]
        [StringLength(255)]
        public string NdioTaja309b { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [Display(Name = "310a. Je umeunganishwa na mama mwambata kwa Huduma?")]
        [StringLength(255)]
        public string MamaMwambata310a { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [Display(Name = "310b.Kama kama ndio huduma gani ulipatiwa?")]
        [StringLength(255)]
        public string HudumaHulipatiwa310b { get; set; }

        [Display(Name = "306b.Rufaa kwenda")]
        [StringLength(255)]
        public string Rufaa { get; set; }


        [Required(ErrorMessage = "Jaza Tarehe!")]
        [Display(Name = "Tarehe ya Hudhurio lijalo:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyyy}", ApplyFormatInEditMode = true)]
        public DateTime TareheHudhurioLijalo { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [Display(Name = "Ufuatiliaji")]
        [StringLength(255)]
        public string Ufuatiliaji { get; set; }

        [Display(Name = "Jina la mtoa huduma")]
        [StringLength(255)]
        public string JinaMtoHuduma { get; set; }

        [Required(ErrorMessage ="Lazima uweke namba ya Mteja")]
        [Display(Name = "Namba ya Mteja:")]
        public string NambaMshiriki01 { get; set; }
        public PmtctData pmtctData { get; set; }


    }
}
