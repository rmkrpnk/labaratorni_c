namespace Laba5
{
    public class Drink : MenuItem
    {
        public double Volume { get; private set; }
        public bool IsAlcoholic { get; private set; }

        public Drink(string name, decimal price, double volume, bool isAlcoholic)
            : base(name, price, "Напій")
        {
            Volume = volume;
            IsAlcoholic = isAlcoholic;
        }

        public override string GetDescription()
        {
            string type = IsAlcoholic ? "Алк." : "Безалк.";
            return "[Напій] " + Name + " (" + Volume + " мл, " + type + ")";
        }
    }
}