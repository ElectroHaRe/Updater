using System.Xml;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Updater.Base
{
    //Класс для сериализации/десериализации листов типа IPathNode
    public static class PathNodeSerializer
    {
        //Generic метод сериализации листа параметризированного типом, реализующим интерфейс IPathNode
        public static void Save<T>(List<T> nodes, string path) where T : IPathNode
        {
            Save(nodes.AsReadOnly(), path);
        }

        //Generic метод сериализации листа только для чтения типа, параметризированного типом, реализующим интерфейс IPathNode 
        public static void Save<T>(ReadOnlyCollection<T> nodes, string path) where T : IPathNode
        {
            //Блок инициализации  XML Документа (создаётся экземпляр, добавляется декларация и корень
            XmlDocument doc = new XmlDocument();
            doc.CreateXmlDeclaration("1.0", System.Text.Encoding.UTF8.EncodingName, null);
            var mainRoot = doc.CreateElement("Nodes");
            doc.AppendChild(mainRoot);

            //Переберается коллекция элеентов типа IPathNode
            foreach (IPathNode item in nodes)
            {
                //Блок инициализации нод верхнего уровня (root - корневая нода, остальное - subNodes)
                var root = doc.CreateElement("PathNode");
                var descriptionNode = doc.CreateElement("Description");
                var sourceNode = doc.CreateElement("Source");
                var destinationNode = doc.CreateElement("Destination");

                //Блок инициализации текстовых нод (InnerText)
                var description = doc.CreateTextNode(item.Description ?? string.Empty);
                var source = doc.CreateTextNode(item.Source ?? string.Empty);
                var destination = doc.CreateTextNode(item.Destination ?? string.Empty);

                //Блок добавления текстовых нод (InnerText) к соотвествующим SubNodes
                descriptionNode.AppendChild(description);
                sourceNode.AppendChild(source);
                destinationNode.AppendChild(destination);

                //Блок добавления SubNodes к ноде верхнего уровня
                root.AppendChild(descriptionNode);
                root.AppendChild(sourceNode);
                root.AppendChild(destinationNode);

                //Добавление ноды верхнего уровня к корневой ноде
                mainRoot.AppendChild(root);
            }

            //Сохранение по пути (перезаписывает файл, если тот уже имеется)
            doc.Save(path);
        }

        //Genetic метод десериализации xmlDocument'а в лист, параметризированный интерфейсным типом IPathNode
        public static List<IPathNode> Load(string path)
        {
            List<IPathNode> nodes = new List<IPathNode>();

            //Если по указанному пути нет файла, то возвращаю пустой лист (логирование не ведётся)
            if (!System.IO.File.Exists(path))
                return nodes;

            //Блок инициализации XMLDocument (создание экземпляра документа, загрузка из файла и получение корневой ноды)
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            var mainRoot = doc.DocumentElement;

            //Блок создания временных переменных для хранения значений innerText'a от subNodes
            string description = string.Empty;
            string source = string.Empty;
            string destination = string.Empty;

            //Перебираем все subNodes корневой ноды
            foreach (XmlNode topNode in mainRoot.ChildNodes)
            {
                //Если находим непонятную нам ноду, то продолжаем перебор (перескакиваем на следующую итерацию)
                if (topNode.Name != "PathNode")
                    continue;

                //Перебираем SubNodes корнф с именем PathNode и записываем InnerText'ы в соответствующие поля
                foreach (XmlNode node in topNode.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case "Description":
                            description = node.InnerText;
                            break;
                        case "Source":
                            source = node.InnerText;
                            break;
                        case "Destination":
                            destination = node.InnerText;
                            break;
                    }
                }

                //Добавляем полученные значения в лист IPathNode  с помощью класса обёртки PathNode
                nodes.Add(new PathNode(description, source, destination));
            }

            //Возвращаем лист IPathNode
            return nodes;
        }
    }
}
