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
    /// Api Client provided by google
    /// </summary>
    public class YoutubeDataService {

        // The artist's channel url
        private string channelUrl;

        public YoutubeDataService() {
            channelUrl = "";
        }

        /// <summary>
        /// Fetches from YouTube for each track its video url and also stores the artist's channel (if any)
        /// as a class member variable to 
        /// </summary>
        /// <param name="artistName">The artist's name</param>
        /// <param name="trackName">The track's name</param>
        /// <returns></returns>
        public async Task<string> GetYouTubeURLS(string trackName, string artistName) {

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyAGcMPSHBXoxxtrIL82Q7WTQlLP_pyb03k",
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            if (trackName.Length != 0) {
                // Search for the track
                searchListRequest.Q = artistName + " " + trackName;
            } else {
                // Search for the channel
                searchListRequest.Q = artistName;
            }
            searchListRequest.MaxResults = 5;
            searchListRequest.Order = SearchResource.ListRequest.OrderEnum.Relevance;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = await searchListRequest.ExecuteAsync();

            // track's video id
            string videoId = "";
            // its youtube url
            string youtubeUrl = "";
            // artist's channel id
            string channelId = "";

            foreach (var searchResult in searchListResponse.Items) {
                switch (searchResult.Id.Kind) {
                    // Only takes videos and channels
                    case "youtube#video":
                        videoId = searchResult.Id.VideoId;
                        break;
                    case "youtube#channel":
                        channelId = searchResult.Id.ChannelId;
                        break;
                }

                if (videoId.Length != 0 && youtubeUrl.Length == 0) {
                    youtubeUrl = "https://www.youtube.com/watch/" + videoId;
                }

                if (channelId.Length != 0 && channelUrl.Length == 0) {
                    this.channelUrl = "https://www.youtube.com/channel/" + channelId;
                }       
            }

            // Empty string is returned if no video/channel found
            // track youtube url
            return youtubeUrl;
        }

        // Get artist's youtube channel page [Vevo, etc.]
        public async Task<string> GetYoutubeChannel(string artistName) {
            await GetYouTubeURLS("", artistName);
            return channelUrl;
        }

        // Adds to one track its Youtube url
        public async Task<string> GetYoutubeUrl(string trackname, string artistName) {
            return await GetYouTubeURLS(trackname, artistName);
        }

        // Adds to each track its Youtube url
        public async Task AddYoutubeUrl(List<Track> playlist, string artistName) {
            foreach (var track in playlist) {
                track.youtubeUrl = await GetYouTubeURLS(artistName, track.name);
            }
        }
         
    }
}