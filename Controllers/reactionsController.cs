using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASM.Model;

namespace ASM.Controllers
{
    public class reactionsController : Controller
    {
        private blog_wed_Entities db = new blog_wed_Entities();

        // GET: reactions
        public ActionResult Index()
        {
            var reactions = db.reactions.Include(r => r.account).Include(r => r.idea);
            return View(reactions.ToList());
        }

        // GET: reactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reaction reaction = db.reactions.Find(id);
            if (reaction == null)
            {
                return HttpNotFound();
            }
            return View(reaction);
        }

        // GET: reactions/Create
        public ActionResult Create()
        {
            ViewBag.id_account = new SelectList(db.accounts, "id_account", "name");
            ViewBag.id_idea = new SelectList(db.ideas, "id_ideas", "Content");
            return View();
        }

        // POST: reactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "reaction_id,id_idea,id_account")] reaction reaction)
        {
            if (ModelState.IsValid)
            {
                db.reactions.Add(reaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_account = new SelectList(db.accounts, "id_account", "name", reaction.id_account);
            ViewBag.id_idea = new SelectList(db.ideas, "id_ideas", "Content", reaction.id_idea);
            return View(reaction);
        }

        // GET: reactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reaction reaction = db.reactions.Find(id);
            if (reaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_account = new SelectList(db.accounts, "id_account", "name", reaction.id_account);
            ViewBag.id_idea = new SelectList(db.ideas, "id_ideas", "Content", reaction.id_idea);
            return View(reaction);
        }

        // POST: reactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "reaction_id,id_idea,id_account")] reaction reaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_account = new SelectList(db.accounts, "id_account", "name", reaction.id_account);
            ViewBag.id_idea = new SelectList(db.ideas, "id_ideas", "Content", reaction.id_idea);
            return View(reaction);
        }

        // GET: reactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reaction reaction = db.reactions.Find(id);
            if (reaction == null)
            {
                return HttpNotFound();
            }
            return View(reaction);
        }

        // POST: reactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reaction reaction = db.reactions.Find(id);
            db.reactions.Remove(reaction);
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
