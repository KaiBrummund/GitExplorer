using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitExplorer1.Domain.Api
{

    public class EventDto
    {
        public string id { get; set; }
        public string type { get; set; }
        public ActorDto actor { get; set; }
        public RepoDto repo { get; set; }
        public PayloadDto payload { get; set; }
        public bool _public { get; set; }
        public DateTime created_at { get; set; }
        public OrgDto org { get; set; }
    }

    public class ActorDto
    {
        public int id { get; set; }
        public string login { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string avatar_url { get; set; }
    }

    public class RepoDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class PayloadDto
    {
        public int push_id { get; set; }
        public int size { get; set; }
        public int distinct_size { get; set; }
        public string _ref { get; set; }
        public string head { get; set; }
        public string before { get; set; }
        public CommitDto[] commits { get; set; }
    }

    public class CommitDto
    {
        public string sha { get; set; }
        public AuthorDto author { get; set; }
        public string message { get; set; }
        public bool distinct { get; set; }
        public string url { get; set; }
    }

    public class AuthorDto
    {
        public string email { get; set; }
        public string name { get; set; }
    }

    public class OrgDto
    {
        public int id { get; set; }
        public string login { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string avatar_url { get; set; }
    }

}
