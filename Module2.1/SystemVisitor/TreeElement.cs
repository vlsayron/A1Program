namespace SystemVisitor
{
    public class TreeElement
    {
        public enum ElementType { File, Directory }

        public ElementType Type { get; set; }
        public string Path { get; set; }

        public TreeElement(ElementType type, string path)
        {
            Type = type;
            Path = path;
        }
    }
}
