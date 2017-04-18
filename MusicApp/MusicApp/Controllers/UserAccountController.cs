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
            List<Track> favoritedTracks = new List<Track>();
            foreach (string id in favoritedTrackIds) {
                Track track = await spotifyService.GetTrack(id);
                favoritedTracks.Add(track);
            }

            return View(favoritedTracks);
        }

    }
}