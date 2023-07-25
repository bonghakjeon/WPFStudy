using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFStart
{
    public class OpenSubredditEvent
    {
        public string Subreddit { get; set; }
        public SortMode SortMode { get; set; }
    }
}
