using System;

class Program
{
    static int DemSoLuongChuSo(int n)
    {
        if (n == 0) return 1;
        int i = 0;
        while (n != 0)
        {
            n /= 10;
            i++;
        }
        return i;
    }

    static void Main()
    {
        Console.WriteLine("Nhap n: ");
        int n = int.Parse(Console.ReadLine());
        int S = DemSoLuongChuSo(n);
        Console.WriteLine($"So luong chu so cua {n} la {S}");
    }
}
