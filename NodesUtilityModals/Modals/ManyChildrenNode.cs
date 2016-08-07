using System.Collections.Generic;

namespace NodesUtilityModals.Modals
{
    public class ManyChildrenNode : Node
    {
        public IEnumerable<Node> Children { get; }
        public ManyChildrenNode(string name, params Node[] children) : base(name)
        {
            Children = children;
        }
    }
}