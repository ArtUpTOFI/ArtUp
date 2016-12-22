using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtUp.Client.Models
{
    public class PlatformDetailsViewModel
    {
        public byte IncomeTax { get; set; }

        public byte PlatformComission { get; set; }

        public int MaxFreeAmount { get; set; }
    }
}