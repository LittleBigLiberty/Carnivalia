using Bunkum.Core;
using Refresh.GameServer.Authentication;
using Refresh.GameServer.Database;
using Refresh.GameServer.Endpoints.Game.Levels.FilterSettings;
using Refresh.GameServer.Services;
using Refresh.GameServer.Types.UserData;

namespace Refresh.GameServer.Types.Levels.Categories;

public class TeamPickedLevelsCategory : LevelCategory
{
    internal TeamPickedLevelsCategory() : base("teamPicks", "mmpicks", false)
    {
        this.Name = "Team Picks";
        this.Description = "High quality levels, hand-picked by us.";
        this.FontAwesomeIcon = "certificate";
        this.IconHash = "g820626";
    }

    public override DatabaseList<GameLevel>? Fetch(RequestContext context, int skip, int count,
        MatchService matchService, GameDatabaseContext database, GameUser? user, 
        LevelFilterSettings levelFilterSettings) 
        => database.GetTeamPickedLevels(count, skip, user, levelFilterSettings);
}