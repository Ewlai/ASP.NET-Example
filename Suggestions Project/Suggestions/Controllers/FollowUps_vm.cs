using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Suggestions.Controllers
{
    public class FollowUpEditForm
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public String Title { get; set; }

        [Required]
        [StringLength(1000)]
        public String Description { get; set; }

        [Required]
        public SelectList Suggestion { get; set; }

    }
    public class FollowUpEdit
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public String Title { get; set; }

        [Required]
        [StringLength(1000)]
        public String Description { get; set; }

        [Required]
        public int Suggestion { get; set; }

    }

    public class FollowUpList
    {
        public int Id { get; set; }
        public String Title { get; set; }
    }
    public class FollowUpAddForm
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
        public String SuggestionId { get; set; }
        public SelectList Suggestions { get; set; }

    }
    public class FollowUpAdd
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
        public int SuggestionId { get; set; }

        public HttpPostedFileBase ContentUpload { get; set; }
    }

    public class FollowUpBase : FollowUpAdd
    {
        public int Id { get; set; }
        public String SuggestionTitle { get; set; }
        public byte[] Attachment { get; set; }

        [StringLength(30)]
        public String ContentType { get; set; }
    }
}