using MusicApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using MusicApp.Models;

namespace MusicApp.Controllers
{
    public class ProfileController: Controller {
        private SpotifyService spotifyService = new SpotifyService();
    
        [HttpGet]
        public async Task<ActionResult> Index(int? id)  {
            List<Album> artistAlbums = await spotifyService.GetArtistAlbums("3NH8t45zOTqzlZgBvZRjvB");
            return View(artistAlbums);
        }
        
    }
}