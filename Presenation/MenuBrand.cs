using System;
using System.Collections.Generic;
using System.Text;
using Demo.Utility;

namespace Demo.Presenation
{
    //Trình bày dữ liệu cho đẹp
    public class MenuBrand : Menu
    {
        private App mn = new App();
        public MenuBrand(string[] cs) : base(cs) { }
        public override void ThucHien(int vitri)
        {
            FormBrand customer = new FormBrand();

            switch (vitri)
            {
                case 0:
                    customer.NhapNCC();
                    break;
                case 1:
                    customer.Hien();
                    break;
                case 2:
                    customer.TimNCC();
                    break;
                case 3:
                    customer.XoaNCC();
                    break;
                case 4:
                    customer.SuaNCC();
                    break;
                case 5:
                    mn.Main();
                    break;

            }
        }
    }
}

