using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using TOCLogin.Context;
using TOCLogin.Models;
using Microsoft.AspNet.Identity;

namespace TOCLogin.Controllers
{
    [System.Web.Mvc.Authorize]
    public class ProjectController : Controller
    {
        private TOCdb db {get; set;}
        private string userId { get; set; }

        public ProjectController()
        {
            this.db = new TOCdb();
        }

        public ActionResult Index()
        {
            var projects = this.db.Project.ToList();
            return View(projects);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Edit(int projectId)
        {
            return View(this.db.Project.FirstOrDefault(x => x.Id == projectId));
        }

        public ActionResult Save(Project form)
        {
            this.db.Project.Add(form);
            this.db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
