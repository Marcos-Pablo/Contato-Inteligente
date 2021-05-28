using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("/repositories")]
    public class GitHubRepositoriesController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetFiveOlderCSharpRepositories()
        {
            try
            {
                var productInformation = new ProductHeaderValue("Marcos-Pablo");
                var credentials = new Credentials("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");
                var client = new GitHubClient(productInformation) { Credentials = credentials };

                var takeRepositories = await client.Repository.GetAllForUser("takenet");
                var fiveOlderCSharpRepositories = takeRepositories
                                                    .Where(repo => repo.Language == "C#")
                                                    .OrderBy(repo => repo.CreatedAt)
                                                    .Take(5);

                return Ok(fiveOlderCSharpRepositories);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno de servidor");
            }
        }
    }
}
