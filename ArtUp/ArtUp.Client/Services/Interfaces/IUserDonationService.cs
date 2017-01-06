using ArtUp.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUp.Client.Services.Interfaces
{
    public interface IUserDonationService
    {
        IEnumerable<UserDonationViewModel> GetDonations(int projectId);

        IEnumerable<UserDonationViewModel> GetDetailsDonations(int projectId);


        IEnumerable<ProjectUserDonation> GetProjectsWithDonations(int userId);

        bool CreateDonation(UserDonationViewModel donation);
    }
}
