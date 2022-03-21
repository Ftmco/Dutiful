using Dutiful.Entity.Team;
using Dutiful.ViewModels.Team;
using Microsoft.AspNetCore.Http;

namespace Dutiful.Services.Rules;

public interface ITeamRules : IAsyncDisposable
{
    Task<GetTeamsResponse> GetTeamsAsync(HttpContext httpContext);

    Task<UpsertTeamResponse> UpsertAsync(UpsertTeam upsertTeam, HttpContext httpContext);

    Task<UpsertTeamResponse> CreateAsync(UpsertTeam upsertTeam, Guid OwnerId);

    Task<UpsertTeamResponse> UpdateAsync(UpsertTeam upsertTeam);

    Task<TeamViewModel> CreateTeamViewModelAsyc(Team team);

    Task<IEnumerable<TeamViewModel>> CreateTeamViewModelAsyc(IEnumerable<Team> teams);

    Task<TeamActionStatus> DeleteAsync(string token,HttpContext httpContext);
}
