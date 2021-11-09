using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using Demo.Entities;
using Demo.DataAccessLayer.Services;

namespace Demo.DataAccessLayer
{
    class BrandDAL : IBrandDAL
    {
        
        private string txtfile = "Data/Brand.txt";
        
        
        public List<Brand> GetAllData()
        {
            List<Brand> list = new List<Brand>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = Demo.Utility.CongCu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new Brand(int.Parse(a[0]), a[1], a[2]));
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
        
        public void Add(Brand br)
        {
            int id = GetID() + 1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(id + "#" + br.Name + "#" + br.Diachi );
            fwrite.Close();
        }
        
        public void Delete(int id)
        {
            List<Brand> list = GetAllData();
            StreamWriter fwrite = File.CreateText(txtfile);
            foreach (Brand br in list)
                if ( br.Id != id)
                    fwrite.WriteLine(br.Id + "#" + br.Name + "#" + br.Diachi );
            fwrite.Close();
        }

        

        public void Update(Brand id)
        {
            List<Brand> list = GetAllData();
            for (int i = 0; i < list.Count; ++i)
                if (list[i].Id == id.Id) { list[i] = id; break; }

            StreamWriter fwrite = File.CreateText(txtfile);
            foreach (Brand br in list)
                fwrite.WriteLine(br.Id + "#" + br.Name + "#" + br.Diachi);
            fwrite.Close();
        }

        
    }
}

