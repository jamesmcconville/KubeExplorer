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
            var shell = provider.GetService<ShellView>()!;
            shell.Show();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddComponents();
        }
    }
}
