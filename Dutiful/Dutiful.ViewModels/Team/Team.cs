using Dutiful.ViewModels.Tools;

namespace Dutiful.ViewModels.Team;

public record TeamViewModel(Guid Id,string Name,string Bio,FileViewModel Avatar);

public record UpsertTeam(Guid? Id,string Name,string Bio,SendFile Avatar);

public record UpsertTeamResponse(TeamActionStatus Status,TeamViewModel Team);

public enum TeamActionStatus
{

}