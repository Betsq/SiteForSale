using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeautySouthKoreaSiteMVC.Models
{
    public class HttpPostedFileBase
    {
        public string Picture { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        [Display(Name = "Display profile Image")]
        public bool DisplayItem { get; set; }
    }
}
