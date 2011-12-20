using System;

namespace Search.Hyperlinks
{
    public class WeblinkState
    {
        public WeblinkState(Uri url)
        {
            Url = url;
        }

        public Uri Url { get; private set; }

        public override string ToString()
        {
            return Url.ToString();
        }

        public bool Equals(WeblinkState other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(other.Url.Host, this.Url.Host);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != typeof(WeblinkState))
            {
                return false;
            }

            return Equals((WeblinkState)obj);
        }

        public override int GetHashCode()
        {
            return (this.Url.Host != null ? this.Url.GetHashCode() : 0);
        }
    }
}
