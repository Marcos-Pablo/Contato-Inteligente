using Api.Services;
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
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetFiveOlderCSharpRepositories(
            [FromServices] CarroselService carroselService)
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

                var carrosel = carroselService.CreateCarrosel(fiveOlderCSharpRepositories);

                return Ok(carrosel);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno de servidor");
            }
        }
    }
}
