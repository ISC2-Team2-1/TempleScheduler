using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TempleScheduler.Models;

namespace TempleScheduler.Models
{
    public class EFGroupRepository: IGroupRepository
    {
        private GroupContext _context;
        
        //Constructor
        public EFGroupRepository(GroupContext context)
        {
            _context = context;
        }
        public IQueryable<Group> Groups => _context.Groups;
    }

    
}
