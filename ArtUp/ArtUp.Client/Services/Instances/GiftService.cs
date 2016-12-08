using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtUp.DataAccess.DataContext;
using ArtUp.Client.Services.Interfaces;
using ArtUp.Client.Models;
using ArtUp.DataAccess.Entities;

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
                    CurrentCount = g.CurrentCount,
                    AvailableCount = g.AvailableCount,
                    Id = g.Id,
                    ProjectId = g.ProjectId.Value
                });

            return gifts.OrderBy(g => g.MoneyAmount);
        }

        public void CreateGift(GiftViewModel model)
        {
            var newGift = new Gift
            {
                MoneyAmount = model.MoneyAmount,
                CurrentCount = model.CurrentCount,
                Description = model.Description,
                AvailableCount = model.AvailableCount,
                ProjectId = model.ProjectId
            };
            data.Gifts.Create(newGift);
            data.SaveAll();
        }
    }
}