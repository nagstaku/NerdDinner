using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NerdDinner.Models
{
    public class Meeting
    {
        public Guid MeetingID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string OwnerID { get; set; }
        [ForeignKey("OwnerID")]
        public ApplicationUser Owner { get; set; }
        public Location Location { get; set; }
        virtual public List<ApplicationUser> Attendees { get; set; }
    }
}