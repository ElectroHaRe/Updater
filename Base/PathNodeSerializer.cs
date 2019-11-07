using System.Xml;
using System.Collections.Generic;

namespace Updater.Base
{
    public static class PathNodeSerializer
    {
        public static void Save<T>(List<T> nodes, string path) where T : IPathNode
        {
            Save(nodes.AsReadOnly(), path);
        }

        public static void Save<T>(System.Collections.ObjectModel.ReadOnlyCollection<T> nodes, string path) where T : IPathNode
        {
            XmlDocument doc = new XmlDocument();

            doc.CreateXmlDeclaration("1.0", System.Text.Encoding.UTF8.EncodingName, null);

            var mainRoot = doc.CreateElement("Nodes");

            doc.AppendChild(mainRoot);

            foreach (IPathNode item in nodes)
            {
                var root = doc.CreateElement("PathNode");
                var descriptionRoot = doc.CreateElement("Description");
                var sourceRoot = doc.CreateElement("Source");
                var destinationRoot = doc.CreateElement("Destination");

                var _description = doc.CreateTextNode(item.Description ?? string.Empty);
                var _source = doc.CreateTextNode(item.Source ?? string.Empty);
                var _destination = doc.CreateTextNode(item.Destination ?? string.Empty);

                descriptionRoot.AppendChild(_description);
                sourceRoot.AppendChild(_source);
                destinationRoot.AppendChild(_destination);

                root.AppendChild(descriptionRoot);
                root.AppendChild(sourceRoot);
                root.AppendChild(destinationRoot);

                mainRoot.AppendChild(root);
            }

            doc.Save(path);
        }

        public static List<IPathNode> Load(string path)
        {
            List<IPathNode> nodes = new List<IPathNode>();

            if (!System.IO.File.Exists(path))
                return nodes;

            XmlDocument doc = new XmlDocument();

            doc.Load(path);

            var mainRoot = doc.DocumentElement;

            string description = string.Empty;
            string source = string.Empty;
            string destination = string.Empty;

            foreach (XmlNode item in mainRoot.ChildNodes)
            {
                if (item.Name != "PathNode")
                    continue;

                foreach (XmlNode field in item.ChildNodes)
                {
                    if (field.Name == "Description")
                        description = field.InnerText;
                    else if (field.Name == "Source")
                        source = field.InnerText;
                    else if (field.Name == "Destination")
                        destination = field.InnerText;
                }

                nodes.Add(new PathNode(description, source, destination));
            }

            return nodes;
        }
    }
}
