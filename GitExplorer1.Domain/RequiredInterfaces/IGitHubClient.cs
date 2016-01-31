
using GitExplorer1.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitExplorer1.Domain.RequiredInterfaces
{
    public interface IGitHubClient
    {
        Task<List<GitHubEvent>> DownloadEventsAsync();
    }
}
