using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace NerdDinner.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        public string email { get; set; }
        public virtual ICollection<Meeting> Meetings { get; set; }
    }

    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    //{
    //    public ApplicationDbContext()
    //        : base("DefaultConnection")
    //    {
    //    }
    //}
}