using ArtUp.DataAccess.Repositories;
using System;

namespace ArtUp.DataAccess.DataContext
{
    public class ArtUpData: IArtUpData
    {
        private CategoryRepository _categories;
        private CommentRepository _comments;
        private GiftRepository _gifts;
        private ProjectRepository _projects;
        private RoleRepository _roles;
        private UserDonationRepository _userDonations;
        private UserRepository _users;

        private ArtUpDataContextEF context = new ArtUpDataContextEF();       

        private bool _disposed = false;

        public CategoryRepository Categories
        {
            get
            {
                if (_categories == null)
                    _categories = new CategoryRepository(context);
                return _categories;
            }
        }

        public CommentRepository Comments
        {
            get
            {
                if (_comments == null)
                    _comments = new CommentRepository(context);
                return _comments;
            }
        }

        public GiftRepository Gifts
        {
            get
            {
                if (_gifts == null)
                    _gifts = new GiftRepository(context);
                return _gifts;
            }
        }

        public ProjectRepository Projects
        {
            get
            {
                if (_projects == null)
                    _projects = new ProjectRepository(context);
                return _projects;
            }
        }

        public RoleRepository Roles
        {
            get
            {
                if (_roles == null)
                    _roles = new RoleRepository(context);
                return _roles;
            }
        }

        public UserDonationRepository UserDonations
        {
            get
            {
                if (_userDonations == null)
                    _userDonations = new UserDonationRepository(context);
                return _userDonations;
            }
        }

        public UserRepository Users
        {
            get
            {
                if (_users == null)
                    _users = new UserRepository(context);
                return _users;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveAll()
        {
            if (context != null)
                context.SaveChanges();
        }
    }
}
