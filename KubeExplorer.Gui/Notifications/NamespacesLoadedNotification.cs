using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace KubeExplorer.Gui.Notifications
{
    internal class NamespacesLoadedNotification : INotification
    {
        public IEnumerable<string> Namespaces { get; set; } = Enumerable.Empty<string>();
    }
}
