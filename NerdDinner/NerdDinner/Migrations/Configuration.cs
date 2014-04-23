namespace NerdDinner.Migrations
{
    using NerdDinner.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NerdDinner.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NerdDinner.DAL.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );

            ApplicationUser User = new ApplicationUser
                {
                    Id = "bd512618-a4a1-45cb-95e6-ba37d0f5fff4",
                    UserName = "test",
                    PasswordHash = "AJctxUhlvsmkr+gopx9BMvi3d26o3/iRMTJFGbt2BQAyxHuVUE8PSVWoUpyoiQfpfw==",
                    SecurityStamp = "692b8f42-1210-4bda-b004-391b7e9efa8e",
                    email = "nagstaku@gmail.com"
                };

            context.Users.AddOrUpdate(User);
            context.SaveChanges();

            Location Loc = new Location
            {
                Address1 = "1234 SE Salmon St.",
                Address2 = null,
                City = "Portland",
                LocationID = new Guid("2909dc0e-e46d-4295-89a7-149c9d50401d"),
                Meetings = null,
                Name = "Evan's House",
                Phone = "503-236-1234",
                Zip = "97214"
            };

            context.Locations.AddOrUpdate(Loc);
            context.SaveChanges();

            Meeting meeting = new Meeting
            {
                Date = DateTime.Parse("4/26/2014"),
                Location = Loc,
                MeetingID = new Guid("9c810d1a-7a6b-4917-b378-d7a29340c0ee"),
                OwnerID = new Guid("bd512618-a4a1-45cb-95e6-ba37d0f5fff4")
            };

            context.Meetings.AddOrUpdate(meeting);
            context.SaveChanges();
        }
    }
}
