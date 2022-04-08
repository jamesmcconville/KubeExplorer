using k8s;
using System.Collections.Generic;
using System.Linq;

namespace KubeExplorer.Common.Cluster
{
    internal class ClusterService : IClusterService
    { 
        private IKubernetes _client;

        public IEnumerable<string> GetNamespaces()
        {
            var namespaces = _client.ListNamespace();
            return namespaces.Items.Select(x => x.Metadata.Name);
        }

        public IEnumerable<string> GetDeployments(string ns)
        {
            var deployments = _client.ListDeploymentForAllNamespaces();
            return deployments.Items.Where(x => x.Metadata.NamespaceProperty == ns).Select(x => x.Metadata.Name);
        }

        public void Initialise(string kubeConfig)
        {
            var config = KubernetesClientConfiguration.BuildConfigFromConfigFile(kubeConfig);
            _client = new Kubernetes(config);
        }
    }
}
