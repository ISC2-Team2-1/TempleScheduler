using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TempleScheduler.Models
{
    public class Group : DbContext
    {
        [Key]
        public int GroupId { get; set; }
        [Required]
        public string GroupName { get; set; }
        [Required]
        public string GroupSize { get; set; }
        [Required]
        public string EmailAddr { get; set; }
        public string PhoneNum { get; set; }
        [Required]
        public DateTime AvailableTime { get; set; }


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
