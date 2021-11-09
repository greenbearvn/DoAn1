using System;
using System.Collections.Generic;
using System.Text;
using Demo.DataAccessLayer;
using Demo.Entities;
namespace Demo.Business.Services
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    interface IBrandBLL
    {
        List<Brand> GetAllData();
        void Add(Brand br);

        void Delete(int id);
        List<Brand> TimNCC(Brand br);

        void Update(Brand id);
        Brand LayNCCtheoID(int id);
    }
}
