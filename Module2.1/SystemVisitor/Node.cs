namespace SystemVisitor
{
    internal class Node
    {
        public Node(TreeElement data)
        {
            Data = data;
        }
        public TreeElement Data { get; set; }
        public Node Next { get; set; }
    }
}