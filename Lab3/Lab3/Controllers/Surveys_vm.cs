using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab3.Controllers
{
    public class SurveyAdd
    {
        public SurveyAdd() {
            this.Courses = new List<string>();
            this.FavouriteTopics = new List<string>();
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public IEnumerable<string> Courses { get; set; }
        public string PaceOfLearning { get; set; }
        public IEnumerable<string> FavouriteTopics { get; set; }
        public string Comments { get; set; }

    }

    public class SurveyFull : SurveyAdd {
        public int Id { get; set; }
    }

    public class SurveyAddForms {
        public string Name { get; set; }
        public int Age { get; set; }
        public SelectList Courses { get; set; }
        public SelectList PaceOfLearning { get; set; }
        public SelectList FavouriteTopics { get; set; }
        public string Comments { get; set; }
    }
}