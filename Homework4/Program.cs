using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework4
{
    class Program // массивчики
    {
        static void A1(string a) // 1
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == '}')
                    Console.WriteLine();
                if (i != a.Length - 1)
                {
                    if (a[i] != '{' && a[i] != ',' && a[i] != ' ' && a[i] != '}' && (a[i + 1] == ',' || a[i + 1] == '}'))
                        Console.Write(a[i] + " ");
                    else if (a[i] != '{' && a[i] != ',' && a[i] != ' ' && a[i] != '}' && (a[i + 1] != ',' || a[i + 1] != '}'))
                        Console.Write(a[i]);
                }
            }
        }
        static void A2(string a) // 2
        {
            string c = "";
            for (int i = 0; i < a.Length; i++)
            {
                if (i != a.Length - 1)
                {
                    if (a[i] != '{' && a[i] != ',' && a[i] != ' ' && a[i] != '}' && (a[i + 1] == ',' || a[i + 1] == '}'))
                        c = c + a[i] + " ";
                    else if (a[i] != '{' && a[i] != ',' && a[i] != ' ' && a[i] != '}' && (a[i + 1] != ',' || a[i + 1] != '}'))
                        c = c + a[i];
                }
            }
            List<int> d = new List<int>();
            foreach (string i in c.Split())
            {
                if (i != "")
                    d.Add(Convert.ToInt32(i));
            }
            int n = 0;
            foreach (int i in d)
            {
                if (i == d.Max())
                    n += 1;
            }
            Console.WriteLine(d.Max() + " - максимальное значение");
            Console.WriteLine(n + " - количество вхождений максимального значения");
        }
        static (object, object) A3(string a, string b) // 3
        {
            int n = 0;
            int n1 = 0;
            bool tf = true;
            List<char> c = new List<char>();
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == '{')
                    n++;
                else if (a[i] == ',' && tf)
                    n1++;
                else if (a[i] == '}')
                    tf = false;
                else if (a[i] != '{' && a[i] != ',' && a[i] != ' ' && a[i] != '}')
                {
                    c.Add(a[i]);
                }
            }

            string[,] mas_a2 = new string[n, n1 + 1];
            string[] mas_a1 = new string[n1 + 1];
            bool mas_tf;
            if (n >= 2)
            {
                mas_tf = true;
                n -= 1;
                for (int i = 0; i < c.Count; i++)
                    mas_a2[i / n1, i - n1 * (i / n1)] = Convert.ToString(c[i]);
            }
            else
            {
                mas_tf = false;
                for (int i = 0; i < c.Count; i++)
                    mas_a1[i] = Convert.ToString(c[i]);
            }
            n = 0;
            n1 = 1;
            tf = true;
            List<char> c1 = new List<char>();
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] == '{')
                    n++;
                else if (b[i] == ',' && tf)
                    n1++;
                else if (b[i] == '}')
                    tf = false;
                else if (b[i] != '{' && b[i] != ',' && b[i] != ' ' && b[i] != '}')
                {
                    c1.Add(b[i]);
                }
            }
            string[,] mas_b2 = new string[n, n1 + 1];
            string[] mas_b1 = new string[n1 + 1];
            bool mas_tf2;
            if (n >= 2)
            {
                mas_tf2 = true;
                for (int i = 0; i < c1.Count; i++)
                {
                    mas_b2[i / n1, i - n1 * (i / n1)] = Convert.ToString(c1[i]);
                }
            }
            else
            {
                mas_tf2 = false;
                for (int i = 0; i < c1.Count; i++)
                    mas_b1[i] = Convert.ToString(c1[i]);
            }
            if (mas_tf && mas_tf2)
                return (mas_a1, mas_b1);
            else if (mas_tf && (!mas_tf2))
                return (mas_a1, mas_b2);
            else if ((!mas_tf) && mas_tf2)
                return (mas_a2, mas_b1);
            else
                return (mas_a2, mas_b2);
        }
        static void A4(string a, string b) // 4
        {
            int n = 0;
            int n1 = 0;
            int[] len = new int[2];
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == '{')
                    n++;
            }
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] == '{')
                    n1++;
            }
            if (n == 1)
                len[0] = 1;
            else
            {
                n = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] == '}')
                        break;
                    else if (a[i] == ',')
                        n++;
                }
                len[0] = n + 1;
            }
            if (n1 == 1)
                len[1] = 1;
            else
            {
                n1 = 0;
                for (int i = 0; i < b.Length; i++)
                {
                    if (b[i] == '}')
                        break;
                    else if (b[i] == ',')
                        n1++;
                }
                len[1] = n1 + 1;
            }
            Console.WriteLine("(" + len[0] + ", " + len[1] + ")");
        }
        static void A6(string a, string b) // 6
        {
            var sp = A3(a, b);
            string[] a1 = (string[])sp.Item1;
            string[] b1 = (string[])sp.Item2;
            List<string> a2 = new List<string>();
            List<string> b2 = new List<string>();
            foreach(string i in a1)
            {
                a2.Add(i);
            }
            foreach (string i in b1)
            {
                b2.Add(i);
            }
            double kol = 0;
            if (a2.Count >= b2.Count)
            {
                for (int i = 0; i < b2.Count; i++)
                {
                    if (a2[i] == b2[i])
                        kol++;
                }
                Console.WriteLine(kol / Convert.ToDouble(b2.Count);
            }
            else
            {
                for (int i = 0; i < a2.Count; i++)
                {
                    if (a2[i] == b2[i])
                        kol++;
                }
                Console.WriteLine(kol / Convert.ToDouble(a2.Count));
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine(A3(Console.ReadLine(), Console.ReadLine()));
        }
    }
}
