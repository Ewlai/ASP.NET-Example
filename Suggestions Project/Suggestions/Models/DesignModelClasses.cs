using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Suggestions.Models
{
    public class Program
    {
        public Program()
        {
            this.Courses = new List<Course>();
        }

        public int Id { get; set; }

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
        public ICollection<Course> Courses { get; set; }

    }

    public class Course
    {
        public Course()
        {
            this.Programs = new List<Program>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public String Code { get; set; }

        [Required]
        [StringLength(100)]
        public String Name { get; set; }

        [Required]
        [StringLength(2000)]
        public String Description { get; set; }
        public ICollection<Program> Programs { get; set; }
    }

    public class Suggestion
    {
        public Suggestion()
        {
            this.Timestamp = DateTime.Now;
            this.FollowUps = new List<FollowUp>();
        }

        public int Id { get; set; }

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
        public byte[] Attachment { get; set; }

        [StringLength(30)]
        public String ContentType { get; set; }
        public ICollection<FollowUp> FollowUps { get; set; }

    }

    public class FollowUp
    {
        public FollowUp()
        {
            this.Timestamp = DateTime.Now;
            //this.Suggestion = new Suggestion();
        }
        public int Id { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        [StringLength(50)]
        public String Title { get; set; }

        [Required]
        [StringLength(1000)]
        public String Description { get; set; }
        public byte[] Attachment { get; set; }
        
        [StringLength(30)]
        public String ContentType { get; set; }

        public Suggestion Suggestion { get; set; }
    }
}