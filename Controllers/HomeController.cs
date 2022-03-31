﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BowlingProject.Models;

namespace BowlingProject.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository _repo { get; set; }

        public HomeController(IBowlersRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(string bowlerTeam)
        {
            List<Bowler> bowlers = _repo.Bowlers
                .Where(b => b.Team.TeamName == bowlerTeam || bowlerTeam == null)
                .OrderBy(b => b.BowlerID)
                .ToList();

            return View(bowlers);
        }

    }
}
