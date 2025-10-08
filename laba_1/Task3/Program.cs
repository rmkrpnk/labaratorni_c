namespace Task3
{
    public class Program
    {
        static void Main()
        {
            Console.Write("Введіть вік: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int age))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Console.WriteLine(ClassifyAge(age));
        }

        public static string ClassifyAge(int age)
        {
            if (age < 0 || age > 120) return "Нереальний вік";
            if (age < 12) return "Ви дитина";
            if (age <= 17) return "Підліток";
            if (age <= 59) return "Дорослий";
            return "Пенсіонер";
        }
    }
}