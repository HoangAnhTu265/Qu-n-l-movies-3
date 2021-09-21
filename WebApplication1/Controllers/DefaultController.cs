using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        ServicesReference_Movies.Service1Client sv = new ServicesReference_Movies.Service1Client();
        public ActionResult Index()
        {
            var list = sv.getAll();
            //int a = 0;
            //a++;
            return View(sv.getAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ServicesReference_Movies.Movie m)
        {
            sv.Add(m);
            return RedirectToAction("Index", "Default");
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(ServicesReference_Movies.Movie m)
        {
            sv.Edit(m);
            return RedirectToAction("Index", "Default");
        }
    }
}