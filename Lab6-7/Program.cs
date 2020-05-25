using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace Lab6_7
{
    class Program
    {
        static void Main()
        {
            InputEncoding = Encoding.Unicode;
            OutputEncoding = Encoding.Unicode;

            Node[] nodes = { new Node("Київ"), new Node("Житомир"), new Node("Новоград-Волинський"),
                new Node("Рівно"), new Node("Луцьк"), new Node("Бердичів"), new Node("Вінниця"),
                new Node("Хмельницький"), new Node("Тернопіль"), new Node("Шепетовка"), new Node("Біла Церква"),
                new Node("Умань"), new Node("Черкаси"), new Node("Кременчуг"), new Node("Полтава"),
                new Node("Харків"), new Node("Прилуки"), new Node("Суми"), new Node("Миргород") };

            nodes[0].AddChildren(nodes[1]).AddChildren(nodes[10]).AddChildren(nodes[16]);

            nodes[1].AddChildren(nodes[9]).AddChildren(nodes[5]).AddChildren(nodes[2]);

            nodes[2].AddChildren(nodes[3]);

            nodes[3].AddChildren(nodes[4]);

            nodes[5].AddChildren(nodes[6]);

            nodes[6].AddChildren(nodes[7]);

            nodes[7].AddChildren(nodes[8]);

            nodes[10].AddChildren(nodes[11]).AddChildren(nodes[12]).AddChildren(nodes[14]);

            nodes[12].AddChildren(nodes[13]);

            nodes[14].AddChildren(nodes[15]);

            nodes[16].AddChildren(nodes[17]).AddChildren(nodes[18]);

            ConsoleKeyInfo keySwitcher;
            bool repeat;
            do
            {
                WriteLine("Натисніть одну з наступних кнопок:\n" +
                    "1 - DFS\n" +
                    "2 - DLS\n" +
                    "3 - BFS\n\n" +
                    "На екран буде виведено шлях роботи алгоритму по проходженню по графу (DFS / DLS / BFS)\n\n" +
                    "4 - вивести усі маршрути з Києва\n" +
                    "Esc - вихід з програми");
                keySwitcher = ReadKey();

                if (keySwitcher.Key != ConsoleKey.Escape)
                {
                    repeat = true;
                }
                else
                {
                    repeat = false;
                }
                Clear();
                switch (keySwitcher.Key)
                {
                    case ConsoleKey.D1:
                        var search_DFS = new DFS();
                        var path_DFS = search_DFS.DFSList(nodes[8], nodes[15]);
                        PrintPath_DFS(path_DFS);
                        path_DFS = search_DFS.DFSList(nodes[8], nodes[15]);
                        PrintPath_DFS(path_DFS);
                        ReadKey();
                        break;

                    case ConsoleKey.D2:
                        var search_DLS = new DLS();
                        var path_DLS = search_DLS.DLSList(nodes[9], nodes[17], 4);
                        PrintPath_DLS(path_DLS);
                        path_DLS = search_DLS.DLSList(nodes[9], nodes[17], 4);
                        PrintPath_DLS(path_DLS);
                        ReadKey();
                        break;

                    case ConsoleKey.D3:
                        var search_BFS = new BFS();
                        var path_BFS = search_BFS.BFSList(nodes[0], nodes[15]);
                        PrintPath_BFS(path_BFS);
                        path_BFS = search_BFS.BFSList(nodes[0], nodes[15]);
                        PrintPath_BFS(path_BFS);
                        ReadKey();
                        break;

                    case ConsoleKey.D4:
                        var search = new DFS();
                        var path = search.DFSList(nodes[0], nodes[8]);
                        PrintPath_DFS(path);
                        path = search.DFSList(nodes[0], nodes[18]);
                        PrintPath_DFS(path);
                        path = search.DFSList(nodes[0], nodes[17]);
                        PrintPath_DFS(path);
                        path = search.DFSList(nodes[0], nodes[4]);
                        PrintPath_DFS(path);
                        path = search.DFSList(nodes[0], nodes[13]);
                        PrintPath_DFS(path);
                        path = search.DFSList(nodes[0], nodes[15]);
                        PrintPath_DFS(path);
                        path = search.DFSList(nodes[0], nodes[11]);
                        PrintPath_DFS(path);
                        ReadKey();
                        break;

                    case ConsoleKey.Escape:
                        break;
                }
                Clear();
            }
            while (repeat);
        }
        private static void PrintPath_DFS(LinkedList<Node> path_DFS)
        {
            if (path_DFS.Count == 0)
            {
                WriteLine("Граф не має членів");
            }
            else
            {
                WriteLine(string.Join(" ==> ", path_DFS.Select(x => x.Name)));
            }
        }
        private static void PrintPath_DLS(LinkedList<Node> path_DLS)
        {
            if (path_DLS.Count == 0)
            {
                WriteLine("Граф не має членів");
            }
            else
            {
                WriteLine(string.Join(" ==> ", path_DLS.Select(x => x.Name)));
            }
        }
        private static void PrintPath_BFS(LinkedList<Node> path_BFS)
        {
            if (path_BFS.Count == 0)
            {
                WriteLine("Граф не має членів");
            }
            else
            {
                WriteLine(string.Join(" ==> ", path_BFS.Select(x => x.Name)));
            }
        }
    }

    class Node
    {
        public string Name { get; }
        public List<Node> Children { get; }

        public Node(string name)
        {
            Name = name;
            Children = new List<Node>();
        }

        public Node AddChildren(Node node, bool bidirect = true)
        {
            Children.Add(node);
            if (bidirect)
            {
                node.Children.Add(this);
            }
            return this;
        }
    }
}
