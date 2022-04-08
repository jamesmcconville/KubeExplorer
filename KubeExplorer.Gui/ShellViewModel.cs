using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using KubeExplorer.Common;
using KubeExplorer.Common.Cluster;
using KubeExplorer.Gui.Notifications;

namespace KubeExplorer.Gui
{
    public partial class ShellViewModel
    {
        private readonly IClusterService _clusterService;
        private readonly IMessenger _messenger;

        public ShellViewModel(IClusterService clusterService,
                              IMessenger messenger)
        {
            _clusterService = clusterService;
            _messenger = messenger;
        }

        [ICommand]
        private void OpenCluster()
        {
            _clusterService.Initialise(@"C:\Users\james\.kube\config");
            var namespaces = _clusterService.GetNamespaces();
            _messenger.Send(new NamespacesLoadedNotification { Namespaces = namespaces });
        }
    }
}
