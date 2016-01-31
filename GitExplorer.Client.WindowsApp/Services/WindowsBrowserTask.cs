using GitExplorer1.Infrastructure.RequiredInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitExplorer.Client.WindowsApp.Services
{
    public class WindowsBrowserTask : IOpenBrowserTask
    {
        public void OpenBrowser(string url)
        {
            var uri = new Uri(url);
            Windows.System.Launcher.LaunchUriAsync(uri);
        }
    }
}
