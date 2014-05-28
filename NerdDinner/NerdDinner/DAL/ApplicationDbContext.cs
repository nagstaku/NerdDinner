using Microsoft.AspNet.Identity.EntityFramework;
using NerdDinner.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NerdDinner.DAL
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Meeting> Meetings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meeting>()
                .HasMany(c => c.Users)
                .WithMany(u => u.Meetings)
                .Map(x =>
                {
                    x.MapLeftKey("MeetingId");
                    x.MapRightKey("UserId");
                    x.ToTable("MeetingUserMapping");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}