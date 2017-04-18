using MusicApp.Models;
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
        public async Task<ActionResult> Index() {
            //var searchList = await spotifyService.SearchArtist("pnl", 0);
            // between 0 and 1
            ViewBag.JumboTextId = rand.Next(0, 2);
            // Default = PNL Id
            List<Artist> relatedArtists = await spotifyService.GetRelatedArtists("3NH8t45zOTqzlZgBvZRjvB");
            ViewBag.RelatedArtists = relatedArtists;
            return View();
        }
    }
}