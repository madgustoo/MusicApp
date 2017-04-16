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
                    users ru = new users();
                    ru.user_name = r.user_name;
                    ru.mdp_user = r.mdp_user;
                    ru.Email = r.Email;
                    re.users.Add(ru);
                    re.SaveChanges();
                    Response.Write("<script> alert('data submitted successfully')</script>");
                }
            }
            return View();
        }
    }
}