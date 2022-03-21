using Dutiful.ViewModels.Tools;

namespace Dutiful.ViewModels.Team;

public record TeamViewModel(Guid Id, string Name, string Bio,string Token, FileViewModel Avatar);

public record UpsertTeam(Guid? Id, string Name, string Bio, SendFile Avatar);

public record UpsertTeamResponse(TeamActionStatus Status, TeamViewModel? Team);

public record GetTeamsResponse(TeamActionStatus Status,IEnumerable<TeamViewModel> Teams);

public enum TeamActionStatus
{
    Success = 0,
    UserNotFound = 1,
    Exception = 2,
    TeamNotFound = 3
}