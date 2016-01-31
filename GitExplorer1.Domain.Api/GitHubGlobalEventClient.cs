using GitExplorer1.Domain.RequiredInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitExplorer1.Domain.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace GitExplorer1.Domain.Api
{
public class GitHubGlobalEventClient : IGitHubClient
{
    public async Task<List<GitHubEvent>> DownloadEventsAsync()
    {
        try
        {
            //var handler = new ModernHttpClient.NativeMessageHandler();
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("User-Agent", "Awesome 1.0");
            client.DefaultRequestHeaders.Add("Authorization", "Basic YOUR API KEY HERE");

            var result = await client.GetStringAsync("https://api.github.com/events");
            var data = JsonConvert.DeserializeObject<List<EventDto>>(result);

            return data
                .Where(e => e.type == "PushEvent")
                .Select(eventdto => new GitHubEvent()
                {
                    Id = eventdto.id,
                    Actor = new User()
                    {
                        Name = eventdto.actor.login,
                        ProfileImageUrl = eventdto.actor.avatar_url
                    },
                    Commits = eventdto.payload.commits?.Select(commitdto => new Commit()
                    {
                        Sha = commitdto.sha,
                        Comment = commitdto.message
                    }).ToList(),
                    Repository = new GitHubRepository()
                    {
                        FullName = eventdto.repo.name
                    }
                }).ToList();
        }
        catch(Exception e)
        {
            throw new Exception("Something went wrong");
        }
    }
}
}
