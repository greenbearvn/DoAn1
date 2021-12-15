using System;
using System.Collections.Generic;
using System.Text;
using Demo.Utility;

namespace Demo.Presenation
{
    //Trình bày dữ liệu cho đẹp
    public class MenuSearch : Menu // Kế thừa từ lớp menu chính
    {
        private App mn = new App();
        public MenuSearch(string[] rv) : base(rv) { } // gọi hàm khởi tạo không tham số của lớp cha
        public override void ThucHien(int vitri) // ghi đè lên hàm thực hiện của lớp cha
        {
            FormMobile mobile = new FormMobile();// tạo đối tượng hoadon sử dụng các chức năng của FormHoaDon

            switch (vitri)
            {
                case 0:
                    mobile.TimID(); // Gọi hàm Nhập 
                    break;
                case 1:
                    mobile.TimDT(); // gọi hàm hiển thị
                    break;
                case 2:
                    mobile.TimGia(); // gọi hàm hiển thị
                    break;
                case 3:
                    mobile.TimType(); // gọi hàm menu chính
                    break;
                case 4:
                    mn.Main(); // gọi hàm menu chính
                    break;

            }
        }
    }
}
