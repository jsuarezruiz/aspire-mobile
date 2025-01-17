# .NET MAUI + .NET Aspire - Better Together

[![NuGet package](https://img.shields.io/nuget/v/MauiAspire.svg)](https://nuget.org/packages/MauiAspire)

This project provides integration code necessary to use .NET MAUI (and other mobile clients) with .NET Aspire. It also includes a .NET MAUI + Aspire project template.

## Creating a new MAUI+Aspire project

**_Current status:_**
Please test using the CI NuGet feed below. Once a few of us have tested, I will publish to the public nuget.org feed.

[Optional] To use the latest CI built packages create a nuget.config file with contents below. Place it in a parent directory to the directory you use for testing.

```
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="aspire-mobile" value="https://pkgs.dev.azure.com/bretjohn-public/aspire-mobile/_packaging/aspire-mobile/nuget/v3/index.json" />
  </packageSources>
</configuration>
```

Install the templates:
```
dotnet new install MauiAspire.ProjectTemplates
```

In Visual Studio: `File` / `New Project` / `.NET MAUI App with Aspire` / `MyApp`

or create a project from the CLI:
```
dotnet new maui-aspire -o MyApp
```

## Usage

Launch `MyApp.AppHost` project to start any Aspire managed servies and the Aspire dashboard.

Launching AppHost the first time will also generate the `AspireAppSettings.g.cs` file in the MauiApp source directory.
Normally Aspire passess configuration settings as environment variables when launching services/clients, but for MAUI
apps (at least today) those settings are instead generated here and included in the app at build time.

Once AppHost is running, then launch the `MyApp` project to run the MAUI app itself. Hit the Load Weather button and
you should see the MAUI app fetch weather data from the minimal API service running on your desktop, with activity across
all services and the MAUI client itself tracked in the Aspire dashboard.

