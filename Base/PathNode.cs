namespace Updater.Base
{
    public class PathNode : IPathNode
    {
        //Конструктор с инициализацией полей
        public PathNode(string description, string source, string destination)
        {
            this.description = description;
            this.destination = destination;
            this.source = source;
        }

        private string description = string.Empty;
        private string source = string.Empty;
        private string destination = string.Empty;

        public string Description { get => description; set => description = value; }
        public string Source { get => source; set => source = value; }
        public string Destination { get => destination; set => destination = value; }
    }
}
