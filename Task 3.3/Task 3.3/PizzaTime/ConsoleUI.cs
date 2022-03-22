using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3._3.PizzaTime
{
    static class ConsoleUI
    {
        public static void WriteLine(string name, PizzaType pizzaType)
        {
            Console.WriteLine($"{name}, your pizza \"{pizzaType}\" is done");
        }
        
        public static void WriteLine(string ClientName, int NumberOfOrder, PizzaType pizzaType)
        {
            Console.WriteLine($"{ClientName},  your order number: {NumberOfOrder}({pizzaType})");
        }
    }
}
