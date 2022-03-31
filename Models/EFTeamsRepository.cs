using System;
using System.Linq;

namespace BowlingProject.Models
{
    public class EFTeamsRepository : ITeamsRepository
    {
        private BowlersDbContext _context { get; set; }

        public EFTeamsRepository(BowlersDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Team> Teams => _context.Teams;
    }
}
