using System;
using System.Collections.Generic;
using System.Text;
using Demo.Utility;

namespace Demo.Presenation
{
    //Trình bày dữ liệu cho đẹp
    public class MenuRevenue : Menu // Kế thừa từ lớp menu chính
    {
        private App mn = new App();
        public MenuRevenue(string[] rv) : base(rv) { } // gọi hàm khởi tạo không tham số của lớp cha
        public override void ThucHien(int vitri) // ghi đè lên hàm thực hiện của lớp cha
        {
            FormHoaDon hoadon = new FormHoaDon(); // tạo đối tượng hoadon sử dụng các chức năng của FormHoaDon

            switch (vitri)
            {
                case 0:
                    hoadon.DoanhThu(); // Gọi hàm Nhập 
                    break;
                case 1:
                    hoadon.DoanhThuThang(); // gọi hàm hiển thị
                    break;
                case 2:
                    hoadon.DoanhThuNgay(); // gọi hàm menu chính
                    break;
                case 3:
                    mn.Main(); // gọi hàm menu chính
                    break;


            }
        }
    }
}
