using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsPoint.InterlockedConstructs
{
    class InterLockConstructs
    {

    }

    internal sealed class MultiWebResources
    {
        private AsyncCoordinator ac = new AsyncCoordinator();

        private Dictionary<string, Object> m_servers = new Dictionary<string, object>
        {
            { "http://Wintellect.com/", null },
            { "http://Microsoft.com/", null },
            { "http://1.1.1.1/", null }
        };
    }
}
