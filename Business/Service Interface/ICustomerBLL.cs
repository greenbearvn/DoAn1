using System;
using System.Collections.Generic;
using System.Text;
using Demo.DataAccessLayer;
using Demo.Entities;
namespace Demo.Business.Services
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    interface ICustomerBLL
    {
        List<Customer> GetAllData();
        void Add(Customer cm);

        void Delete(int id);
        List<Customer> TimKH(Customer cm);

        void Update(Customer id);
        Customer LayKHtheoID(int id);
        List<Customer> GetSort();

        void Sort();
    }
}
