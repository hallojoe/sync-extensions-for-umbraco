using Umbraco.Cms.Core.Sync;

namespace Casko.SyncExtensionForUmbraco.ServerRoleAccessors;

public class SingleServerRoleAccessor : IServerRoleAccessor
{
    public ServerRole CurrentServerRole => ServerRole.Single;
}