using System;
using System.Diagnostics;
using System.Security.Cryptography;

class PhanSo
{
    private int Tu;
    private int Mau;

    public void Nhap()
    {
        Console.WriteLine("Nhập tử số: ");
        Tu = int.Parse(Console.ReadLine());
        Console.WriteLine("Nhâp mẫu số: ");
        Mau = int.Parse(Console.ReadLine());    
    }

    public void Xuat()
    {
        Console.WriteLine($"{Tu}/{Mau}");
    }

    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public void RutGon()
    {
        int gcd = GCD(Tu,Mau);
        Tu /= gcd;
        Mau /= gcd;
    }

    public static PhanSo operator +(PhanSo ps1, PhanSo ps2)
    {
        int tu = ps1.Tu * ps2.Mau + ps1.Mau * ps2.Tu;
        int mau = ps1.Mau * ps2.Mau;
        PhanSo result = new PhanSo();
        result.Tu = tu;
        result.Mau = mau;
        result.RutGon();
        return result;
    }

    public static PhanSo operator -(PhanSo ps1, PhanSo ps2)
    {
        int tu = ps1.Tu * ps2.Mau - ps1.Mau * ps2.Tu;
        int mau = ps1.Mau * ps2.Mau;
        PhanSo result = new PhanSo();
        result.Tu = tu;
        result.Mau = mau;
        result.RutGon();
        return result;
    }

    public static PhanSo operator *(PhanSo ps1, PhanSo ps2)
    {
        int tu = ps1.Tu * ps2.Tu;
        int mau = ps1.Mau * ps2.Mau;
        PhanSo result = new PhanSo();
        result.Tu = tu;
        result.Mau = mau;
        result.RutGon();
        return result;
    }

    public static PhanSo operator /(PhanSo ps1, PhanSo ps2)
    {
        int tu = ps1.Tu * ps2.Mau;
        int mau = ps1.Mau * ps2.Tu;
        PhanSo result = new PhanSo();
        result.Tu = tu;
        result.Mau = mau;
        result.RutGon();
        return result;
    }

    public int SoSanh(PhanSo ps)
    {
        float a = Tu / ps.Mau;
        float b = Tu / ps.Mau;
        float c = a - b;
        if (c < 1)
            return -1;
        if (c > 0)
            return 1;
        return 0;
    }

    public static void SapXepTangDan(PhanSo[] arr)
    {
        Array.Sort(arr, (a, b) => a.SoSanh(b));
    }

    // Sắp xếp giảm dần
    public static void SapXepGiamDan(PhanSo[] arr)
    {
        Array.Sort(arr, (a, b) => b.SoSanh(a));
    }
}



class Program
{
    static void Main()
    {
        // Nhập phân số
        PhanSo ps1 = new PhanSo();
        Console.WriteLine("Nhap phan so 1:");
        ps1.Nhap();

        PhanSo ps2 = new PhanSo();
        Console.WriteLine("Nhap phan so 2:");
        ps2.Nhap();

        // Xuất phân số
        Console.WriteLine("\nPhan so 1:");
        ps1.Xuat();
        Console.WriteLine("Phan so 2:");
        ps2.Xuat();

        // Tính toán
        PhanSo psTong = ps1 + ps2;
        Console.WriteLine("\nTong: ");
        psTong.Xuat();

        PhanSo psHieu = ps1 - ps2;
        Console.WriteLine("\nHieu: ");
        psHieu.Xuat();

        PhanSo psTich = ps1 * ps2;
        Console.WriteLine("\nTich: ");
        psTich.Xuat();

        PhanSo psThuong = ps1 / ps2;
        Console.WriteLine("\nThuong: ");
        psThuong.Xuat();

        // So sánh
        int result = ps1.SoSanh(ps2);
        if (result > 0) Console.WriteLine("\nPhan so 1 > Phan so 2");
        else if (result < 0) Console.WriteLine("\nPhan so 1 < Phan so 2");
        else Console.WriteLine("\nPhan so 1 = Phan so 2");

        // Sắp xếp
        PhanSo[] phanSos = { ps1, ps2 };
        Console.WriteLine("\nSap xep tang dan:");
        PhanSo.SapXepTangDan(phanSos);
        foreach (var ps in phanSos)
        {
            ps.Xuat();
        }

        Console.WriteLine("\nSap xep giam dan:");
        PhanSo.SapXepGiamDan(phanSos);
        foreach (var ps in phanSos)
        {
            ps.Xuat();

        }
    }
}