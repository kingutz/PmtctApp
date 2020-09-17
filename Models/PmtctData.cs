

    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pmtct.Models { 

    public partial class PmtctData:EntityData
    {
        //[Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public Int64 ID { get; set; }

       [Display(Name = "401.Initiated ART")]
        public bool InitiatedART401 { get; set; }

        [Display(Name = "Date:")]
        [DataType(DataType.Date)]
       [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? InitiatedARTDate401 { get; set; }

        [Display(Name = "402.Delivery at the health facility")]
        public bool DeliveryFacility402 { get; set; }

        [Display(Name = "Date:")]
        [DataType(DataType.Date)]
       [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DeliveryFacilityDate402 { get; set; }

        [Display(Name = "403a.Early infant diagnosis at 2 months after birth")]
        public bool EarlyBirth403a { get; set; }
        
        [Display(Name = "Date:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EarlyBirthDate403a { get; set; }

        [Display(Name = "403b.Infant HIV status")]
        public string InfantHIVstatus403b { get; set; }

        //[Display(Name = "Date:")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime? InfantHIVstatusDate403b { get; set; }

        [Display(Name = "403c.Mother/guardian received results")]
        public bool MotherResults403c { get; set; }
        
        [Display(Name = "Date:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? MotherResultsDate403c { get; set; }

        [Display(Name = "404a. Infant HIV diagnosis 6 weeks after cessation of Breastfeeding")]
        public bool InfantBreastfeeding404a { get; set; }
        [Display(Name = "Date:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? InfantBreastfeedingDate404a { get; set; }
        [StringLength(255)]
        [Display(Name = "Remarks:")]
        public string RemarksName { get; set; }



        [Required(ErrorMessage = "Jaza namba ya Mteja LAZIMA!")]
        [Display(Name = "Namba ya mshiriki:")]
        [StringLength(255)]
        public string NambaMshiriki01 { get; set; }

      
        //[Display(Name = "User Id:")]
        //public string UserId { get; set; }

        
        [Required(ErrorMessage = "Jaza!")]
        [Display(Name = "Wilaya:")]
        public string Wilaya02 { get; set; }

        [Required(ErrorMessage = "Jaza Tarehe!")]
        [Display(Name = "Tarehe ya mahojiano:")]
         [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{0:MM,dd, yyyy}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
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
        [Display(Name = "108.Mda ulioishi Zanzibar")]

        public string MdaKuishiZanzibar109 { get; set; }
        [StringLength(255)]
        [Display(Name = "109.Taja sehemu nje ya Zanzibar")]
        public string NjeZanzibar108 { get; set; }

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
        [Display(Name = "201. Kisia Umbali kwa Kilometa kutokea unapoisha mpaka kituo cha karibu")]
        public string KilomitaKituo201 { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [StringLength(255)]
        [Display(Name = "202.Kisia Umbali kwa Kilometa kutokea unapoishi mpaka kituo hiki unachopata huduma za ujauzito")]
        public string KilomitaUjazo202 { get; set; }


        [Required(ErrorMessage = "Jaza!")]
        [StringLength(255)]
        [Display(Name = "203.Njia ya usafiri kuja kwenye kituo hiki unachopata huduma za ujauzito")]
        public string HudumaUjauzito203 { get; set; }


        [Required(ErrorMessage = "Jaza!")]
        [StringLength(255)]
        [Display(Name = "204a. Je? Unapata ugumu wowote  kuja Kliniki kwa sababu ya usafiri?")]
         public string UgumuKliniki204a { get; set; }


        [Required(ErrorMessage = "Jaza!")]
        [StringLength(255)]
        [Display(Name = "205.Je hii ni mara yako ya kwanza kupata huduma ktk hiki kituo?")]
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

        [Display(Name = "204b 7. Mengineyo")]
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
        [Display(Name = "303.Muda uliogundulika na maambukizi VVU?")]
        public string MdaVVU303 { get; set; }

        [Required(ErrorMessage = "Jaza!")]
        [StringLength(255)]
        [Display(Name = "304a.Je?kwa sasa unatumia dawa za kupunguza makali ya VVU?")]
        public string DawaVVU304a { get; set; }

        [StringLength(255)]
        [Display(Name = "304b.Kama ndio,Ni lini ulianzishiwa dawa hizo?(mwaka)")]

       
        public string LiniDawaVVU304b { get; set; }
        [StringLength(255)]

         [Display(Name = "304c.Tafadhali weka nambari ya utambulisho ya CTC.(CTC ID)")]
        public string CTC304c { get; set; }

        
        //[DisplayFormat(DataFormatString = "{0:dd MMM, yyyy}", ApplyFormatInEditMode = false)]
        //public DateTime CreatedDate { get; set; }


        public ICollection<PmtctFollowUp> followup { get; set; }
        

    }
    }

