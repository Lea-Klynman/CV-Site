using GitHub_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV_Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controller : ControllerBase
    {
        private readonly GithubService _service;

        public Controller(GithubService service)
        {
            _service = service;
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<Portfolio>> GetPortfolio(string username)
        {
            var portfolio = await _service.GetPortfolioAsync();
            return Ok(portfolio);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchRepositories([FromQuery] string? repoName, [FromQuery] string? language, [FromQuery] string? user)
        {
            var results = await _service.SearchRepositoriesAsync(repoName, language, user);
            return Ok(results);
        }
    }
}
