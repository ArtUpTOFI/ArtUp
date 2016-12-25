using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtUp.Client.Models
{
    public class PlatformDetailsViewModel
    {
        [Display(Name ="Подоходный налог")]
        public int IncomeTax { get; set; }

        [Display(Name = "Комиссия платформы")]
        public int PlatformComission { get; set; }

        [Display(Name = "Максимальная необлагаемая налогом сумма сбора")]
        public int MaxFreeAmount { get; set; }
    }
}