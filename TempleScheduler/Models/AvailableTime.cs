using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TempleScheduler.Models
{
    public class AvailableTime
    {
        [Key]
        public int TimeId { get; set; }

        [Required(ErrorMessage = "You need to choose an available time slot.")]
        public string Timeslots { get; set; }
    }
}
