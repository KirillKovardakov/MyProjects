using System;
using System.Collections.Generic;
using System.Linq;
using SuperArray;
using SuperString;

namespace Task_3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 4 };
            Console.WriteLine(mas.Summ());
            Console.WriteLine(mas.AverageValue());
            Console.WriteLine(mas.MaxRepeatedElement());
            string str = "в";
            Console.WriteLine(str.WhatLanguage());
            //Console.WriteLine(Console.ReadLine().WhatLanguage());
        }
    }
    
}
