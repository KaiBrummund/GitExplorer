using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GitExplorer1.Domain.Api;
using System.Threading.Tasks;
using GitExplorer1.Domain.Services;

namespace GitExplorer1.Domain.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestApiClientDownload()
        {
            var client = new GitHubOrganisationEventClient();
            var data = await client.DownloadEventsAsync();

            Assert.IsTrue(data.Count > 0);
        }

        [TestMethod]
        public async Task TestService()
        {
            var client = new GitHubOrganisationEventClient();
            var service = new GitHubEventService(client);
            var data = await service.GetEventsAsync();

            Assert.IsTrue(data.Count > 0);
        }
    }
}
