namespace Updater.Base
{
    public interface IPathNode
    {
        string Description { get; set; }
        string Source { get; set; }
        string Destination { get; set; }
    }
}
