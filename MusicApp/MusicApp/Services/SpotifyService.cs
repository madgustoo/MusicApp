using MusicApp.Models;
using Newtonsoft.Json;
using SpotifyAPI.Web;
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

        private SpotifyWebAPI _spotify;

        public SpotifyService() {
            _spotify = new SpotifyWebAPI() {
                UseAuth = false, // This will disable Authentication
            };
        }

        // Returns searchObject that contains 'artists' list
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

        // Get an artist's albums Limit = 20
        public async Task<List<Album>> GetArtistAlbums(string artistId) {
            var output = await _spotify.GetArtistsAlbumsAsync(artistId);
            string outputString = JsonConvert.SerializeObject(output);
            AlbumRootObject albumObject = JsonConvert.DeserializeObject<AlbumRootObject>(outputString);
            return albumObject.items;
        }

        // Get an artist's top tracks
        public async Task<List<Track>> GetArtistTopTracks(string artistId) {
            var output = await _spotify.GetArtistsTopTracksAsync(artistId, "US");
            string outputString = JsonConvert.SerializeObject(output);
            TopTrackRootobject topTrackObject = JsonConvert.DeserializeObject<TopTrackRootobject>(outputString);
            return topTrackObject.tracks;
        }


    }
}