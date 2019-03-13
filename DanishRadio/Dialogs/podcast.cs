using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace DanishRadio.Dialogs
{
    public class podcast
    {
        static HttpClient client = new HttpClient();
        public async Task<podItem> getmediaURL(string url)
        {
            var response = await client.GetAsync(url);

            var result = await response.Content.ReadAsStringAsync();
            var feed = XElement.Parse(result);
            IEnumerable<XElement> items =
                from el in feed.Element("channel").Elements("item")
                let pubDate = (DateTime)el.Element("pubDate")
                orderby pubDate
                select el;
            podItem output = new podItem();

            output.url = items.Last().Element("enclosure").Attribute("url").Value;
            output.title = items.Last().Element("title").Value;
            output.pubDate = DateTime.Parse(items.Last().Element("pubDate").Value);
            return output;
        }
        public async Task<List<podItem>> getmediaURLs(string url)
        {
            var response = await client.GetAsync(url);

            var result = await response.Content.ReadAsStringAsync();
            var feed = XElement.Parse(result);
            IEnumerable<XElement> items =
                from el in feed.Element("channel").Elements("item")
                let pubDate = (DateTime)el.Element("pubDate")
                orderby pubDate 
                select el;
            var output = new List<podItem>();

            foreach (var item in items)
            {
                output.Add(new podItem { title=item.Element("title").Value, pubDate = DateTime.Parse(item.Element("pubDate").Value), url=item.Element("enclosure").Attribute("url").Value });
            }
            return output;
        }

    }
    public class podItem
    {
        public string title;
        public string url;
        public DateTime pubDate;


    }
}