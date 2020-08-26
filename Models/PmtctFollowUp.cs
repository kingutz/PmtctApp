using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Pmtct.Models
{
    public class PmtctFollowUp:EntityData
    {   
        //[Key]
        //public Int64 ID { get; set; }

        //[Required]
        //[Display(Name = "User Name:")]
       // public string UserId { get; set; }

        [Required(ErrorMessage = "Jaza Tarehe!")]
        [Display(Name = "Tarehe ya Hudhurio:")]
        [DataType(DataType.Date)]
       [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TareheHudhurio { get; set; }


        [Required(ErrorMessage ="Jaza!")]
        [Display(Name = "305a.Je,Kuna mtu yoyote anafahamu hali yako ya VVU?")]
        [StringLength(255)]
        public string HaliYako305a { get; set; }


        //305b kama ndio nani
        
        [Display(Name = "305b 1.Mwenza")]
        public bool Mwenza305b1 { get; set; }

        [Display(Name = "305b 2.Mwana familia")]
        public bool Mwanafamiliaa305b2 { get; set; }

        [Display(Name = "305b 3.Wazazi")]
        public bool Wazazi305b3 { get; set; }

        [Display(Name = "305b 4.Rafiki")]
        public bool Rafiki305b1 { get; set; }

        [Display(Name = "305b 5.Mfanyakazi mwezangu")]
        public bool Mfanyakazi305b5 { get; set; }

        [Display(Name = "305b 6.Wengine")]
        public bool Wengine305b6 { get; set; }

        
        [Display(Name = "305b 7.Wengine taja")]
        [StringLength(255)]
        public string Tajawengine305b7 { get; set; }

        //306b Kama hapana taja sababu"
       

        [Display(Name = "306a 1.Naogopa kutengwa na familia/jamii")]
        public bool Naogopakutengwa306a1 { get; set; }

        [Display(Name = "306a 2.Naogopa kuachwa/kukimbiwa na mume/mwenza")]
        public bool Naogopakuachwa306a2 { get; set; }

        [Display(Name = "306a 3.Naogopa kunyanyapaliwa")]
        public bool kunyanyapaliwa306a2 { get; set; }

        [Display(Name = "306a 4.Bado sijaamini kama nimeambukizwa VVU")]
        public bool BadosijaaminiVVUliwa306a4 { get; set; }

        [Display(Name = "306a 5.Sina mtu wa karibu/ninaemwamini")]
        public bool Sinaninaemwamini306a6 { get; set; }

        [Display(Name = "306a 6.Nyinginezo")]
        public bool Nyinginezo306a6 { get; set; }


        //305b.Kama ndio nani anafahamu?
      

        //[Required(ErrorMessage = "Jaza!")]
        [Display(Name = "306b.Kama hapana, je una mpango wa kumwambia mtu yoyote hali yako ya maambukizi ya VVu kwa baadae?")]
        [StringLength(255)]
        public string MpangoMtu306b { get; set; }



        [Required(ErrorMessage = "Jaza!")]
        [Display(Name = "307.Je,hali ya maambukizi ya VVU ya mwenza wako ikoje kwa sasa?")]
        [StringLength(255)]
        public string HaliMwenza307 { get; set; }


        [Required(ErrorMessage = "Jaza!")]
        [Display(Name = "308a.Je,umewahi kuhudumiwa kutendewa tofauti kwa sababu ya hali yako ya maambukizi ya VVU?")]
        [StringLength(255)]
        public string KuhudumiwaTofautiVVU308a { get; set; }

       
        //308b.Kama ndio nani aliekufanyia/kutendea?
        
        [Display(Name = "308b 1.Mwenza")]
        public bool Mwenza308b1 { get; set; }

        [Display(Name = "308b 2.Mwana familia")]
        public bool Mwanafamiliaa308b2 { get; set; }

        [Display(Name = "308b 3.Wazazi")]
        public bool Wazazi308b3 { get; set; }

        [Display(Name = "308b 4.Rafiki")]
        public bool Rafiki308b1 { get; set; }

        [Display(Name = "308b 5.Mfanyakazi mwezangu")]
        public bool Mfanyakazi308b5 { get; set; }

        [Display(Name = "308b 6.Mhudumu wa afya")]
        public bool Mhudumu308b6 { get; set; }

        [Display(Name = "308b 7.Wengine")]
        public bool Wengine308b7 { get; set; }


        [Display(Name = "308b 8.Wengine taja")]
        [StringLength(255)]
        public string Tajawengine308b8 { get; set; }



        [Required(ErrorMessage = "Jaza!")]
        [Display(Name = "309a.Je,Umejiunga kwenye kikundi chochote cha watu wanaoishi na VVU?")]
        [StringLength(255)]
        public string UmejiungaVVU309a { get; set; }

        
        [Display(Name = "309a.Kama ndio  taja:")]
        [StringLength(255)]
        public string NdioTaja309b { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [Display(Name = "310a. Je umeunganishwa na mama mwambata kupata msaada Huduma?")]
        [StringLength(255)]
        public string MamaMwambata310a { get; set; }

        
        //310b.Kama kama ndio huduma gani ulipatiwa?
       
        [Display(Name = "310b 1.Ushauri nasaha")]
        public bool Ushauri310b1 { get; set; }

        [Display(Name = "310b 2.Elimu ya afya")]
        public bool Elimuafya310b2 { get; set; }

        [Display(Name = "310b 3.Ufuatiliaji")]
        public bool Ufuatiliaji310b3 { get; set; }



        [Display(Name = "310b 4.Nyinginezo")]
        public bool Nyinginezo310b4 { get; set; }

        [Display(Name = "306b.Rufaa kwenda")]
        [StringLength(255)]
        public string Rufaa { get; set; }


        [Required(ErrorMessage = "Jaza Tarehe!")]
        [Display(Name = "Tarehe ya Hudhurio lijalo:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TareheHudhurioLijalo { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [Display(Name = "Client status")]
        [StringLength(255)]
        public string Ufuatiliaji { get; set; }

        [Display(Name = "Jina la mtoa huduma")]
        [StringLength(255)]
        public string JinaMtoHuduma { get; set; }

        [Required(ErrorMessage ="Lazima uweke namba ya Mteja")]
        [Display(Name = "Namba ya Mteja:")]
        public Int64 NambaMshiriki01 { get; set; }
        [Display(Name = "Created Date:")]

       

        public PmtctData pmtctData { get; set; }


    }
}
