using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PromotionEngine.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Unit unit)
        {
            unit.Result = Calculate(unit);
            return View(unit);
        }

        public int Calculate(Unit unit)
        {
            int A = (unit.A / 3) * 130 + (unit.A % 3) * 50;
            int B= (unit.B / 2) * 45 + (unit.B % 2) * 30;
            int CD = 0;
            if(unit.C==0 || unit.D == 0)
            {
                CD = (unit.C) * 20 + (unit.D) * 15;
            }
            else
            {
                int CDpair = Math.Min(unit.C, unit.D) * 30;
                int remainder = Math.Max(unit.C, unit.D) - Math.Min(unit.C, unit.D);
                CD=CDpair+ (Math.Max(unit.C, unit.D) == unit.C ? remainder * 20 : remainder * 15);
            }
            unit.Result = A + B + CD;
            return unit.Result;
        }
    }
}