using ArtUp.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUp.Client.Services.Interfaces
{
    public interface IGiftService
    {
        IEnumerable<GiftViewModel> GetGifts(int projectId);

        void CreateGift(GiftViewModel model);
    }
}
