using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3.Models
{
    public class Survey
    {
        public Survey() {
            this.Courses = new List<string>();
            this.FavouriteTopics = new List<string>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public ICollection<string> Courses { get; set; }
        public string PaceOfLearning { get; set; }
        public ICollection<string> FavouriteTopics { get; set; }
        public string Comments { get; set; }


    }
}