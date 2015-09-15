using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using TOCGOJS.Context;
using TOCGOJS.Models;

namespace TOCGOJS.Controllers
{
    public class ProjectController : Controller
    {
        private TOCdb tocDB {get; set;}

        public ProjectController()
        {
            this.tocDB = new TOCdb();
        }

        public ActionResult Index()
        {
            return View(this.tocDB.Project.ToList());
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Save(Project form)
        {
            this.tocDB.Project.Add(form);
            this.tocDB.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
