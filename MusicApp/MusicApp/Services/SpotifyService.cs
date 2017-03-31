using MusicApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicApp.Service
{
    /// <summary>
    /// Requests from the Spotify API 
    /// Wrapper / API Client used: https://spotifywebapi.codeplex.com/
    /// </summary>
    public class SpotifyService {

        // MusicApp.Models.Item == Artist list
        public async Task<Artists> SearchArtist(string name, int offset) {
            name += "*";
            var output = (Object) null;
            if (offset > 0) {
                // At the end: limit and offset
                output = await SpotifyWebAPI.Artist.Search(name, "", "", "", "", 20, offset);
            } else {
                output = await SpotifyWebAPI.Artist.Search(name);
            }
            string outputString = JsonConvert.SerializeObject(output);
            // Deserialize the JSON string into a Artists Object / Item[an Artist is an item] 
            Artists searchResult = JsonConvert.DeserializeObject<Artists>(outputString);
            return searchResult;
        }

        // Limit = 20 With no tracks
        public async Task<List<Album>> GetArtistAlbums(string artistId) {
            var output = await SpotifyWebAPI.Album.GetArtistAlbums(artistId);
            string outputString = JsonConvert.SerializeObject(output);
            AlbumRootObject searchResult = JsonConvert.DeserializeObject<AlbumRootObject>(outputString);
            return searchResult.items;
        }

        /*
        // To play tracks put them in a table
        public async Task<List<Track>> GetArtistTopTracks(string artistId) {
            // var output = await SpotifyWebAPI.Artist.GetTopTracks(artistId);
            return null;
        }
        */


    }
}