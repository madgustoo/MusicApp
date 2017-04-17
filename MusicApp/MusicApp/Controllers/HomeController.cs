using MusicApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MusicApp.Controllers
{
    public class HomeController: Controller {
        private SpotifyService spotifyService = new SpotifyService();
        private Random rand = new Random();

        [HttpGet]
        public ActionResult Index() {
            //var searchList = await spotifyService.SearchArtist("pnl", 0);
            // between 0 and 1
            ViewBag.JumboTextId = rand.Next(0, 2);
            return View();
        }
    }
}