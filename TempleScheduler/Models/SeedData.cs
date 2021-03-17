using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleScheduler.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            GroupDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<GroupDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Groups.Any())
            {
                context.Groups.AddRange(
                    new Group
                    {
                        GroupName = "Team 2",
                        GroupSize = "4",
                        EmailAddr = "team2@byu.edu",
                        PhoneNum = "555-555-1234",
                        AvailableTime = "Tuesday at 4pm"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
