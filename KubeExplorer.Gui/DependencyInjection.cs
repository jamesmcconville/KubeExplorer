using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace KubeExplorer.Gui
{
    [ExcludeFromCodeCoverage]
    internal static class DependencyInjection
    {
        public static IServiceCollection AddComponents(this IServiceCollection services)
        {
            services.AddSingleton<ShellView>();
            return services;
        }
    }
}
