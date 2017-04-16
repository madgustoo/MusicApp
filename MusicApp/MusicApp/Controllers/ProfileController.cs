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
        private WikipediaService wikipediaService = new WikipediaService();

        [HttpGet]
        public async Task<ActionResult> Index(string artistId) {
            Artist artist = await spotifyService.GetArtist(artistId);
            List<Track> topTracks = null;
            if (artist.id != null) { 
                topTracks = await spotifyService.GetArtistTopTracks(artistId);
                List<Album> albums = await spotifyService.GetArtistAlbums(artistId);
                await youtubeService.AddYoutubeUrl(topTracks);
                wikipediaService.GetArticleIntro(artist);

                ViewBag.Albums = albums;
                ViewBag.ArtistName = artist.name;
                ViewBag.ArtistImage = artist.images[0].url;
                ViewBag.WikiActicle = artist.wikipediaArticle;
                ViewBag.WikipediaURL = artist.wikipediaProfile;
                ViewBag.SpotifyURL = "https://play.spotify.com/artist/" + artist.id;
            }
            return View(topTracks);
        }

        [HttpGet]
        public async Task<ActionResult> Album(string albumId) {
            Album album = await spotifyService.GetAlbum(albumId);
            List<Track> albumTracks = null;
            if (album.id != null) {
                AlbumTracksRootobject albumTracksObject = await spotifyService.GetAlbumTracks(albumId);
                albumTracks = albumTracksObject.items;
                await youtubeService.AddYoutubeUrl(albumTracks);

                ViewBag.AlbumName = album.name;
                ViewBag.AlbumImage = album.images[0].url;
                ViewBag.ReleaseDate = album.release_date;
                ViewBag.Label = album.label;
                ViewBag.SpotifyURL = album.external_urls.spotify;
                ViewBag.Copyright = album.copyrights[0].text;
                ViewBag.Artists = album.artists;
            }
            return View(albumTracks);
        }
        
    }
}