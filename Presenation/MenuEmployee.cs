using System;
using System.Collections.Generic;
using System.Text;
using Demo.Utility;

namespace Demo.Presenation
{
    //Trình bày dữ liệu cho đẹp
    public class MenuEmployee : Menu
    {
        private App mn = new App();
        public MenuEmployee(string[] em) : base(em) { }
        public override void ThucHien(int vitri)
        {
            FormEmployee employee = new FormEmployee();

            switch (vitri)
            {
                case 0:
                    employee.NhapNV();
                    break;
                case 1:
                    employee.Hien();
                    break;
                case 2:
                    employee.TimNV();
                    break;
                case 3:
                    employee.XoaNV();
                    break;
                case 4:
                    employee.SuaNV();
                    break;
                case 5:
                    mn.Main(); 
                    break;

            }
        }
    }
}

