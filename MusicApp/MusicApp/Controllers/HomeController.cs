using MusicApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicApp.Controllers
{
    public class HomeController: Controller {
        private SpotifyService spotifyService = new SpotifyService();

        public ActionResult Index() {
            return View("Index");
        }
    }
}