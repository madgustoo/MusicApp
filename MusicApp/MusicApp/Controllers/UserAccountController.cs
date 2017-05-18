using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicApp.Service;
using System.Threading.Tasks;

namespace MusicApp.Controllers
{
    public class UserAccountController: Controller {
        private SpotifyService spotifyService = new SpotifyService();

        [HttpGet]
        public async Task<ActionResult> Index() {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            // select de la bd
            List<Track> favoritedTracks = new List<Track>();
            using (pushmusicwebEntities re = new pushmusicwebEntities())
            { 
                string username = Session["username"].ToString();
                List<favorite> fav = re.favorite.Where(a => a.user_name == username).ToList();
                favoritedTracks = new List<Track>();
                foreach (favorite itemfav in fav) {
                    Track track = await spotifyService.GetTrack(itemfav.track_id);
                    favoritedTracks.Add(track);
                }
            }

            return View(favoritedTracks);
        }

    }
}