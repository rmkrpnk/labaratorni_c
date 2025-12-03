using System;
using System.Collections.Generic;

namespace Laba5
{
    public class Restaurant
    {
        private List<MenuItem> menu = new List<MenuItem>();
        private List<Order> orders = new List<Order>();

        public Restaurant()
        {
            SeedMenu();
        }

        private void SeedMenu()
        {
            menu.Add(new Dish("Борщ", 120, "Перше"));
            menu.Add(new Dish("Стейк", 350, "М'ясо"));
            menu.Add(new Dish("Цезар", 180, "Салат"));
            menu.Add(new Drink("Кава", 60, 200, false));
            menu.Add(new Drink("Сік", 70, 250, false));
            menu.Add(new Drink("Вино", 150, 150, true));
        }

        public void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("=== МЕНЮ РЕСТОРАНУ ===");
            foreach (MenuItem item in menu)
            {
                Console.WriteLine(item.GetDescription() + " - " + item.Price + " грн");
            }
        }

        public MenuItem FindMenuItem(string name)
        {
            foreach (MenuItem item in menu)
            {
                if (item.Name.ToLower() == name.ToLower())
                {
                    return item;
                }
            }
            return null;
        }

        public void CreateOrder(int tableNumber)
        {
            Order newOrder = new Order(tableNumber);
            orders.Add(newOrder);
            Console.WriteLine("Замовлення #" + newOrder.Id + " створено для столика " + tableNumber);
        }

        public Order GetOrder(int id)
        {
            foreach (Order order in orders)
            {
                if (order.Id == id)
                {
                    return order;
                }
            }
            return null;
        }

        public void ShowAllOrders()
        {
            Console.WriteLine();
            Console.WriteLine("=== АКТИВНІ ЗАМОВЛЕННЯ ===");
            foreach (Order order in orders)
            {
                Console.WriteLine("ID: " + order.Id + " | Стіл: " + order.TableNumber + " | Статус: " + order.Status + " | Сума: " + order.CalculateTotal() + " грн");
            }
        }
    }
}