using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOCGOJS.Models
{
    public class TreeModelJson
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Nodes { get; set; }
        public string Links { get; set; }
    }
}