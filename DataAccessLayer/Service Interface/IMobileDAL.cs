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
        List<Mobile> GetAllData();
        List<Mobile> GetThongKe();
        void Add(Mobile mb);
        void Delete(int id);
        void ThongKe();
        void Sort();
        void Update(Mobile id);
    }
}
