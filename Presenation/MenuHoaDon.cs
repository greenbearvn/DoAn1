using System;
using System.Collections.Generic;
using System.Text;
using Demo.Utility;

namespace Demo.Presenation
{
    //Trình bày dữ liệu cho đẹp
    public class MenuHoaDon : Menu // Kế thừa từ lớp menu chính
    {
        public MenuHoaDon(string[] aa) : base(aa) { } // gọi hàm khởi tạo không tham số của lớp cha
        public override void ThucHien(int vitri) // ghi đè lên hàm thực hiện của lớp cha
        {
            FormHoaDon hoadon = new FormHoaDon(); // tạo đối tượng hoadon sử dụng các chức năng của FormHoaDon

            switch (vitri)
            {
                case 0:
                    hoadon.NhapHD(); // Gọi hàm Nhập 
                    break;
                case 1:
                    hoadon.Hien(); // gọi hàm hiển thị
                    break;
                case 2:
                    hoadon.TimHD(); // gọi hàm tìm
                    break;
                case 3:
                    hoadon.XoaHD(); // gọi hàm xóa
                    break;
                case 4:
                    hoadon.SuaHD(); // gọi hàm sửa thông tin
                    break;
                case 5:
                    Environment.Exit(0); // gọi hàm Sắp xếp
                    break;

            }
        }
    }
}

