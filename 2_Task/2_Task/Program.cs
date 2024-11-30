using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Кiлькiсть тестiв: ");
            int c = int.Parse(Console.ReadLine()); // Кількість тестів
            Console.WriteLine("----------------------------------------");

            for (int t = 0; t < c; t++)
            {
                // Зчитуємо дані для кожного тесту
                Console.WriteLine($"Даннi для {t+1} тесту:");
                string[] input = Console.ReadLine().Split();
                int n = int.Parse(input[0]);       // Кількість вершин
                string preorder = input[1];       // Прямий обхід
                string inorder = input[2];        // Центрований обхід

                // Відновлюємо обернений обхід
                string postorder = GetPostorder(preorder, inorder);
                Console.WriteLine($"Обернений обхiд: {postorder}");
                Console.WriteLine("----------------------------------------");
            }
        }

        static string GetPostorder(string preorder, string inorder)
        {
            if (string.IsNullOrEmpty(preorder) || string.IsNullOrEmpty(inorder))
                return "";

            // Кореневий вузол дерева — це перший символ у прямому обході
            char root = preorder[0];

            // Знаходимо позицію кореня в центрованому обході
            int rootIndex = inorder.IndexOf(root);

            // Ліва частина центрованого обходу — це ліве піддерево
            string leftInorder = inorder.Substring(0, rootIndex);

            // Права частина центрованого обходу — це праве піддерево
            string rightInorder = inorder.Substring(rootIndex + 1);

            // Відповідні частини прямого обходу для лівого та правого піддерев
            string leftPreorder = preorder.Substring(1, leftInorder.Length);
            string rightPreorder = preorder.Substring(1 + leftInorder.Length);

            // Рекурсивно обробляємо ліве і праве піддерева
            string leftPostorder = GetPostorder(leftPreorder, leftInorder);
            string rightPostorder = GetPostorder(rightPreorder, rightInorder);

            // Формуємо обернений обхід: ліва частина + права частина + корінь
            return leftPostorder + rightPostorder + root;
        }
    }
}
