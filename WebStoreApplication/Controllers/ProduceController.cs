using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStoreApplication.Controllers
{
    public class ProduceController : Controller
    {
        private Manager m = new Manager();


       
        // GET: Produce
        public ActionResult Index()
        {
            return View(m.AllProduce);
        }

        // GET: Produce/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue) { return HttpNotFound(); }

            // Fetch the object, so that we can inspect its value
            var fetchedObject = m.GetProduceById(id.Value);

            if (fetchedObject == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(fetchedObject);
            }
        }

        // GET: Produce/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produce/Create
        [HttpPost]
        public ActionResult Create(ProduceAdd newItem)
        {

            ProduceBase addedItem = null;

            if (ModelState.IsValid)
            {
                addedItem = m.AddProduce(newItem);
            }
            else
            {
                return View(newItem);
            }

            return RedirectToAction("index");
        }

        // GET: Produce/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Produce/Edit/5
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

        // GET: Produce/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Produce/Delete/5
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
    }
}
