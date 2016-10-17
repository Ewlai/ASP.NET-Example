using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab5.Controllers
{
    public class SongsController : Controller
    {
        private Manager m = new Manager();

        // GET: Songs
        public ActionResult Index()
        {
            return View(m.AllSongs());
        }

        // GET: Songs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Songs/Create
        public ActionResult Create()
        {
            var songAdd = new SongAddForm();
            songAdd.Genre = new SelectList(m.AllGenres());
            songAdd.Albums = new SelectList(m.AllAlbumsList(), "Id", "Name");
            songAdd.ReleaseDateAsSingle = DateTime.Now;

            return View(songAdd);
        }

        // POST: Songs/Create
        [HttpPost]
        public ActionResult Create(SongAdd newItem)
        {
            if (ModelState.IsValid)
            {

                SongBase addedItem = m.AddSong(newItem);

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

    }
}
