using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _config;
        public GitHubRepositoriesController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetFiveOlderCSharpRepositories()
        {
            try
            {
                string token = _config["AppSettings:token"];
                string login = _config["AppSettings:login"];
                var productInformation = new ProductHeaderValue(login);
                var credentials = new Credentials(token);
                var client = new GitHubClient(productInformation) { Credentials = credentials };

                var takeRepositories = await client.Repository.GetAllForUser("takenet");
                var fiveOlderCSharpRepositories = takeRepositories
                                                    .Where(repo => repo.Language == "C#")
                                                    .OrderBy(repo => repo.CreatedAt)
                                                    .Take(5);

                return Ok(fiveOlderCSharpRepositories);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno de servidor");
            }
        }
    }
}
