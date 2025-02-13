using Blip.Challenge.Presentation.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Blip.Challenge.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GitHubController : ControllerBase
    {
        private readonly IPresentationService _presentationService;
        public GitHubController(IPresentationService presentationService)
        {
            _presentationService = presentationService;
        }

        [HttpGet]
        [Route("{username}/repositories/oldest")]
        public async Task<IActionResult> GetFiveOldestRepositoriesAsync(string username)
        {
            if (String.IsNullOrWhiteSpace(username))
            {
                return BadRequest("Username is required");
            }

            return Ok(await _presentationService.GetFiveOldestRepositoriesAsync(username));
        }
    }
}
