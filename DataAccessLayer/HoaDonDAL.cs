using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using Demo.Entities;
using Demo.DataAccessLayer.Services;

namespace Demo.DataAccessLayer
{
    class HoaDonDAL : IHoaDonDAL
    {
         
        private string txtfile = "Data/HoaDon.txt";
        
       
        public List<HoaDon> GetAllData()
        {
            List<HoaDon> list = new List<HoaDon>();
            StreamReader fread = File.OpenText(txtfile);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = Demo.Utility.CongCu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new HoaDon(int.Parse(a[0]), a[1], a[2], a[3], double.Parse(a[4]), int.Parse(a[5]), int.Parse(a[6]), double.Parse(a[7])));
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
        
        public void Add(HoaDon hd)
        {
            int id = GetID() + 1;
            StreamWriter fwrite = File.AppendText(txtfile);
            fwrite.WriteLine();
            fwrite.Write(id + "#" + hd.TenDT + "#" + hd.HoTenKH + "#" + hd.Ngaydat + "#" + hd.Price + "#" + hd.Sale + "#" + hd.Soluong + "#" + hd.Total);
            fwrite.Close();
        }
      
        public void Delete(int id)
        {
            List<HoaDon> list = GetAllData();
            StreamWriter fwrite = File.CreateText(txtfile);
            foreach (HoaDon hd in list)
                if (hd.Id != id)
                    fwrite.WriteLine(hd.Id + "#" + hd.TenDT + "#" + hd.HoTenKH + "#" + hd.Ngaydat + "#" + hd.Price + "#" + hd.Sale + "#" + hd.Soluong + "#" + hd.Total);
            fwrite.Close();
        }

        public void Update(HoaDon id)
        {
            List<HoaDon> list = GetAllData();
            for (int i = 0; i < list.Count; ++i)
                if (list[i].Id == id.Id) { list[i] = id; break; }

            StreamWriter fwrite = File.CreateText(txtfile);
            foreach (HoaDon hd in list)
                fwrite.WriteLine(hd.Id + "#" + hd.TenDT + "#" + hd.HoTenKH + "#" + hd.Ngaydat + "#" + hd.Price + "#" + hd.Sale + "#" + hd.Soluong + "#" + hd.Total);
            fwrite.Close();
        }

    }
}
