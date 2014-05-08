using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NerdDinner.Models
{
    public class Location
    {
        public Location()
        {
            Meetings = new List<Meeting>();
        }
        public Guid LocationID { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        virtual public List<Meeting> Meetings { get; set; }
    }
}