using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TOCGOJS.Models
{
    public class Project : Entity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual List<CurrentRealityTree> CurrentRealityTrees { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string CreateBy { get; set; }
        public string ModifiedBy { get; set; }

    }
}