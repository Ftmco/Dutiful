using Dutiful.Entity.Team;
using Dutiful.ViewModels.Team;
using Microsoft.AspNetCore.Http;

namespace Dutiful.Services.Services;

public class TeamServices : ITeamRules
{
    readonly IBaseRules<Team> _teamBase;

    public TeamServices(IBaseRules<Team> teamBase)
    {
        _teamBase = teamBase;
    }


    public async ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
        await _teamBase.DisposeAsync();
    }

    public Task GetTeamsAsync(HttpContext httpContext)
    {
        var token = httpContext.Request.Headers["I-Authentication"].ToString();
        if (token != null)
        {
            
        }
        throw new NotImplementedException();
    }

    public async Task<UpsertTeamResponse> UpsertAsync(UpsertTeam upsertTeam, HttpContext httpContext)
    {
        Team team;
        if (upsertTeam.Id == null)
        {
            team = new()
            {
                Bio = upsertTeam.Bio,
                Name = upsertTeam.Name,
                Token = "TeamToken-" + Guid.NewGuid().ToString(),
            };

        }
        else
        {
            team = await _teamBase.GetAsync(upsertTeam.Id);
            if(team != null)
            {
                team.Name = upsertTeam.Name;
                team.Bio = upsertTeam.Bio;
            }
        }
        throw new NotImplementedException();
    }
}
