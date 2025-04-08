using System;
class Program
{
static double S(double x, int n)       
    {
        double s = 0;
        for (int i = 1; i <= n; i++)
            s += Math.Pow(-1, i + 1) * Math.Pow(x, i);
        return s;
    }
    static void Main(string[] args)
    {
        Console.Write("Nhap n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Nhap x: ");
        double x = double.Parse(Console.ReadLine());
        double kq = S(x, n);
        Console.WriteLine("Ket qua: S(x,n) = " + kq);
    }
}
