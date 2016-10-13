using ArtUp.DataAccess.Repositories;
using System;

namespace ArtUp.DataAccess.DataContext
{
    public interface IArtUpData: IDisposable
    {
        void SaveAll();
        ICommentRepository Comments { get; }
        ICategoryRepository Categories { get; }
        IGiftRepository Gifts { get; }
        IProjectRepository Projects { get; }
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }
        IUserDonationRepository UserDonations { get; }
    }
}
