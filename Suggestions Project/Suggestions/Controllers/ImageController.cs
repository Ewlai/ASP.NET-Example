using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Suggestions.Controllers
{
    public class ImageController : Controller
    {
        Manager m = new Manager();

        // GET: Image
        public ActionResult Index()
        {
            return RedirectToAction("Suggestions", "Home");
        }

        [Route("image/suggestion/logo/{id}")]
        public ActionResult GetSuggestionsImgById(int? id)
        {
            // Notice that we changed the parameter type to nullable

            // Determine whether we can continue
            if (!id.HasValue) { return HttpNotFound(); }

            // Fetch the object, so that we can inspect its value
            var fetchedObject = m.GetSuggestionById(id.Value);

            if (fetchedObject == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Return a file content result
                // Set the Content-Type header, and return the photo bytes
                 return File(fetchedObject.Attachment, fetchedObject.ContentType);
            }
        }

        [Route("image/followup/logo/{id}")]
        public ActionResult GetFollowUpsImgById(int? id)
        {
            // Notice that we changed the parameter type to nullable

            // Determine whether we can continue
            if (!id.HasValue) { return HttpNotFound(); }

            // Fetch the object, so that we can inspect its value
            var fetchedObject = m.GetFollowUpById(id.Value);

            if (fetchedObject == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Return a file content result
                // Set the Content-Type header, and return the photo bytes
                return File(fetchedObject.Attachment, fetchedObject.ContentType);
            }
        }
    }
}