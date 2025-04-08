using System;
using System.Diagnostics;

class Program
{
    static double TinhS(int n, double x)
    {
        double S = 0;
        for (int i = 1; i <= n; i++)
        {
            double Mau = i * (i + 1) / 2.0;

            double Tu = Math.Pow(x, i);

            S += Tu / Mau;
        }
        return S;
    }
    static void Main()
    {
        Console.Write("Nhap gia tri x: ");
        double x = Convert.ToDouble(Console.ReadLine());

        Console.Write("Nhap gia tri n: ");
        int n = Convert.ToInt32(Console.ReadLine());

        double S = TinhS(n, x);

        Console.WriteLine($"S({x},{n}) = {S}");
    }
}