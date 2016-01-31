using GitExplorer1.Domain.Models;
using GitExplorer1.Domain.RequiredInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitExplorer1.Domain.Services
{
    public class GitHubEventService
    {
        private readonly IGitHubClient _client;

        private List<GitHubEvent> _events = new List<GitHubEvent>();

        public GitHubEventService(IGitHubClient client)
        {
            _client = client;
        }

        public async Task<List<GitHubEvent>> GetEventsAsync()
        {
            var items = await _client.DownloadEventsAsync();
            _events = items;
            return _events;
        }

        public List<GitHubEvent>  GetEventsFromMemory()
        {
            return _events;
        }
    }
}
