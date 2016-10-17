using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab5.Controllers
{
    public class ArtistsController : Controller
    {
        private Manager m = new Manager();

        // GET: Artists
        public ActionResult Index()
        {
            return View(m.AllArtists());
        }

        // GET: Artists/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Artists/Create
        public ActionResult Create()
        {
            var addForm = new ArtistAddForm();
            addForm.Genre = new SelectList(m.AllGenres());
            addForm.BirthOrStartDate = DateTime.Now.AddYears(-30);
            addForm.StartDecade = ((int)((DateTime.Now.Year - 10) / 10)) * 10;

            return View(addForm);
        }

        // POST: Artists/Create
        [HttpPost]
        public ActionResult Create(ArtistAdd newItem)
        {
            if(ModelState.IsValid)
            {
                ArtistBase addItem = m.AddArtist(newItem);
            } 
            
            return RedirectToAction("Index");

        }

    }
}
