using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using Demo.Entities;
using Demo.DataAccessLayer.Services;

namespace Demo.DataAccessLayer
{
    class MobileDAL : IMobileDAL
    {
        
        private string txtfile = "Data/Mobile.txt";
        private string f = "Data/ThongKe.txt";
        
        public List<Mobile> GetAllData()
        {
            List<Mobile> list = new List<Mobile>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = Demo.Utility.CongCu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new Mobile(int.Parse(a[0]), a[1], a[2], a[3], double.Parse(a[4]), int.Parse(a[5]), int.Parse(a[6])));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        public List<Mobile> GetThongKe()
        {
            List<Mobile> list = new List<Mobile>();
            StreamReader fread = File.OpenText(f);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = Demo.Utility.CongCu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new Mobile(int.Parse(a[0]), a[1], a[2], a[3], double.Parse(a[4]), int.Parse(a[5]), int.Parse(a[6])));
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
                if(s!="")tmp = s;
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
        
        public void Add(Mobile mb)
        {
            int id = GetID()+1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(id + "#" + mb.TenDT + "#" + mb.NhaCC + "#" + mb.Type + "#" + mb.Price + "#" + mb.Sale + "#" + mb.Quantum);
            fwrite.Close();
        }
        //Xóa một học sinh khi biết mã
        public void Delete(int id)
        { 
            List<Mobile> list = GetAllData();
            StreamWriter fwrite = File.CreateText(txtfile);
            foreach(Mobile mb in list)
                if (mb.Id != id)
                    fwrite.WriteLine(mb.Id + "#" + mb.TenDT + "#" + mb.NhaCC + "#" + mb.Type + "#" + mb.Price + "#" + mb.Sale + "#" + mb.Quantum);
            fwrite.Close();
        }

        public void ThongKe()
        {
            List<Mobile> list = GetAllData();
            StreamWriter fwrite = File.CreateText(f);
            foreach (Mobile mb in list)
                if (mb.Quantum >0)
                    fwrite.WriteLine(mb.Id + "#" + mb.TenDT + "#" + mb.NhaCC + "#" + mb.Type + "#" + mb.Price + "#" + mb.Sale + "#" + mb.Quantum);
            fwrite.Close();
        }

        public void Update(Mobile id)
        {
            List<Mobile> list = GetAllData();
            for (int i = 0; i < list.Count; ++i)
                if (list[i].Id == id.Id) { list[i] = id; break; }

            StreamWriter fwrite = File.CreateText(txtfile);
            foreach (Mobile mb in list)
                fwrite.WriteLine(mb.Id + "#" + mb.TenDT + "#" + mb.NhaCC + "#" + mb.Type + "#" + mb.Price + "#" + mb.Sale + "#" + mb.Quantum);
            fwrite.Close();
        }

        public void Sort()
        {
            List<Mobile> list = GetAllData();
            int n = list.Count;
            int id, sale, quantum;
            string tendt, nhacc, type;
            double price;
            for (int i = 0; i < n-1; i++)
            {
                int min = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (list[j].Price < list[min].Price)
                    {
                        id = list[i].Id;
                        list[i].Id = list[j].Id;
                        list[j].Id = id;
                        tendt = list[i].TenDT;
                        list[i].TenDT = list[j].TenDT;
                        list[j].TenDT = tendt;
                        nhacc = list[i].NhaCC;
                        list[i].NhaCC = list[j].NhaCC;
                        list[j].NhaCC = nhacc;
                        type = list[i].Type;
                        list[i].Type = list[j].Type;
                        list[j].Type = type;
                        sale = list[i].Sale;
                        list[i].Sale = list[j].Sale;
                        list[j].Sale = sale;
                        quantum = list[i].Quantum;
                        list[i].Quantum = list[j].Quantum;
                        list[j].Quantum = quantum;
                        price = list[i].Price;
                        list[i].Price = list[j].Price;
                        list[j].Price = price;
                    }
                    StreamWriter fwrite = File.CreateText(txtfile);
                    for (int g = 0; g < n; ++g)
                        fwrite.WriteLine(list[g].Id + "#" + list[g].TenDT + "#" + list[g].NhaCC + "#" + list[g].Type + "#" + list[g].Price + "#" + list[g].Sale + "#" + list[g].Quantum);
                    fwrite.Close();

                }
            }    
                

            
        }

    }
}
