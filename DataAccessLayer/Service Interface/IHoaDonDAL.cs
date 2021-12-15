using System;
using System.Collections.Generic;
using System.Text;
using Demo.DataAccessLayer;
using Demo.Entities;
namespace Demo.DataAccessLayer.Services
{
    //Xác định các yêu cầu cần phải thao tác với cơ sở dữ liệu để phục vụ cho phần xử lý nghiệp vụ
    interface IHoaDonDAL
    {
        List<HoaDon> GetAllData();// Khai báo phương thức lấy tất cả dữ liệu từ tệp HoaDon.txt
        List<HoaDon> GetSort();
        void Add(HoaDon mb); // Khai báo phương thức thêm thông tin hóa đơn với tham số truyền vào là đối tượng điện thoại
        void Delete(int id); // Khai báo phương thức xóa thông tin hóa đơn với tham số truyền vào là biến ID không trả lại giá trị
        void Update(HoaDon id); // Khai báo phương thức cập nhật thông tin điện hóa đơn với tham số truyền vào là thuộc tính ID của đối tượng hóa đơn không trả lại giá trị
        void Sort();

    }
}
