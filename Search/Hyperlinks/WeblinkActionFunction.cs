using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using Search.Framework;

namespace Search.Hyperlinks
{
    public class WeblinkActionFunction : ActionFunction<WeblinkState, WeblinkAction>
    {
        public override List<WeblinkAction> Actions(WeblinkState state)
        {
            var links = this.FindLinks(state.Url);
            var result = links.Select(p => new WeblinkAction(p)).ToList();
            return result;
        }

        private List<Uri> FindLinks(Uri url)
        {
            var result = new List<Uri>();

            var client = new WebClient();
            try
            {
                var downloadString = client.DownloadString(url);
                var urls = ExtractURLs(downloadString, url);
                return urls;
            }
            catch (Exception)
            {
            }

            return result;
        }

        public List<Uri> ExtractURLs(string str, Uri parentUrl)
        {
            string RegexPattern = @"<a.*?href=[""'](?<url>.*?)[""'].*?>(?<name>.*?)</a>";

            System.Text.RegularExpressions.MatchCollection matches = System.Text.RegularExpressions.Regex.Matches(
                str, RegexPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            var result = new List<Uri>();

            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                var url = match.Groups["url"].Value;
                try
                {
                    var uri = new Uri(url);
                    if (url.Contains("http://") && uri.Host != parentUrl.Host)
                    {
                        result.Add(uri);
                    }
                }
                catch (UriFormatException)
                {
                }
            }

            return result;
        }
    }
}
