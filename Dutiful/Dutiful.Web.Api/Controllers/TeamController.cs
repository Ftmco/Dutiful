using Dutiful.Services.Rules;
using Dutiful.ViewModels.Team;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dutiful.Web.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamController : ControllerBase
{
    readonly ITeamRules _team;

    public TeamController(ITeamRules team)
    {
        _team = team;
    }


    [HttpGet("GetTeams")]
    public async Task<IActionResult> GetTeams()
    {
         await _team.GetTeamsAsync(HttpContext);
        return Ok();
    }
        
    [HttpPost("Upsert")]
    public async Task<IActionResult> Upsert(UpsertTeam upsertTeam)
    {
        UpsertTeamResponse upsert = await _team.UpsertAsync(upsertTeam, HttpContext);
        return Ok();
    }
}
