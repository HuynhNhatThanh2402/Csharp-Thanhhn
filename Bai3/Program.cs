using System;
using System.Threading;

class Program
{
    static void Main()
    {
    Console.OutputEncoding = System.Text.Encoding.UTF8;
        string[] ngayTrongTuan = { "Chủ nhật", "Thứ hai", "Thứ ba", "Thứ tư", "Thứ năm", "Thứ sáu", "Thứ bảy" };
        while (true)
        {
            DateTime currentTime = DateTime.Now;

            string dayOfWeek = ngayTrongTuan[(int)currentTime.DayOfWeek];

            Console.Clear();
            Console.WriteLine($"Thời gian hiện tại: {dayOfWeek}, ngày {currentTime:dd}/{currentTime:MM}/{currentTime:yyyy}, thời gian: {currentTime:HH:mm:ss}");

            Thread.Sleep(1000);
        }
    }
}
