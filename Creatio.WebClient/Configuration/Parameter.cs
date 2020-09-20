namespace Creatio.WebClient.Configuration
{
    public class Parameter
    {
        public string Name { get; set; }

        public object Value { get; set; }

        public override bool Equals(object obj)
        {
            Parameter other = obj as Parameter;
            if (other == null)
                return false;
            if (Name != other.Name)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            int nameHash = Name.GetHashCode();
            int valueHash = Value.GetHashCode();
            return nameHash ^ valueHash;
        }

        public override string ToString()
        {
            return $"{Name}: {Value}";
        }
    }
}
