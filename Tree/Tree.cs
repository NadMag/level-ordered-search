using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Level_Ordered_Search
{
    public class Tree<T>
    {
        public Node<T> Root { get; set; }
        public Tree(Node<T> root)
        {
            this.Root = root;
        }

        public override string ToString()
        {
            return Root.ToString();
        }

        private IEnumerable<T> GetNodesAtHight(Node<T> root, int hightFromRoot)
        {
            Debug.WriteLine("GetNodeAtHight: root, level" + hightFromRoot);
            if (root == null) yield break;

            if (hightFromRoot == 0) yield return root.Value;

            else if (hightFromRoot > 0)
            {
                var a = GetNodesAtHight(root.LeftBranch, hightFromRoot - 1);
                var b = GetNodesAtHight(root.RightBranch, hightFromRoot - 1);
                foreach (var c in a.Concat(b))
                {
                    yield return c;
                }
            }
        }

        private int ComputeHeight(Node<T> node)
        {
            if (node == null) return 0;

            int leftDepth = ComputeHeight(node.LeftBranch);
            int rightDepth = ComputeHeight(node.LeftBranch);

            return Math.Max(leftDepth, rightDepth) + 1;

        }
        public IEnumerable<T> BreadthFirstTraverse()
        {
            int height = ComputeHeight(Root);
            for (int i = 0; i < height; i++)
            {
                Debug.WriteLine("height: " + i);

                var nodes = GetNodesAtHight(Root, i);

                foreach (T value in nodes)
                {
                    Debug.WriteLine("Following value yielded: " + value);
                    yield return value;
                    Debug.WriteLine("After yield");
                }
            }
        }
    }
}