using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;

namespace Notes.Controllers
{
    [Authorize]
    public class NotesController : Controller
    {
        private Manager m = new Manager();

        // GET: Notes
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            throw new NotImplementedException();
        }

        // GET: Notes/Details/5
        public ActionResult Details(int? id)
        {
            // Determine whether we can continue, non-null id
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Attempt to fetch the object
                var fetchedObject = m.GetNoteForAuthenticatedEmployee(id.Value);

                // Present the view
                return View(fetchedObject);
            }

        }

        // GET: Notes/Create/{id}
        public ActionResult Create(int? id)
        {

            // Validate the user name 
            var fetchedObject = m.GetEmployeeById(id.Value);

            if ((User.Identity as ClaimsIdentity).Name != fetchedObject.IdentityUserId)
            {
                // If validation fails, exit
                return HttpNotFound();
            } else {
                // Otherwise, continue...
                // Create and configure an 'add form'
                var addForm = new NoteAddForm();
                addForm.EmployeeId = id.Value;
                
                return View(addForm);
            }
        }

        // POST: Notes/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(NoteAdd newItem)
        {

            // Standard 'add new' handling
            // Including checking the ModelState
            if(ModelState.IsValid)
            {
                var addedItem = m.AddNoteForAuthenticatedEmployee(newItem);

                // Otherwise, whether successful or not, redirect back to the employee's
                // details view
                if (addedItem == null)
                {
                    return HttpNotFound();
                }

                return RedirectToAction("Details", "Employees", new { id = newItem.EmployeeId });
            }
            else
            {
                // If there's a problem with the form data postback, redisplay the form
                //repopulate form
                var addForm = new NoteAddForm();
                addForm.EmployeeId = newItem.EmployeeId;
                addForm.NoteText = newItem.NoteText;
                addForm.Title = newItem.Title;
                return View(addForm);
            }
            
            
        }

        /*
        // GET: Notes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Notes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Notes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Notes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
