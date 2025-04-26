using GitHub_Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CV_Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepoController : ControllerBase
    {
        private readonly IGithubService _githubService;
        public RepoController(IGithubService githubService)
        {
            _githubService = githubService;
        }
        // GET: api/<RepoController>
        [HttpGet]
        public async Task<ActionResult<Octokit.Repository>> GetRepo()
        {
            return Ok( await _githubService.GetUserRepoAsync());
        }

        // GET api/<RepoController>/5
        [HttpGet("Activities")]
        public async Task<ActionResult<Octokit.Activity>> GetActivities()
        {
            return Ok(await _githubService.GetUserActivitiesAsync());
        }



        [HttpGet("{username}/publicRepo")]
        public async Task<ActionResult<int>> GetUserPublicRepo(string username)
        {
            var result = await _githubService.GetUserPublicRepositopriesAsync(username);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchRepositories([FromQuery] string? repoName, [FromQuery] string? language, [FromQuery] string? user)
        {
            var results = await _githubService.SearchRepositoriesAsync(repoName, language, user);
            return Ok(results);
        }

    }
}
