using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_3._3.PizzaTime
{
    public static class Pizza
    {
         public static event EventHandler<string> EndCooked;

         public static string ConfirmOrder(string name, PizzaType pizzaType)
        {
            return Cooking(name, pizzaType);
        }

         private static string Cooking(string name, PizzaType pizzaType)
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
             return GiveOrder(name, pizzaType);
        }

         private static string GiveOrder(string name, PizzaType pizzaType)
        {
            
            OrderTable order = new OrderTable();
            EndCooked?.Invoke(null, order.Order(name, pizzaType));
            return "\n\r" + name + " " + pizzaType;
        }
    }
}
