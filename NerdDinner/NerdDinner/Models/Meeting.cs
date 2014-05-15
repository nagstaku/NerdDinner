using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        [HiddenInput(DisplayValue=false)]
        public string Lat { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string lng { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string OwnerID { get; set; }
        [ForeignKey("OwnerID")]
        [HiddenInput(DisplayValue = false)]
        public User Host { get; set; }
        virtual public List<User> Attendees { get; set; }
    }
}