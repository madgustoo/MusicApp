using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using MusicApp.Models;
using MusicApp.Service;

namespace MusicApp.Controllers
{
    public class SearchController: Controller {
        private SpotifyService spotifyService = new SpotifyService();

        // For manual search
        [HttpGet]
        public async Task<ActionResult> Index(string searchTerm) {
            SearchRootObject searchResult = null;
            string param = this.Request.QueryString["offset"];
            int offset = 0;
            if (param != null) {
                offset = Int32.Parse(param);
                searchResult = await spotifyService.SearchArtist(searchTerm, offset);
            } else {
                searchResult = await spotifyService.SearchArtist(searchTerm, 0);
            }

            // Page total
            // First of page always adds up to 20 more than the last one
            ViewBag.FirstOfPage = 1 + offset;
            ViewBag.Total = searchResult.artists.total;
            ViewBag.Next = searchResult.artists.next;
            ViewBag.Previous = searchResult.artists.previous;
            ViewBag.Term = searchTerm;
            // Total of this page
            int totalCount = 0;
            foreach (var result in searchResult.artists.items) {
                totalCount++;
            }

            ViewBag.PageCount = totalCount + offset;
            ViewBag.Offset = offset;
       
            return View(searchResult.artists.items);
        }
    }
}