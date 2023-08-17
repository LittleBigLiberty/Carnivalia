using Bunkum.HttpServer;
using Refresh.GameServer.Database;
using Refresh.GameServer.Services;
using Refresh.GameServer.Types.UserData;

namespace Refresh.GameServer.Types.Levels.Categories;

public class CurrentlyPlayingCategory : LevelCategory
{
    internal CurrentlyPlayingCategory() : base("currentlyPlaying", "busiest", false,
        nameof(GameDatabaseContext.GetBusiestLevels))
    {
        this.Name = "Busiest Levels";
        this.Description = "Levels being played right now!";
        this.IconHash = "g820602";
        this.FontAwesomeIcon = "users";
    }

    public override DatabaseList<GameLevel>? Fetch(RequestContext context, int skip, int count,
        MatchService matchService, GameDatabaseContext database, GameUser? user,
        object[]? extraArgs = null)
    {
        extraArgs = new object[] { matchService };
        
        return base.Fetch(context, skip, count, matchService, database, user, extraArgs);
    }
}