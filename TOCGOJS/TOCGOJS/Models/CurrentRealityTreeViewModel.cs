using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOCGOJS.Models
{
    public class CurrentRealityTreeViewModel : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Json { get; set; }
        public int ProjectId { get; set; }

        public string Nodes { get; set; }
        public string Links { get; set; }

        public string CreateBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}