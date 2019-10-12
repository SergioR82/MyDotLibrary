using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecetasMockup;
using RecetasMockup.Models;

namespace RecetasMockup.Controllers
{
    public class MyRecipeTransactionsController : Controller
    {
        private RecetasMockupContext db = new RecetasMockupContext();

        // GET: RecipeTransactions
        public ActionResult Index()
        {
            return View(db.Transactions.ToList());
        }

        // GET: RecipeTransactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeTransaction recipeTransaction = db.Transactions.Find(id);
            if (recipeTransaction == null)
            {
                return HttpNotFound();
            }
            return View(recipeTransaction);
        }

        // GET: RecipeTransactions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecipeTransactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RecipeId,DateAdded,Machine,UserAdded")] RecipeTransaction recipeTransaction)
        {
            if (ModelState.IsValid)
            {
                db.Transactions.Add(recipeTransaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recipeTransaction);
        }

        // GET: RecipeTransactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeTransaction recipeTransaction = db.Transactions.Find(id);
            if (recipeTransaction == null)
            {
                return HttpNotFound();
            }
            return View(recipeTransaction);
        }

        // POST: RecipeTransactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RecipeId,DateAdded,Machine,UserAdded")] RecipeTransaction recipeTransaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipeTransaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipeTransaction);
        }

        // GET: RecipeTransactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeTransaction recipeTransaction = db.Transactions.Find(id);
            if (recipeTransaction == null)
            {
                return HttpNotFound();
            }
            return View(recipeTransaction);
        }

        // POST: RecipeTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecipeTransaction recipeTransaction = db.Transactions.Find(id);
            db.Transactions.Remove(recipeTransaction);
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
