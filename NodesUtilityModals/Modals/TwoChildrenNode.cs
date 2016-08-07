namespace NodesUtilityModals.Modals
{
    public class TwoChildrenNode : Node
    {
        public TwoChildrenNode(string name, Node first, Node second) : base(name)
        {
            FirstChild = first;
            SecondChild = second;
        }

        public Node FirstChild { get; }
        public Node SecondChild { get; }

        protected bool Equals(TwoChildrenNode other)
        {
            return Equals(FirstChild, other.FirstChild) && Equals(SecondChild, other.SecondChild);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((TwoChildrenNode) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((FirstChild != null ? FirstChild.GetHashCode() : 0)*397) ^
                       (SecondChild != null ? SecondChild.GetHashCode() : 0);
            }
        }
    }
}