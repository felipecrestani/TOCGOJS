using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TOCLogin.Models
{
    public class Cloud : Entity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Json { get; set; }

        public int NodeId { get; set; }
        public int ProjectId { get; set; }
        public int TreeId { get; set; }

        public string CreateBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}