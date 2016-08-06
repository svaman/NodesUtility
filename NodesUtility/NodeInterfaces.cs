using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodesUtility
{
    public interface INodeDescriber
    {
        string Describe(Node node);
    }

    public interface INodeTransformer
    {
        Node Transform(Node node);
    }

    public interface INodeWriter
    {
        Task WriteToFileAsync(Node node, string filePath);
    }
}
