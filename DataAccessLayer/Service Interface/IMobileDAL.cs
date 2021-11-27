using System;
using System.Collections.Generic;
using System.Text;
using Demo.DataAccessLayer;
using Demo.Entities;
namespace Demo.DataAccessLayer.Services
{
    //Xác định các yêu cầu cần phải thao tác với cơ sở dữ liệu để phục vụ cho phần xử lý nghiệp vụ
    interface IMobileDAL
    {
        List<Mobile> GetAllData(); // Khai báo phương thức lấy tất cả dữ liệu từ tệp Mobile.txt
        List<Mobile> GetThongKe(); // Khai báo phương thức lấy tất cả dữ liệu đã thống kê từ tệp ThongKe.txt
        List<Mobile> GetSort();
        void Add(Mobile mb); // Khai báo phương thức thêm thông tin điện thoại với tham số truyền vào là đối tượng điện thoại
        void Delete(int id); // Khai báo phương thức xóa thông tin điện thoại với tham số truyền vào là biến ID không trả lại giá trị
        void ThongKe(); // Khai báo phương thức  thống kê điện thoại còn hàng không trả về giá trị 
        void Sort(); // Khai báo phương thức Sắp xếp điện thoại còn hàng không trả về giá trị 
        void Update(Mobile id); // Khai báo phương thức cập nhật thông tin điện thoại với tham số truyền vào là thuộc tính ID của đối tượng điện thoại không trả lại giá trị
    }
}
