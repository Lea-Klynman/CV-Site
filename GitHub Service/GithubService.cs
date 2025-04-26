using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Octokit;

namespace GitHub_Service
{
    public class GithubService : IGithubService
    {
        public readonly GitHubClient _client;
        private readonly GitHubIntegrationOptions _options;
        public GithubService(IOptions<GitHubIntegrationOptions> options)
        {
            _options = options.Value;
            _client = new GitHubClient(new ProductHeaderValue("CVSiteApp")) {
                Credentials = new Credentials(_options.Token)
            };

        }
       
        public async Task<int> GetUserFollowerAsync(string userName)
        {
            var user = await _client.User.Get(userName);
            Console.WriteLine(user.Followers + "followers!");
            
            return user.Followers;
        }


        public async Task<int> GetUserPublicRepositopriesAsync(string userName)
        {
            var user = await _client.User.Get(userName);
            return user.PublicRepos;
        }


        public async Task<List<Repository>> SearchRepositoriesInCSharpAsync()
        {
            var request = new SearchRepositoriesRequest("repo-name") { Language = Language.CSharp  };
            var result = await _client.Search.SearchRepo(request);
            return result.Items.ToList();
        }


        public async Task<IReadOnlyList<Repository>> SearchRepositoriesAsync(string? repoName, string? language, string? userName)
        {
            var request = new SearchRepositoriesRequest(repoName ?? "")
            {
                Language = Enum.TryParse(language, true, out Language lang) ? lang : null,
                User = userName,
                
                
            };
            var result = await _client.Search.SearchRepo(request);
            
            return result.Items;
        }

        public async Task<IReadOnlyList<Repository>> GetUserRepoAsync()
        {
            return await _client.Repository.GetAllForCurrent();
        }


        public async Task<IReadOnlyList<Activity>> GetUserActivitiesAsync()
        {
            return await _client.Activity.Events.GetAllUserPerformed(_options.UserName);
        }


        public async Task<Portfolio> GetPortfolioAsync()
        {
            var portfolio = new Portfolio();

            var repositories = (await _client.Repository.GetAllForCurrent()).ToList();

            foreach (var repo in repositories)
            {
                var pulls = await _client.PullRequest.GetAllForRepository(repo.Owner.Login, repo.Name);

                var repoInfo = new RepositoryInfo
                {
                    Name = repo.Name,
                    Language = repo.Language,
                    LastCommit = repo.PushedAt?.DateTime ?? DateTime.MinValue,
                    Stars = repo.StargazersCount,
                    PullRequestsCount = pulls.Count,
                    HtmlUrl = repo.HtmlUrl
                };

                portfolio.Repositories.Add(repoInfo);
            }

            return portfolio;
        }

    }
}
