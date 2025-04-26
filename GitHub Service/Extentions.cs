using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace GitHub_Service
{
    public static class Extentions
    {
        public static void AddGitHubintegration(this IServiceCollection services, Action<GitHubIntegrationOptions> configuration)
        {
            services.Configure(configuration);
            services.AddScoped<IGithubService, GithubService>();
        }
    }
}
