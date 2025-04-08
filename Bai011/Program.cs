using System;

class Program
{
    static double TinhDienTichTamGiac(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        return Math.Abs(x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2;
    }

    static void Main()
    {
        Console.WriteLine("Nhap toa do A (x1, y1): ");
        double x1 = double.Parse(Console.ReadLine());
        double y1 = double.Parse(Console.ReadLine());

        Console.WriteLine("Nhap toa do B (x2, y2): ");
        double x2 = double.Parse(Console.ReadLine());
        double y2 = double.Parse(Console.ReadLine());

        Console.WriteLine("Nhap toa do C (x3, y3): ");
        double x3 = double.Parse(Console.ReadLine());
        double y3 = double.Parse(Console.ReadLine());

        double area = TinhDienTichTamGiac(x1, y1, x2, y2, x3, y3);
        Console.WriteLine($"Dien tich tam giac ABC = {area}");
    }
}
