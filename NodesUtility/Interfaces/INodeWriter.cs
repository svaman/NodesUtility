using System.Threading.Tasks;
using NodesUtilityModals.Modals;

namespace NodesUtility.Interfaces
{
    public interface INodeWriter
    {
        Task WriteToFileAsync(Node node, string filePath);
    }
}
