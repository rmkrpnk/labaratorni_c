using System;

namespace Laba5
{
    public abstract class MenuItem
    {
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public string Category { get; protected set; }

        protected MenuItem(string name, decimal price, string category)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Назва була порожня.");
                name = "Без назви";
            }

            if (price < 0)
            {
                Console.WriteLine("Ціна не може бути менше нуля.");
                price = 0;
            }

            Name = name;
            Price = price;
            Category = category;
        }

        public abstract string GetDescription();

        public override string ToString()
        {
            return Name + " (" + Category + ") — " + Price + " грн";
        }
    }
}