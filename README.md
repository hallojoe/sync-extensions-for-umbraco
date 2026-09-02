# Sync Extensions for Umbraco

`Casko.SyncExtensionForUmbraco` provides small, explicit server-role configuration helpers for Umbraco applications.

The package supports Umbraco's built-in `Single`, `Subscriber`, and `SchedulingPublisher` server roles.

## Requirements

- .NET 10
- Umbraco CMS 17

## Installation

Install the package from NuGet:

```bash
dotnet add package Casko.SyncExtensionForUmbraco
```

## Usage

Choose a fixed role while configuring the Umbraco builder:

```csharp
using Casko.SyncExtensionForUmbraco.Configuration;

builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddComposers()
    .AddSchedulingPublisherServerRole()
    .Build();
```

Alternatively, choose a role from a configuration value:

```csharp
using Casko.SyncExtensionForUmbraco.Configuration;

var serverRole = builder.Configuration["Umbraco:CMS:Global:ServerRole"] ?? "Single";

builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddComposers()
    .AddServerRole(serverRole)
    .Build();
```

`AddServerRole(string)` matches role names case-insensitively. The default names are `Single`, `Subscriber`, and `SchedulingPublisher`; provide a `ServerRoleNames` instance to use different configuration values. Unknown values safely fall back to `Single`.

## Development

Build the solution:

```bash
dotnet build src/Casko.SyncExtensionForUmbraco.slnx --configuration Release
```

GitHub Actions validates Release builds on pushes and pull requests. Publishing a GitHub release packages the project and publishes it to GitHub Packages and NuGet. Release tags must use the form `v<major>.<minor>.<patch>`; stable releases must target `main`, while prereleases must target another branch.

## License

Licensed under the [MIT License](LICENSE).
