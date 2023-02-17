using System;

namespace ConsoleApp
{
    class Program
    {
        static List<string> path = new List<string>();

        static bool DFS(int[,] arr, int[] mark, int from, int to)
        {
            if (from == to)
            {
                path.Add(Convert.ToString(from));
                return true;
            }
            mark[from] = 1;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (arr[from, i] == 1)
                {
                    if (mark[i] != 1)
                    {
                        if (DFS(arr, mark, i, to))
                        {
                            path.Add(Convert.ToString(from));
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        static void GetPath()
        {
            Console.Write("Путь: ");
            path.Reverse();
            for (int i = 0; i < path.Count; i++)
            {
                if (i != path.Count - 1)
                {
                    Console.Write(path.ElementAt(i) + "-");
                }
                else
                {
                    Console.Write(path.ElementAt(i));
                }
            }
            path.Clear();
        }

        static void Main(string[] args)
        {
            Console.Write("Введите количество вершин -> ");
            int n = int.Parse(Console.ReadLine());
            int[,] arr = new int[n, n];

            Console.WriteLine("====Ввод матрицы====");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{i},{j} = ");
                    arr[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.Clear();
            Console.WriteLine("=====Матрица=====\n");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            int[] mark = new int[n];

            for (int i = 0; i < n - 1; i++)
            {
                Array.Clear(mark);
                for (int j = i + 1; j < n; j++)
                {
                    bool flag = false;
                    if (DFS(arr, mark, i, j))
                    {
                        Console.WriteLine($"Из {i} в {j} можно попасть");
                        Array.Clear(mark);
                        GetPath();
                        Console.WriteLine();
                        flag = true;
                    }
                    else
                    {
                        Array.Clear(mark);
                        path.Clear();
                        if (DFS(arr, mark, j, i))
                        {
                            Console.WriteLine($"Из {j} в {i} можно попасть");
                            Array.Clear(mark);
                            GetPath();
                            Console.WriteLine();
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        Console.WriteLine($"Между {i} и {j} нет пути");
                        Console.WriteLine("Не верно, что для любой пары вершин заданного орграфа одна из этих вершин достижима из другой!");
                        return;
                    }
                }
            }
            Console.WriteLine("Верно, что для любой пары вершин заданного орграфа одна из этих вершин достижима из другой!");
        }
    }
}
