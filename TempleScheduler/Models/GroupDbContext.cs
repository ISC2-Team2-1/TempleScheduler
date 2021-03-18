using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleScheduler.Models
{
    public class GroupDbContext : DbContext
    {
        public GroupDbContext(DbContextOptions<GroupDbContext> options) : base(options)
        { }

        public DbSet<Group> Groups { get; set; }

        public DbSet<AvailableTime> Times { get; set; }
    }
}
