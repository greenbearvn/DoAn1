using System;
using System.Collections.Generic;
using System.Text;
using Demo.DataAccessLayer;
using Demo.Entities;
namespace Demo.Business.Services
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    interface IMobileBLL
    {
        List<Mobile> GetAllData();// Khai báo phương thức lấy tất cả dữ liệu từ tệp Mobile.txt
        List<Mobile> GetThongKe(); // Khai báo phương thức lấy tất cả dữ liệu đã thống kê từ tệp ThongKe.txt
        List<Mobile> GetSort();
        void Add(Mobile mb); // Khai báo phương thức thêm thông tin điện thoại với tham số truyền vào là đối tượng điện thoại
        void Delete(int id);// Khai báo phương thức xóa thông tin điện thoại với tham số truyền vào là biến ID không trả lại giá trị
        List<Mobile> Timdt(Mobile mb); // Khai báo phương thức tìm thông tin điện thoại với tham số truyền vào là đối tượng điện thoại
        void ThongKe();// Khai báo phương thức  thống kê điện thoại còn hàng không trả về giá trị

        void Update(Mobile id);// Khai báo phương thức cập nhật thông tin điện thoại với tham số truyền vào là thuộc tính ID của đối tượng điện thoại không trả lại giá trị
        Mobile LayMBtheoID(int id);// Khai báo phương thức lấy thông tin điện thoại có tham số  truyền vào là id
        void Sort();// Khai báo phương thức Sắp xếp điện thoại còn hàng không trả về giá trị 
    }
}
