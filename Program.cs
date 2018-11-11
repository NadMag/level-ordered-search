using System;
using System.Collections.Generic;

namespace Level_Ordered_Search
{
    public class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>(Node<int>.CreateNode(1, 2, 3));
            foreach (int item in tree.BreadthFirstTraverse())
            {
                Console.WriteLine(item);
            }
        }
    }
}
