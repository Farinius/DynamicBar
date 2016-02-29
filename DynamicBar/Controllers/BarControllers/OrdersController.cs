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
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.OrderedBy).Include(o => o.OrderState).Include(o => o.Place).Include(o => o.Product).Include(o => o.Unit);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.OrderedById = new SelectList(db.Users, "Id", "Email");
            ViewBag.OrderStateId = new SelectList(db.OrderStates, "OrderStateId", "Title");
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "Title");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Title");
            ViewBag.UnitId = new SelectList(db.Units, "UnitId", "Title");
            return View();
        }

        // POST: Orders/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,Amount,OrderTime,UnitPrice,ProductId,UnitId,OrderedById,PlaceId,OrderStateId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderedById = new SelectList(db.Users, "Id", "Email", order.OrderedById);
            ViewBag.OrderStateId = new SelectList(db.OrderStates, "OrderStateId", "Title", order.OrderStateId);
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "Title", order.PlaceId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Title", order.ProductId);
            ViewBag.UnitId = new SelectList(db.Units, "UnitId", "Title", order.UnitId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderedById = new SelectList(db.Users, "Id", "Email", order.OrderedById);
            ViewBag.OrderStateId = new SelectList(db.OrderStates, "OrderStateId", "Title", order.OrderStateId);
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "Title", order.PlaceId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Title", order.ProductId);
            ViewBag.UnitId = new SelectList(db.Units, "UnitId", "Title", order.UnitId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,Amount,OrderTime,UnitPrice,ProductId,UnitId,OrderedById,PlaceId,OrderStateId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderedById = new SelectList(db.Users, "Id", "Email", order.OrderedById);
            ViewBag.OrderStateId = new SelectList(db.OrderStates, "OrderStateId", "Title", order.OrderStateId);
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "Title", order.PlaceId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Title", order.ProductId);
            ViewBag.UnitId = new SelectList(db.Units, "UnitId", "Title", order.UnitId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
