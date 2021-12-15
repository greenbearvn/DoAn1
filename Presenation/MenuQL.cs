using System;
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
                            " 1.Thêm thông tin điện thoại vào danh sách",
                            " 2.Hiển thị danh sách thông tin điện thoại ",
                            " 3.Tìm kiếm thông tin điện thoại ",
                            " 4.Xóa thông tin điện thoại theo mã",
                            " 5.Thống kê điện thoại còn hàng ",
                            " 6.Cập nhật thông tin điện thoại theo mã ",
                            " 7.Sắp xếp danh sách điện thoại ",
                            " 8.Quay lại Menu chính"
                        };
            MenuMobile mndemo = new MenuMobile(mn);
            
            string[] aa ={
                            " 1.Nhập thông tin hóa đơn",
                            " 2.Xuất hoá đơn có mã ",
                            " 3.Hiển thị danh sách hóa đơn ",
                            " 4.Tìm kiếm hóa đơn theo mã",
                            " 5.Xóa thông tin hóa đơn theo mã",
                            " 6.Cập nhật thông tin hóa đơn theo mã ",
                            " 7.Sắp xếp danh sách hóa đơn theo giá đơn giảm dần ",
                            " 8.Quay lại Menu chính"
                        };
            MenuHoaDon aademo = new MenuHoaDon(aa);

            string[] cs ={
                            " 1.Thêm thông tin khách hàng mới vào danh sách",
                            " 2.Hiển thị danh sách khách hàng ",
                            " 3.Tìm kiếm thông tin khách hàng",
                            " 4.Xóa hông tin khách hàng theo mã",
                            " 5.Cập nhật thông tin khách hàng theo mã ",
                            " 6.Sắp xếp danh sách khách hàng theo bảng chữ cái",
                            " 7.Quay lại Menu chính"
                        };
            MenuCustomer csdemo = new MenuCustomer(cs);

            string[] em ={
                            " 1.Thêm thông tin nhân viên mới vào danh sách",
                            " 2.Hiển thị danh sách nhân viên ",
                            " 3.Tìm kiếm thông tin nhân viên",
                            " 4.Xóa hông tin nhân viên theo mã",
                            " 5.Cập nhật thông tin nhân viên theo mã ",
                            " 6.Sắp xếp danh sách nhân viên theo bảng chữ cái",
                            " 7.Quay lại Menu chính"

                        };
            MenuEmployee emdemo = new MenuEmployee(em);

            string[] br ={
                            " 1.Thêm thông tin nhà cung cấp mới vào danh sách",
                            " 2.Hiển thị danh sách nhà cung cấp",
                            " 3.Tìm kiếm thông tin nhà cung cấp",
                            " 4.Xóa thông tin nhà cung cấp theo mã",
                            " 5.Cập nhật thông tin nhà cung cấp theo mã ",
                            " 6.Quay lại Menu chính"

                        };
            MenuBrand aaa = new MenuBrand(br);

            string[] rv ={
                            " 1.Thống kê doanh thu của cửa hàng",
                            " 2.Doanh thu của cửa hàng trong tháng và năm",
                            " 3.Doanh thu của cửa hàng trong ngày tháng năm",
                            " 4.Quay lại Menu chính"

                        };
            MenuRevenue bbb = new MenuRevenue(rv);

            switch (vitri)
            {
                case 0:
                    mndemo.HienMeNu(10, 10, ConsoleColor.Black, ConsoleColor.Cyan, ConsoleColor.DarkBlue, ConsoleColor.White);
                    break;
                case 1:
                    aademo.HienMeNu(10, 10, ConsoleColor.Black, ConsoleColor.Cyan, ConsoleColor.DarkBlue, ConsoleColor.White);
                    break;
                case 2:
                    csdemo.HienMeNu(10, 10, ConsoleColor.Black, ConsoleColor.Cyan, ConsoleColor.DarkBlue, ConsoleColor.White);
                    break;
                case 3:
                    emdemo.HienMeNu(10, 10, ConsoleColor.Black, ConsoleColor.Cyan, ConsoleColor.DarkBlue, ConsoleColor.White);
                    break;
                case 4:
                    aaa.HienMeNu(10, 10, ConsoleColor.Black, ConsoleColor.Cyan, ConsoleColor.DarkBlue, ConsoleColor.White);
                    break;
                case 5:
                    bbb.HienMeNu(10, 10, ConsoleColor.Black, ConsoleColor.Cyan, ConsoleColor.DarkBlue, ConsoleColor.White);
                    break;
                case 6:
                    Environment.Exit(0);
                    break;

            }
        }
    }
}

