using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtUp.DataAccess.DataContext;
using ArtUp.Client.Services.Interfaces;
using ArtUp.Client.Models;

namespace ArtUp.Client.Services.Instances
{
    public class UserDonationService : IUserDonationService
    {
        ArtUpData data;

        public UserDonationService()
        {
            data = new ArtUpData();
        }

        public IEnumerable<UserDonationViewModel> GetDonations(int projectId)
        {
            var donations = data.UserDonations
                .Find(d => d.ProjectId == projectId)
                .Select(d => new UserDonationViewModel()
                {
                    DonationDate = d.DonationDate,
                    Amount = d.Amount,
                    Email = data.Users.Get(d.UserId ?? 0).Email
                });

            return donations;
        }
    }
}