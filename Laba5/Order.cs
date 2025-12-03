using System;
using System.Collections.Generic;

namespace Laba5
{
    public class Order
    {
        private static int idCounter = 0;
        private List<MenuItem> items = new List<MenuItem>();

        public int Id { get; private set; }
        public int TableNumber { get; private set; }
        public OrderStatus Status { get; private set; }

        public Order(int tableNumber)
        {
            idCounter++;
            Id = idCounter;
            TableNumber = tableNumber;
            Status = OrderStatus.New;
        }

        public void AddItem(MenuItem item)
        {
            items.Add(item);
            Console.WriteLine("-> Додано: " + item.Name);
        }

        public void RemoveItem(string name)
        {
            MenuItem itemToRemove = null;

            foreach (MenuItem item in items)
            {
                if (item.Name == name)
                {
                    itemToRemove = item;
                    break;
                }
            }

            if (itemToRemove != null)
            {
                items.Remove(itemToRemove);
                Console.WriteLine("-> Видалено: " + itemToRemove.Name);
            }
            else
            {
                Console.WriteLine("-> Позицію не знайдено.");
            }
        }

        public decimal CalculateTotal()
        {
            decimal sum = 0;
            foreach (MenuItem item in items)
            {
                sum += item.Price;
            }
            return sum;
        }

        public void SetStatus(OrderStatus newStatus)
        {
            if (Status == OrderStatus.Paid && newStatus != OrderStatus.Paid)
            {
                Console.WriteLine("Помилка: Замовлення вже оплачено.");
                return;
            }
            Status = newStatus;
            Console.WriteLine("Статус замовлення #" + Id + " змінено на " + Status);
        }

        public void PrintCheck()
        {
            Console.WriteLine();
            Console.WriteLine("--- ЧЕК ЗАМОВЛЕННЯ #" + Id + " ---");
            Console.WriteLine("Стіл: " + TableNumber + " | Статус: " + Status);
            Console.WriteLine("------------------------------");

            if (items.Count == 0)
            {
                Console.WriteLine("  (Порожньо)");
            }
            else
            {
                foreach (MenuItem item in items)
                {
                    if (item is Drink)
                    {
                        Drink drink = (Drink)item;
                        string alcInfo = "";
                        if (drink.IsAlcoholic)
                        {
                            alcInfo = "(18+)";
                        }
                        Console.WriteLine("  " + drink.Name + " " + drink.Volume + "мл - " + drink.Price + " грн " + alcInfo);
                    }
                    else if (item is Dish)
                    {
                        Dish dish = (Dish)item;
                        Console.WriteLine("  " + dish.Name + " (" + dish.Category + ") - " + dish.Price + " грн");
                    }
                }
            }
            Console.WriteLine("------------------------------");
            Console.WriteLine("ВСЬОГО ДО СПЛАТИ: " + CalculateTotal() + " грн");
            Console.WriteLine();
        }
    }
}