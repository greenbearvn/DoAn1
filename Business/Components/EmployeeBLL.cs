using System;
using System.Collections.Generic;
using System.Text;
using Demo.DataAccessLayer;
using Demo.Entities;
using Demo.DataAccessLayer.Services;
using Demo.Business.Services;
namespace Demo.Business.Components
{
    class EmployeeBLL : IEmployeeBLL
    {
        private IEmployeeDAL emDA = new EmployeeDAL();
        public bool CheckID(int id)
        {
            bool ok = false;
            foreach (Employee employee in emDA.GetAllData())
                if (employee.Id == id)
                {
                    ok = true; break;
                }
            return ok;
        }
        public void Add(Employee em)
        {
            if (em.Name != "" && em.Address != "" && em.Numberphone != "")
            {
                em.Name = Demo.Utility.CongCu.ChuanHoaXau(em.Name);
                em.Address = Demo.Utility.CongCu.ChuanHoaXau(em.Address);
                em.Numberphone = Demo.Utility.CongCu.ChuanHoaXau(em.Numberphone);
                emDA.Add(em);
            }
            else
                throw new Exception("Du lieu sai");
        }

        public void Delete(int id)
        {
            if (CheckID(id))
                emDA.Delete(id);
            else
                throw new Exception("Khong ton tai ma nay");
        }

        public List<Employee> GetAllData()
        {
            return emDA.GetAllData();
        }

        public List<Employee> TimNV(Employee em)
        {
            List<Employee> list = emDA.GetAllData();
            List<Employee> kq = new List<Employee>();
            //Voi gai tri ngam dinh ban dau
            if (em.Name == null && em.Address == null && em.Id == 0)
            {
                kq = list;
            }
            //Tim theo ho ten
            if (em.Name != null && em.Address == null && em.Id == 0)
            {
                foreach (Employee employee in list)
                    if (employee.Name.IndexOf(em.Name) >= 0)
                    {
                        kq.Add(new Employee(employee));
                    }
            }
            // Tim theo que quan
            else if (em.Name == null && em.Address != null && em.Id == 0)
            {
                foreach (Employee employee in list)
                    if (employee.Address.IndexOf(em.Address) >= 0)
                    {
                        kq.Add(new Employee(employee));
                    }
            }
            //Tim theo ma
            else if (em.Name == null && em.Address == null && em.Id != 0)
            {
                foreach (Employee employee in list)
                    if (employee.Id == em.Id)
                    {
                        kq.Add(new Employee(employee));
                    }
            }
            //Tim ket hop giua ho ten va que quan
            else if (em.Name != null && em.Address != null && em.Id == 0)
            {
                foreach (Employee employee in list)
                    if (employee.Name.IndexOf(em.Name) >= 0 && employee.Address.IndexOf(em.Address) >= 0)
                    {
                        kq.Add(new Employee(employee));
                    }
            }
            //
            else kq = null;
            return kq;
        }

        void IEmployeeBLL.Update(Employee em)
        {
            if (CheckID(em.Id))
                emDA.Update(em);
            else
                throw new Exception("Khong ton tai ma nay");
        }

        Employee IEmployeeBLL.LayNVtheoID(int id)
        {
            Employee em = null;
            foreach (Employee employee in emDA.GetAllData())
                if (employee.Id == id)
                {
                    em = new Employee(employee); break;
                }
            return em;
        }
    }
}
