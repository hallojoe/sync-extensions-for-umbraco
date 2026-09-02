using Umbraco.Cms.Core.Sync;

namespace Casko.SyncExtensionsForUmbraco.ServerRoleAccessors;

public class SubscriberServerRoleAccessor : IServerRoleAccessor
{
    public ServerRole CurrentServerRole => ServerRole.Subscriber;
}