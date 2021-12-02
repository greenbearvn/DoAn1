using System;
using System.Collections.Generic;
using System.Text;


namespace Demo
{
    class App
    {
        
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            string[] mn ={
                            " ║      1.Quản Lý Điện Thoại     ",
                            " ║      2.Quản Lý Hóa Đơn        ",
                            " ║      3.Quản Lý Khách Hàng     ",
                            " ║      4.Quản Lý Nhân Viên      ",
                            " ║      5.Quản Lý Nhà Cung Cấp     ",
                            " ║      6.Quản Lý Doanh Thu Cửa Hàng     ",
                            " ║      7.Kết Thúc                ",
                            " ╚═════════════════════════════"
                        };
            Demo.Presenation.MenuQL mndemo = new Demo.Presenation.MenuQL(mn);
            mndemo.HienMeNu(35, 10, ConsoleColor.Black, ConsoleColor.Green, ConsoleColor.DarkBlue, ConsoleColor.White);
        }

        internal void Main()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            string[] mn ={
                            " ║      1.Quản Lý Điện Thoại     ",
                            " ║      2.Quản Lý Hóa Đơn        ",
                            " ║      3.Quản Lý Khách Hàng     ",
                            " ║      4.Quản Lý Nhân Viên      ",
                            " ║      5.Quản Lý Nhà Cung Cấp     ",
                            " ║      6.Quản Lý Doanh Thu Cửa Hàng     ",
                            " ║      7.Kết Thúc                ",
                            " ╚═════════════════════════════"
                        };
            Demo.Presenation.MenuQL mndemo = new Demo.Presenation.MenuQL(mn);
            mndemo.HienMeNu(35, 10, ConsoleColor.Black, ConsoleColor.Green, ConsoleColor.DarkBlue, ConsoleColor.White);
        }
    }
}
