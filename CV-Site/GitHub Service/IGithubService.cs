using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace GitHub_Service
{
    public interface IGithubService
    {
        public Task<int> GetUserFollowerAsync(string userName);
        public Task<List<Repository>> SearchRepositoriesInCSharp();
    }
}
