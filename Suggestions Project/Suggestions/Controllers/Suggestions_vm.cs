using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Suggestions.Controllers
{
    public class SuggestionEditForm
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public String Title { get; set; }

        [Required]
        [StringLength(1000)]
        public String Description { get; set; }
        public SelectList Program { get; set; }
        public SelectList Course { get; set; }
    }

    public class SuggestionEdit
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public String Title { get; set; }

        [Required]
        [StringLength(1000)]
        public String Description { get; set; }

        [Required]
        [StringLength(30)]
        public String Program { get; set; }

        [Required]
        [StringLength(30)]
        public String Course { get; set; }
    }

    public class SuggestionList
    {
        public int Id { get; set; }
        public String Title { get; set; }
    }

    public class SuggestionAddForm
    {
        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        [StringLength(50)]
        public String Title { get; set; }

        [Required]
        [StringLength(1000)]
        public String Description { get; set; }
        public SelectList Program { get; set; }
        public SelectList Course { get; set; }
        //public HttpPostedFileBase ContentUpload { get; set; }

    }
    public class SuggestionAdd
    {
        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        [StringLength(50)]
        public String Title { get; set; }

        [Required]
        [StringLength(1000)]
        public String Description { get; set; }

        [Required]
        [StringLength(30)]
        public String Program { get; set; }

        [Required]
        [StringLength(30)]
        public String Course { get; set; }

        public HttpPostedFileBase ContentUpload { get; set; }
    }

    public class SuggestionBase : SuggestionAdd
    {
        public int Id { get; set; }

        public byte[] Attachment { get; set; }

        [StringLength(30)]
        public String ContentType { get; set; }
    }

    public class SuggestionBaseWithFollowUps : SuggestionBase
    {
        public IEnumerable<FollowUpBase> FollowUps { get; set; }
    }
}