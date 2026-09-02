using Umbraco.Cms.Core.Sync;

namespace Casko.SyncExtensionsForUmbraco.ServerRoleAccessors;

public class SchedulingPublisherServerRoleAccessor : IServerRoleAccessor
{
    public ServerRole CurrentServerRole => ServerRole.SchedulingPublisher;
}