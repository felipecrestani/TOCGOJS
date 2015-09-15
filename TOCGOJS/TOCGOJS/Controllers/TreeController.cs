using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOCGOJS.Context;
using TOCGOJS.Models;

namespace TOCGOJS.Controllers
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
            CurrentRealityTreeViewModel model = new CurrentRealityTreeViewModel();
            model.ProjectId = projectId;

            return View(model);
        }

        public ActionResult Save(string data, int id, int projectId, string name)
        {
            if(id == 0)
            {
                CurrentRealityTree tree = new CurrentRealityTree()
                {
                    ProjectId = projectId,
                    Json = data,
                    Name = name
                };

                db.CurrentRealityTree.Add(tree);
                db.SaveChanges();

                return Json("/Tree/Edit?id=" + tree.Id, JsonRequestBehavior.AllowGet);

            }
            else
            {
                var tree = db.CurrentRealityTree.FirstOrDefault(x => x.Id == id);
                tree.Json = data;
                tree.Name = name;
                db.SaveChanges();
            }

            return Json("Saved", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            var tree = db.CurrentRealityTree.FirstOrDefault(x => x.Id == id);

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