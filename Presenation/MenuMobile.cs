using System;
using System.Collections.Generic;
using System.Text;
using Demo.Utility;

namespace Demo.Presenation
{
    //Trình bày dữ liệu cho đẹp
    public class MenuMobile : Menu // Kế thừa từ lớp menu chính
    {
        private App mn = new App();
        public MenuMobile(string[] mn) : base(mn) { } // gọi hàm khởi tạo không tham số của lớp cha
        public override void ThucHien(int vitri) // ghi đè lên hàm thực hiện của lớp cha
        {
            FormMobile mobile = new FormMobile(); // tạo đối tượng mobile sử dụng các chức năng của FormMobile
            
            switch (vitri)
            {
                case 0:
                    mobile.NhapMB(); // Gọi hàm Nhập 
                    break;
                case 1:
                    mobile.Hien(); // gọi hàm hiển thị
                    break;
                case 2:
                    mobile.TimDT(); // gọi hàm tìm
                    break;
                case 3:
                    mobile.XoaMB(); // gọi hàm xóa
                    break;
                case 4:
                    mobile.ThongKe(); // gọi hàm thống kê
                    break;
                case 5:
                    mobile.SuaMB(); // gọi hàm sửa thông tin
                    break;
                case 6:
                    mobile.Sort(); // gọi hàm Sắp xếp
                    break;
                case 7:
                    mn.Main(); // thoát chương trình
                    break;

            } 
        } 
    }    
}
