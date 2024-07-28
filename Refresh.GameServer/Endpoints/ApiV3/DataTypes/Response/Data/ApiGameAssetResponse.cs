using Refresh.GameServer.Endpoints.ApiV3.DataTypes.Response.Users;
using Refresh.GameServer.Types.Assets;
using Refresh.GameServer.Types.Data;

namespace Refresh.GameServer.Endpoints.ApiV3.DataTypes.Response.Data;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public class ApiGameAssetResponse : IApiResponse, IDataConvertableFrom<ApiGameAssetResponse, GameAsset>
{
    public required string AssetHash { get; set; }
    public required ApiGameUserResponse? OriginalUploader { get; set; }
    public required DateTimeOffset UploadDate { get; set; }
    public required GameAssetType AssetType { get; set; }
    public required IEnumerable<string> Dependencies { get; set; }
    public required IEnumerable<string> Dependents { get; set; }
    
    public static ApiGameAssetResponse? FromOld(GameAsset? old, DataContext dataContext)
    {
        if (old == null) return null;

        return new ApiGameAssetResponse
        {
            AssetHash = old.AssetHash,
            OriginalUploader = ApiGameUserResponse.FromOld(old.OriginalUploader, dataContext),
            UploadDate = old.UploadDate,
            AssetType = old.AssetType,
            Dependencies = dataContext.Database.GetAssetDependencies(old),
            Dependents = dataContext.Database.GetAssetDependents(old),
        };
    }

    public static IEnumerable<ApiGameAssetResponse> FromOldList(IEnumerable<GameAsset> oldList, DataContext dataContext) => oldList.Select(old => FromOld(old, dataContext)).ToList()!;
}