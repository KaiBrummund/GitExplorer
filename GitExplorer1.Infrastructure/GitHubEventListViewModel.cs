using GitExplorer1.Domain.Models;
using GitExplorer1.Domain.Services;
using GitExplorer1.Infrastructure.RequiredInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitExplorer1.Infrastructure
{
    public class GitHubEventListViewModel : BaseViewModel
    {
        private readonly GitHubEventService _service;
        private readonly IOpenBrowserTask _browerTask;

        private List<GitHubEvent> _events = new List<GitHubEvent>();

        public GitHubEventListViewModel(GitHubEventService service, IOpenBrowserTask browserTask)
        {
            _service = service;
            _browerTask = browserTask;
        }

        public List<GitHubEvent> Events
        {
            get { return _events; }
            set
            {
                if (value != _events)
                {
                    _events = value;
                    RaisePropertyChanged(nameof(Events));
                }
            }
        }

        public async Task UpdateEvents()
        {
            if (IsDownloading) return;

            try
            {
                IsDownloading = true;

                Events = await _service.GetEventsAsync();
            }
            catch(Exception e)
            {
                // Hier sollte theroretisch auf freundliche Art und Weise
                // der Benutzer über einen aufgetretenen Fehler informiert werden
            }

            IsDownloading = false;
        }

        public void GoToGithubDotCom()
        {
            _browerTask.OpenBrowser("http://www.github.com");
        }
    }
}
