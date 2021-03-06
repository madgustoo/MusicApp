﻿using MusicApp.Service;
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
       // private GeniusService geniusService = new GeniusService();


        [HttpGet]
        public async Task<ActionResult> Index(string artistId) {
            Artist artist = await spotifyService.GetArtist(artistId);
            List<Track> topTracks = null;
            if (artist.id != null) {
                // Set cookie for homepage's related artists section
                Response.Cookies["cookie"].Value = artist.id;

                topTracks = await spotifyService.GetArtistTopTracks(artistId);
                List<Album> albums = await spotifyService.GetArtistAlbums(artistId);
                artist.youtubeProfile = await youtubeService.GetYoutubeChannel(artist.name);
                wikipediaService.GetArticleIntro(artist);

                // geniusService.SetTrackLyrics("PNL");

                ViewBag.Albums = albums;
                ViewBag.ArtistName = artist.name;
                ViewBag.ArtistImage = artist.images[0].url;
                ViewBag.WikiActicle = artist.wikipediaArticle;
                ViewBag.WikipediaURL = artist.wikipediaProfile;
                ViewBag.YoutubeChannelURL = artist.youtubeProfile;
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
                await youtubeService.AddYoutubeUrl(albumTracks, album.artists[0].name);

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

        // Redirects to the track's youtube video
        [HttpGet]
        public async Task<string> YoutubeRedirect(string trackName, string artistName) {
            return await youtubeService.GetYoutubeUrl(trackName, artistName);
        }

        
        [HttpPost]
        public ActionResult AddToFavorites(string trackId, string artistName, favorite fav) {
            if (ModelState.IsValid) {
                using (pushmusicwebEntities re = new pushmusicwebEntities()) {
                    string username = Session["username"].ToString();
                    var reFav = re.favorite.Where(a => a.user_name == username && a.track_id == trackId).ToList();
                    if (reFav.Count > 0) {
                        //quand le track est deja dans favorite on le delete de la table
                        var row = re.favorite.Where(d => d.track_id == trackId && d.user_name == username).First();
                        re.favorite.Remove(row);
                        re.SaveChanges();
                        return Json(new { success = false, responseText = artistName + "'s track removed successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else {
                        //sinon on l'ajoute dans la table favorite
                        favorite fa = new favorite();
                        fa.user_name = Session["username"].ToString();
                        fa.track_id = trackId;
                        fa.artist_name = artistName;
                        re.favorite.Add(fa);
                        re.SaveChanges();
                        return Json(new { success = true, responseText = artistName + "'s track added successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return Json(new { success = false, responseText = "Something went wrong in our end. Please try again at a later time" }, JsonRequestBehavior.AllowGet);
        }

    }
}