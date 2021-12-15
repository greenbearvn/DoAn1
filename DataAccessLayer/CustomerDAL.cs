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
        private string sort = "Data/SortCustomer.txt";

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

        public List<Customer> GetSort()
        {
            List<Customer> list = new List<Customer>();
            StreamReader fread = File.OpenText(sort);
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

        public void Sort()
        {
            List<Customer> list = GetAllData(); // gán hàm lấy toàn bộ dữ liệu từ tệp là list
            int n = list.Count;// lấy độ dài của list
            string name, numberphone, address;// biến trung gian so sánh
            int age;

            for (int i = 0; i < n - 1; i++) // Lặp qua list điện thoại
            {
                int min = i; // vị trí đầu tiên
                string minStr = list[i].Name;
                for (int j = i + 1; j < n; j++)// lặp lồng để so sánh vị trí sau
                {
                    if (list[j].Name.CompareTo(minStr) != 0)
                    {
                        minStr = list[i].Name;
                        min = j;
                    }

                    if (min != i)// Nếu vị trí đầu lớn hơn vị trí sau
                    {
                        // Thao tác trung gian đổi vị trí
                        name = list[i].Name;
                        list[i].Name = list[j].Name;
                        list[j].Name = name;

                        address = list[i].Address;
                        list[i].Address = list[j].Address;
                        list[j].Address = address;

                        numberphone = list[i].Numberphone;
                        list[i].Numberphone = list[j].Numberphone;
                        list[j].Numberphone = numberphone;

                        age = list[i].Age;
                        list[i].Age = list[j].Age;
                        list[j].Age = age;

                    }
                    StreamWriter fwrite = File.CreateText(sort); // mở file
                    for (int g = 0; g < n; ++g) // lặp phần tử trong list
                        fwrite.WriteLine(list[g].Id + "#" + list[g].Name + "#" + list[g].Address + "#" + list[g].Age + "#" + list[g].Numberphone); // ghi lại thông tin điện thoại đã được sắp xếp

                    fwrite.Close();// đóng file

                }
            }
        }
    }
}
