using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using Demo.Entities;
using Demo.DataAccessLayer.Services;

namespace Demo.DataAccessLayer
{
    class CustomerDAL : ICustomerDAL
    {
        
        private string txtfile = "Data/Customer.txt";
        
        
        public List<Customer> GetAllData()
        {
            List<Customer> list = new List<Customer>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = Demo.Utility.CongCu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new Customer(int.Parse(a[0]), a[1], a[2], int.Parse(a[3]), a[4]));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
       
        public int GetID()
        {
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            string tmp = "";
            while (s != null)
            {
                if (s != "") tmp = s;
                s = fread.ReadLine();
            }
            fread.Close();
            if (tmp == "") return 0;
            else
            {
                tmp = Demo.Utility.CongCu.ChuanHoaXau(tmp);
                string[] a = tmp.Split('#');
                return int.Parse(a[0]);
            }
        }
        
        public void Add(Customer cm)
        {
            int id = GetID() + 1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(id + "#" + cm.Name + "#" + cm.Address + "#" + cm.Age + "#" + cm.Numberphone);
            fwrite.Close();
        }
        
        public void Delete(int id)
        {
            List<Customer> list = GetAllData();
            StreamWriter fwrite = File.CreateText(txtfile);
            foreach (Customer cm in list)
                if (cm.Id != id)
                    fwrite.WriteLine(cm.Id + "#" + cm.Name + "#" + cm.Address + "#" + cm.Age + "#" + cm.Numberphone);
            fwrite.Close();
        }
        public void Update(Customer id)
        {
            List<Customer> list = GetAllData();
            for (int i = 0; i < list.Count; ++i)
                if (list[i].Id == id.Id) { list[i] = id; break; }

            StreamWriter fwrite = File.CreateText(txtfile);
            foreach (Customer cm in list)
                fwrite.WriteLine(cm.Id + "#" + cm.Name + "#" + cm.Address + "#" + cm.Age + "#" + cm.Numberphone);
            fwrite.Close();
        }
    }
}
