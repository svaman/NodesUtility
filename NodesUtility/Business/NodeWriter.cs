using System.IO;
using System.Text;
using System.Threading.Tasks;
using NodesUtility.Interfaces;
using NodesUtilityModals.Modals;

namespace NodesUtility.Business
{
    public class NodeWriter : INodeWriter
    {
        private readonly INodeDescriber _nodeDescriber;

        public NodeWriter(INodeDescriber nodeDescriber)
        {
            _nodeDescriber = nodeDescriber;
        }

        public async Task WriteToFileAsync(Node node, string filePath)
        {
            var nodeDescriberText = _nodeDescriber.Describe(node);
            var encodedText = Encoding.Unicode.GetBytes(nodeDescriberText);

            using (var sourceStream = new FileStream(filePath,
                                                    FileMode.Create, FileAccess.Write, FileShare.None,
                                                    bufferSize: 4096, useAsync: true))
            {
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            };
        }

    }
}