using System.Threading.Tasks;
using NodesUtility.Modals;

namespace NodesUtility.Interfaces
{
    public interface INodeWriter
    {
        Task WriteToFileAsync(Node node, string filePath);
    }
}
