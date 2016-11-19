using ArtUp.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUp.WebApi.Services.Interfaces
{
    public interface IUserDonationService
    {
        IEnumerable<UserDonationViewModel> GetDonations(int projectId);
    }
}
