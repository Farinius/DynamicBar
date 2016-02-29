using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DynamicBar.Models;
using DynamicBar.Models.DBEntities;

namespace DynamicBar.Controllers.BarControllers
{
    public class OrderStatesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OrderStates
        public ActionResult Index()
        {
            var orderStates = db.OrderStates.Include(o => o.CreatedBy);
            return View(orderStates.ToList());
        }

        // GET: OrderStates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderState orderState = db.OrderStates.Find(id);
            if (orderState == null)
            {
                return HttpNotFound();
            }
            return View(orderState);
        }

        // GET: OrderStates/Create
        public ActionResult Create()
        {
            ViewBag.CreatedById = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: OrderStates/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderStateId,Title,Description,DateCreated,CreatedById")] OrderState orderState)
        {
            if (ModelState.IsValid)
            {
                db.OrderStates.Add(orderState);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedById = new SelectList(db.Users, "Id", "Email", orderState.CreatedById);
            return View(orderState);
        }

        // GET: OrderStates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderState orderState = db.OrderStates.Find(id);
            if (orderState == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedById = new SelectList(db.Users, "Id", "Email", orderState.CreatedById);
            return View(orderState);
        }

        // POST: OrderStates/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderStateId,Title,Description,DateCreated,CreatedById")] OrderState orderState)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderState).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedById = new SelectList(db.Users, "Id", "Email", orderState.CreatedById);
            return View(orderState);
        }

        // GET: OrderStates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderState orderState = db.OrderStates.Find(id);
            if (orderState == null)
            {
                return HttpNotFound();
            }
            return View(orderState);
        }

        // POST: OrderStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderState orderState = db.OrderStates.Find(id);
            db.OrderStates.Remove(orderState);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
