namespace Task4
{
    public class Program
    {
        static void Main()
        {
            Console.Write("Введіть a: ");
            string sa = Console.ReadLine();
            Console.Write("Введіть b: ");
            string sb = Console.ReadLine();
            Console.Write("Введіть c: ");
            string sc = Console.ReadLine();

            if (!double.TryParse(sa, out double a) ||
                !double.TryParse(sb, out double b) ||
                !double.TryParse(sc, out double c))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            if (!IsValidTriangle(a, b, c))
            {
                Console.WriteLine("Нереальні сторони або трикутник не існує");
                return;
            }

            double p = GetPerimeter(a, b, c);
            double area = GetArea(a, b, c);
            string type = GetTriangleType(a, b, c);

            Console.WriteLine($"Периметр: {p}");
            Console.WriteLine($"Площа: {area}");
            Console.WriteLine($"Тип: {type}");
        }

        public static bool IsValidTriangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0) return false;
            return a + b > c && a + c > b && b + c > a;
        }

        public static double GetPerimeter(double a, double b, double c)
        {
            return a + b + c;
        }

        public static double GetArea(double a, double b, double c)
        {
            double s = GetPerimeter(a, b, c) / 2.0;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

        public static string GetTriangleType(double a, double b, double c)
        {
            const double eps = 1e-6;

            bool eqAB = Math.Abs(a - b) < eps;
            bool eqBC = Math.Abs(b - c) < eps;
            bool eqAC = Math.Abs(a - c) < eps;

            if (eqAB && eqBC) return "рівносторонній";

            double a2 = a * a, b2 = b * b, c2 = c * c;
            bool right = Math.Abs(a2 + b2 - c2) < eps ||
                         Math.Abs(a2 + c2 - b2) < eps ||
                         Math.Abs(b2 + c2 - a2) < eps;

            if (right) return "прямокутний";
            if (eqAB || eqBC || eqAC) return "рівнобедрений";
            return "довільний";
        }
    }
}