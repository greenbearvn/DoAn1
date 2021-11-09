using System;
using System.Collections.Generic;
using System.Text;
using Demo.Utility;

namespace Demo.Presenation
{
    //Trình bày dữ liệu cho đẹp
    public class MenuHoaDon : Menu
    {
        public MenuHoaDon(string[] aa) : base(aa) { }
        public override void ThucHien(int vitri)
        {
            FormHoaDon hoadon = new FormHoaDon();

            switch (vitri)
            {
                case 0:
                    hoadon.NhapHD();
                    break;
                case 1:
                    hoadon.Hien();
                    break;
                case 2:
                    hoadon.TimHD();
                    break;
                case 3:
                    hoadon.XoaHD();
                    break;
                case 4:
                    hoadon.SuaHD();
                    break;
                

                case 5:
                    Environment.Exit(0);
                    break;

            }
        }
    }
}

