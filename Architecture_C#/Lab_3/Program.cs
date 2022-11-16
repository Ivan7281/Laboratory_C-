using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class FastFood
    {
        public static void MakeOrder(int[,] order)
        {
            for (int i = order.GetLength(0) - 1; i >= 0; i--)
            {
                Console.WriteLine($"Meal {order[i, 0]} - {order[i, 1]} times;");
            }
            Console.WriteLine();
        }
    }
    class Sushi
    {
        public static void MakeOrder(int[,] order)
        {
            for (int i = 0; i < order.GetLength(0); i++)
            {
                Console.WriteLine($"Meal {order[0, i]} - {order[1, i]} times;");
            }
            Console.WriteLine();
        }
    }
    class TraditionalUkrainian
    {
        public static void MakeOrder(int[] order)
        {
            foreach (int i in order)
            {
                Console.WriteLine($"Meal {i};");
            }
        }
    }
    class OrderFacade
    {
        public static void MakeOrder(string food, Dictionary<int, int> order)
        {
            switch (food)
            {
                case "fastfood":
                    int[,] processedOrder1 = new int[order.Count, 2];
                    int counter1 = 0;
                    foreach (var item in order)
                    {
                        processedOrder1[counter1, 0] = item.Key;
                        processedOrder1[counter1, 1] = item.Value;
                        counter1++;
                    }
                    FastFood.MakeOrder(processedOrder1);
                    break;

                case "sushi":
                    int[,] processedOrder2 = new int[2, order.Count];
                    int counter2 = 0;
                    foreach (var item in order)
                    {
                        processedOrder2[0, counter2] = item.Key;
                        processedOrder2[1, counter2] = item.Value;
                        counter2++;
                    }
                    Sushi.MakeOrder(processedOrder2);
                    break;

                case "ukr":
                    List<int> processedOrder3 = new List<int>();
                    foreach (var item in order)
                    {
                        for (int i = 0; i < item.Value; i++)
                        {
                            processedOrder3.Add(item.Key);
                        }
                    }
                    TraditionalUkrainian.MakeOrder(processedOrder3.ToArray());
                    break;
                default:
                    throw new Exception("Invalid food");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> order = new Dictionary<int, int>() {
                { 123, 2 },
                { 42, 4 }
            };
            OrderFacade.MakeOrder("fastfood", order);
            OrderFacade.MakeOrder("sushi", order);
            OrderFacade.MakeOrder("ukr", order);
        }
    }
}
