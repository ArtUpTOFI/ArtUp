using ArtUp.DataAccess.Repositories;
using System;

namespace ArtUp.DataAccess.DataContext
{
    public class ArtUpData: IArtUpData
    {
        private ICategoryRepository _categories;
        private ICommentRepository _comments;
        private IGiftRepository _gifts;
        private IProjectRepository _projects;
        private IRoleRepository _roles;
        private IUserDonationRepository _userDonations;
        private IUserRepository _users;

        public ArtUpDataContextEF Context { get; }        

        private bool _disposed = false;

        public ArtUpData(ArtUpDataContextEF context)
        {
            Context = context;
        }

        public ICategoryRepository Categories
        {
            get
            {
                if (_categories == null)
                    _categories = new CategoryRepository(Context);
                return _categories;
            }
        }

        public ICommentRepository Comments
        {
            get
            {
                if (_comments == null)
                    _comments = new CommentRepository(Context);
                return _comments;
            }
        }

        public IGiftRepository Gifts
        {
            get
            {
                if (_gifts == null)
                    _gifts = new GiftRepository(Context);
                return _gifts;
            }
        }

        public IProjectRepository Projects
        {
            get
            {
                if (_projects == null)
                    _projects = new ProjectRepository(Context);
                return _projects;
            }
        }

        public IRoleRepository Roles
        {
            get
            {
                if (_roles == null)
                    _roles = new RoleRepository(Context);
                return _roles;
            }
        }

        public IUserDonationRepository UserDonations
        {
            get
            {
                if (_userDonations == null)
                    _userDonations = new UserDonationRepository(Context);
                return _userDonations;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if (_users == null)
                    _users = new UserRepository(Context);
                return _users;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
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
            if (Context != null)
                Context.SaveChanges();
        }
    }
}
