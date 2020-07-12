

    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pmtct.Models { 

    public partial class PmtctData
    {
        [Key]
        [Required(ErrorMessage = "Jaza nambaya Mteja LAZIMA!")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Namba ya mshiriki:")]
        [StringLength(255)]
        public string NambaMshiriki01 { get; set; }

        [Required]
        [Display(Name = "User Id:")]
        public string UserId { get; set; }

        //[Required]
        //[Display(Name = "User Name:")]
        //public string Name { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [Display(Name = "Wilaya:")]
        public string Wilaya02 { get; set; }

        [Required(ErrorMessage = "Jaza Tarehe!")]
        [Display(Name = "Tarehe ya mahojiano:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
         public DateTime TareheMahojiano03 { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [StringLength(255)]
        [Display(Name = "Jina la kituo cha afya:")]
        public string Kituo04 { get; set; }

        //[Required(ErrorMessage = "Jaza!")]
        [StringLength(255)]
        [Display(Name = "Jina la anayehoji:")]
        public string JinaAnayehoji05 { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [StringLength(255)]
        [Display(Name = "Ngazi ya kituo:")]
        public string Ngazikituo06 { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [StringLength(255)]
        [Display(Name = "109.Mda ulioishi Zanzibar")]
        public string MdaKuishiZanzibar109 { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [StringLength(255)]
        [Display(Name = "102. Kiwango cha Elimu")]
        public string KiwangoElimu102 { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [Display(Name = "101.Umri (Miaka)")]
        public double? Umri101 { get; set; }


        [Required(ErrorMessage = "Jaza!")]
        [StringLength(255)]
        [Display(Name = "107.Wilaya unayoishi")]
        public string WilayaUnayoishi107 { get; set; }


        [Required(ErrorMessage = "Jaza!")]
        [StringLength(255)]
        [Display(Name = "106. Idadi ya Mimba zilizotangulia")]
        public string IdadiMimba106 { get; set; }


        [Required(ErrorMessage = "Jaza!")]
        [StringLength(255)]
        [Display(Name = "103. Hali ya Ndoa")]
        public string HaliNdoa103 { get; set; }

        [Display(Name = "104.Kipato cha Mwezi")]
        public double? KipatoMwezi104 { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [StringLength(255)]
        [Display(Name = "105. Kazi")]
        public string Kazi105 { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [StringLength(255)]
        [Display(Name = "108.Taja sehemu nje ya Zanzibar")]
        public string NjeZanzibar108 { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [StringLength(255)]
        [Display(Name = "201. Kisia Umbali kwa Kilomita mpaka kituo")]
        public string KilomitaKituo201 { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [StringLength(255)]
        [Display(Name = "202.Kisia Umbali kwa Kilomita mpaka kituo huduma Ujazo")]
        public string KilomitaUjazo202 { get; set; }


        [Required(ErrorMessage = "Jaza!")]
        [StringLength(255)]
        [Display(Name = "203.Njia ya usafiri Kwa huduma za ujauzito")]
        public string HudumaUjauzito203 { get; set; }


        [Required(ErrorMessage = "Jaza!")]
        [StringLength(255)]
        [Display(Name = "204a. Je? Unapata Ugumu kuja Kliniki")]
         public string UgumuKliniki204a { get; set; }


        [Required(ErrorMessage = "Jaza!")]
        [StringLength(255)]
        [Display(Name = "205.Je hii ni mara yako ya kwanza huduma hapa")]
        public string HudumaHapa205 { get; set; }

        
        [Display(Name = "204b 1. Basi husimama mbali na kituo cha afya")]
        public bool BasiMbaliAfya204b_1 { get; set; }

        
        [Display(Name = "204b 2.Ugumu wa kupata usafiri wa umma")]
        public bool UgumuUsafiriUmma204b_2 { get; set; }


        [Display(Name = "204b 3.Kukosa nauli ya basi")]
        public bool KukosaNauli204b_3 { get; set; }


        [Display(Name = "204b 4. Msafara mrefu kufika kituo cha afya")]
        public bool MsafaraMrefu204b_4 { get; set; }


        [Display(Name = "204b 5.Anaishi mbali na kituo cha basi")]
        public bool AnaishiMbaliBasi204b_5 { get; set; }


        [Display(Name = "204b 6. Anaishi mbali na kituo cha Afya")]
        public bool AnaishiMbaliAfya204b_6 { get; set; }

        [Display(Name = "204b 7. Anaishi mbali na kituo cha Afya")]
        public bool Mengine204b_7 { get; set; }

        [StringLength(255)]
        [Display(Name = "204b. Taja Mengine")]
        public string TajaMengine204b { get; set; }


        [Required(ErrorMessage = "Jaza!")]
        [StringLength(255)]
        [Display(Name = "206.Umeshapata huduma hapa ukiacha leo ktk mwaka uliopita?")]
        public string UmepataHapaHuduma206 { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [Display(Name = "301.Umri wa mimba(wiki)")]
        public double? UmriMimba301 { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [StringLength(255)]
        [Display(Name = "302. Mwaka gani uligundulika na VVU?(mwaka)")]
        public string MwakaVVU302 { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [StringLength(255)]
        [Display(Name = "303.Mda uliogundulika na maambukizi VVU?")]
        public string MdaVVU303 { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [StringLength(255)]
        [Display(Name = "304a.Je? Unatumia dawa kupunguza VVU")]
        public string DawaVVU304a { get; set; }

        [StringLength(255)]
        [Display(Name = "304b.Kama ndio ulianza lini kutumia dawa?(mwaka)")]

        [Required(ErrorMessage = "Jaza!")]
        public string LiniDawaVVU304b { get; set; }
        [StringLength(255)]
         [Display(Name = "304c.Utambulisho CTC")]
        public string CTC304c { get; set; }

        public ICollection<PmtctFollowUp> followup { get; set; }
        public ICollection<PmtctCareCascade> careCascades { get; set; }

    }
    }

