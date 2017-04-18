using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicApp.Models.viewModel;
using MusicApp.Models;

namespace MusicApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(userRegisterView r)
        {
            if (ModelState.IsValid)
            {
                using (pushmusicwebEntities re = new pushmusicwebEntities())
                {
                    var resemail = re.users.Where(a => a.user_name == r.user_name).ToList();

                    if (resemail.Count > 0)
                    {
                        Response.Write("<script> alert('user already existe, use different email')</script>");
                    }
                    else { 
                        users ru = new users();
                        ru.user_name = r.user_name;
                        ru.mdp_user = r.mdp_user;
                        ru.Email = r.Email;
                        re.users.Add(ru);
                        re.SaveChanges();
                        Session["username"] = r.user_name;
                        return RedirectToAction("index", "Home");
                    }
                }
            }
            return View("register");
            


        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(userLoginView lg)
        {
            if (ModelState.IsValid)
            {
                using (pushmusicwebEntities ue = new pushmusicwebEntities())
                {
                    var log = ue.users.Where(a => a.user_name.Equals(lg.user_name) && a.mdp_user.Equals(lg.mdp_user)).FirstOrDefault();

                    if (log != null)
                    {
                        Session["username"] = log.user_name;
                        return RedirectToAction("index", "Home");
                    }
                    else
                    {
                        Response.Write("<script> alert('Wrong username or password ')</script>");//append
                    }
                }
            }
                return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        }
}