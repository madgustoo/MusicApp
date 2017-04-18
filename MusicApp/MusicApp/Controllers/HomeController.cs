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
            string cookieArtistId = "";
            if (Request.Cookies["cookie"] != null) {
                cookieArtistId = Request.Cookies["cookie"].Value;
            } else {
                // Default artist ID: PNL
                cookieArtistId = "3NH8t45zOTqzlZgBvZRjvB";
            }

            List<Artist> relatedArtists = await spotifyService.GetRelatedArtists(cookieArtistId);
            // Between 0 and 1
            ViewBag.JumboTextId = rand.Next(0, 2);
            ViewBag.RelatedArtists = relatedArtists;

            return View();
        }
    }
}