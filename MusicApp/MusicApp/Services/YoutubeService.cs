using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicApp.Services
{
    /// <summary>
    /// YouTube Data API (v3) service methods
    /// </summary>
    public class YoutubeService {

        public YoutubeService() {

        }

        public async void GetVideoUrl(string trackName) {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "REPLACE_ME",
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = trackName; 
            searchListRequest.MaxResults = 5;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = await searchListRequest.ExecuteAsync();

            // track's video id
            string videoId = ""; 

            foreach (var searchResult in searchListResponse.Items) {
                switch (searchResult.Id.Kind) {
                    // Only takes videos no playlists nor channels
                    case "youtube#video":
                        videoId = searchResult.Id.VideoId;
                        break;
                }
            }
        } // End search

    }
}