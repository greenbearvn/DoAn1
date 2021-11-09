using System;
using System.Collections.Generic;
using System.Text;
using Demo.DataAccessLayer;
using Demo.Entities;
namespace Demo.DataAccessLayer.Services
{
    //Xác định các yêu cầu cần phải thao tác với cơ sở dữ liệu để phục vụ cho phần xử lý nghiệp vụ
    interface IEmployeeDAL
    {
        List<Employee> GetAllData();

        void Add(Employee em);
        void Delete(int id);
        void Update(Employee id);
    }
}