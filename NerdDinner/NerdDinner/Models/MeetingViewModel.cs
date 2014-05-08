using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NerdDinner.Models
{
    public class MeetingViewModel
    {
        public MeetingViewModel(Meeting meeting, Location location)
        {
            this.Meeting = meeting;
            this.Location = location;
        }
        public MeetingViewModel()
        {
            this.Meeting = new Meeting();
            this.Location = new Location();
        }
        public Location Location { get; set; }
        public Meeting Meeting { get; set; }
    }
}