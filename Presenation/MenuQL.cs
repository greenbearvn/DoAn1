using System;
using System.Collections.Generic;
using System.Text;
using Demo.Utility;

namespace Demo.Presenation
{
    //Trình bày dữ liệu cho đẹp
    public class MenuQL : Menu
    {
        public MenuQL(string[] mn) : base(mn) { }
        public override void ThucHien(int vitri)
        {
            string[] mn ={
                            " 1.Them thong tin den thoai vao danh sach",
                            " 2.Hien thi danh sach thong tin dien thoai ",
                            " 3.Tim thong tin dien thoai ",
                            " 4.Xoa thong tin dien thoai theo ma",
                            " 5.Thong ke dien thoai con hang ",
                            " 6.Cap nhat thong tin nha cung cap theo ma ",
                            " 7.Sap xep danh sach dien thoai ",
                            " 8.Ket thuc"
                        };
            Demo.Presenation.MenuMobile mndemo = new Demo.Presenation.MenuMobile(mn);
            
            string[] aa ={
                            " 1.Nhap thong tin hoa don",
                            " 2.Hien thi danh sach hoa don ",
                            " 3.Tim hoa don theo ten",
                            " 4.Xoa thong tin hoa don theo ma",
                            " 5.Cap nhat thong tin hoa don theo ma ",
                            " 6.Ket Thuc "
                        };
            Demo.Presenation.MenuHoaDon aademo = new Demo.Presenation.MenuHoaDon(aa);

            string[] cs ={
                            " 1.Them thong tin khach hang moi vao danh sach",
                            " 2.Hien thi cac danh sach khach hang ",
                            " 3.Tim khach hang theo ten",
                            " 4.Xoa thong tin khach hang theo ma",
                            " 5.Cap nhat thong tin khach hang theo ma ",
                            " 6.Ket Thuc "
                        };
            Demo.Presenation.MenuCustomer csdemo = new Demo.Presenation.MenuCustomer(cs);

            string[] em ={
                            " 1.Them thong tin nhan vien moi vao danh sach",
                            " 2.Hien thi danh sach cac nhan vien ",
                            " 3.Tim nhan vien theo ten",
                            " 4.Xoa thong tin nhan vien theo ma",
                            " 5.Ket Thuc",

                        };
            Demo.Presenation.MenuEmployee emdemo = new Demo.Presenation.MenuEmployee(em);

            string[] br ={
                            " 1.Them thong tin nha cung cap moi vao danh sach",
                            " 2.Hien thi danh sach cac nha cung cap ",
                            " 3.Tim nha cung cap theo ten",
                            " 4.Xoa thong tin nha cung cap theo ma",
                            " 5.Ket Thuc",

                        };
            Demo.Presenation.MenuBrand aaa = new Demo.Presenation.MenuBrand(br);

            switch (vitri)
            {
                case 0:
                    mndemo.HienMeNu(10, 10, ConsoleColor.Black, ConsoleColor.DarkGreen, ConsoleColor.DarkBlue, ConsoleColor.White);
                    break;
                case 1:
                    aademo.HienMeNu(10, 10, ConsoleColor.Black, ConsoleColor.DarkGreen, ConsoleColor.DarkBlue, ConsoleColor.White);
                    break;
                case 2:
                    csdemo.HienMeNu(10, 10, ConsoleColor.Black, ConsoleColor.DarkGreen, ConsoleColor.DarkBlue, ConsoleColor.White);
                    break;
                case 3:
                    emdemo.HienMeNu(10, 10, ConsoleColor.Black, ConsoleColor.DarkGreen, ConsoleColor.DarkBlue, ConsoleColor.White);
                    break;
                case 4:
                    aaa.HienMeNu(10, 10, ConsoleColor.Black, ConsoleColor.DarkGreen, ConsoleColor.DarkBlue, ConsoleColor.White);
                    break;
                case 6:
                    Environment.Exit(0);
                    break;

            }
        }
    }
}

