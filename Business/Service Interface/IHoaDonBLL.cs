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
        List<HoaDon> GetAllData();
        void Add(HoaDon hd);

        void Delete(int id);
        List<HoaDon> TimHD(HoaDon hd);
        void Update(HoaDon id);
        HoaDon LayHDtheoID(int id);
    }
}
