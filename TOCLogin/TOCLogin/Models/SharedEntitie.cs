using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOCLogin.Models
{
    public class SharedEntitie : Entity
    {
        public int Id { get; set; }

        public Guid EntityId { get; set; }
        public Guid User { get; set; }
        public PermissionType Permission { get; set; }
        
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string CreateBy { get; set; }
        public string ModifiedBy { get; set; }

    }
}