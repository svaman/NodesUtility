using NodesUtility.Interfaces;
using NodesUtilityModals.Modals;

namespace NodesUtility.Business
{
    public class NodeDescriber : INodeDescriber
    {
        private readonly string _indentation;

        public NodeDescriber(string indentation)
        {
            _indentation = indentation;
        }

        public string Describe(Node node)
        {
            return GetNodeDescription(node, 0);
        }

        private string GetNodeDescription(Node node, int nestingLevel)
        {
            var className = node.GetType().Name;
            var nodeName = node.Name;
            var output = string.Empty;
            if (nestingLevel > 0)
            {
                output += "\n";
            }
            for (var index = 1; index <= nestingLevel; index++)
            {
                output += _indentation;
            }
            output += "new " + className + "(\"" + nodeName + "\"";

            var noChildrenNode = node as NoChildrenNode;
            if (noChildrenNode != null)
            {
                return output + ")";
            }

            var singleChildNode = node as SingleChildNode;
            if (singleChildNode != null)
            {
                output += "," + GetNodeDescription(singleChildNode.Child, nestingLevel + 1);
                return output + ")";
            }

            var twoChildrenNode = node as TwoChildrenNode;
            if (twoChildrenNode != null)
            {
                output += "," + GetNodeDescription(twoChildrenNode.FirstChild, nestingLevel + 1);
                output += "," + GetNodeDescription(twoChildrenNode.SecondChild, nestingLevel + 1);
                return output + ")";
            }

            var manyChildrenNode = node as ManyChildrenNode;
            if (manyChildrenNode != null)
            {
                foreach (var child in manyChildrenNode.Children)
                {
                    output += "," + GetNodeDescription(child, nestingLevel + 1);
                    output += ")";
                }
            }
            return output;
        }
    }
}