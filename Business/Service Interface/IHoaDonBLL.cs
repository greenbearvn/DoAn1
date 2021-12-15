using System;
using System.Collections.Generic;
using System.Text;
using Demo.DataAccessLayer;
using Demo.Entities;
namespace Demo.Business.Services
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    interface IHoaDonBLL
    {
        List<HoaDon> GetAllData(); // Khai báo phương thức lấy tất cả dữ liệu từ tệp HoaDon.txt
        void Add(HoaDon hd); // Khai báo phương thức thêm thông tin hóa đơn với tham số truyền vào là đối tượng hóa đơn
        List<HoaDon> GetSort();
        void Sort();
        void Delete(int id); // Khai báo phương thức xóa thông tin hóa đơn với tham số truyền vào là biến ID không trả lại giá trị
        List<HoaDon> TimHD(HoaDon hd); // Khai báo phương thức tìm thông tin hóa đơn với tham số truyền vào là đối tượng hóa đơn
       
        void Update(HoaDon id); // Khai báo phương thức cập nhật thông tin hóa đơn với tham số truyền vào là thuộc tính ID của đối tượng hóa đơn không trả lại giá trị
        HoaDon LayHDtheoID(int id); // Khai báo phương thức lấy thông tin hóa đơn có tham số  truyền vào là id
        double TongDoanhThu();
        double DoanhThuThang(string month, string year);
        double DoanhThuNgay(string day, string month,string year);
        string GetMobileName(HoaDon hd);
        string GetCustomerName(HoaDon hd);
        string GetEmployeeName(HoaDon hd);    
        string GetAddressCustomer(HoaDon hd);
        double GetPrice(HoaDon hd);
        void TimID(int id);
    }
}
