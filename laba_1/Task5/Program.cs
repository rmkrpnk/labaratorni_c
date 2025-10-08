namespace Task5
{
    public class Program
    {
        static void Main()
        {
            int[][] groups = new int[][]
            {
                new int[] { 100, 92, 90, 83, 76, 60, 75, 84, 92, 70, 81, 85 },
                new int[] { 95, 90, 92, 81, 85, 73, 60, 50, 55, 95, 75, 65, 72, 69, 75 },
                new int[] { 100, 50, 95, 97, 95, 94, 93, 82, 90, 91 }
            };

            PrintGroupStatistics(groups);
        }
        public static double GetAverage(int[] marks)
        {
            if (marks.Length == 0) return 0;
            int sum = 0;
            foreach (var m in marks)
            {
                sum += m;
            }
            return (double)sum / marks.Length;
        }
        public static int GetMin(int[] marks)
        {
            if (marks.Length == 0) return 0;
            int min = marks[0];
            for (int i = 1; i < marks.Length; i++)
            {
                if (marks[i] < min) min = marks[i];
            }
            return min;
        }
        public static int GetMax(int[] marks)
        {
            if (marks.Length == 0) return 0;
            int max = marks[0];
            for (int i = 1; i < marks.Length; i++)
            {
                if (marks[i] > max) max = marks[i];
            }
            return max;
        }
        public static void PrintGroupStatistics(int[][] groups)
        {
            for (int i = 0; i < groups.Length; i++)
            {
                double avg = GetAverage(groups[i]);
                int min = GetMin(groups[i]);
                int max = GetMax(groups[i]);

                int avgRounded = (int)System.Math.Round(avg);

                Console.WriteLine($"Група {i + 1}: Середній = {avgRounded}, Мінімальний = {min}, Максимальний = {max}");
            }
        }
    }
}

