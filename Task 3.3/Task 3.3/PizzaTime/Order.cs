using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task_3._3.PizzaTime
{
    public class Order
    {
        public event Action OnPizzaDone = delegate { };
        public int NumberOfOrder { get; private set; } = 100;
        public string ClientName { get; set; }
        public Order(string client, PizzaType pizza)
        {
            ClientName = client;
            NumberOfOrder++;
            PizzaCooking(pizza);
        }
        public void PizzaCooking(PizzaType pizza)
        {
            ConsoleUI.WriteLine(ClientName, NumberOfOrder, pizza);
            Pizza.ConfirmOrder(ClientName, pizza);
        }
    }
    public enum PizzaType
    { 
        None = 0,
        Margarita = 1,
        UltraCheese = 2,
        Quatro = 3,
        BigPepperoni = 4,
        HamAndMushroom = 5

    }
}
