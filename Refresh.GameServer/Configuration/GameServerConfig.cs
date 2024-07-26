using System.Diagnostics.CodeAnalysis;
using Bunkum.Core.Configuration;
using Refresh.GameServer.Types.Assets;
using Refresh.GameServer.Types.Roles;

namespace Refresh.GameServer.Configuration;

[SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
[SuppressMessage("ReSharper", "RedundantDefaultMemberInitializer")]
public class GameServerConfig : Config
{
    public override int CurrentConfigVersion => 17;
    public override int Version { get; set; } = 0;

    protected override void Migrate(int oldVer, dynamic oldConfig) {}

    public string LicenseText { get; set; } = "Welcome to Refresh!";

    public AssetSafetyLevel MaximumAssetSafetyLevel { get; set; } = AssetSafetyLevel.SafeMedia;
    /// <seealso cref="GameUserRole.Trusted"/>
    public AssetSafetyLevel MaximumAssetSafetyLevelForTrustedUsers { get; set; } = AssetSafetyLevel.SafeMedia;
    public bool AllowUsersToUseIpAuthentication { get; set; } = false;
    public bool UseTicketVerification { get; set; } = true;
    public bool RegistrationEnabled { get; set; } = true;
    public string InstanceName { get; set; } = "Liberty";
    public string InstanceDescription { get; set; } = "niko bellic real idk what to put here uhhhh lbp yay wahaooooo";
    public bool MaintenanceMode { get; set; } = false;
    public bool RequireGameLoginToRegister { get; set; } = false;
    /// <summary>
    /// Whether to use deflate compression for responses.
    /// If this is disabled, large enough responses will cause LBP to overflow its read buffer and eventually corrupt its own memory to the point of crashing.
    /// </summary>
    public bool UseDeflateCompression { get; set; } = true;
    public string WebExternalUrl { get; set; } = "https://littlebigliberty.com";
    /// <summary>
    /// The base URL that LBP3 uses to grab config files like `network_settings.nws`.
    /// </summary>
    public string GameConfigStorageUrl { get; set; } = "https://littlebigliberty.com/lbp";
    public bool AllowInvalidTextureGuids { get; set; } = false;
    public bool BlockAssetUploads { get; set; } = false;
    /// <seealso cref="GameUserRole.Trusted"/>
    public bool BlockAssetUploadsForTrustedUsers { get; set; } = false;
    /// <summary>
    /// The amount of data the user is allowed to upload before all resource uploads get blocked, defaults to 100mb.
    /// </summary>
    public int UserFilesizeQuota { get; set; } = 100 * 1_048_576;
    /// <summary>
    /// Whether to print the room state whenever a `FindBestRoom` match returns no results
    /// </summary>
    public bool PrintRoomStateWhenNoFoundRooms { get; set; } = true;

    public string[] Sha1DigestKeys = ["CustomServerDigest"];
    public string[] HmacDigestKeys = ["CustomServerDigest"];
}
