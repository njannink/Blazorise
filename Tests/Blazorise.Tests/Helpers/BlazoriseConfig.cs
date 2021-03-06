﻿#region Using directives
using System;
using Blazorise.Bootstrap;
using Blazorise.Utils;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Moq;
#endregion

namespace Blazorise.Tests.Helpers
{
    public static class BlazoriseConfig
    {
        public static void AddBootstrapProviders( TestServiceProvider services )
        {
            services.AddSingleton<IEditContextValidator>( new EditContextValidator( new ValidationMessageLocalizerAttributeFinder() ) );
            services.AddSingleton<IClassProvider>( new BootstrapClassProvider() );
            services.AddSingleton<IStyleProvider>( new BootstrapStyleProvider() );
            services.AddSingleton<IJSRunner>( new BootstrapJSRunner( new Mock<IJSRuntime>().Object ) );
            services.AddSingleton<IComponentMapper>( new ComponentMapper() );
            services.AddSingleton<IThemeGenerator>( new BootstrapThemeGenerator() );
            services.AddSingleton<IIconProvider>( new Mock<IIconProvider>().Object );

            Action<BlazoriseOptions> configureOptions = ( options ) =>
            {
            };

            services.AddSingleton( configureOptions );
            services.AddSingleton<BlazoriseOptions>();
        }
    }
}
