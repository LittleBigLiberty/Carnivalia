using Bunkum.Core;
using Refresh.GameServer.Authentication;
using Refresh.GameServer.Database;
using Refresh.GameServer.Endpoints.Game.Levels.FilterSettings;
using Refresh.GameServer.Services;
using Refresh.GameServer.Types.Data;
using Refresh.GameServer.Types.UserData;

namespace Refresh.GameServer.Types.Levels.Categories;

public class RandomLevelsCategory : LevelCategory
{
    internal RandomLevelsCategory() : base("random", "lbp2luckydip", false)
    {
        this.Name = "Lucky Dip";
        this.Description = "A random assortment of levels!";
        this.FontAwesomeIcon = "shuffle";
        this.IconHash = "g820605";
    }
    
    public override DatabaseList<GameLevel>? Fetch(RequestContext context, int skip, int count, DataContext dataContext,
        LevelFilterSettings levelFilterSettings, GameUser? _) 
        => dataContext.Database.GetRandomLevels(count, skip, dataContext.User, levelFilterSettings);
}