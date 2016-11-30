using ArtUp.DataAccess.DataContext;
using ArtUp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUp.DataAccess.DataInitializers
{
    public class DevDBInitializer: DropCreateDatabaseAlways<ArtUpDataContextEF>
    {
        protected override void Seed(ArtUpDataContextEF context)
        {
            context.Roles.AddRange(new List<Role>()
            {
                new Role() { Id = 1, Name = "Admin" },
                new Role() { Id = 2, Name = "User" },
                new Role() { Id = 3, Name = "Moderator" }
            });

            context.Categories.AddRange(new List<Category>()
            {
                new Category() { Id = 1, Title = "music" },
                new Category() { Id = 2, Title = "literature" },
                new Category() { Id = 3, Title = "movie" },
                new Category() { Id = 4, Title = "photo" },
                new Category() { Id = 5, Title = "art" }
            });

            context.Users.AddRange(new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Email = "dog@gmail.com",
                    Password = "666",
                    About = "woof",
                    Avatar = "dog.png",
                    Location = "Minsk",
                    Name = "Doge",
                    RegistrationDate = DateTime.Today,
                    RoleId = 2,
                    Surname = "Jones"
                },
                new User()
                {
                    Id = 2,
                    Email = "cat@gmail.com",
                    Password = "676",
                    About = "mya",
                    Avatar = "cat.png",
                    Location = "Mogilev",
                    Name = "Kitty",
                    RegistrationDate = DateTime.Today,
                    RoleId = 2,
                    Surname = "Tigerovich"
                },
                new User()
                {
                    Id = 3,
                    Email = "horse@gmail.com",
                    Password = "987asd",
                    About = "hey hey",
                    Avatar = "horse.png",
                    Location = "Bobruisk",
                    Name = "Racer",
                    RegistrationDate = DateTime.Today,
                    RoleId = 2,
                    Surname = "Ivanovich"
                }
            });

            context.Projects.AddRange(new List<Project>()
            {
                new Project()
                {
                    Id = 1,
                    Title = "Super startup",
                    RequiredMoney = 10000,
                    Adress = "Minsk, 666",
                    Avatar = "project-1.jpg",
                    CategoryId = 1,
                    CurrentMoney = 11000,
                    DateOfBirth = new DateTime(1995, 3, 3),
                    DocumentType = Entities.Enums.DocumentType.Passport,
                    Duration = TimeSpan.FromHours(3),
                    FullDescription = "A project, created to gain money for nothing",
                    MiddleName = "Petrovich",
                    Name = "Artsiom",
                    PasspotNumberSeries = "MP2653900",
                    PersonalPassportNumber = "1235Bdasd13575",
                    PhoneNumber = "1234372",
                    Surname = "Rasputin",
                    ProjectState = Entities.Enums.ProjectState.Approved,
                    WhoAndWhereIssued = "Borisovskoe Ruvd Minskoi oblasti",
                    ShortDescription = "Just project",
                    UserId = 3
                },
                new Project()
                {
                    Id = 2,
                    Title = "Super puper mega startup",
                    RequiredMoney = 6000,
                    Adress = "Minsk, 9",
                    Avatar = "project-2.jpg",
                    CategoryId = 2,
                    CurrentMoney = 6900,
                    DateOfBirth = new DateTime(1990, 5, 19),
                    DocumentType = Entities.Enums.DocumentType.Passport,
                    Duration = TimeSpan.FromHours(3),
                    FullDescription = "A project, created to become a new apple kajsdfgkjsdfl;khgsdhf;ghsdfklhglksdfhghrugsurughrgurhgurhg",
                    MiddleName = "Sashevich",
                    Name = "Ivan",
                    PasspotNumberSeries = "MC2000900",
                    PersonalPassportNumber = "1235B3249C75",
                    PhoneNumber = "9084012",
                    Surname = "Tseretelli",
                    ProjectState = Entities.Enums.ProjectState.Draft,
                    WhoAndWhereIssued = "Ruvd Minska",
                    ShortDescription = "New Microsoft",
                    UserId = 2
                },
                new Project()
                {
                    Id = 3,
                    Title = "mega startup",
                    RequiredMoney = 6000,
                    Adress = "Minsk, 9",
                    Avatar = "project-3.jpg",
                    CategoryId = 2,
                    CurrentMoney = 5900,
                    DateOfBirth = new DateTime(1990, 5, 19),
                    DocumentType = Entities.Enums.DocumentType.Passport,
                    Duration = TimeSpan.FromHours(3),
                    FullDescription = "A project",
                    MiddleName = "Sashevich",
                    Name = "Ivan",
                    PasspotNumberSeries = "MC2000900",
                    PersonalPassportNumber = "1235B3249C75",
                    PhoneNumber = "9084012",
                    Surname = "Tseretelli",
                    ProjectState = Entities.Enums.ProjectState.Draft,
                    WhoAndWhereIssued = "Ruvd Minska",
                    ShortDescription = "New Microsoft",
                    UserId = 2
                },
                new Project()
                {
                    Id = 4,
                    Title = "Super mega startup",
                    RequiredMoney = 6000,
                    Adress = "Minsk, 9",
                    Avatar = "project-4.jpg",
                    CategoryId = 2,
                    CurrentMoney = 6900,
                    DateOfBirth = new DateTime(1990, 5, 19),
                    DocumentType = Entities.Enums.DocumentType.Passport,
                    Duration = TimeSpan.FromHours(3),
                    FullDescription = "A project, created to become a new apple aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                    MiddleName = "Sashevich",
                    Name = "Ivan",
                    PasspotNumberSeries = "MC2000900",
                    PersonalPassportNumber = "1235B3249C75",
                    PhoneNumber = "9084012",
                    Surname = "Tseretelli",
                    ProjectState = Entities.Enums.ProjectState.Draft,
                    WhoAndWhereIssued = "Ruvd Minska",
                    ShortDescription = "New Microsoft",
                    UserId = 2
                },
                new Project()
                {
                    Id = 5,
                    Title = "Super pupe",
                    RequiredMoney = 6000,
                    Adress = "Minsk, 9",
                    Avatar = "project-5.jpg",
                    CategoryId = 2,
                    CurrentMoney = 6900,
                    DateOfBirth = new DateTime(1990, 5, 19),
                    DocumentType = Entities.Enums.DocumentType.Passport,
                    Duration = TimeSpan.FromHours(3),
                    FullDescription = "A project, created to become a new pineapple",
                    MiddleName = "Sashevich",
                    Name = "Ivan",
                    PasspotNumberSeries = "MC2000900",
                    PersonalPassportNumber = "1235B3249C75",
                    PhoneNumber = "9084012",
                    Surname = "Tseretelli",
                    ProjectState = Entities.Enums.ProjectState.Draft,
                    WhoAndWhereIssued = "Ruvd Minska",
                    ShortDescription = "New Microsoft",
                    UserId = 2
                },
                new Project()
                {
                    Id = 6,
                    Title = "STARTUP",
                    RequiredMoney = 6000,
                    Adress = "Minsk, 9",
                    Avatar = "project-3.jpg",
                    CategoryId = 2,
                    CurrentMoney = 6900,
                    DateOfBirth = new DateTime(1990, 5, 19),
                    DocumentType = Entities.Enums.DocumentType.Passport,
                    Duration = TimeSpan.FromHours(3),
                    FullDescription = "A project, created to become a new apple",
                    MiddleName = "Sashevich",
                    Name = "Ivan",
                    PasspotNumberSeries = "MC2000900",
                    PersonalPassportNumber = "1235B3249C75",
                    PhoneNumber = "9084012",
                    Surname = "Tseretelli",
                    ProjectState = Entities.Enums.ProjectState.Draft,
                    WhoAndWhereIssued = "Ruvd Minska",
                    ShortDescription = "New Microsoft",
                    UserId = 2
                },
                new Project()
                {
                    Id = 7,
                    Title = "Startup 1",
                    RequiredMoney = 6000,
                    Adress = "Minsk, 9",
                    Avatar = "project-4.jpg",
                    CategoryId = 2,
                    CurrentMoney = 7500,
                    DateOfBirth = new DateTime(1990, 5, 19),
                    DocumentType = Entities.Enums.DocumentType.Passport,
                    Duration = TimeSpan.FromHours(3),
                    FullDescription = "A project, created to become a new apple",
                    MiddleName = "Sashevich",
                    Name = "Ivan",
                    PasspotNumberSeries = "MC2000900",
                    PersonalPassportNumber = "1235B3249C75",
                    PhoneNumber = "9084012",
                    Surname = "Tseretelli",
                    ProjectState = Entities.Enums.ProjectState.Draft,
                    WhoAndWhereIssued = "Ruvd Minska",
                    ShortDescription = "New Microsoft",
                    UserId = 2
                },
                new Project()
                {
                    Id = 5,
                    Title = "STARTUP))))))))",
                    RequiredMoney = 6000,
                    Adress = "Minsk, 9",
                    Avatar = "project-2.jpg",
                    CategoryId = 2,
                    CurrentMoney = 8000,
                    DateOfBirth = new DateTime(1990, 5, 19),
                    DocumentType = Entities.Enums.DocumentType.Passport,
                    Duration = TimeSpan.FromHours(3),
                    FullDescription = "A project, created to become a new apple",
                    MiddleName = "Sashevich",
                    Name = "Ivan",
                    PasspotNumberSeries = "MC2000900",
                    PersonalPassportNumber = "1235B3249C75",
                    PhoneNumber = "9084012",
                    Surname = "Tseretelli",
                    ProjectState = Entities.Enums.ProjectState.Draft,
                    WhoAndWhereIssued = "Ruvd Minska",
                    ShortDescription = "New Microsoft",
                    UserId = 2
                },
            });

            context.Comments.AddRange(new List<Comment>()
            {
                new Comment() { Id = 1, Text = "Wow, such a cool idea!", Date = new DateTime(2016, 12, 3), ProjectId = 1, UserId = 1 },
                new Comment() { Id = 2, Text = "You are dog, you know nothing!", Date = DateTime.Today, ProjectId = 1, UserId = 2 },
                new Comment() { Id = 3, Text = "Relax guys", Date = DateTime.Today, ProjectId = 1, UserId = 3 },
                new Comment() { Id = 4, Text = "I like it", Date = DateTime.Today, ProjectId = 2, UserId = 3}
            });

            context.Gifts.AddRange(new List<Gift>()
            {
                new Gift() { Id = 1, Description = "Sigature", MoneyAmount = 10, Number = 1, ProjectId = 1 },
                new Gift() { Id = 2, Description = "CD with songs", MoneyAmount = 20, Number = 2, ProjectId = 2 },
                new Gift() { Id = 3, Description = "Thanks", MoneyAmount = 10, Number = 1, ProjectId = 2 }
            });

            context.UserDonations.AddRange(new List<UserDonation>()
            {
                new UserDonation() { Id = 1, Amount = 14, DonationDate = DateTime.Today, AccountNumber = "1298 4574 1235 2323", IsCardNumber = true, GiftId = 1, ProjectId = 1, UserId = 1 },
                new UserDonation() { Id = 2, Amount = 20, DonationDate = DateTime.Today, AccountNumber = "12345757543546", IsCardNumber = false, GiftId = 2, ProjectId = 2, UserId = 1 },
                new UserDonation() { Id = 3, Amount = 20, DonationDate = DateTime.Today, AccountNumber = "12305768793456", IsCardNumber = false, GiftId = 2, ProjectId = 2, UserId = 3 },
                new UserDonation() { Id = 4, Amount = 11, DonationDate = DateTime.Today, AccountNumber = "12345757543546", IsCardNumber = false, GiftId = 3, ProjectId = 2, UserId = 2 },
            });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
