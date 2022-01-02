using System;
using System.Collections.Generic;

namespace Task_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle();
            Triangle();
            AnotherTriangle();
            XMasTree();
            SumOfNumbers();
            FontAdjustment();
            ArrayProcessing();
            NoPositive();
            NonNegativeSum();
            TwoDArray();
        }
        public static int GetConsoleIntValue()
        {
            string value = Console.ReadLine();
            int result;
            if (Int32.TryParse(value, out result))
                return result;
            Console.WriteLine("Incorrect input! Can't parse to Int32!");//
            value = Console.ReadLine();
            if (Int32.TryParse(value, out result))
                return result;
            return 0;
        }
        static void Sort(int[] a)
        {
            int temp;
            int i, j;
            int incr = a.Length / 2;
            while (incr > 0)
            {
                for (i = incr; i < a.Length; i++)
                {
                    j = i - incr;
                    while (j >= 0)
                    {
                        if (a[j] > a[j + incr])
                        {
                            temp = a[j];
                            a[j] = a[j + incr];
                            a[j + incr] = temp;
                            j -= incr;
                        }
                        else
                        {
                            j = -1;
                        }
                    }
                }
                incr /= 2;
            }
        }
        public static void Rectangle()
        {
            Console.WriteLine("Input A to Rectangle: ");
            int a = GetConsoleIntValue();
            Console.WriteLine("Input B to Rectangle: ");
            int b = GetConsoleIntValue();
            if (a <= 0 || b <= 0) Console.WriteLine("Incorrect Input!The number must not be less than zero");//
            else
                Console.WriteLine("S = " + a * b);
        }
        public static void Triangle()
        {

            Console.WriteLine("Input N to Triangle: ");
            int n = GetConsoleIntValue();//
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new string('*', i));
            }
        }
        public static void AnotherTriangle()
        {

            Console.WriteLine("Input N to Another Triangle: ");
            int n = GetConsoleIntValue() * 2;
            for (int i = 0; i < n; i++)
            {
                if (i % 2 != 0)
                {
                    Console.Write(new string(' ', (n - i) / 2));//
                    Console.WriteLine(new string('*', i));//
                }
            }
        }
        public static void XMasTree()
        {
            Console.WriteLine("Input N to X-Mas Tree: ");
            int n = GetConsoleIntValue() * 2;
            for (int l = 0; l <= n; l += 2)
            {
                for (int i = 0; i < l; i++)
                {
                    if (i % 2 != 0)
                    {
                        Console.Write(new string(' ', (n - i) / 2));//
                        Console.WriteLine(new string('*', i));//
                    }

                }
            }
        }
        public static void SumOfNumbers()
        {
            Console.WriteLine("\n1.1.5\tSum of numbers.");
            int sum = 0;
            for (int i = 3; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    sum += i;
            }
            Console.WriteLine($"Sum %3 of %5 less 1000 = {sum}");
        }
        public static void Output(List<string> list)
        {

            if (list.Count == 0) Console.WriteLine("Параметры надписи: None");
            else
            {
                list.Sort();
                Console.Write("Параметры надписи: ");
                foreach (var item in list)
                {

                    Console.Write(item + ' ');
                }
                Console.WriteLine();
            }
        }
        public static void FontAdjustment()//
        {
            List<string> list = new List<string>();
            Console.WriteLine("\n1.1.6 Font Adjustment");
            bool temp = true, bold = false, italic = false, underline = false;
            do
            {

                Output(list);
                Console.WriteLine("Введите:\n\t1: bold\n\t2: italic\n\t3: underline");
                switch (GetConsoleIntValue())
                {
                    case 1:
                        bold = !bold;
                        if (bold) list.Add("Bold");
                        else list.Remove("Bold");
                        break;
                    case 2:
                        italic = !italic;
                        if (italic) list.Add("Italic");
                        else list.Remove("Italic");
                        break;
                    case 3:
                        underline = !underline;
                        if (underline) list.Add("Underline");
                        else list.Remove("Underline");
                        break;
                    default:
                        temp = false;
                        break;
                };
            }
            while (temp);
        }
        public static void Random(ref int[] arr)
        {
            Random x = new Random();//Change random numbers
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = x.Next(-100, 100);
            }
        }
        public static int Max(params int[] arr)
        {
            int max = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (max < arr[i])       //find max
                {
                    max = arr[i];
                }
            }
            return max;
        }
        public static int Min(params int[] arr)
        {
            int min = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (min > arr[i])       //find min
                {
                    min = arr[i];
                }
            }
            return min;
        }
        public static void Output(int[] arr)
        {
            Console.Write("Array: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();
        }
        public static void ArrayProcessing()//
        {
            Console.WriteLine("\n1.1.7 Array processing");
            int[] arr = new int[30];
            Random(ref arr);
            Sort(arr);                  //I use my described sorting
            Console.WriteLine($"Min = {Min(arr)} \nMax = {Max(arr)}");
            Output(arr);

        }
        public static void NoPositive()
        {
            Console.WriteLine("\n1.1.8 No positive number in the array.");
            int[,,] mas = { { { 11, 23, -2, 0, -1, -3 }, { -23, -12, -10, 0, -1, -3 }, { 23, 2, 1, 4, 3, 4 }, { 0, 0, 0, 0, 0, 0 }, { -1, -1, -1, -1, -1, -1 } } };
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    for (int k = 0; k < mas.GetLength(2); k++)
                    {
                        if (mas[i, j, k] >= 0)
                        {
                            mas[i, j, k] = 0;
                        }
                        Console.Write($"{mas[i, j, k]} ");
                    }
                    Console.WriteLine();
                }
            }
        }
        public static void NonNegativeSum()
        {
            int[] mass = new int[] { 0, 2, 3, 4, 3, 3, -23, -234, -223, 34, 43, 0, 2, 1, -3452 };  //Sum is 95
            int sum = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] >= 0)
                    sum += mass[i];
            }
            Console.WriteLine($"\n1.1.9.\tNon-Negative Sum = {sum}");
            Output(mass);
        }
        public static void TwoDArray()
        {
            int[,] mas = { { 0, 1, 2, 3, 4, 5, 6 }, { 6, 5, 4, 3, 2, 1, 0 }, { 6, 5, 6, 4, 3, 2, 3 }, { 1, 2, 1, 2, 1, 2, 1 } };
            int sum = 0;
            Console.WriteLine($"\n1.1.10\t2D array.");
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if (mas[i, j] % 2 == 0)
                    {
                        sum += mas[i, j];
                    }
                    Console.Write($"{mas[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"The sum of the numbers in the even position: {sum}");
        }
    }
}