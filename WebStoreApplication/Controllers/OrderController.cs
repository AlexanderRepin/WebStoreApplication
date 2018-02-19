using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStoreApplication.Controllers
{
    public class OrderController : Controller
    {
        private Manager m = new Manager();


        public ActionResult AddCart(int Id)
        {

            //return View(addOrder);


            return View(m.AllOrdersWithProduce());

        }

        [HttpPost]
        public ActionResult AddToCart(ProduceBase newItem)
        {
            OrderBase addedItem = null;            

            // Check that the incoming data is valid
            if (ModelState.IsValid)
            {
                addedItem = m.AddToCart(newItem);
                m.AddOrder(addedItem);

            }
            else
            {
                // Return the object so the user can edit it correctly
                return View(newItem);
            }

            // If the incoming data is valid and the new data was added, redirect
            return RedirectToAction("Index", "Produce");
        }

        // GET: Order
        public ActionResult Index()
        {
            return View(m.AllOrdersWithProduce());
        }

        // GET: Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) { return RedirectToAction("index"); }

            // Attempt to fetch the object
            var fetchedObject = m.GetOrderById(id.GetValueOrDefault());

            if (fetchedObject == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(fetchedObject);
            }
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            var addForm = new OrderBaseWithProduce();


            return View(addForm);
        }

        /*
        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(OrderAdd newItem)
        {
            OrderBase addedItem = null;

            // Check that the incoming data is valid
            if (ModelState.IsValid)
            {
                addedItem = m.AddOrder(newItem);
            }
            else
            {
                // Return the object so the user can edit it correctly
                return View(newItem);
            }

            // If the incoming data is valid and the new data was added, redirect
            return RedirectToAction("index");
        }
        */

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
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

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
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
