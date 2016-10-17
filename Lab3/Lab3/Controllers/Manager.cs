using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Biggy.Core;
using Biggy.Data.Json;
using Lab3.Models;
using AutoMapper;

namespace Lab3.Controllers
{
    public class Manager
    {
        private JsonStore<Survey> store;
        private BiggyList<Survey> surveys;

        public Manager() { 
            //configure AutoMapper
            Mapper.CreateMap<Survey, SurveyFull>();
            Mapper.CreateMap<SurveyAdd, Survey>();

            //path to the app's read-write file system location
            var localData = HttpContext.Current.Server.MapPath("~/App_Data");

            //Open or create the data store
            store = new JsonStore<Survey>(localData, "bti420", "surveys");
            surveys = new BiggyList<Survey>(store);
        }

        public IEnumerable<SurveyFull> AllSurveys
        {
            get { return Mapper.Map<IEnumerable<SurveyFull>>(surveys.OrderBy(nm=>nm.Name)); }
        }

        public SurveyFull AddSurvey(SurveyAdd newItem) {

            // Calculate the next value for the identifier
            int newId = (surveys.Count > 0) ? newId = surveys.Max(id => id.Id) + 1 : 1;

            Survey addedItem = Mapper.Map<Survey>(newItem);
            addedItem.Id = newId;

            // Add the new item to the store
            surveys.Add(addedItem);

            // Return the new item
            return Mapper.Map<SurveyFull>(addedItem);
        }

        public SurveyFull GetSurveyById(int id)
        {
            // Attempt to fetch the item
            var fetchedObject = surveys.SingleOrDefault(i => i.Id == id);

            // Return the result
            return (fetchedObject == null) ? null : Mapper.Map<SurveyFull>(fetchedObject);
        }

        public IEnumerable<string> UI_Courses()
        {
            var courses = new List<string>{"BTP400","BTN415","BTI420", "BTS430", "BTC440"};
            return courses;
        }

        public IEnumerable<string> UI_LearningPace()
        {
            var pace = new List<string>
            {
                "Too slow",
                "Slow",
                "Just right",
                "Fast",
                "Too fast"
            };

            return pace;
        }

        public IEnumerable<string>UI_Topics()
        {
            var topics = new List<string>
            {
                "Visual Studio 2013 developer tool",
                "C# language",
                ".NET Framework class library",
                "Learning and applying the MVC pattern",
                "Collection Class",
                "LINQ - language integrated query",
                "View model classes",
                "Data persistence",
                "Scaffolding",
                "HTML Helpers"
            };

            return topics;
        }

    }
}