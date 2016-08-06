using NodesUtility.Interfaces;
using NodesUtility.Modals;

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
            dynamic parent = node;
            var className = parent.GetType().Name;
            var nodeName = parent.Name;
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

            if (parent.GetType() == typeof(NoChildrenNode))
            {
                return output + ")";
            }

            if (parent.GetType() == typeof(SingleChildNode))
            {
                output += "," + GetNodeDescription(parent.Child, nestingLevel + 1);
                return output + ")";
            }
            return "";
        }

    }
}