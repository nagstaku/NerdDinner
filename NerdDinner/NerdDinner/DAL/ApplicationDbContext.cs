﻿using Microsoft.AspNet.Identity.EntityFramework;
using NerdDinner.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NerdDinner.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Meeting> Meetings { get; set; }

    }
}