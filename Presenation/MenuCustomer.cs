using System;
using System.Collections.Generic;
using System.Text;
using Demo.Utility;

namespace Demo.Presenation
{
    //Trình bày dữ liệu cho đẹp
    public class MenuCustomer : Menu
    {
        private App mn = new App();
        public MenuCustomer(string[] cs) : base(cs) { }
        public override void ThucHien(int vitri)
        {
            FormCustomer customer = new FormCustomer();

            switch (vitri)
            {
                case 0:
                    customer.NhapHK();
                    break;
                case 1:
                    customer.Hien();
                    break;
                case 2:
                    customer.TimKH();
                    break;
                case 3:
                    customer.XoaKH();
                    break;
                case 4:
                    customer.SuaCS();
                    break;
                case 5:
                    mn.Main(); 
                    break;

            }
        }
    }
}

