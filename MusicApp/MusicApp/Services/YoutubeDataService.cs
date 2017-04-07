using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using MusicApp.Models;

namespace MusicApp.Services
{
    /// <summary>
    /// YouTube Data API (v3) service methods
    /// </summary>
    public class YoutubeDataService {


        public YoutubeDataService() {

        }

        public async Task<string> GetVideoUrl(string trackName) {

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyAGcMPSHBXoxxtrIL82Q7WTQlLP_pyb03k",
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = trackName; 
            searchListRequest.MaxResults = 5;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = await searchListRequest.ExecuteAsync();

            // track's video id
            string videoId = "";
            // the youtube url
            string youtubeUrl = "";

            foreach (var searchResult in searchListResponse.Items) {
                switch (searchResult.Id.Kind) {
                    // Only takes videos no playlists nor channels
                    case "youtube#video":
                        videoId = searchResult.Id.VideoId;
                        break;
                }
                if (videoId.Length != 0) {
                    youtubeUrl = "https://www.youtube.com/watch/" + videoId;
                    break;
                }
            }

            // Empty string is returned if no video found
            return youtubeUrl;
        }

        // Adds to each track its Youtube url
        public async void AddYoutubeUrl(List<Track> playlist) {
            foreach (var track in playlist) {
                track.youtubeUrl = await GetVideoUrl(track.name);
            }
        }
         
    }
}