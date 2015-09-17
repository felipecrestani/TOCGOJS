using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOCLogin.Models
{
    public class CloudModelJson
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int NodeId { get; set; }
        public string Name { get; set; }
        public string Nodes { get; set; }
        public string Links { get; set; }
    }
}