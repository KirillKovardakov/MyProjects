using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Task_3._3.PizzaTime
{
    static public class Pizza
    {
        static public event EventHandler<Order> EndCooked;

        static public void ConfirmOrder(string name, PizzaType pizzaType)
        {
            Cooking(name, pizzaType);
        }

        static private void Cooking(string name, PizzaType pizzaType)
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            GiveOrder(name, pizzaType);
        }

        static private void GiveOrder(string name, PizzaType pizzaType)
        {
            EndCooked?.Invoke(null, new Order(name, pizzaType));
            ConsoleUI. WriteLine(name, pizzaType);
        }
    }
}
