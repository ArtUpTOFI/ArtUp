using ArtUp.DataAccess.Repositories;
using System;

namespace ArtUp.DataAccess.DataContext
{
    public interface IArtUpData: IDisposable
    {
        void SaveAll();
        CommentRepository Comments { get; }
        CategoryRepository Categories { get; }
        GiftRepository Gifts { get; }
        ProjectRepository Projects { get; }
        RoleRepository Roles { get; }
        UserRepository Users { get; }
        UserDonationRepository UserDonations { get; }
    }
}
