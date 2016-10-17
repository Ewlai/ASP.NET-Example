using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Notes.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private Manager m = new Manager();

        // GET: Employees
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View(m.GetAllEmployees());
        }

        // GET: Employees/DetailsByUserName/{username}
        // The purpose of this method is to support a username lookup,
        // but as you can see, it simply redirects with the user identifier
        // to the next method
        public ActionResult DetailsByUserName(string username)
        {
            // Determine whether we can continue, non-null username

            if (username == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                // Attempt to fetch the object
                var identifier = m.GetEmployeeIdForUserName(username);

                if (identifier == null)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    // If found, redirect to the Details method, specifying the Employee Id
                    return RedirectToAction("details", new { id = identifier });
                }

            }

        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {

            // Determine whether we can continue, non-null id
            if (id == null)
            {
                return RedirectToAction("index");
            }
            else
            {   // Attempt to fetch the object
                var fetchedObject = m.GetEmployeeByIdWithAssociatedData(id.Value);

                if (fetchedObject == null)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    // Prepare the object for the view
                    // Present the view
                    return View(fetchedObject);
                }

            }
        }

        // GET: Employees/ChooseDirectReports/5
        // Sends the form to enable a manager to select their direct reports
        public ActionResult ChooseDirectReports(int? id)
        {

            // Determine whether we can continue, non-null id
            if (id == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                // Verify that the security context user has the 'Manager' role claim
                // e.g. (User as ClaimsPrincipal).HasClaim(ClaimTypes.Role, "Manager")

                var fetchedObject = m.GetEmployeeByIdWithAssociatedData(id.Value);
                var username = fetchedObject.IdentityUserId;

                if (m.IsUserAManager(username))
                {
                    // Prepare and configure a form to send to the view
                    // Present the view
                    var chooseEmp = new EmployeeDirectReportsForm();
                    chooseEmp.Id = id.Value;
                    chooseEmp.Employees = new MultiSelectList(m.GetAllEmployeesNoManager(), "Id", "FullName");

                    return View(chooseEmp);
                }
                else
                {
                    // User is not a manager
                    return RedirectToAction("Details", new { id = id });
                }

            }

        }

        // POST: Employees/ChooseDirectReports/5
        // Handles the selection of direct reports
        [HttpPost]
        public ActionResult ChooseDirectReports(int? id, EmployeeDirectReports newItem)
        {
            if (ModelState.IsValid & id == newItem.Id)
            {
                // Attempt to perform the task
                var addedItem = m.ConfigureDirectReports(newItem);

                if (addedItem == null)
                {
                    // There was a problem, just do a redirect
                    return View("ChooseDirectReports", addedItem);
                    
                }
                else
                {
                    // Maybe return to a results page
                    return RedirectToAction("Details", new { id = id });
                }
            }
            else
            {
                // There was a problem, just do a redirect
                return RedirectToAction("Details", new { id = id });
            }
        }

    }
}
