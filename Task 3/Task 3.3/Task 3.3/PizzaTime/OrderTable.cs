using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime;

namespace Task_3._3.PizzaTime
{
    public class OrderTable
    {
        public event Action OnPizzaDone = delegate { };
        public Guid NumberOfOrder { get; private set; }
        public string ClientName { get; set; }
        public string Order(string client, PizzaType pizza)
        {
            ClientName = client;
            NumberOfOrder = Guid.NewGuid();
            return PizzaCooking(pizza);
        }
        public string PizzaCooking(PizzaType pizza)
        {
            
            return Pizza.ConfirmOrder(ClientName, pizza);
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
