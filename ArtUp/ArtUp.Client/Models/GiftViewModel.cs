using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtUp.Client.Models
{
    public class GiftViewModel
    {
        public decimal MoneyAmount { get; set; }

        public int AvailableCount { get; set; }

        public int CurrentCount { get; set; }

        public string Description { get; set; }

        public int ProjectId { get; set; }
    }
}