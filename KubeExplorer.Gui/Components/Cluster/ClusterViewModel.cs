using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using KubeExplorer.Common.Cluster;
using KubeExplorer.Gui.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace KubeExplorer.Gui.Components.Cluster
{
    internal interface IClusterViewModel
    {

    }

    [INotifyPropertyChanged]
    internal partial class ClusterViewModel : IClusterViewModel
    {
        private readonly IClusterService _clusterService;

        [ObservableProperty]
        private IEnumerable<string> _namespaces = Enumerable.Empty<string>();

        [ObservableProperty]
        private IEnumerable<string> _deployments = Enumerable.Empty<string>();

        private string? _selectedNamespace;

        public ClusterViewModel(IClusterService clusterService,
            IMessenger messenger)
        {
            _clusterService = clusterService;
            messenger.Register<NamespacesLoadedNotification>(this, HandleNamespacesUpdated);
        }

        public string SelectedNamespace
        {
            get => _selectedNamespace ?? string.Empty;
            set
            {
                SetProperty(ref _selectedNamespace, value);
                Deployments = _clusterService.GetDeployments(value);
            }
        }

        private void HandleNamespacesUpdated(object recipient, NamespacesLoadedNotification message)
        {
            Namespaces = message.Namespaces;
        }
    }
}
