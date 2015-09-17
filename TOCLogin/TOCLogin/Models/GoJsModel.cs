using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOCLogin.Models
{
    public class GoJsModel
    {
        public List<NodeDataArray> nodeDataArray { get; set; }
        public List<LinkDataArray> linkDataArray { get; set; }
    }

    public class NodeDataArray
    {
        public int key { get; set; }
        public string text { get; set; }
        public string loc { get; set; }
        public string color { get; set; }
        public string fig { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        public bool? fromLinkable { get; set; }
        public bool? toLinkable { get; set; }
    }

    public class LinkDataArray
    {
        public int from { get; set; }
        public int to { get; set; }
    }

}