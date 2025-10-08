namespace Task1
{
    public class Program
    {
        static void Main()
        {
            Console.Write("Введіть число: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                Console.WriteLine(GetMessage(number));
            }
            else
            {
                Console.WriteLine("Некоректний ввід");
            }
        }
        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }
        public static string GetMessage(int number)
        {
            return IsEven(number) ? "Двері відкриваються!" : "Двері зачинені...";
        }
    }
}