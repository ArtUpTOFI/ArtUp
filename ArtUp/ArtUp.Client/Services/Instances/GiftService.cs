using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtUp.DataAccess.DataContext;
using ArtUp.Client.Services.Interfaces;
using ArtUp.Client.Models;

namespace ArtUp.CLient.Services.Instances
{
    public class GiftService : IGiftService
    {
        ArtUpData data;

        public GiftService()
        {
            data = new ArtUpData();
        }

        public IEnumerable<GiftViewModel> GetGifts(int projectId)
        {
            var gifts = data.Gifts.Find(g => g.ProjectId == projectId)
                .Select(g => new GiftViewModel()
                {
                    MoneyAmount = g.MoneyAmount,
                    Description = g.Description,
                    TotalCount = g.Number,
                    //AvailableCount = g.Number
                });

            return gifts;
        }
    }
}