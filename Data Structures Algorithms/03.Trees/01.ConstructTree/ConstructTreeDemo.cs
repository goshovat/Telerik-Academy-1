namespace _01.ConstructTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ConstructTreeDemo
    {
        private static TreeNode<int>[] maxPath = new TreeNode<int>[0];
        private static TreeNode<int>[] maxSecondPath = new TreeNode<int>[0];

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var treeNodes = new TreeNode<int>[n];

            for (int i = 0; i < n; i++)
            {
                treeNodes[i] = new TreeNode<int>(i);
            }

            for (int i = 1; i <= n - 1; i++)
            {
                var edgeAsString = Console.ReadLine();
                var edgeParts = edgeAsString.Split(' ');

                var parentId = int.Parse(edgeParts[0]);
                var childId = int.Parse(edgeParts[1]);

                treeNodes[parentId].Childred.Add(treeNodes[childId]);
                treeNodes[childId].HasParent = true;
            }

            var separator = '-';
            var separatorCount = 50;
            Console.WriteLine(new string(separator, separatorCount));

            // A) Find the root
            var root = FindRoot(treeNodes);
            Console.WriteLine("Tree's root: {0}", root.Value);
            Console.WriteLine(new string(separator, separatorCount));

            // B) Find all leaves
            var leafs = FindAllLeaves(treeNodes);
            Console.WriteLine("Leafs: ");
            foreach (var leaf in leafs)
            {
                Console.Write("{0}, ", leaf.Value);
            }

            Console.WriteLine();
            Console.WriteLine(new string(separator, separatorCount));

            // C) Find all middle TreeNodes
            var moddleTreeNodes = FindAllMiddleTreeNodes(treeNodes);
            Console.WriteLine("Middle TreeNodes: ");
            foreach (var treeNode in moddleTreeNodes)
            {
                Console.Write("{0}, ", treeNode.Value);
            }

            Console.WriteLine();
            Console.WriteLine(new string(separator, separatorCount));

            // D) Find the longest path
            FindLongestPathFromLeafToLeaf(root);

            Console.WriteLine(new string(separator, separatorCount));

            // E) Find all paths summed equal to number
            int sum = 6;
            TraverseDFS(treeNodes, sum);
            Console.WriteLine(new string(separator, separatorCount));

            // F) Find all sub trees summed equal to number
            sum = 12;
            TraverseDFSsubTree(treeNodes, sum, root);
            Console.WriteLine(new string(separator, separatorCount));
        }

        private static TreeNode<int> FindRoot(TreeNode<int>[] treeNodes)
        {
            for (int i = 0; i < treeNodes.Length; i++)
            {
                if (!treeNodes[i].HasParent)
                {
                    return treeNodes[i];
                }
            }

            throw new ArgumentException("treeNodes", "The tree has no root");
        }

        private static List<TreeNode<int>> FindAllLeaves(TreeNode<int>[] treeNodes)
        {
            List<TreeNode<int>> leaves = new List<TreeNode<int>>();

            foreach (var treeNode in treeNodes)
            {
                if (treeNode.Childred.Count == 0)
                {
                    leaves.Add(treeNode);
                }
            }

            return leaves;
        }

        private static List<TreeNode<int>> FindAllMiddleTreeNodes(TreeNode<int>[] treeNodes)
        {
            List<TreeNode<int>> midTreeNodes = new List<TreeNode<int>>();

            foreach (var treeNode in treeNodes)
            {
                if (treeNode.HasParent && treeNode.Childred.Count > 0)
                {
                    midTreeNodes.Add(treeNode);
                }
            }

            return midTreeNodes;
        }

        private static void FindLongestPathFromLeafToLeaf(TreeNode<int> root)
        {
            var path = new TreeNode<int>[1];
            var exceptElements = new HashSet<int>();

            FindLongestPathFromRoot(root, path, exceptElements, true);

            Console.WriteLine("Longest path:");

            foreach (var node in maxPath)
            {
                exceptElements.Add(node.Value);
            }

            exceptElements.Remove(root.Value);

            path = new TreeNode<int>[1];
            FindLongestPathFromRoot(root, path, exceptElements, false);

            for (int i = maxPath.Length - 1; i > 0; i--)
            {
                Console.WriteLine(maxPath[i].Value);
            }

            for (int i = 0; i < maxSecondPath.Length; i++)
            {
                Console.WriteLine(maxSecondPath[i].Value);
            }
        }

        private static void FindLongestPathFromRoot(TreeNode<int> root, TreeNode<int>[] path, HashSet<int> exceptElements, bool isFirstMaxPath)
        {
            if (exceptElements.Contains(root.Value))
            {
                return;
            }

            path[path.Length - 1] = root;

            if (isFirstMaxPath)
            {
                if (path.Length > maxPath.Length)
                {
                    maxPath = new TreeNode<int>[path.Length];
                    maxPath = path;
                }
            }
            else
            {
                if (path.Length > maxSecondPath.Length)
                {
                    maxSecondPath = new TreeNode<int>[path.Length];
                    maxSecondPath = path;
                }
            }

            var clonedPath = path.Clone();
            TreeNode<int>[] tempPath = clonedPath as TreeNode<int>[];

            foreach (var treeNode in root.Childred)
            {
                path = new TreeNode<int>[tempPath.Length + 1];

                for (int i = 0; i < tempPath.Length; i++)
                {
                    path[i] = tempPath[i];
                }

                FindLongestPathFromRoot(treeNode, path, exceptElements, isFirstMaxPath);
            }
        }


        private static int CheckSum(int sum, int currentSum, int currentTreeNodeValue, List<int> currentTreeNodes)
        {
            if (currentSum == sum)
            {
                foreach (var treeNodeValue in currentTreeNodes)
                {
                    Console.Write("{0}, ", treeNodeValue);
                }

                Console.WriteLine();
            }

            currentSum = currentSum - currentTreeNodeValue;
            return currentSum;
        }

        private static void TraverseDFS(TreeNode<int>[] treeNodes, int sum)
        {
            Console.WriteLine("The path members which sum is equal to {0} are: ", sum);
            Stack<TreeNode<int>> stack = new Stack<TreeNode<int>>();
            int currentSum = 0;

            foreach (var treeNode in treeNodes)
            {
                List<int> currentTreeNodes = new List<int>();
                stack.Push(treeNode);
                currentSum = 0;
                while (stack.Count > 0)
                {
                    TreeNode<int> currentTreeNode = stack.Pop();
                    if (stack.Count == 0 && currentTreeNode.Childred.Count != 0)
                    {
                        if (currentTreeNode != treeNode)
                        {
                            currentSum = treeNode.Value + currentTreeNode.Value;
                            currentTreeNodes.RemoveAt(currentTreeNodes.Count - 1);
                        }
                        else
                        {
                            currentSum = treeNode.Value;
                        }
                    }
                    else
                    {
                        currentSum = currentTreeNode.Value + currentSum;
                    }

                    currentTreeNodes.Add(currentTreeNode.Value);
                    
                    if (currentTreeNode.Childred.Count > 0)
                    {
                        for (int i = 0; i < currentTreeNode.Childred.Count; i++)
                        {
                            TreeNode<int> childTreeNode = currentTreeNode.Childred[i];
                            stack.Push(childTreeNode);
                        }
                    }
                    else
                    {
                        currentSum = CheckSum(sum, currentSum, currentTreeNode.Value, currentTreeNodes);
                        currentTreeNodes.RemoveAt(currentTreeNodes.Count - 1);
                    }
                }
            }
        }

        private static void TraverseDFSsubTree(TreeNode<int>[] treeNodes, int sum, TreeNode<int> root)
        {
            Console.WriteLine("The subtrees which sum is equal to {0} are: ", sum);
            Stack<TreeNode<int>> stack = new Stack<TreeNode<int>>();
            int currentSum = 0;
            foreach (var treeNode in treeNodes)
            {
                if (treeNode == root)
                {
                    continue;
                }

                List<int> currentSubtreeTreeNodes = new List<int>();
                stack.Push(treeNode);
                currentSum = 0;

                while (stack.Count > 0)
                {
                    TreeNode<int> currentTreeNode = stack.Pop();
                    currentSum = currentTreeNode.Value + currentSum;
                    currentSubtreeTreeNodes.Add(currentTreeNode.Value);
                    for (int i = 0; i < currentTreeNode.Childred.Count; i++)
                    {
                        TreeNode<int> childTreeNode = currentTreeNode.Childred[i];
                        stack.Push(childTreeNode);
                    }
                }

                if (currentSum == sum)
                {
                    foreach (var treeNodeValue in currentSubtreeTreeNodes)
                    {
                        Console.Write("{0}, ", treeNodeValue);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
