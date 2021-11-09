using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using Demo.Entities;
using Demo.DataAccessLayer.Services;

namespace Demo.DataAccessLayer
{
    class EmployeeDAL : IEmployeeDAL
    {
        
        private string txtfile = "Data/Employee.txt";
       
        public List<Employee> GetAllData()
        {
            List<Employee> list = new List<Employee>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = Demo.Utility.CongCu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new Employee(int.Parse(a[0]), a[1], a[2], int.Parse(a[3]), a[4], double.Parse(a[5]), double.Parse(a[6]), double.Parse(a[7])));
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
        
        public void Add(Employee em)
        {
            int id = GetID() + 1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(id + "#" + em.Name + "#" + em.Address + "#" + em.Age + "#" + em.Numberphone + "#" + em.Luongcoban + "#" + em.Hesoluong + "#" + em.Phucap);
            fwrite.Close();
        }
          
        public void Delete(int id)
        {
            List<Employee> list = GetAllData();
            StreamWriter fwrite = File.CreateText(txtfile);
            foreach (Employee em in list)
                if (em.Id != id)
                    fwrite.WriteLine(em.Id + "#" + em.Name + "#" + em.Address + "#" + em.Age + "#" + em.Numberphone + "#" + em.Luongcoban + "#" + em.Hesoluong + "#" + em.Phucap);
            fwrite.Close();
        }

        

        public void Update(Employee id)
        {
            List<Employee> list = GetAllData();
            for (int i = 0; i < list.Count; ++i)
                if (list[i].Id == id.Id) { list[i] = id; break; }

            StreamWriter fwrite = File.CreateText(txtfile);
            foreach (Employee em in list)
                fwrite.WriteLine(em.Id + "#" + em.Name + "#" + em.Address + "#" + em.Age + "#" + em.Numberphone + "#" + em.Luongcoban + "#" + em.Hesoluong + "#" + em.Phucap);
            fwrite.Close();
        }

       
    }
}
