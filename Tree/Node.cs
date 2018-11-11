namespace Level_Ordered_Search
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> LeftBranch { get; set; }
        public Node<T> RightBranch { get; set; }


        public static Node<T> CreateNode(T value) => new Node<T>(value);
        public static Node<T> CreateNode(T value, T rightValue) => new Node<T>(value, CreateNode(rightValue));
        public static Node<T> CreateNode(T value, T leftValue, T rightValue)
        {
            return new Node<T>(value, CreateNode(leftValue), CreateNode(rightValue));
        }

        private Node(T value)
        {
            Value = value;
        }

        private Node(T value, Node<T> leftValue)
        {
            LeftBranch = leftValue;
        }
        private Node(T value, Node<T> leftBranch, Node<T> rightBranch)
        {
            Value = value;
            LeftBranch = leftBranch;
            RightBranch = rightBranch;
        }

        public override string ToString()
        {
            return $"({Value}, {LeftBranch}, {RightBranch})";
        }

    }
}