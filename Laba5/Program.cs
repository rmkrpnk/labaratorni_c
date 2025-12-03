using System;
using System.Text;

namespace Laba5
{
    class Program
    {
        static void Main(string[] args)
        {
            Restaurant restaurant = new Restaurant();
            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("--- ГОЛОВНЕ МЕНЮ ---");
                Console.WriteLine("1. Переглянути меню");
                Console.WriteLine("2. Створити замовлення");
                Console.WriteLine("3. Додати страву/напій у замовлення");
                Console.WriteLine("4. Змінити статус замовлення");
                Console.WriteLine("5. Показати деталі замовлення (Чек)");
                Console.WriteLine("6. Показати всі замовлення");
                Console.WriteLine("0. Вихід");
                Console.Write("> ");

                string input = Console.ReadLine()!;

                try
                {
                    switch (input)
                    {
                        case "1":
                            restaurant.ShowMenu();
                            break;

                        case "2":
                            Console.Write("Номер столика: ");
                            int table = int.Parse(Console.ReadLine()!);
                            restaurant.CreateOrder(table);
                            break;

                        case "3":
                            Console.Write("ID замовлення: ");
                            int orderId = int.Parse(Console.ReadLine()!);
                            Order currentOrder = restaurant.GetOrder(orderId);

                            if (currentOrder != null)
                            {
                                Console.Write("Назва страви з меню: ");
                                string itemName = Console.ReadLine()!;
                                MenuItem item = restaurant.FindMenuItem(itemName);

                                if (item != null)
                                {
                                    currentOrder.AddItem(item);
                                }
                                else
                                {
                                    Console.WriteLine("Такої страви немає в меню.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Замовлення не знайдено.");
                            }
                            break;

                        case "4":
                            Console.Write("ID замовлення: ");
                            int statusOrderId = int.Parse(Console.ReadLine()!);
                            Order statusOrder = restaurant.GetOrder(statusOrderId);

                            if (statusOrder != null)
                            {
                                Console.WriteLine("Статуси: 0-New, 1-InProgress, 2-Ready, 3-Paid");
                                Console.Write("Новий статус (цифра): ");
                                int statusVal = int.Parse(Console.ReadLine()!);

                                if (statusVal >= 0 && statusVal <= 3)
                                {
                                    statusOrder.SetStatus((OrderStatus)statusVal);
                                }
                                else
                                {
                                    Console.WriteLine("Некоректний статус.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Замовлення не знайдено.");
                            }
                            break;

                        case "5":
                            Console.Write("ID замовлення: ");
                            int checkOrderId = int.Parse(Console.ReadLine()!);
                            Order checkOrder = restaurant.GetOrder(checkOrderId);

                            if (checkOrder != null)
                            {
                                checkOrder.PrintCheck();
                            }
                            else
                            {
                                Console.WriteLine("Замовлення не знайдено.");
                            }
                            break;

                        case "6":
                            restaurant.ShowAllOrders();
                            break;

                        case "0":
                            running = false;
                            break;

                        default:
                            Console.WriteLine("Невідома команда.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Помилка: " + ex.Message);
                }
            }
        }
    }
}