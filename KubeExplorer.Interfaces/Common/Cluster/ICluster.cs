using System.Collections.Generic;

namespace KubeExplorer.Common.Cluster
{
    public interface ICluster
    {
        public IEnumerable<string> Namespaces { get; }
    }
}
