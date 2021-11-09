using System;
using System.Collections.Generic;
using System.Text;
using Demo.DataAccessLayer;
using Demo.Entities;
using Demo.DataAccessLayer.Services;
using Demo.Business.Services;
namespace Demo.Business.Components
{
    class CustomerBLL : ICustomerBLL
    {
        private ICustomerDAL cmDA = new CustomerDAL();
        public bool CheckID(int id)
        {
            bool ok = false;
            foreach (Customer customer in cmDA.GetAllData())
                if (customer.Id == id)
                {
                    ok = true; break;
                }
            return ok;
        }
        public void Add(Customer cm)
        {
            if (cm.Name != "" && cm.Address != "" && cm.Numberphone != "")
            {
                cm.Name = Demo.Utility.CongCu.ChuanHoaXau(cm.Name);
                cm.Address = Demo.Utility.CongCu.ChuanHoaXau(cm.Address);
                cm.Numberphone = Demo.Utility.CongCu.ChuanHoaXau(cm.Numberphone);
                cmDA.Add(cm);
            }
            else
                throw new Exception("Du lieu sai");
        }

        public void Delete(int id)
        {
            if (CheckID(id))
                cmDA.Delete(id);
            else
                throw new Exception("Khong ton tai ma nay");
        }

        public List<Customer> GetAllData()
        {
            return cmDA.GetAllData();
        }

        public List<Customer> TimKH(Customer cm)
        {
            List<Customer> list = cmDA.GetAllData();
            List<Customer> kq = new List<Customer>();
            //Voi gai tri ngam dinh ban dau
            if (cm.Name == null && cm.Address == null && cm.Id == 0)
            {
                kq = list;
            }
            //Tim theo ho ten
            if (cm.Name != null && cm.Address == null && cm.Id == 0)
            {
                foreach (Customer customer in list)
                    if (customer.Name.IndexOf(cm.Name) >= 0)
                    {
                        kq.Add(new Customer(customer));
                    }
            }
            // Tim theo que quan
            else if (cm.Name == null && cm.Address != null && cm.Id == 0)
            {
                foreach (Customer customer in list)
                    if (customer.Address.IndexOf(cm.Address) >= 0)
                    {
                        kq.Add(new Customer(customer));
                    }
            }
            //Tim theo ma
            else if (cm.Name == null && cm.Address == null && cm.Id != 0)
            {
                foreach (Customer customer in list)
                    if (customer.Id == cm.Id)
                    {
                        kq.Add(new Customer(customer));
                    }
            }
            //Tim ket hop giua ho ten va que quan
            else if (cm.Name != null && cm.Address != null && cm.Id == 0)
            {
                foreach (Customer customer in list)
                    if (customer.Name.IndexOf(cm.Name) >= 0 && customer.Address.IndexOf(cm.Address) >= 0)
                    {
                        kq.Add(new Customer(customer));
                    }
            }
           
            else kq = null;
            return kq;
        }
        void ICustomerBLL.Update(Customer cm)
        {
            if (CheckID(cm.Id))
                cmDA.Update(cm);
            else
                throw new Exception("Khong ton tai ma nay");
        }
 
        public Customer LayKHtheoID(int id)
        {
            Customer cm = null;
            foreach (Customer customer in cmDA.GetAllData())
                if (customer.Id == id)
                {
                    cm = new Customer(customer); break;
                }
            return cm;
        }
    }
}
