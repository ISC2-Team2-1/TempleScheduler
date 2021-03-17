using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleScheduler.Models.ViewModels
{
    public class ProjectListViewModel
    {

        public virtual IEnumerable<Group> Groups { get; set; }
    }
}
