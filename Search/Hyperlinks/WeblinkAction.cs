using System;

namespace Search.Hyperlinks
{
    public class WeblinkAction
    {
        public Uri Url { get; set; }

        public WeblinkAction(Uri url)
        {
            Url = url;
        }

        public override string ToString()
        {
            return Url.ToString();
        }
    }
}
