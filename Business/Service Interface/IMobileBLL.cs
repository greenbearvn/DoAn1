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
        List<Mobile> GetAllData();
        List<Mobile> GetThongKe();
        void Add(Mobile mb);
        void Delete(int id);
        List<Mobile> Timdt(Mobile mb);
        void ThongKe();
        
        void Update(Mobile id);
        Mobile LayMBtheoID(int id);
        void Sort();
    }
}
