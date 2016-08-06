using NodesUtility.Interfaces;
using NodesUtility.Modals;

namespace NodesUtility.Business
{
    public class NodeDescriber : INodeDescriber
    {
        public string Describe(Node node)
        {
            var nodeName = node.Name;
            var className = node.GetType().Name;
            var output = "new " + className + "(\"" + nodeName + "\"" + ")";
            return output;
        }


    }
}