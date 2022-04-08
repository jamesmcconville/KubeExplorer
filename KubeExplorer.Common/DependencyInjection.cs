using KubeExplorer.Common.Cluster;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace KubeExplorer.Common
{
    public delegate TR Factory<in T, out TR>(T arg1);
         
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddKubeExplorerCommon(this IServiceCollection services)
        {
            services.AddSingleton<IClusterService, ClusterService>();
            return services;
        }
    }
}
