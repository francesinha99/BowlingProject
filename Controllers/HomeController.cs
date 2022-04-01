using System;
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
            ViewBag.name = RouteData?.Values["bowlerTeam"];

            List<Bowler> bowlers = _repo.Bowlers
                .Where(b => b.Team.TeamName == bowlerTeam || bowlerTeam == null)
                .OrderBy(b => b.BowlerID)
                .ToList();

            return View(bowlers);
        }

        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            ViewBag.Bowler = _repo.Bowlers.ToList();

            var bowler = _repo.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View("BowlerForm", bowler);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            _repo.EditBowler(b);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("BowlerForm");
        }

        [HttpPost]
        public IActionResult Add(Bowler b)
        {
            
            _repo.CreateBowler(b);
            return RedirectToAction("Index");
           
        }

        public IActionResult Delete(int bowlerid)
        {
            var bowler = _repo.Bowlers.Single(x => x.BowlerID == bowlerid);

            _repo.DeleteBowler(bowler);

            return RedirectToAction("Index");
        }

    }
}
