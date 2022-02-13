using System;
using System.Collections.Generic;
using System.Linq;
using SuperArray;
using SuperString;
using Task_3._3.PizzaTime;

namespace Task_3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] mas = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 4 };
            //Console.WriteLine(mas.Summ());
            //Console.WriteLine(mas.AverageValue());
            //Console.WriteLine(mas.MaxRepeatedElement());
            //string str = "пываьлплываьпвав";
            //Console.WriteLine(str.WhatLanguage());
            
            do 
            {
                _ = new Order(GetName(), InputPizzaType());
            } while(GetConsoleIntValue() != 0);
        }
        public static int GetConsoleIntValue()
        {
            string value = Console.ReadLine();
            int result;
            if (Int32.TryParse(value, out result))
                return result;
            Console.WriteLine("Incorrect input! Can't parse to Int32!");
            value = Console.ReadLine();
            if (Int32.TryParse(value, out result))
                return result;
            return 0;
        }
        public static string GetName()
        {
            Console.WriteLine("Input your name");
            return Console.ReadLine();
        }
        private static PizzaType InputPizzaType()
        {

            PizzaType result;
            do
            {
                Console.WriteLine("Выберите пиццу:\n\r1. Маргарита\n\r2. Сырная\n\r3. 4 сезона\n\r4. Пепперони \n\r5. Ветчина и сыр");
            } while (!Enum.TryParse<PizzaType>(Console.ReadLine(), out result));

            return result;
        }
    }
    
}
