using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOCLogin.Context;
using TOCLogin.Models;

namespace TOCLogin.Controllers
{
    public class TreeController : Controller
    {
        private TOCdb db { get; set; }

        public TreeController()
        {
            this.db = new TOCdb();
        }

        public ActionResult New(int projectId)
        {
            TreeViewModel model = new TreeViewModel();
            model.ProjectId = projectId;

            return View(model);
        }

        public ActionResult Save(string data, int id, int projectId, string name)
        {
            if(id == 0)
            {
                Tree tree = new Tree()
                {
                    ProjectId = projectId,
                    Json = data,
                    Name = name
                };

                db.Tree.Add(tree);
                db.SaveChanges();

                return Json("/Tree/Edit?id=" + tree.Id, JsonRequestBehavior.AllowGet);

            }
            else
            {
                var tree = db.Tree.FirstOrDefault(x => x.Id == id);
                tree.Json = data;
                tree.Name = name;
                db.SaveChanges();
            }

            return Json("Saved", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            var tree = db.Tree.FirstOrDefault(x => x.Id == id);

            TreeModelJson result = new TreeModelJson();
            JObject o = JObject.Parse(tree.Json);

            result.Id = id;
            result.ProjectId = tree.ProjectId;
            result.Name = tree.Name;
            result.Nodes = o["nodeDataArray"].ToString();
            result.Links = o["linkDataArray"].ToString(Formatting.None);

            var xx = JsonConvert.SerializeObject(result);

            return View(result);
        }

    }
}