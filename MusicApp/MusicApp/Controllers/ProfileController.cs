using MusicApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using MusicApp.Models;
using MusicApp.Services;

namespace MusicApp.Controllers
{
    public class ProfileController: Controller {
        private SpotifyService spotifyService = new SpotifyService();
        private YoutubeDataService youtubeService = new YoutubeDataService();
    
        [HttpGet]
        public async Task<ActionResult> Index(int? id)  {
            List<Track> topTracks = await spotifyService.GetArtistTopTracks("3NH8t45zOTqzlZgBvZRjvB");
            List<Album> albums = await spotifyService.GetArtistAlbums("3NH8t45zOTqzlZgBvZRjvB");
            await youtubeService.AddYoutubeUrl(topTracks);
            ViewBag.Albums = albums;
            ViewBag.Artist = topTracks[0].artists[0].name;
            return View(topTracks);
        }
        
    }
}