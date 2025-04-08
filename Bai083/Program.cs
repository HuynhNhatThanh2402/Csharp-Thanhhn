using System;

class Program
{
    static double TinhS(double x, int n)
    {
        double sum = 0;
        for (int i = 1; i <= n; i++)
        {
            sum += Math.Sin(Math.Pow(x, i)); // sin(x^i)
        }
        return sum;
    }

    static void Main()
    {
        Console.WriteLine("Nhap x: ");
        double x = double.Parse(Console.ReadLine());
        Console.WriteLine("Nhap n: ");
        int n = int.Parse(Console.ReadLine());

        double S = TinhS(x, n);
        Console.WriteLine($"S({x},{n}) = {S}");
    }
}
