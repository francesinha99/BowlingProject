using System;
using System.Linq;

namespace BowlingProject.Models
{
    public interface ITeamsRepository
    {
        public IQueryable<Team> Teams { get; }
    }
}
