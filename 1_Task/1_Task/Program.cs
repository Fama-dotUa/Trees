using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Генеруємо дерево з випадковою кількістю вузлів
            Console.WriteLine("Enter the number of nodes for the tree:");
            int nodeCount = int.Parse(Console.ReadLine());

            TreeNode root = GenerateRandomBST(nodeCount, 1, 100); // Значення вузлів у діапазоні [1, 100]

            Console.WriteLine("\nGenerated Binary Search Tree:");
            PrintTree(root);

            // Введення меж діапазону
            Console.WriteLine("\nEnter low value:");
            int low = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter high value:");
            int high = int.Parse(Console.ReadLine());

            // Обчислення суми значень вузлів у діапазоні
            int result = RangeSumBST(root, low, high);
            Console.WriteLine($"\nSum of nodes in range [{low}, {high}]: {result}");
        }

        static Random random = new Random();

        // Генерує рандомне дерево пошуку
        static TreeNode GenerateRandomBST(int nodeCount, int minValue, int maxValue)
        {
            if (nodeCount == 0) return null;

            if (minValue > maxValue)
            {
                int abs = minValue;
                minValue = maxValue;
                maxValue = abs+5;
            }; 

            int rootValue = random.Next(minValue, maxValue + 1);
            TreeNode root = new TreeNode(rootValue);

            int leftCount = random.Next(0, nodeCount); // Кількість вузлів у лівому піддереві
            int rightCount = nodeCount - 1 - leftCount;

            root.Left = GenerateRandomBST(leftCount, minValue, rootValue - 1);  // Ліве піддерево
            root.Right = GenerateRandomBST(rightCount, rootValue +1, maxValue); // Праве піддерево

            return root;
        }

        // Виводить дерево у вигляді ієрархії
        static void PrintTree(TreeNode root, string indent = "", bool isLeft = true)
        {
            if (root != null)
            {
                Console.WriteLine($"{indent}{(isLeft ? "├──" : "└──")}{root.Val}");
                PrintTree(root.Left, indent + (isLeft ? "│   " : "    "), true);
                PrintTree(root.Right, indent + (isLeft ? "│   " : "    "), false);
            }
        }

        static int RangeSumBST(TreeNode root, int low, int high)
        {
            if (root == null)
                return 0;

            int sum = 0;

            if (root.Val >= low && root.Val <= high)
            {
                sum += root.Val;
            }

            if (root.Val > low)
            {
                sum += RangeSumBST(root.Left, low, high);
            }

            if (root.Val < high)
            {
                sum += RangeSumBST(root.Right, low, high);
            }

            return sum;
        }
    }

    class TreeNode
    {
        public int Val;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            Val = val;
            Left = left;
            Right = right;
        }
    }

}
