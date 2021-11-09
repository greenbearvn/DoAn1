using System;
using System.Collections.Generic;
using System.Text;
using Demo.Utility;

namespace Demo.Presenation
{
    //Trình bày dữ liệu cho đẹp
    public class MenuMobile : Menu
    {
        public MenuMobile(string[] mn) : base(mn) { }
        public override void ThucHien(int vitri)
        {
            FormMobile mobile = new FormMobile();
            
            switch (vitri)
            {
                case 0:
                    mobile.NhapMB();
                    break;
                case 1:
                    mobile.Hien();
                    break;
                case 2:
                    mobile.TimDT();
                    break;
                case 3:
                    mobile.XoaMB();
                    break;
                case 4:
                    mobile.ThongKe();
                    break;
                case 5:
                    mobile.SuaMB();
                    break;
                case 6:
                    mobile.Sort();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;

            } 
        } 
    }    
}
