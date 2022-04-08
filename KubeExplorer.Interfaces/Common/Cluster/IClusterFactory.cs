namespace KubeExplorer.Common.Cluster
{
    public interface IClusterFactory
    {
        public ICluster Create(string kubeConfig);
    }
}
