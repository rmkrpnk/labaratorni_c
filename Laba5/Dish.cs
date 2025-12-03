namespace Laba5
{
    public class Dish : MenuItem
    {
        public Dish(string name, decimal price, string category = "Страва")
            : base(name, price, category)
        {
        }

        public override string GetDescription()
        {
            return "[Їжа] " + Name + " (" + Category + ")";
        }
    }
}