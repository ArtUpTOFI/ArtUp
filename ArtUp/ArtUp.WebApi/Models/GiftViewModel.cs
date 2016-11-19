using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtUp.WebApi.Models
{
    public class GiftViewModel
    {
        public decimal MoneyAmount { get; set; }

        //public int AvailableCount { get; set; }

        public int TotalCount { get; set; }

        public string Description { get; set; }
    }
}