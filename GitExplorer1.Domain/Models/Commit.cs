using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitExplorer1.Domain.Models
{
    public class Commit
    {
        public string Sha { get; set; }
        public string Comment { get; set; }
    }
}
