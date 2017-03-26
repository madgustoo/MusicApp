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

        [HttpGet]
        public async Task<ActionResult> Index() {
            var searchList = await spotifyService.SearchArtist("pnl");
            return View(searchList);
        }

    }
}