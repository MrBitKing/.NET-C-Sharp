using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using Lab6.Models;


namespace Lab6.Controllers
{
    public class Home : Controller
    {
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            // to get tweets from the cloud
            var client = new HttpClient();
            var result = await client.GetAsync("http://cst8359.hopto.org/lab6server/api/twitter/getlast100tweets");

            // the get the string content from the clients call to the server
            var content = await result.Content.ReadAsStringAsync();

            // convert the content into a list of tweet objects
            var tweets = JsonConvert.DeserializeObject<List<Tweet>>(content);

            // pass them to the view
            return View(tweets.OrderByDescending(o => o.TweetId));
        }

        [HttpPost]
        public async Task<IActionResult> PostTweet()
        {
            var tweet = new Tweet();
            tweet.Username = HttpContext.Request.Form["username"];
            tweet.Content = HttpContext.Request.Form["content"];

            var json = JsonConvert.SerializeObject(tweet);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var client = new HttpClient();
            await client.PostAsync("http://cst8359.hopto.org/lab6server/api/twitter/add", httpContent);

            return RedirectToAction("Index");
        }
    }
}