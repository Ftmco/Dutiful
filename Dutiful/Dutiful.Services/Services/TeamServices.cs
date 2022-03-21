using Dutiful.Entity.Team;
using Dutiful.Tools.Token;
using Dutiful.ViewModels.Team;
using Dutiful.ViewModels.User;
using Microsoft.AspNetCore.Http;

namespace Dutiful.Services.Services;

public class TeamServices : ITeamRules
{
    readonly IBaseRules<Team> _teamBase;

    readonly IAccountRules _account;

    public TeamServices(IBaseRules<Team> teamBase, IAccountRules account)
    {
        _teamBase = teamBase;
        _account = account;
    }

    public async Task<UpsertTeamResponse> CreateAsync(UpsertTeam upsertTeam, Guid OwnerId)
    {
        Team newTeam = new()
        {
            Bio = upsertTeam.Bio,
            Name = upsertTeam.Name,
            OwnerId = OwnerId,
            Token = $"Team{upsertTeam.Name}".CreateToken(),
        };
        return await _teamBase.InsertAsync(newTeam) ?
                new UpsertTeamResponse(TeamActionStatus.Success, await CreateTeamViewModelAsyc(newTeam)) :
                    new UpsertTeamResponse(TeamActionStatus.Exception, null);
    }

    public Task<TeamViewModel> CreateTeamViewModelAsyc(Team team)
    {
        TeamViewModel teamViewModel = new(Id: team.Id,
             Name: team.Name,
             Bio: team.Bio,
             Token:team.Token,
             Avatar: default);
        return Task.FromResult(teamViewModel);
    }

    public async Task<IEnumerable<TeamViewModel>> CreateTeamViewModelAsyc(IEnumerable<Team> teams)
    {
        List<TeamViewModel> result = new();
        foreach (var team in teams)
            result.Add(await CreateTeamViewModelAsyc(team));
        return result;
    }

    public async Task<TeamActionStatus> DeleteAsync(string token, HttpContext httpContext)
    {
        UserViewModel? user = await _account.GetUserAsync(httpContext);
        if (user != null)
            return await _teamBase.DeleteAsync(t => t.Token == token && t.OwnerId == user.Id) ?
             TeamActionStatus.Success : TeamActionStatus.Exception;

        return TeamActionStatus.UserNotFound;
    }

    public async ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
        await _teamBase.DisposeAsync();
    }

    public async Task<GetTeamsResponse> GetTeamsAsync(HttpContext httpContext)
    {
        UserViewModel? user = await _account.GetUserAsync(httpContext);
        if (user != null)
        {
            IEnumerable<Team>? teams = await _teamBase.GetAsync(ut => ut.OwnerId == user.Id);
            var teamsViewModel = await CreateTeamViewModelAsyc(teams);
            return new GetTeamsResponse(TeamActionStatus.Success, teamsViewModel);
        }
        return new GetTeamsResponse(TeamActionStatus.UserNotFound, new List<TeamViewModel>());
    }

    public async Task<UpsertTeamResponse> UpdateAsync(UpsertTeam upsertTeam)
    {
        var team = await _teamBase.GetAsync(upsertTeam.Id);
        if (team != null)
        {
            team.Name = upsertTeam.Name;
            team.Bio = upsertTeam.Bio;
            return await _teamBase.UpdateAsync(team) ?
                    new UpsertTeamResponse(TeamActionStatus.Success, await CreateTeamViewModelAsyc(team)) :
                        new UpsertTeamResponse(TeamActionStatus.Exception, null);
        }
        return new UpsertTeamResponse(TeamActionStatus.TeamNotFound, null);
    }

    public async Task<UpsertTeamResponse> UpsertAsync(UpsertTeam upsertTeam, HttpContext httpContext)
    {
        UserViewModel? user = await _account.GetUserAsync(httpContext);
        if (user != null)
            return upsertTeam.Id == null ?
                await CreateAsync(upsertTeam, user.Id) :
                    await UpdateAsync(upsertTeam);

        return new UpsertTeamResponse(TeamActionStatus.UserNotFound, null);
    }
}
