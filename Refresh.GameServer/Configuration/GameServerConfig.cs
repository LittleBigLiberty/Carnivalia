using System.Diagnostics.CodeAnalysis;
using Bunkum.Core.Configuration;
using Microsoft.CSharp.RuntimeBinder;
using Refresh.GameServer.Types.Roles;

namespace Refresh.GameServer.Configuration;

[SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
[SuppressMessage("ReSharper", "RedundantDefaultMemberInitializer")]
public class GameServerConfig : Config
{
    public override int CurrentConfigVersion => 18;
    public override int Version { get; set; } = 0;
    
    protected override void Migrate(int oldVer, dynamic oldConfig)
    {
        if (oldVer < 18)
        {
            int oldSafetyLevel = (int)oldConfig.MaximumAssetSafetyLevel;
            this.BlockedAssetFlags = new ConfigAssetFlags
            {
                Dangerous = oldSafetyLevel < 3,
                Modded = oldSafetyLevel < 2,
                Media = oldSafetyLevel < 1,
            };
            
            // There was no version bump for trusted users being added, so we just have to catch this error :/
            try
            {
                int oldTrustedSafetyLevel = (int)oldConfig.MaximumAssetSafetyLevelForTrustedUsers;
                this.BlockedAssetFlagsForTrustedUsers = new ConfigAssetFlags
                {
                    Dangerous = oldTrustedSafetyLevel < 3,
                    Modded = oldTrustedSafetyLevel < 2,
                    Media = oldTrustedSafetyLevel < 1,
                };
            }
            catch (RuntimeBinderException)
            {
                this.BlockedAssetFlagsForTrustedUsers = this.BlockedAssetFlags;
            }
        }
    }

    public string LicenseText { get; set; } = "Welcome to Refresh!";

    public ConfigAssetFlags BlockedAssetFlags { get; set; } = new()
    {
        Dangerous = true,
        Modded = true,
    };
    /// <seealso cref="GameUserRole.Trusted"/>
    public ConfigAssetFlags BlockedAssetFlagsForTrustedUsers { get; set; } = new()
    {
        Dangerous = true,
        Modded = true,
    };
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
