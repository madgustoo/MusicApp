using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicApp.Models;

namespace MusicApp.Controllers
{
    public class UserViewTestController : Controller
    {
        private pushmusicwebEntities personneContexte = new pushmusicwebEntities();
        // GET: UserViewTest
        public ActionResult Personne()
        {
            List<users> personnes = personneContexte.users.ToList();
            return View(personnes);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            users personne = personneContexte.users.Single(p => p.user_id == id);

           
            //var userEditee = new userEditee
            //{
            //    user_id = personne.user_id,
            //    user_name = personne.user_name,

            //};


            return View(personne);
        }
    }
}