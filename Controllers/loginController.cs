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
    public class loginController : Controller
    {
        private blog_wed_Entities db = new blog_wed_Entities();

        // GET: login
        public ActionResult Index()
        {
            return View();
        }
       
        // https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "name,password")] account account)
        {
            if (ModelState.IsValid)
            {

                account usr = db.accounts.Where(p => p.name.Equals(account.name)).FirstOrDefault();
                if (usr != null && usr.password.Equals(account.password))
                {
                    Session["User"]=usr;
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    } 
      
}
