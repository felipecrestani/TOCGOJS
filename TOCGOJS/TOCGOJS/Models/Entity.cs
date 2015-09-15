using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOCGOJS.Models
{
    public interface Entity
    {
        DateTime? CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
        string CreateBy { get; set; }
        string ModifiedBy { get; set; }
    }
}