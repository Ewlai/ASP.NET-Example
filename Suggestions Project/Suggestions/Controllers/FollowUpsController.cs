using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace Suggestions.Controllers
{
    public class FollowUpsController : Controller
    {
        private Manager m = new Manager();

        // GET: FollowUps
        public ActionResult Index()
        {
            return View(m.AllFollowUp());
        }

        
        // GET: FollowUps/Details/5
        public ActionResult Details(int? id)
        {
            //Determine whether we can continue
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            // Fetch the object, so that we can inspect its value
            var fetchedObject = m.GetFollowUpById(id.Value);

            if (fetchedObject == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(fetchedObject);
            }
        }
        

        // GET: FollowUps/Create
        public ActionResult Create()
        {
            var followUpAdd = new FollowUpAddForm();
            followUpAdd.Suggestions = new SelectList(m.AllSuggestionsList(), "Id", "Title");
            followUpAdd.Timestamp = DateTime.Now;

            return View(followUpAdd);
        }

        // POST: FollowUps/Create
        [HttpPost]
        public ActionResult Create(FollowUpAdd newItem)
        {
            if (ModelState.IsValid)
            {

                FollowUpBase addedItem = m.AddFollowUp(newItem);

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        
        // GET: FollowUps/Edit/5
        public ActionResult Edit(int? id)
        {
            //Determine whether we can continue
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            // Fetch the object, so that we can edit the value

            var fetchedObject = m.GetFollowUpById(id.Value);

            if (fetchedObject == null)
            {
                return HttpNotFound();
            }
            else
            {
                var editItem = Mapper.Map<FollowUpEditForm>(fetchedObject);
                editItem.Suggestion = new SelectList(m.AllSuggestionsList(), "Id", "Title", fetchedObject.SuggestionId);

                return View(editItem);
            }
        }

        // POST: FollowUps/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FollowUpEdit editItem)
        {
            if (ModelState.IsValid)
            {
                FollowUpBase editedItem = m.EditFollowUp(editItem);

                if (editedItem == null)
                {

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
        
        // GET: FollowUps/Delete/5
        public ActionResult Delete(int? id)
        {
            //Determine whether we can continue
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            // Fetch the object, so that we can display then delete object

            var fetchedObject = m.GetFollowUpById(id.Value);

            if (fetchedObject == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(fetchedObject);
            }
        }

        // POST: FollowUps/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (m.DeleteFollowUpById(id))
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
