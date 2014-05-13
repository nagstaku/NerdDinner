using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NerdDinner.Models
{
    public class Meeting
    {
        public Meeting()
        {
            Attendees = new List<User>();
        }
        public Guid MeetingID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Lat { get; set; }
        public string lng { get; set; }
        public string Description { get; set; }
        public string OwnerID { get; set; }
        [ForeignKey("OwnerID")]
        public User Owner { get; set; }
        virtual public List<User> Attendees { get; set; }
    }
}