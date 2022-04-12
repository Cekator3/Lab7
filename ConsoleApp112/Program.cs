using System;

namespace ConsoleApp111
{
    //Точное решение такого уравнения можно найти при помощи простой подстановки(1 вариант решения)
    class Program
    {
        static void Main()
        {
            //Найти y(3) y(1)=3
            const decimal delta1 = 1m;
            const decimal delta2 = 0.5m;
            const decimal delta3 = 0.1m;
            const decimal delta4 = 0.05m;
            Console.WriteLine("Приближённый метод Эйлера");
            MethodEilera1(delta1);
            MethodEilera1(delta2);
            MethodEilera1(delta3);
            MethodEilera1(delta4);
            MethodEilera1(0.0001m);
            Console.WriteLine("Метод Эйлера с пересчётом");
            MethodEilera2(delta1);

            void MethodEilera1(decimal delta) //приближённый метод(2 вариант решения)
            {
                int i = 0;
                Point[] points = new Point[500000];
                points[i] = new Point() { X = 1, Y = 3, dy = -2.5m };
                for (decimal x = 1m + delta; x <= 3; x += delta)
                {
                    i++;
                    Point a = new Point();
                    a.X = x;
                    a.Y = points[i - 1].Y + points[i - 1].dy * delta;
                    a.dy = (a.Y + 4.5m * (a.X - 1m) - 5.5m) / a.X;

                    points[i] = a;
                }
                Console.WriteLine($"{points[i]} при шаге функции d={delta}");
            }
            void MethodEilera2(decimal delta) //приближённый метод(2 вариант решения)
            {
                int i = 0;
                Point[] points = new Point[500000];
                points[i] = new Point() { X = 1, Y = 3, dy = -2.5m };
                for (decimal delta2 = delta; points[0].X + delta2 <= 3; delta2 += delta)
                {
                    i++;
                    Point a = new Point();
                    a.X = points[0].X + delta2;
                    a.Y = points[0].Y + points[i - 1].dy * delta2;
                    a.dy = (a.Y + 4.5m * (a.X - 1m) - 5.5m) / a.X;

                    points[i] = a;
                }
                Console.WriteLine($"{points[i]} при шаге функции d={delta}");
            }
        }
        struct Point
        {
            public decimal X, Y, dy;
            public override string ToString() => $"[x: {X:f3}; y: {Y:f3}]";
        }
    }
}
