using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4.Controllers
{
    public class ProductsController : Controller
    {
        private Manager m = new Manager();

        // ############################################################

        //
        // GET: /Products/
        public ActionResult Index()
        {
            // Return all products
            return View(m.GetAllProducts());
        }

        //
        // GET: /Products/Details/5
        public ActionResult Details(int id)
        {
            // Attempt to fetch the object
            // If not found, redirect to the index view
            // Otherwise, return the fetched object in the view
            return View();
        }

        // ############################################################

        //
        // GET: /Products/Create
        public ActionResult Create()
        {
            // Prepare the data for the view...
            // Create a new ProductAddForm object

            var addProduct = new ProductAddForm();

            addProduct.Size = new SelectList(m.GetProductSizes());
            addProduct.Supplier = new SelectList(m.GetAllSuppliersList(), "Id", "Name");

            // Configure the SelectList properties with data
            // Return the object in the view
            return View(addProduct);
        }

        //
        // POST: /Products/Create
        [HttpPost]
        public ActionResult Create(ProductAdd newItem)
        {
            // Model state validity check
            // If not valid, redirect to the index view
            // Otherwise, continue
            // Attempt to add the new item, using the manager method
            // If the attempt fails, redirect to the index view
            // Otherwise, redirect to the details view for the added object

            ProductBase addedItem = null;

            // Check that the incoming data is valid
            if (ModelState.IsValid)
            {
                addedItem = m.AddNewProduct(newItem);
            }
            else
            {
                // Return the object so the user can edit it correctly
                return View(newItem);
            }

            // If the incoming data is valid and the new data was added, redirect
            return RedirectToAction("index");
        }

        // ############################################################

        /*
        //
        // GET: /Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Products/Edit/5
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

        //
        // GET: /Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Products/Delete/5
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
