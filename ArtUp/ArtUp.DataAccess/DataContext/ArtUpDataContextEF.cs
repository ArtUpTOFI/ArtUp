using ArtUp.DataAccess.DataInitializers;
using ArtUp.DataAccess.Entities;
using System.Data.Entity;

namespace ArtUp.DataAccess.DataContext
{
    public class ArtUpDataContextEF: DbContext
    {
        public ArtUpDataContextEF(): base("ArtUpConnection") { }

        static ArtUpDataContextEF()
        {
            Database.SetInitializer<ArtUpDataContextEF>(new DevDBInitializer());
        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserDonation> UserDonations { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Gift> Gifts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
