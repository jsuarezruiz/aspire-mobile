﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.Metrics;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MauiAspire.App;

public class WrapperMauiAppBuilder : IHostApplicationBuilder
{
    private readonly MauiAppBuilder _appBuilder;

    public WrapperMauiAppBuilder(MauiAppBuilder appBuilder)
    {
        _appBuilder = appBuilder;
    }

    public IConfigurationManager Configuration => _appBuilder.Configuration;

    public IHostEnvironment Environment => new MauiHostEnvironment();

    public ILoggingBuilder Logging => _appBuilder.Logging;

#pragma warning disable CS8603 // Possible null reference return.
    public IMetricsBuilder Metrics => null;
#pragma warning restore CS8603 // Possible null reference return.

    public IDictionary<object, object> Properties => throw new NotImplementedException();

    public IServiceCollection Services => _appBuilder.Services;

    public void ConfigureContainer<TContainerBuilder>(IServiceProviderFactory<TContainerBuilder> factory, Action<TContainerBuilder>? configure = null)
        where TContainerBuilder : notnull
    {
        _appBuilder.ConfigureContainer<TContainerBuilder>(factory, configure);
    }

    public MauiApp Build()
    {
        return _appBuilder.Build();
    }
}
