using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Xml.Linq;
using System;

namespace speedСomparison
{
    internal class Program
    {
        static void Main()
        {
            var list = new List<int>();
            var arrayList = new ArrayList();
            var linkedList = new LinkedList<int>();
            Stopwatch stopwatch = new();

            Comparison((s) => SpeedComparison(list, s), "List");
            Comparison((s) => SpeedComparison(linkedList, s), "LinkedList");
            Comparison((s) => SpeedComparison(arrayList, s), "ArrayList");

            //Вызов методов для поиска 496753-ого элемента в коллекциях;
            FindIElement(list, stopwatch);
            FindIElement(arrayList, stopwatch);
            FindIElement(linkedList, stopwatch);

            //Вызов методов для поиска элементов коллекциях, которые делятся на 777 без остатка;
            DivisionWithoutRemainder(list, stopwatch, "List");
            DivisionWithoutRemainder(arrayList, stopwatch, "ArrayList");
            DivisionWithoutRemainder(linkedList, stopwatch, "LinkedList");
        }

        //Определение метода добавления i-ого элемента и получение времени исполнения в коллекциях с типом List и LinkedList;
        static void SpeedComparison(ICollection<int> list, Stopwatch stopwatch)
        {
            stopwatch.Start();

            for (int i = 1; i <= 1000000; i++)
            {
                list.Add(i);
            }

            stopwatch.Stop();
        }

        //Перегрузка метода SpeedComparison добавления i-ого элемента и получение времени исполнения в коллекциях с типом ArrayList;
        static void SpeedComparison(ArrayList list, Stopwatch stopwatch)
        {
            stopwatch.Start();

            for (int i = 1; i <= 1000000; i++)
            {
                list.Add(i);
            }

            stopwatch.Stop();
        }

        //Определение метода вывода в консоль затраченного времени добавления i-ого элемента в коллекции;
        static void Comparison(Action<Stopwatch> speedTest, string name)
        {
            Stopwatch stopwatch = new();

            speedTest(stopwatch);

            Console.WriteLine("Время затраченное на заполнение {1} составляет: {0}", stopwatch.Elapsed, name);
        }

        //Определение метода поиска 496753-ого элемента в коллекциях с типом List и LinkedList и вывода в консоль;
        static void FindIElement(ICollection<int> list, Stopwatch stopwatch)
        {
            stopwatch.Start();
            list.Select((n, i) => n == 496753);
            stopwatch.Stop();
            Console.WriteLine("Время затраченное на поиск 496753-ий элемент составляет: {0}", stopwatch.Elapsed);
        }

        //Перегрузка метода FindIElement для поиска 496753-ого элемента в коллекции с типом ArrayList и вывода в консоль;
        static void FindIElement(ArrayList list, Stopwatch stopwatch)
        {
            stopwatch.Start();
            list.IndexOf(496753);
            stopwatch.Stop();
            Console.WriteLine("Время затраченное на поиск 496753-ий элемент составляет: {0}", stopwatch.Elapsed);
        }

        //Определение метода нахождение всех элементов, которые делятся на 777 без остатка в коллекциях с типом List и LinkedList и вывода в консоль;
        static void DivisionWithoutRemainder(ICollection<int> list, Stopwatch stopwatch, string name)
        {
            stopwatch.Start();

            foreach (int el in list)
            {
                if (el % 777 == 0)
                {
                    Console.WriteLine($"элемент {el} делится на 777 без остатка в коллекции {name}");
                }
            }

            stopwatch.Stop();
            Console.WriteLine(@"Время затраченное на нахождение всех элементов, которые делятся на 777 без остатка в коллекции {1}: {0}", stopwatch.Elapsed, name);
        }

        //Перегрузка метода DivisionWithoutRemainder нахождение всех элементов, которые делятся на 777 без остатка в коллекциях с типом ArrayList и вывода в консоль;
        static void DivisionWithoutRemainder(ArrayList list, Stopwatch stopwatch, string name)
        {
            stopwatch.Start();

            foreach (int el in list)
            {
                if (el % 777 == 0)
                {
                    Console.WriteLine($"элемент {el} делится на 777 без остатка в коллекции {name}");
                }
            }

            stopwatch.Stop();
            Console.WriteLine(@"Время затраченное на нахождение всех элементов, которые делятся на 777 без остатка в коллекции {1}: {0}", stopwatch.Elapsed, name);
        }
    }
}