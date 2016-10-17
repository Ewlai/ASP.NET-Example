using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab5.Controllers
{
    public class AlbumsController : Controller
    {
        private Manager m = new Manager();

        // GET: Albums
        public ActionResult Index()
        {
            return View(m.AllAlbums());
        }

        // GET: Albums/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            var addForm = new AlbumAddForm();

            addForm.Artists = new SelectList(m.AllArtistsList(), "Id", "Name");

            addForm.Genre = new SelectList(m.AllGenres());

            addForm.ReleaseDate = DateTime.Now;

            return View(addForm);
        }

        // POST: Albums/Create
        [HttpPost]
        public ActionResult Create(AlbumAdd newItem)
        {
            if (ModelState.IsValid)
            {
                AlbumBase addItem = m.AddAlbum(newItem);

                return RedirectToAction("Index");
            } else {

                return RedirectToAction("Create");
            }
        }
    }
}
