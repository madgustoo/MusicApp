using MusicApp.Models;
using Newtonsoft.Json;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicApp.Service
{
    /// <summary>
    /// Requests from the Spotify API 
    /// Wrapper / API Client used: https://github.com/JohnnyCrazy/SpotifyAPI-NET
    /// </summary>
    public class SpotifyService {
        // TODO: Implement Singleton pattern for all Services Class
        private SpotifyWebAPI _spotify;

        public SpotifyService() {
            _spotify = new SpotifyWebAPI() {
                UseAuth = false, // This will disable Authentication
            };
        }

        // Returns searchObject that contains 'artists' list [returns the Root Object]
        public async Task<SearchRootObject> SearchArtist(string name, int offset) {
            name += "*";
            var output = (Object) null;
            if (offset > 0) {
                // At the end: limit and offset
                output =await _spotify.SearchItemsAsync(name, SpotifyAPI.Web.Enums.SearchType.Artist, 20, offset, "");
            } else {
                // (string q, SearchType type, int limit = 20, int offset = 0, string market = "");
                output = await _spotify.SearchItemsAsync(name, SpotifyAPI.Web.Enums.SearchType.Artist, 20, 0, "");
            }
            string outputString = JsonConvert.SerializeObject(output);
            // Deserialize the JSON string into a Artists Object / Item[an Artist is an item] 
            SearchRootObject searchObject = JsonConvert.DeserializeObject<SearchRootObject>(outputString);
            return searchObject;
        }

        // Get an artist's albums
        public async Task<List<Album>> GetArtistAlbums(string artistId) {
            var output = await _spotify.GetArtistsAlbumsAsync(artistId, AlbumType.Album, 20, 0, "US");
            string outputString = JsonConvert.SerializeObject(output);
            AlbumRootObject albumObject = JsonConvert.DeserializeObject<AlbumRootObject>(outputString);
            return albumObject.items;
        }

        // Get one album of an artist
        public async Task<Album> GetAlbum(string albumId) {
            var output = await _spotify.GetAlbumAsync(albumId, "US");
            string outputString = JsonConvert.SerializeObject(output);
            Album album = JsonConvert.DeserializeObject<Album>(outputString);
            return album;
        }

        // Get an artist's top tracks
        public async Task<List<Track>> GetArtistTopTracks(string artistId) {
            var output = await _spotify.GetArtistsTopTracksAsync(artistId, "US");
            string outputString = JsonConvert.SerializeObject(output);
            TopTrackRootobject topTrackObject = JsonConvert.DeserializeObject<TopTrackRootobject>(outputString);
            return topTrackObject.tracks;
        }

        // Get all of an album's tracks [returns the RootObject]
        public async Task<AlbumTracksRootobject> GetAlbumTracks(string albumId) {
            // string id, int limit = 20, int offset = 0, string market = ""
            var output = await _spotify.GetAlbumTracksAsync(albumId, 20, 0, "US");
            string outputString = JsonConvert.SerializeObject(output);
            AlbumTracksRootobject albumTracksObject = JsonConvert.DeserializeObject<AlbumTracksRootobject>(outputString);
            return albumTracksObject;
        }

        // Get an artist
        public async Task<Artist> GetArtist(string artistId) {
            var output = await _spotify.GetArtistAsync(artistId);
            string outputString = JsonConvert.SerializeObject(output);
            Artist artist = JsonConvert.DeserializeObject<Artist>(outputString);
            return artist;
        }

        // Get an artist's related artists
        public async Task<List<Artist>> GetRelatedArtists(string artistId) {
            var output = await _spotify.GetRelatedArtistsAsync(artistId);
            string outputString = JsonConvert.SerializeObject(output);
            RelatedArtistRootObject relatedArtistsObject = JsonConvert.DeserializeObject<RelatedArtistRootObject>(outputString);
            return relatedArtistsObject.artists;
        }

        // Get a single track 
        public async Task<Track> GetTrack(string trackId)  {
            var output = await _spotify.GetTrackAsync(trackId, "US");
            string outputString = JsonConvert.SerializeObject(output);
            Track track = JsonConvert.DeserializeObject<Track>(outputString);
            return track;
        }
    }
}