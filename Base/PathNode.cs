using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Updater.Base
{
    public class PathNode : IPathNode
    {
        public PathNode() { }

        public PathNode(string description, string source, string destination)
        {
            _description = description;
            _destination = destination;
            _source = source;
        }

        private string _description = string.Empty;
        public string Description { get => _description; set => _description = value; }

        private string _source = string.Empty;
        public string Source { get => _source; set => _source = value; }

        private string _destination = string.Empty;
        public string Destination { get => _destination; set => _destination = value; }
    }
}
