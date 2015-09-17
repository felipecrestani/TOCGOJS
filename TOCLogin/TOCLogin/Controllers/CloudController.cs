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
    public class CloudController : Controller
    {
        private TOCdb db { get; set; }

        public CloudController()
        {
            this.db = new TOCdb();
        }

        public ActionResult New(int projectId,int nodeId,int TreeId)
        {
            Cloud model = new Cloud();
            model.ProjectId = projectId;
            model.NodeId = nodeId;
            model.TreeId = TreeId;

            return View(model);
        }

        public ActionResult Save(string data, int id, int projectId,int nodeId, string name,int treeId)
        {
            if(id == 0)
            {
                Cloud cloud = new Cloud()
                {
                    ProjectId = projectId,
                    Json = data,
                    Name = name,
                    NodeId = nodeId,
                    TreeId = treeId
                };

                db.Cloud.Add(cloud);
                db.SaveChanges();

                return Json("/Cloud/Edit?id=" + cloud.Id, JsonRequestBehavior.AllowGet);

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
            var cloud = db.Cloud.FirstOrDefault(x => x.Id == id);

            CloudModelJson result = new CloudModelJson();
            JObject o = JObject.Parse(cloud.Json);

            result.Id = id;
            result.ProjectId = cloud.ProjectId;
            result.Name = cloud.Name;
            result.Nodes = o["nodeDataArray"].ToString();
            result.Links = o["linkDataArray"].ToString();

            var xx = JsonConvert.SerializeObject(result);

            return View(result);
        }

    }
}