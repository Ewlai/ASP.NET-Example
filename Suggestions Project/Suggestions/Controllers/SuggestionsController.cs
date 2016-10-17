using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace Suggestions.Controllers
{
    public class SuggestionsController : Controller
    {
        private Manager m = new Manager();

        // GET: Suggestions
        public ActionResult Index()
        {
            return View(m.AllSuggestions());
        }

        
        // GET: Suggestions/Details/5
        public ActionResult Details(int? id)
        {
            //Determine whether we can continue
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            // Fetch the object, so that we can inspect its value

            var fetchedObject = m.GetSuggestionByIdWithFollowUps(id.Value);

            if (fetchedObject == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(fetchedObject);
            }

        }
        

        // GET: Suggestions/Create
        public ActionResult Create()
        {
            var addForm = new SuggestionAddForm();
            addForm.Program = new SelectList(m.AllPrograms());
            addForm.Course = new SelectList(m.AllCourses());
            addForm.Timestamp = DateTime.Now;

            return View(addForm);
        }

        // POST: Suggestions/Create
        [HttpPost]
        public ActionResult Create(SuggestionAdd newItem)
        {
            if (ModelState.IsValid)
            {
                SuggestionBase addItem = m.AddSuggestion(newItem);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Create");
            }
             
            
        }

        
        // GET: Suggestions/Edit/5
        public ActionResult Edit(int? id)
        {
            //Determine whether we can continue
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            // Fetch the object, so that we can edit the value

            SuggestionBaseWithFollowUps fetchedObject = m.GetSuggestionByIdWithFollowUps(id.Value);

            if (fetchedObject == null)
            {
                return HttpNotFound();
            }
            else
            {
                var editItem = Mapper.Map<SuggestionEditForm>(fetchedObject);
                editItem.Program = new SelectList(m.AllPrograms(), fetchedObject.Program);
                editItem.Course = new SelectList(m.AllCourses(), fetchedObject.Course);

                return View(editItem);
            }

        }

        // POST: Suggestions/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SuggestionEdit editItem)
        {
            if (ModelState.IsValid)
            {
                SuggestionBase editedItem = m.EditSuggestion(editItem);

                if (editedItem == null) {

                    return RedirectToAction("index");
                }
                else
                {
                    return RedirectToAction("details", new { id = editedItem.Id });
                }

            }
            else
            {
                return RedirectToAction("index");
            }
        }

        
        // GET: Suggestions/Delete/5
        public ActionResult Delete(int? id)
        {
            //Determine whether we can continue
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            // Fetch the object, so that we can display then delete object

            var fetchedObject = m.GetSuggestionByIdWithFollowUps(id.Value);

            if (fetchedObject == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(fetchedObject);
            }
        }

        // POST: Suggestions/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (m.DeleteSuggestionById(id))
            {
                return RedirectToAction("index");
            }
            else
            {
                return RedirectToAction("details", new { id = id });
            }
        }
        
    }
}
