using GitHub_Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CV_Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IGithubService _githubService;
        public UsersController(IGithubService githubService)
        {
            _githubService = githubService;
        }

        // GET: api/<UsersController>
        [HttpGet("portfolio")]
        public async Task<ActionResult<IReadOnlyList<Portfolio>>> GetPortfolio()
        {
            return Ok(await _githubService.GetPortfolioAsync());
        }

        // GET api/<UsersController>/5
        [HttpGet("Followers/{userName}")]
        public async Task<ActionResult<int>> GetFollowers(string userName)
        {
            return Ok(await _githubService.GetUserFollowerAsync(userName));
        }


        [HttpGet("{username}/publicRepo")]
        public async Task<ActionResult<int>> GetUserPublicRepo(string username)
        {
            var result = await _githubService.GetUserPublicRepositopriesAsync(username);
            return Ok(result);
        }

    }
}
