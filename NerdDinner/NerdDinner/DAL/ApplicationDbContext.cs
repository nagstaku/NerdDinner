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

        public System.Data.Entity.DbSet<NerdDinner.Models.User> IdentityUsers { get; set; }


    }
}