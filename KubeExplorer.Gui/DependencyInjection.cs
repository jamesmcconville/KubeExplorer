using KubeExplorer.Gui.Components.Cluster;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Markup;

namespace KubeExplorer.Gui
{
    [ExcludeFromCodeCoverage]
    internal static class DependencyInjection
    {
        public static IServiceCollection AddComponents(this IServiceCollection services)
        {
            services.AddSingleton<ShellView>();
            services.AddSingleton<ShellViewModel>();
            services.AddTransient<IClusterViewModel, ClusterViewModel>();
            return services;
        }
    }

    internal class DependencyInjectionSource : MarkupExtension
    {
        public static Func<Type, object>? Resolver { get; set; }
        public Type? Type { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider) => Resolver?.Invoke(Type);
    }
}
