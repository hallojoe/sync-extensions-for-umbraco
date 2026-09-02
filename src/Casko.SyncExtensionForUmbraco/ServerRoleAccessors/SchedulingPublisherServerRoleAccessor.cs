using Umbraco.Cms.Core.Sync;

namespace Casko.SyncExtensionForUmbraco.ServerRoleAccessors;

public class SchedulingPublisherServerRoleAccessor : IServerRoleAccessor
{
    public ServerRole CurrentServerRole => ServerRole.SchedulingPublisher;
}