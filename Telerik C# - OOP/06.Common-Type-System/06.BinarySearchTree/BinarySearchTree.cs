namespace _06.BinarySearchTree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    struct BinarySearchTree<T> : ICloneable, IEnumerable<TreeNode<T>>
        where T : IComparable<T>
    {
        // Struct field
        public TreeNode<T> Root { get; set; }

        // Struct public methods
        public void Insert(T value)
        {
            this.Root = Insert(value, this.Root);
        }

        public void Remove(T value)
        {
            this.Root = Remove(value, this.Root);
        }

        public void RemoveMin()
        {
            this.Root = RemoveMin(this.Root);
        }

        public T FindMin()
        {
            return ElementAt(FindMin(this.Root));
        }

        public T FindMax()
        {
            return ElementAt(FindMax(this.Root));
        }

        public T Find(T value)
        {
            return ElementAt(Find(value, this.Root));
        }

        public void MakeEmpty()
        {
            this.Root = null;
        }

        public bool IsEmpty()
        {
            return this.Root == null;
        }

        // Overrided methods
        public override string ToString()
        {
            return this.Root.ToString();
        }

        public override int GetHashCode()
        {
            return (dynamic)this.FindMin() ^ (dynamic)this.FindMax();
        }

        public override bool Equals(object obj)
        {
            bool equal = true;
            CheckNodes(this.Root, ((BinarySearchTree<T>)obj).Root, ref equal);
            return equal;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            List<TreeNode<T>> nodes = new List<TreeNode<T>>();
            GetNextNode(Root, ref nodes);

            foreach (TreeNode<T> node in nodes)
                yield return node;
        }

        public void GetNextNode(TreeNode<T> node, ref List<TreeNode<T>> nodes)
        {
            if (node == null) return;

            GetNextNode(node.Left, ref nodes);
            nodes.Add(node);
            GetNextNode(node.Right, ref nodes);
        }

        public object Clone()
        {
            BinarySearchTree<T> clone = new BinarySearchTree<T>();
            CopyNode(this.Root, ref clone);
            return clone;
        }

        // Struct operators       
        public static bool operator ==(BinarySearchTree<T> firstTree, BinarySearchTree<T> secondTree)
        {
            return firstTree.Equals(secondTree);
        }

        public static bool operator !=(BinarySearchTree<T> firstTree, BinarySearchTree<T> secondTree)
        {
            return !(firstTree.Equals(secondTree));
        }

        // Struct private methods
        private T ElementAt(TreeNode<T> node)
        {
            return node == null ? default(T) : node.Element;
        }

        private TreeNode<T> Find(T value, TreeNode<T> node)
        {
            while (node != null)
            {
                if ((value as IComparable).CompareTo(node.Element) < 0)
                {
                    node = node.Left;
                }
                else if ((value as IComparable).CompareTo(node.Element) > 0)
                {
                    node = node.Right;
                }
                else
                {
                    return node;
                }
            }

            return null;
        }

        private TreeNode<T> FindMin(TreeNode<T> node)
        {
            if (node != null)
            {
                while (node.Left != null)
                {
                    node = node.Left;
                }
            }

            return node;
        }

        private TreeNode<T> FindMax(TreeNode<T> node)
        {
            if (node != null)
            {
                while (node.Right != null)
                {
                    node = node.Right;
                }
            }

            return node;
        }

        private TreeNode<T> Insert(T value, TreeNode<T> node)
        {
            if (node == null)
            {
                node = new TreeNode<T>(value);
            }
            else if ((value as IComparable).CompareTo(node.Element) < 0)
            {
                node.Left = Insert(value, node.Left);
            }
            else if ((value as IComparable).CompareTo(node.Element) > 0)
            {
                node.Right = Insert(value, node.Right);
            }
            else
            {
                throw new ArgumentException("The element already exists in the tree! In Binary Search Tree there mustn't have duplicated elements!");
            }

            return node;
        }

        private TreeNode<T> RemoveMin(TreeNode<T> node)
        {
            if (node == null)
            {
                throw new Exception("Item not found");
            }
            else if (node.Left != null)
            {
                node.Left = RemoveMin(node.Left);
                return node;
            }
            else
            {
                return node.Right;
            }
        }

        private TreeNode<T> Remove(T value, TreeNode<T> node)
        {
            if (node == null)
            {
                throw new Exception("Item not found");
            }
            else if ((value as IComparable).CompareTo(node.Element) < 0)
            {
                node.Left = Remove(value, node.Left);
            }
            else if ((value as IComparable).CompareTo(node.Element) > 0)
            {
                node.Right = Remove(value, node.Right);
            }
            else if (node.Left != null && node.Right != null)
            {
                node.Element = FindMin(node.Right).Element;
                node.Right = RemoveMin(node.Right);
            }
            else
            {
                node = (node.Left != null) ? node.Left : node.Right;
            }

            return node;
        }

        private void CheckNodes(TreeNode<T> firstNode, TreeNode<T> secondNode, ref bool equal)
        {
            // The nodes don't exist
            if (firstNode == null && secondNode == null) return;

            // One of the nodes doesn't exist or the nodes aren't equal 
            if ((firstNode != null && secondNode == null) || (firstNode == null && secondNode != null) || firstNode.Element.CompareTo(secondNode.Element) != 0)
            {
                equal = false;
                return;
            }

            CheckNodes(firstNode.Left, secondNode.Left, ref equal);
            CheckNodes(firstNode.Right, secondNode.Right, ref equal);
        }

        private void CopyNode(TreeNode<T> root, ref BinarySearchTree<T> tree)
        {
            if (root == null) return;

            tree.Insert(root.Element);
            CopyNode(root.Left, ref tree);
            CopyNode(root.Right, ref tree);
        }

    }
}
