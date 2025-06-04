//Небезопасный код, указатели. Необходимо построить бинарное дерево из объектов следующей структуры:
//идентификационный номер, наименование животного + 2 поля (указатели): левое поддерево и правое, изначально null.
//Первый элемент – головной указатель.

using System;
using System.Runtime.InteropServices;

namespace Task1
{
    public unsafe struct Node
    {
        public int Id;
        public string Name;
        public Node* Left;
        public Node* Right;
    }
    public unsafe class BinaryTree
    {
        public Node* root;
        public void AddNode(int id, string name)
        {
            if (root == null)
            {
                root = (Node*)NativeMemory.Alloc((nuint)sizeof(Node));
                root->Id = id;
                root->Name = name;
                root->Left = null;
                root->Right = null;
                return;
            }

            Node* current = root;
            while (true)
            {
                if (id < current->Id)
                {
                    if (current->Left == null)
                    {
                        current->Left = (Node*)NativeMemory.Alloc((nuint)sizeof(Node));
                        current->Left->Id = id;
                        current->Left->Name = name;
                        current->Left->Left = null;
                        current->Left->Right = null;
                        break;
                    }
                    current = current->Left;
                }
                else
                {
                    if (current->Right == null)
                    {
                        current->Right = (Node*)NativeMemory.Alloc((nuint)sizeof(Node));
                        current->Right->Id = id;
                        current->Right->Name = name;
                        current->Right->Left = null;
                        current->Right->Right = null;
                        break;
                    }
                    current = current->Right;
                }
            }
        }
        public void PrintTree()
        {
            PrintNode(root, null, "Корень");
        }
        private void PrintNode(Node* node, Node* parent, string branchType)
        {
            if (node == null) return;
            if (parent == null) Console.WriteLine($"[{branchType}] {node->Id} ({node->Name})");
            else Console.WriteLine($"  [{branchType} от {parent->Id}] {node->Id} ({node->Name})");

            PrintNode(node->Left, node, "Левая ветка");
            PrintNode(node->Right, node, "Правая ветка");
        }
    }
    class Program
    {
        static void Main()
        {
            BinaryTree tree = new BinaryTree();

            tree.AddNode(5, "Лев");
            tree.AddNode(3, "Тигр");
            tree.AddNode(7, "Медведь");
            tree.AddNode(2, "Волк");
            tree.AddNode(4, "Лиса");
            tree.AddNode(6, "Зебра");
            tree.AddNode(8, "Слон");

            Console.WriteLine("Список животных:");
            tree.PrintTree();
        }
    }
}
