using NodesUtility.Interfaces;
using NodesUtility.Modals;

namespace NodesUtility.Business
{
    public class NodeTransformer : INodeTransformer
    {
        public Node Transform(Node node)
        {
            if (node.GetType() != typeof(ManyChildrenNode))
            {
                return node;
            }
            return null;
        }
    }
}