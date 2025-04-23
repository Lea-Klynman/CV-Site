using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub_Service
{
    public class Portfolio
    {
        public List<RepositoryInfo> Repositories { get; set; } = new();
    }

    public class RepositoryInfo
    {
        public string Name { get; set; }
        public string Language { get; set; }
        public DateTime LastCommit { get; set; }
        public int Stars { get; set; }
        public int PullRequestsCount { get; set; }
        public string HtmlUrl { get; set; }
    }
}
