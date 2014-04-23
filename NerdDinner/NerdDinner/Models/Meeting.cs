using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NerdDinner.Models
{
    public class Meeting
    {
        public Guid MeetingID { get; set; }
        public DateTime Date { get; set; }
        public Guid OwnerID { get; set; }
        public Location Location { get; set; }
        virtual public ApplicationUser Attendees { get; set; }
    }
}