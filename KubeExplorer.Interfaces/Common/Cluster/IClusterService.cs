using System.Collections.Generic;

namespace KubeExplorer.Common.Cluster
{
    public delegate IClusterService ClusterServiceFactory(string kubeConfig);
    public interface IClusterService
    {
        void Initialise(string kubeConfig);
        IEnumerable<string> GetNamespaces();
        IEnumerable<string> GetDeployments(string ns);
    }
}
