using Dutiful.Services.Rules;
using Dutiful.ViewModels.Team;
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
        var teams = await _team.GetTeamsAsync(HttpContext);
        return teams.Status switch
        {
            TeamActionStatus.Success => Ok(Success("", "", teams.Teams)),
            TeamActionStatus.UserNotFound => Ok(Faild(401, "User Not Authorized", "Please Login And Try Again")),
            TeamActionStatus.Exception => Ok(ApiException("Exception,Please Try Again", "")),
            TeamActionStatus.TeamNotFound => throw new NotImplementedException(),
            _ => Ok(ApiException("Exception,Please Try Again", "")),
        };
    }

    [HttpPost("Upsert")]
    public async Task<IActionResult> Upsert(UpsertTeam upsertTeam)
    {
        UpsertTeamResponse upsert = await _team.UpsertAsync(upsertTeam, HttpContext);
        return upsert.Status switch
        {
            TeamActionStatus.Success => Ok(Success($"Action Success Fully For {upsert.Team.Name}", "", upsert.Team)),
            TeamActionStatus.UserNotFound => Ok(Faild(401, "User Not Authorized", "Please Login And Try Again")),
            TeamActionStatus.Exception => Ok(ApiException("Exception,Please Try Again", "")),
            TeamActionStatus.TeamNotFound => Ok(Faild(404, "Team Not Found", "")),
            _ => Ok(ApiException("Exception,Please Try Again", "")),
        };
    }

    [HttpGet("Delete")]
    public async Task<IActionResult> Delete(string token)
    {
        TeamActionStatus delete = await _team.DeleteAsync(token,HttpContext);
        return delete switch
        {
            TeamActionStatus.Success => Ok(Success("Team Deleted", "", new { })),
            TeamActionStatus.UserNotFound => Ok(Faild(401, "User Not Authorized", "Please Login And Try Again")),
            TeamActionStatus.Exception => Ok(ApiException("Exception,Please Try Again", "")),
            TeamActionStatus.TeamNotFound => Ok(Faild(404, "Team Not Found", "")),
            _ => Ok(ApiException("Exception,Please Try Again", "")),
        };
    }
}
