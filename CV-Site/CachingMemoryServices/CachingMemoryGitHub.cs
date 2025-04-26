using GitHub_Service;
using Microsoft.Extensions.Caching.Memory;
using Octokit;

namespace CV_Site.CachingMemoryServices
{
    public class CachingMemoryGitHub : IGithubService
    {
        private readonly IGithubService _githubService;
        private readonly IMemoryCache _memoryCache;
        private const string UserPortfolioKey = "UserPortfolioKey";
        public CachingMemoryGitHub(IGithubService githubService,IMemoryCache memoryCache)
        {
            _githubService = githubService;
            _memoryCache = memoryCache;
        }
        public async Task<Portfolio> GetPortfolioAsync()
        {
            if(_memoryCache.TryGetValue(UserPortfolioKey,out Portfolio portfolio))
                return portfolio;
           
            portfolio = await _githubService.GetPortfolioAsync();
            var cacheOptions = new MemoryCacheEntryOptions()
               .SetAbsoluteExpiration(TimeSpan.FromSeconds(40))
               .SetSlidingExpiration(TimeSpan.FromSeconds(10));
            _memoryCache.Set(UserPortfolioKey, portfolio, cacheOptions);
            return portfolio;
        }

        public async Task<IReadOnlyList<Activity>> GetUserActivitiesAsync()
        {
            return await _githubService.GetUserActivitiesAsync();
        }

        public async Task<int> GetUserFollowerAsync(string userName)
        {
            return await _githubService.GetUserFollowerAsync(userName);
        }

        public async Task<int> GetUserPublicRepositopriesAsync(string userName)
        {
            return await _githubService.GetUserPublicRepositopriesAsync(userName);
        }

        public async Task<IReadOnlyList<Repository>> GetUserRepoAsync()
        {
            return await _githubService.GetUserRepoAsync();
        }

        public async Task<IReadOnlyList<Repository>> SearchRepositoriesAsync(string? repoName, string? language, string? userName)
        {
           return await _githubService.SearchRepositoriesAsync(repoName, language, userName);
        }

        public async Task<List<Repository>> SearchRepositoriesInCSharpAsync()
        {
            return await _githubService.SearchRepositoriesInCSharpAsync();
        }
    }
}
