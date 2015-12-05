using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfraMap.Web.MVC.Controllers
{
    public class SaoLeopoldoController : Controller
    {
        [HttpGet]
        public ActionResult Terceiro()
        {
            return View();
        }
    }
}