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

        public bool CreateDonation(UserDonationViewModel donation)
        {
            data.UserDonations.Create(new DataAccess.Entities.UserDonation()
            {
                AccountNumber = donation.CardNumber,
                Amount = donation.Amount,
                CardDate = donation.CardDate,
                CardHolder = donation.CardHolder,
                CVV = donation.CVV,
                DonationDate = DateTime.Now,
                GiftId = donation.GiftId,
                ProjectId = donation.ProjectId,
                UserId = donation.UserId
            });
            data.SaveAll();
            return true;
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

        public IEnumerable<ProjectUserDonation> GetProjectsWithDonations(int userId)
        {
            var donationProjects = data.UserDonations
                .Find(d => d.UserId == userId)
                .GroupBy(d => d.ProjectId)
                .Select(g => {
                    var project = data.Projects.Get(g.First().ProjectId.Value);
                    return new ProjectUserDonation()
                    {
                        Project = new ProjectViewModel()
                        {
                            Avatar = project.Avatar,
                            Title = project.Title,
                            CreationDate = project.CreationDate,
                            RequiredMoney = project.RequiredMoney,
                            CurrentMoney = project.CurrentMoney,
                            Duration = project.Duration,
                            ShortDescription = project.ShortDescription,
                            FullDescription = project.FullDescription
                        },
                        DonationTotal = g.Sum(d => d.Amount)
                    };
                });

            return donationProjects;
        }
    }
}