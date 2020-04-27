using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeFinder
{
    public class Voice_actors
    {
        public int mal_id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string image_url { get; set; }
        public string language { get; set; }

    }
    public class Characters
    {
        public int mal_id { get; set; }
        public string url { get; set; }
        public string image_url { get; set; }
        public string name { get; set; }
        public string role { get; set; }
        public IList<Voice_actors> voice_actors { get; set; }

    }
    public class Staff
    {
        public int mal_id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string image_url { get; set; }
        public IList<string> positions { get; set; }

    }
    public class Applicationss
    {
        public string request_hash { get; set; }
        public bool request_cached { get; set; }
        public int request_cache_expiry { get; set; }
        public IList<Characters> characters { get; set; }
        public IList<Staff> staff { get; set; }

    }
}
