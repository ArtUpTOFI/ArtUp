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
    public class UserDonationController : ApiController
    {
        IUserDonationService _userDonationService;

        public UserDonationController()
        {
            _userDonationService = new UserDonationService();
        }

        [HttpGet]
        public IEnumerable<UserDonationViewModel> GetDonations(int projectId)
        {
            return _userDonationService.GetDonations(projectId);
        }
    }
}
