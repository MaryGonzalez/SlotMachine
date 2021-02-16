using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthenticatedSlotMachineMVC.Models;

namespace AuthenticatedSlotMachineMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //When a user clicks the "New Game" button
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.TotalWin = 0.0;
            ViewBag.TotalInserted = 0.0;
            ViewBag.Deposit = 0.0;

            Machine machine = new Machine();
            machine.Display();
            ViewBag.Symbol1 = machine.symbol1;
            ViewBag.Symbol2 = machine.symbol2;
            ViewBag.Symbol3 = machine.symbol3;

            return View();
        }



        [HttpPost]
        public ActionResult Index(Machine machine)
        {

            if (ModelState.IsValid)
            {
                machine.Display();
                ViewBag.Symbol1 = machine.symbol1;
                ViewBag.Symbol2 = machine.symbol2;
                ViewBag.Symbol3 = machine.symbol3;

                //Bet + Winnings
                ViewBag.TotalWin = machine.CheckWinner();

                //Total in Bets
                ViewBag.TotalInserted = machine.TotalInserted();

              

            }
            else
            {
                ViewBag.TotalWin = 0.0;
                ViewBag.TotalInserted = 0.0;
                ViewBag.Deposit = 0.0;

                machine.Display();
                ViewBag.Symbol1 = machine.symbol1;
                ViewBag.Symbol2 = machine.symbol2;
                ViewBag.Symbol3 = machine.symbol3;

            }



            return View(machine);
        }
    }
}