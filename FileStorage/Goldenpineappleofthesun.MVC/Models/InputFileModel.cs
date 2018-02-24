using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Goldenpineappleofthesun.MVC.Models
{
    public class InputFileModel
    {
        [Required]
        public HttpPostedFileBase File { get; set; }
    }
}