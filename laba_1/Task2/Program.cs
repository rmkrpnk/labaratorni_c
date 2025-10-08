namespace Task2
{
    public class Program
    {
        static void Main()
        {
            int[] numbers = GenerateRandomArray(10, 1, 100);

            Console.WriteLine("Масив:");
            foreach (var n in numbers)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();

            int sum = GetSum(numbers);
            double avg = GetAverage(numbers);
            int min = GetMin(numbers);
            int max = GetMax(numbers);

            Console.WriteLine($"Сума: {sum}");
            Console.WriteLine($"Середнє: {avg}");
            Console.WriteLine($"Мінімум: {min}");
            Console.WriteLine($"Максимум: {max}");
        }

        public static int[] GenerateRandomArray(int size, int min, int max)
        {
            var rnd = new Random();
            int[] arr = new int[size];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(min, max + 1);
            }
            return arr;
        }

        public static int GetSum(int[] numbers)
        {
            int sum = 0;
            foreach (var n in numbers)
            {
                sum += n;
            }
            return sum;
        }

        public static double GetAverage(int[] numbers)
        {
            if (numbers.Length == 0) return 0;
            return (double)GetSum(numbers) / numbers.Length;
        }

        public static int GetMin(int[] numbers)
        {
            if (numbers.Length == 0) return 0;
            int min = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min) min = numbers[i];
            }
            return min;
        }

        public static int GetMax(int[] numbers)
        {
            if (numbers.Length == 0) return 0;
            int max = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max) max = numbers[i];
            }
            return max;
        }
    }
}