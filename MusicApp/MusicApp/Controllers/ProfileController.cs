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
        public async Task<ActionResult> Index(string id)  {
            if (id != null) {
                List<Track> topTracks = await spotifyService.GetArtistTopTracks(id);
                List<Album> albums = await spotifyService.GetArtistAlbums(id);
                await youtubeService.AddYoutubeUrl(topTracks);
                ViewBag.Albums = albums;
                ViewBag.ArtistImage = albums[0].images[0].url;
                ViewBag.Artist = topTracks[0].artists[0].name;
                ViewBag.SpotifyURL = "https://play.spotify.com/artist/" + topTracks[0].artists[0].id;
                return View(topTracks);
            } else {
                return HttpNotFound("Artist Not Found");
            }
        }

        [HttpGet]
        public async Task<ActionResult> Album(string id) {
            List<AlbumTrack> albumTracks = null;
            AlbumTracksRootobject albumTracksObject = await spotifyService.GetAlbumTracks(id);
            if (albumTracksObject.items != null) {
                albumTracks = albumTracksObject.items;
            }
            return View(albumTracks);
        }
        
    }
}