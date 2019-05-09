using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace ClassLibrary1
{
    public class HackerNews
    {
        public string Title { get; set; }
        public string Url { get; set; }
    }
    
    public class HackerNewsApi
    {
        public HackerNews GetStoryForId(int id)
        {
            var client = new HttpClient();            
            string url = $"https://hacker-news.firebaseio.com/v0/item/{id}.json?print=pretty";
            string json = client.GetStringAsync(url).Result;
            var result = JsonConvert.DeserializeObject<HackerNews>(json);
            return result;
        }
        public List<int> GetIds()
        {
            var client = new HttpClient();
            string url = $"https://hacker-news.firebaseio.com/v0/topstories.json?print=pretty";
            string json = client.GetStringAsync(url).Result;
            var result = JsonConvert.DeserializeObject<List<int>>(json);
            return result;
        }
        public List<HackerNews> Get20News()
        {
            List<HackerNews> hn = new List<HackerNews>();
            List<int> ids = GetIds();
            for(int i = 0; i < 20; i++)
            {                
                hn.Add(GetStoryForId(ids[i]));
            }
            return hn;

        }
    }
}
