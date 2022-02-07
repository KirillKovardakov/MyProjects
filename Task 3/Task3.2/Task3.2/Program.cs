using System;
using System.Collections.Generic;
using DynamicArray;

namespace Task3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var mas = new DynamicArray<int>(9);
            var list = new List<int>{0, 1, 2, 3, 4, 5, 6, 7};
            var arr = new int[114];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
            }
            DynamicArray<string> mas2 = new DynamicArray<string>();
            var mas3 = new DynamicArray<int>(list);
            mas3.Add(100);
            Stack<int> stack = new Stack<int> ();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4); 
            stack.Push(5);
            mas3.AddRange(stack);
            mas3.AddRange(arr);
            mas3.Remove(8);
            mas3.Insert(8, 200);
            mas3.Insert(128,13);
            Console.WriteLine(mas3.Length());
            Console.WriteLine(mas3.Capacity());
            Print(mas3);
        }
        public static void Print<T>(DynamicArray<T> tempArray)
        {
            for (int i = 0; i < tempArray.Length(); i++)
            {
                Console.Write($"{tempArray[i]} ");
            }
            Console.WriteLine();
        }
    }
}
