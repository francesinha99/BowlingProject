using System;
using System.Linq;
using BowlingProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BowlingProject.Components
{
    public class TeamsViewComponent : ViewComponent
    {
        private IBowlersRepository repo { get; set; }

        public TeamsViewComponent (IBowlersRepository temp)
        {
            repo = temp;
        }


        public IViewComponentResult Invoke()
        {
            var teams = repo.Bowlers
                .Select(x => x.Team.TeamName)
                .Distinct()
                .OrderBy(x => x);

            return View(teams);
        }

    }
}
