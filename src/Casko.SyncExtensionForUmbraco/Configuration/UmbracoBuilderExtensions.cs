using Casko.SyncExtensionForUmbraco.ServerRoleAccessors;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Sync;
using Umbraco.Cms.Infrastructure.DependencyInjection;

namespace Casko.SyncExtensionForUmbraco.Configuration;

public record ServerRoleNames(
    string Subscriber = Constants.SubscriberServerRoleName,
    string SchedulingPublisher = Constants.SchedulingPublisherServerRoleName);

public static class ServerRolesConfigurationExtensions
{
    public static IUmbracoBuilder AddSingleServerRole(this IUmbracoBuilder builder)
    {
        builder.SetServerRegistrar(new SingleServerRoleAccessor());
        return builder;
    }

    public static IUmbracoBuilder AddSubscriberServerRole(this IUmbracoBuilder builder)
    {
        builder.SetServerRegistrar(new SubscriberServerRoleAccessor());
        return builder;
    }
    
    public static IUmbracoBuilder AddSchedulingPublisherServerRole(this IUmbracoBuilder builder)
    {
        builder.SetServerRegistrar(new SchedulingPublisherServerRoleAccessor());
        return builder;
    }

    public static IUmbracoBuilder AddServerRole(this IUmbracoBuilder builder, ServerRole serverRole)
    {
        return serverRole switch
        {
            ServerRole.Subscriber => builder.AddSubscriberServerRole(),
            ServerRole.SchedulingPublisher => builder.AddSchedulingPublisherServerRole(),
            _ => builder.AddSingleServerRole()
        };
    }
    
    public static IUmbracoBuilder AddServerRole(this IUmbracoBuilder builder, string serverRole, ServerRoleNames? serverRoleNames = null)
    {
        serverRoleNames ??= new ServerRoleNames();

        if (IsServerRole(serverRole, serverRoleNames.Subscriber))
        {
            return builder.AddSubscriberServerRole();
        }

        if (IsServerRole(serverRole, serverRoleNames.SchedulingPublisher))
        {
            return builder.AddSchedulingPublisherServerRole();
        }

        return builder.AddSingleServerRole();
    }
    
    private static bool IsServerRole(string claimedServerRole, string serverRole)
        => string.Equals(claimedServerRole, serverRole, StringComparison.OrdinalIgnoreCase);
}