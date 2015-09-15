using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOCGOJS.Models
{
    public class Cloud : Entity
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int CurrentRealityTreeId { get; set; }

        public string CreateBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}