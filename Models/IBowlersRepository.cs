using System;
using System.Linq;

namespace BowlingProject.Models
{
    public interface IBowlersRepository
    {
       IQueryable<Bowler> Bowlers { get; }
    }
}
