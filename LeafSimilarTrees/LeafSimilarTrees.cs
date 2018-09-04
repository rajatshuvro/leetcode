using System;
using System.Collections.Generic;
using System.Linq;

namespace LeafSimilarTrees
{
    class LeafSimilarTrees
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Checking if two binary trees are leaf-similar!");

            var result = UnitTest1();
            result &= UnitTest2();

            if (result)
                Console.WriteLine("Passed all unit tests");

            Console.Read();
        }

        private static bool UnitTest2()
        {
            var root1 = GetTreeOne();
            var root2 = GetTreeOne();

            var result = LeafSimilarCheck.LeafSimilar(root1, root2);

            if (! result)
                Console.WriteLine("Failed unit test 2 - comparing two equal trees");

            return result;
        }

        private static TreeNode GetTreeOne()
        {
            var node9 = new TreeNode(9);
            var node8 = new TreeNode(8);
            var node1 = new TreeNode(1)
            {
                left = node9,
                right = node8
            };

            var node7 = new TreeNode(7);
            var node4 = new TreeNode(4);
            var node2 = new TreeNode(2)
            {
                left = node7,
                right = node4
            };

            var node6 = new TreeNode(6);
            var node5 = new TreeNode(5)
            {
                left = node6,
                right = node2
            };

            var node3 = new TreeNode(3)
            {
                left = node5,
                right = node1
            };

            return node3;
        }

        private static bool UnitTest1()
        {
            var leaves = new List<int>();
            LeafSimilarCheck.GetLeaves(GetTreeOne(), leaves);

            if (! leaves.SequenceEqual(new[] {6, 7, 4, 9, 8}))
            {
                Console.WriteLine("Failed test 1- checking leaf sequence");
                return false;
            }

            return true;
        }
    }
}
