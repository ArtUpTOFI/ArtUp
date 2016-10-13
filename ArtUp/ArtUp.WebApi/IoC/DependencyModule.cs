using System;
using Ninject.Modules;
using ArtUp.DataAccess.DataContext;
using ArtUp.DataAccess.Repositories;

namespace ArtUp.WebApi.IoC
{
    public class DependencyModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IArtUpData>().To<ArtUpData>();
            Bind<ICategoryRepository>().To<CategoryRepository>();
            Bind<ICommentRepository>().To<CommentRepository>();
            Bind<IGiftRepository>().To<GiftRepository>();
            Bind<IProjectRepository>().To<ProjectRepository>();
            Bind<IRoleRepository>().To<RoleRepository>();
            Bind<IUserDonationRepository>().To<UserDonationRepository>();
            Bind<IUserRepository>().To<UserRepository>();
        }
    }
}