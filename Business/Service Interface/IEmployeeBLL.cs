using System;
using System.Collections.Generic;
using System.Text;
using Demo.DataAccessLayer;
using Demo.Entities;
namespace Demo.Business.Services
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    interface IEmployeeBLL
    {
        List<Employee> GetAllData();
        void Add(Employee em);

        void Delete(int id);
        List<Employee> TimNV(Employee em);

        void Update(Employee id);
        Employee LayNVtheoID(int id);
        List<Employee> GetSort();

        void Sort();
    }
}
