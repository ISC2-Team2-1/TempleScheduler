using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TempleScheduler.Models;

namespace TempleScheduler.Models
{
    public class EFGroupRepository: IGroupRepository
    {
        private GroupDbContext _context;
        
        //Constructor
        public EFGroupRepository(GroupDbContext context)
        {
            _context = context;
        }
        public IQueryable<Group> Groups => _context.Groups;
    }

    
}
