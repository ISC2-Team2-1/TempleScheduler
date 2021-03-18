using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TempleScheduler.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }
        [Required(ErrorMessage = "You need to enter a group name..")]
        public string GroupName { get; set; }
        [Required(ErrorMessage = "You need to enter a group size.")]
        public int GroupSize { get; set; }
        [Required(ErrorMessage = "You need to enter an email address.")][EmailAddress]
        public string EmailAddr { get; set; }
        public string PhoneNum { get; set; }
        public int TimeID { get; set; }
        public AvailableTime Timeslots { get; set; }



        //How to build a funciton in the quantrant

        //public string Get Quandrant()
        //{
        //    string quadrant Name = "";
        //    if (Urgent == true && Important == true)
        //    {
        //        quadrantName = "Quandrant I";
        //    }
        //    else if(!Urgent && Important)
        //    {
        //        quandrantName = "Quandrant II";
        //    }
        //}
    }
}
