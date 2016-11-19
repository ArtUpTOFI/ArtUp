using ArtUp.WebApi.Models;
using ArtUp.WebApi.Services.Instances;
using ArtUp.WebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ArtUp.WebApi.Controllers
{
    public class GiftController : ApiController
    {
        IGiftService _giftService;

        public GiftController()
        {
            _giftService = new GiftService();
        }

        [HttpGet]
        public IEnumerable<GiftViewModel> GetGifts(int projectId)
        {
            return _giftService.GetGifts(projectId);
        }
    }
}
