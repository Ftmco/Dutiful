using Dutiful.ViewModels.Team;
using Microsoft.AspNetCore.Http;

namespace Dutiful.Services.Rules;

public interface ITeamRules : IAsyncDisposable
{
    Task GetTeamsAsync(HttpContext httpContext);

    Task<UpsertTeamResponse> UpsertAsync(UpsertTeam upsertTeam, HttpContext httpContext);
}
