namespace _01.ConstructTree
{
    using System.Collections.Generic;

    public class TreeNode<T>
    {
        public TreeNode() 
        {
            this.Childred = new List<TreeNode<T>>();
        }

        public TreeNode(T value)
            : this()
        {
            this.Value = value;
        }

        public List<TreeNode<T>> Childred { get; set; }

        public T Value { get; set; }

        public bool HasParent { get; set; }
    }
}
