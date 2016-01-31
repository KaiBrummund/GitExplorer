using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitExplorer1.Domain.Models
{
    public class GitHubEvent
    {
        public string Id { get; set; }

        public User Actor { get; set; }

        public GitHubRepository Repository { get; set; }

        public List<Commit> Commits { get; set; }
    }
}
