using System;

namespace BSTIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's iterate through a binary search tree!");

            var result = UnitTest1();
            result &= UnitTest2();
            result &= UnitTest3();
            result &= UnitTest4();
            result &= UnitTest5();

            if (result)
                Console.WriteLine("Passed all unit tests");

            Console.Read();
        }

        private static bool UnitTest2()
        {
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node1 = new TreeNode(1);
            node2.left = node1;
            node2.right = node3;

            var iterator = new BSTIterator(node2);

            if (!iterator.HasNext())
            {
                Console.WriteLine("Failed has next in UT 2");
                return false;
            }
            if (iterator.Next() != 1)
            {
                Console.WriteLine("Failed to get next in UT 2");
                return false;
            }
            if (!iterator.HasNext())
            {
                Console.WriteLine("Failed has next after extraction in UT 2");
                return false;
            }
            if (iterator.Next() != 2)
            {
                Console.WriteLine("Failed to get next in UT 2");
                return false;
            }
            if (!iterator.HasNext())
            {
                Console.WriteLine("Failed has next after extraction in UT 2");
                return false;
            }
            if (iterator.Next() != 3)
            {
                Console.WriteLine("Failed to get next in UT 2");
                return false;
            }
            if (iterator.HasNext())
            {
                Console.WriteLine("Failed has next after extraction in UT 2");
                return false;
            }
            return true;
        }

        private static bool UnitTest5()
        {
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node1 = new TreeNode(1);
            node3.left = node1;
            node1.right = node2;

            var iterator = new BSTIterator(node3);

            if (!iterator.HasNext())
            {
                Console.WriteLine("Failed has next in UT 5");
                return false;
            }
            if (iterator.Next() != 1)
            {
                Console.WriteLine("Failed to get next in UT 5");
                return false;
            }
            if (!iterator.HasNext())
            {
                Console.WriteLine("Failed has next after extraction in UT 5");
                return false;
            }
            if (iterator.Next() != 2)
            {
                Console.WriteLine("Failed to get next in UT 5");
                return false;
            }
            if (!iterator.HasNext())
            {
                Console.WriteLine("Failed has next after extraction in UT 5");
                return false;
            }
            if (iterator.Next() != 3)
            {
                Console.WriteLine("Failed to get next in UT 5");
                return false;
            }
            if (iterator.HasNext())
            {
                Console.WriteLine("Failed has next after extraction in UT 5");
                return false;
            }
            return true;
        }

        private static bool UnitTest3()
        {
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node1 = new TreeNode(1);
            node3.left = node2;
            node2.left = node1;

            var iterator = new BSTIterator(node3);

            if (!iterator.HasNext())
            {
                Console.WriteLine("Failed has next in UT 3");
                return false;
            }
            if (iterator.Next() != 1)
            {
                Console.WriteLine("Failed to get next in UT 3");
                return false;
            }
            if (!iterator.HasNext())
            {
                Console.WriteLine("Failed has next after extraction in UT 3");
                return false;
            }
            if (iterator.Next() != 2)
            {
                Console.WriteLine("Failed to get next in UT 3");
                return false;
            }
            if (!iterator.HasNext())
            {
                Console.WriteLine("Failed has next after extraction in UT 3");
                return false;
            }
            if (iterator.Next() != 3)
            {
                Console.WriteLine("Failed to get next in UT 3");
                return false;
            }
            if (iterator.HasNext())
            {
                Console.WriteLine("Failed has next after extraction in UT 3");
                return false;
            }
            return true;
        }

        private static bool UnitTest4()
        {
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node1 = new TreeNode(1);
            node1.right = node2;
            node2.right = node3;

            var iterator = new BSTIterator(node1);

            if (!iterator.HasNext())
            {
                Console.WriteLine("Failed has next in UT 4");
                return false;
            }
            if (iterator.Next() != 1)
            {
                Console.WriteLine("Failed to get next in UT 4");
                return false;
            }
            if (!iterator.HasNext())
            {
                Console.WriteLine("Failed has next after extraction in UT 4");
                return false;
            }
            if (iterator.Next() != 2)
            {
                Console.WriteLine("Failed to get next in UT 4");
                return false;
            }
            if (!iterator.HasNext())
            {
                Console.WriteLine("Failed has next after extraction in UT 4");
                return false;
            }
            if (iterator.Next() != 3)
            {
                Console.WriteLine("Failed to get next in UT 4");
                return false;
            }
            if (iterator.HasNext())
            {
                Console.WriteLine("Failed has next after extraction in UT 4");
                return false;
            }
            return true;
        }

        private static bool UnitTest1()
        {
            var iterator = new BSTIterator(new TreeNode(1));

            if (!iterator.HasNext()) 
            {
                Console.WriteLine("Failed has next in UT 1");
                return false;
            }
            if (iterator.Next() != 1)
            {
                Console.WriteLine("Failed to get next in UT 1");
                return false;
            }
            if (iterator.HasNext())
            {
                Console.WriteLine("Failed has next after extraction in UT 1");
                return false;
            }

            return true;
        }
    }
}
