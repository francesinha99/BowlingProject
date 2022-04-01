using System;
using System.Linq;

namespace BowlingProject.Models
{
    public interface IBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get; }
        void SaveBowler(Bowler b);
        void CreateBowler(Bowler b);
        void DeleteBowler(Bowler b);
        void EditBowler(Bowler b);

    }
}
