using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TOCLogin.Models
{
    public interface Entity
    {
        [Key]
        int Id { get; set; }
        DateTime? CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
        string CreateBy { get; set; }
        string ModifiedBy { get; set; }
    }
}