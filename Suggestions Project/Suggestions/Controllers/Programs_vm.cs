using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Suggestions.Controllers
{
    public class ProgramAdd
    {

        [Required]
        [StringLength(10)]
        public String Code { get; set; }

        [Required]
        [StringLength(50)]
        public String Name { get; set; }

        [Required]
        [StringLength(1000)]
        public String Description { get; set; }

        [Required]
        [StringLength(50)]
        public String Credential { get; set; }
    }
}