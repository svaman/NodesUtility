namespace NodesUtility.Modals
{
    public abstract class Node
    {
        protected Node(string name)
        {
            Name = name;
        }

        public string Name { get; }

        protected bool Equals(Node other)
        {
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Node) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}