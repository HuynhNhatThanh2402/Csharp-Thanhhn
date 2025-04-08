using System;
using System.Collections.Generic;

class CSanPham
{
    protected long MaSo { get; set; }
    protected string TieuDe { get; set; }
    protected int Gia { get; set; }

    public virtual void Nhap()
    {
        // Mã mặc định, các lớp con sẽ ghi đè
    }

    public virtual void Xuat()
    {
        // Mã mặc định, các lớp con sẽ ghi đè
    }

    public virtual int TinhTien()
    {
        return 0;
    }
}

class CTranh : CSanPham
{
    protected int ChieuDai { get; set; }
    protected int ChieuRong { get; set; }
    protected string TenHoaSi { get; set; }

    public override void Nhap()
    {
        Console.Write("\nNhap ma san pham: ");
        MaSo = long.Parse(Console.ReadLine());
        Console.Write("\nNhap tieu de: ");
        TieuDe = Console.ReadLine();
        Console.Write("\nNhap gia: ");
        Gia = int.Parse(Console.ReadLine());
        Console.Write("\nNhap chieu dai tranh: ");
        ChieuDai = int.Parse(Console.ReadLine());
        Console.Write("\nNhap chieu rong tranh: ");
        ChieuRong = int.Parse(Console.ReadLine());
        Console.Write("\nNhap ten hoa si: ");
        TenHoaSi = Console.ReadLine();
    }

    public override void Xuat()
    {
        Console.WriteLine("\nMa san pham: " + MaSo);
        Console.WriteLine("Tieu de: " + TieuDe);
        Console.WriteLine("Gia: " + Gia);
        Console.WriteLine("Chieu dai tranh: " + ChieuDai);
        Console.WriteLine("Chieu rong tranh: " + ChieuRong);
        Console.WriteLine("Ten hoa si: " + TenHoaSi);
    }

    public override int TinhTien()
    {
        return Gia;
    }
}

class CDia : CSanPham
{
    protected string TenCaSi { get; set; }
    protected string TenDonVi { get; set; }

    public override void Nhap()
    {
        Console.Write("\nNhap ma san pham: ");
        MaSo = long.Parse(Console.ReadLine());
        Console.Write("\nNhap tieu de: ");
        TieuDe = Console.ReadLine();
        Console.Write("\nNhap gia: ");
        Gia = int.Parse(Console.ReadLine());
        Console.Write("\nNhap ten ca si: ");
        TenCaSi = Console.ReadLine();
        Console.Write("\nNhap ten don vi: ");
        TenDonVi = Console.ReadLine();
    }

    public override void Xuat()
    {
        Console.WriteLine("\nMa san pham: " + MaSo);
        Console.WriteLine("Tieu de: " + TieuDe);
        Console.WriteLine("Gia: " + Gia);
        Console.WriteLine("Ten ca si: " + TenCaSi);
        Console.WriteLine("Ten don vi: " + TenDonVi);
    }

    public override int TinhTien()
    {
        return Gia;
    }
}

class CKhachHang
{
    protected string MaKhachHang { get; set; }
    protected string TenKhachHang { get; set; }
    protected string Phone { get; set; }

    public void Nhap()
    {
        Console.Write("\nNhap ma khach hang: ");
        MaKhachHang = Console.ReadLine();
        Console.Write("\nNhap ten khach hang: ");
        TenKhachHang = Console.ReadLine();
        Console.Write("\nNhap so dien thoai khach hang: ");
        Phone = Console.ReadLine();
    }

    public void Xuat()
    {
        Console.WriteLine("\nMa khach hang: " + MaKhachHang);
        Console.WriteLine("Ten khach hang: " + TenKhachHang);
        Console.WriteLine("So dien thoai khach hang: " + Phone);
    }

    public override bool Equals(object obj)
    {
        if (obj is CKhachHang other)
        {
            return this.MaKhachHang == other.MaKhachHang &&
                   this.TenKhachHang == other.TenKhachHang &&
                   this.Phone == other.Phone;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return MaKhachHang.GetHashCode() ^ TenKhachHang.GetHashCode() ^ Phone.GetHashCode();
    }
}

class CNgay
{
    protected int Ngay { get; set; }
    protected int Thang { get; set; }
    protected int Nam { get; set; }

    public void Nhap()
    {
        Console.Write("\nNhap ngay: ");
        Ngay = int.Parse(Console.ReadLine());
        Console.Write("\nNhap thang: ");
        Thang = int.Parse(Console.ReadLine());
        Console.Write("\nNhap nam: ");
        Nam = int.Parse(Console.ReadLine());
    }

    public void Xuat()
    {
        Console.WriteLine($"({Ngay}/{Thang}/{Nam})");
    }
}

class CHoaDon
{
    protected string MaHoaDon { get; set; }
    protected CSanPham[] Sp { get; set; }
    protected int N { get; set; }
    protected CKhachHang Guest { get; set; }
    protected int TongGiaTri { get; set; }
    protected CNgay NgayLap { get; set; }

    public void Nhap()
    {
        Console.Write("\nNhap ma hoa don: ");
        MaHoaDon = Console.ReadLine();
        Guest = new CKhachHang();
        Guest.Nhap();
        NgayLap = new CNgay();
        NgayLap.Nhap();
        Console.Write("\nNhap so luong san pham: ");
        N = int.Parse(Console.ReadLine());
        Sp = new CSanPham[N];
        for (int i = 0; i < N; i++)
        {
            Console.Write("\nNhap loai san pham (0: Dia CD, 1: Tranh): ");
            int loai = int.Parse(Console.ReadLine());
            switch (loai)
            {
                case 0:
                    Sp[i] = new CDia();
                    break;
                case 1:
                    Sp[i] = new CTranh();
                    break;
            }
            Sp[i].Nhap();
        }
    }

    public void Xuat()
    {
        Console.WriteLine("\nMa hoa don: " + MaHoaDon);
        Guest.Xuat();
        NgayLap.Xuat();
        Console.WriteLine("\nSo luong san pham: " + N);
        for (int i = 0; i < N; i++)
        {
            Console.WriteLine("\nThong tin san pham thu " + (i + 1) + ": ");
            Sp[i].Xuat();
        }
    }

    public void TinhTien()
    {
        int tong = 0;
        for (int i = 0; i < N; i++)
        {
            tong += Sp[i].TinhTien();
        }
        TongGiaTri = tong;
    }

    public int TongTien()
    {
        return TongGiaTri;
    }

    public CKhachHang LayKhach()
    {
        return Guest;
    }
}

class CCuaHang
{
    protected CHoaDon[] Ds { get; set; }
    protected int N { get; set; }
    protected int TongDoanhThu { get; set; }

    public void Nhap()
    {
        Console.Write("\nNhap so luong hoa don: ");
        N = int.Parse(Console.ReadLine());
        Ds = new CHoaDon[N];
        for (int i = 0; i < N; i++)
        {
            Console.Write("\nNhap hoa don thu " + (i + 1) + ": ");
            Ds[i] = new CHoaDon();
            Ds[i].Nhap();
        }
    }

    public void Xuat()
    {
        Console.WriteLine("\nSo luong hoa don: " + N);
        for (int i = 0; i < N; i++)
        {
            Console.WriteLine("\nThong tin hoa don thu " + (i + 1) + ": ");
            Ds[i].Xuat();
        }
    }

    public void TinhDoanhThu()
    {
        int tong = 0;
        for (int i = 0; i < N; i++)
        {
            Ds[i].TinhTien();
            tong += Ds[i].TongTien();
        }
        TongDoanhThu = tong;
    }

    public int DoanhThu()
    {
        return TongDoanhThu;
    }

    public void TimKiem()
    {
        Dictionary<CKhachHang, int> list = new Dictionary<CKhachHang, int>();
        foreach (var hoaDon in Ds)
        {
            CKhachHang temp = hoaDon.LayKhach();
            if (!list.ContainsKey(temp))
            {
                list[temp] = 0;
            }
            list[temp] += hoaDon.TongTien();
        }

        int maxDoanhThu = 0;
        foreach (var item in list)
        {
            if (item.Value > maxDoanhThu)
            {
                maxDoanhThu = item.Value;
            }
        }

        foreach (var item in list)
        {
            if (item.Value == maxDoanhThu)
            {
                item.Key.Xuat();
            }
        }
    }
}

class Program
{
    static void Main()
    {
        CCuaHang store = new CCuaHang();
        store.Nhap();

        CCuaHang shop = new CCuaHang();
        shop = store;

        Console.WriteLine("\nCua hang vua nhap: ");
        shop.Xuat();

        shop.TinhDoanhThu();
        Console.WriteLine("\nTong doanh thu cua hang: " + shop.DoanhThu());

        Console.WriteLine("\nNhung khach hang mua hang nhieu nhat la: ");
        shop.TimKiem();

        Console.WriteLine("\n\n\nKet thuc!!!!!");
    }
}
