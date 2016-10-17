using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Suggestions.Controllers
{
    public class CourseAdd
    {

        [Required]
        [StringLength(10)]
        public String Code { get; set; }

        [Required]
        [StringLength(100)]
        public String Name { get; set; }

        [Required]
        [StringLength(2000)]
        public String Description { get; set; }
    }
}