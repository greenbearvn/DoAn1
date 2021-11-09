using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    class App
    {
        static void Main(string[] args)
        {

            string[] mn ={
                            " 1.Quan ly dien thoai",
                            " 2.Quan ly hoa don",
                            " 3.Quan ly khach hang",
                            " 4.Quan ly nhan vien",
                            " 5.Quan ly nha cung cap",
                            " 6.Ket Thuc "
                        };
            Demo.Presenation.MenuQL mndemo = new Demo.Presenation.MenuQL(mn);
            mndemo.HienMeNu(10, 10, ConsoleColor.Black, ConsoleColor.DarkGreen, ConsoleColor.DarkBlue, ConsoleColor.White);
        }
    }
}
