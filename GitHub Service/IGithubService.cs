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
        public  Task<int> GetUserFollowerAsync(string userName);
        

        public  Task<int> GetUserPublicRepositopriesAsync(string userName);
       


        public Task<List<Repository>> SearchRepositoriesInCSharpAsync();
       


        public Task<IReadOnlyList<Repository>> SearchRepositoriesAsync(string? repoName, string? language, string? userName);
        
        public  Task<IReadOnlyList<Repository>> GetUserRepoAsync();
        


        public Task<IReadOnlyList<Activity>> GetUserActivitiesAsync();
        


        public Task<Portfolio> GetPortfolioAsync();
        
    }
}
