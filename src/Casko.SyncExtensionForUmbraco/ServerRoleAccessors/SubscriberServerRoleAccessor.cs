using Umbraco.Cms.Core.Sync;

namespace Casko.SyncExtensionForUmbraco.ServerRoleAccessors;

public class SubscriberServerRoleAccessor : IServerRoleAccessor
{
    public ServerRole CurrentServerRole => ServerRole.Subscriber;
}