using CommunityToolkit.Mvvm.Messaging;
using KubeExplorer.Common;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Windows;

namespace KubeExplorer.Gui
{
    [ExcludeFromCodeCoverage]
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var provider = services.BuildServiceProvider();

            DependencyInjectionSource.Resolver = type => provider.GetService(type);

            var shell = provider.GetService<ShellView>()!;
            shell.DataContext = provider.GetService<ShellViewModel>();
            shell.Show();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddComponents()
                .AddKubeExplorerCommon()
                .AddMediatR(typeof(App))
                .AddSingleton<IMessenger>(StrongReferenceMessenger.Default);
        }
    }
}
