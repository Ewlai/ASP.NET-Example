using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab3.Controllers
{
    public class SurveysController : Controller
    {
        // create an instance of the Manager class, which will handle the app's data
        private Manager m = new Manager();

        // GET: Surveys
        public ActionResult Index()
        {
            return View(m.AllSurveys);
        }

        // GET: Surveys/Details/5
        public ActionResult Details(int? id)
        {
            // Handle an empty identifier
            if (id == null) { return RedirectToAction("index"); }

            // Attempt to fetch the object
            var fetchedObject = m.GetSurveyById(id.GetValueOrDefault());

            if (fetchedObject == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(fetchedObject);
            }
        }

        // GET: Surveys/Create
        public ActionResult Create()
        {
            var addForm = new SurveyAddForms();

            addForm.Courses = new SelectList(m.UI_Courses());
            addForm.PaceOfLearning = new SelectList(m.UI_LearningPace());
            addForm.FavouriteTopics = new SelectList(m.UI_Topics());

            return View(addForm);
        }

    }
}
