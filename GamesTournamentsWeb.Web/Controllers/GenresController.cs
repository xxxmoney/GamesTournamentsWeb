using GamesTournamentsWeb.Infrastructure.Operations.Games;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamesTournamentsWeb.Web.Controllers;

public class GenresController(IGenreOperation genreOperation) : BaseController
{
    [AllowAnonymous]
    [HttpGet("")]
    public async Task<IActionResult> GetGenres()
    {
        return Ok(await genreOperation.GetGenresAsync());
    }
}