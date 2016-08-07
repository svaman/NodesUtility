namespace NodesUtilityModals.Modals
{
    public class SingleChildNode : Node
    {
        public SingleChildNode(string name, Node child) : base(name)
        {
            Child = child;
        }

        public Node Child { get; }

        protected bool Equals(SingleChildNode other)
        {
            return Equals(Child, other.Child);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SingleChildNode) obj);
        }

        public override int GetHashCode()
        {
            return (Child != null ? Child.GetHashCode() : 0);
        }
    }
}