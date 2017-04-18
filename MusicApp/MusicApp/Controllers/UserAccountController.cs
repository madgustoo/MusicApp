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
            // select de la bd
            //List<string> favoritedTrackIds = select trackid from favorites where userid = session[userid]
            using (pushmusicwebEntities re = new pushmusicwebEntities())
            { 
                var fav = re.favorite.Where(a => a.user_name == Session["username"].ToString()).ToList();
                List<Track> favoritedTracks = new List<Track>();
                foreach (favorite itemfav in fav) {

                    foreach (Track itemtrack in favoritedTracks) {
                        itemtrack.id = itemfav.track_id;
                        
                    }
                }

                foreach (string id in favoritedTrackIds) {
                Track track = await spotifyService.GetTrack(id);
                favoritedTracks.Add(track);
            }
            }

            return View(favoritedTracks);
        }

    }
}