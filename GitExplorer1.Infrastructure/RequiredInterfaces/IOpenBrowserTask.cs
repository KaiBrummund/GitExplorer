using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitExplorer1.Infrastructure.RequiredInterfaces
{
    public interface IOpenBrowserTask
    {
        void OpenBrowser(string url);
    }
}
