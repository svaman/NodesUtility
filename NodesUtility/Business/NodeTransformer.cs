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
            else
            {
                dynamic parent = node;
                int numberOfChildren = parent.Children.Length;
                switch (numberOfChildren)
                {
                    case 0:
                        return new NoChildrenNode(node.Name);
                    case 1:
                        return new SingleChildNode(node.Name, 
                                                Transform(parent.Children[0]));
                    case 2:
                        return new TwoChildrenNode(node.Name,
                                                Transform(parent.Children[0]),
                                                Transform(parent.Children[1]));
                }
                return node;
            }
        }
    }
}