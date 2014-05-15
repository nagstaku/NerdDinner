using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Meeting
    {
        public Guid MeetingID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DbGeography Coords { get; set; }
        public ApplicationUser OwnerID { get; set; }
        public virtual ICollection<ApplicationUser> Attendees { get; set; }
    }
}