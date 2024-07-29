using Bunkum.Core;
using Refresh.GameServer.Authentication;
using Refresh.GameServer.Database;
using Refresh.GameServer.Endpoints.Game.Levels.FilterSettings;
using Refresh.GameServer.Services;
using Refresh.GameServer.Types.Data;
using Refresh.GameServer.Types.UserData;

namespace Refresh.GameServer.Types.Levels.Categories;

public class MostHeartedLevelsCategory : LevelCategory
{
    internal MostHeartedLevelsCategory() : base("mostHearted", "mostHearted", false)
    {
        this.Name = "Community's Favorites";
        this.Description = "The all-time most hearted levels!";
        this.FontAwesomeIcon = "heart";
        this.IconHash = "g820607";
    }

    public override DatabaseList<GameLevel>? Fetch(RequestContext context, int skip, int count,
        DataContext dataContext,
        LevelFilterSettings levelFilterSettings, GameUser? _) 
        => dataContext.Database.GetMostHeartedLevels(count, skip, dataContext.User, levelFilterSettings);
}