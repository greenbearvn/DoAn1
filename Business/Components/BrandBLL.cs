using System;
using System.Collections.Generic;
using System.Text;
using Demo.DataAccessLayer;
using Demo.Entities;
using Demo.DataAccessLayer.Services;
using Demo.Business.Services;
namespace Demo.Business.Components
{
    
    public class BrandBLL : IBrandBLL
    {
        private IBrandDAL brDA = new BrandDAL();
        //Thực thi các yêu cầu


        public void Delete(int id)
        {
            if (CheckID(id))
                brDA.Delete(id);
            else
                throw new Exception("Khong ton tai ma nay");
        }


        
        public bool CheckID(int id)
        {
            bool ok = false;
            foreach (Brand brand in brDA.GetAllData())
                if (brand.Id == id)
                {
                    ok = true; break;
                }
            return ok;
        }



        List<Brand> IBrandBLL.GetAllData()
        {
            return brDA.GetAllData();
        }

        void IBrandBLL.Add(Brand br)
        {
            if (br.Name != "" && br.Diachi != "" )
            {
                br.Name = Demo.Utility.CongCu.ChuanHoaXau(br.Name);
                br.Diachi = Demo.Utility.CongCu.ChuanHoaXau(br.Diachi);
                brDA.Add(br);
            }
            else
                throw new Exception("Du lieu sai");
        }

        List<Brand> IBrandBLL.TimNCC(Brand br)
        {
            List<Brand> list = brDA.GetAllData();
            List<Brand> kq = new List<Brand>();
            //Voi gai tri ngam dinh ban dau
            if (br.Name == null && br.Diachi == null && br.Id == 0)
            {
                kq = list;
            }
            //Tim theo ho ten
            if (br.Name != null && br.Diachi == null && br.Id == 0)
            {
                foreach (Brand brand in list)
                    if (brand.Name.IndexOf(br.Name) >= 0)
                    {
                        kq.Add(new Brand(brand));
                    }
            }
            // Tim theo que quan
            else if (br.Name == null && br.Diachi != null && br.Id == 0)
            {
                foreach (Brand brand in list)
                    if (brand.Diachi.IndexOf(br.Diachi) >= 0)
                    {
                        kq.Add(new Brand(brand));
                    }
            }
            //Tim theo ma
            else if (br.Name == null && br.Diachi == null && br.Id != 0)
            {
                foreach (Brand brand in list)
                    if (brand.Id == br.Id)
                    {
                        kq.Add(new Brand(brand));
                    }
            }
            //Tim ket hop giua ho ten va que quan
            else if (br.Name != null && br.Diachi != null && br.Id == 0)
            {
                foreach (Brand brand in list)
                    if (brand.Name.IndexOf(br.Name) >= 0 && brand.Diachi.IndexOf(br.Diachi) >= 0)
                    {
                        kq.Add(new Brand(brand));
                    }
            }
            
            else kq = null;
            return kq;
        }

        

        void IBrandBLL.Update(Brand br)
        {
            if (CheckID(br.Id))
                brDA.Update(br);
            else
                throw new Exception("Khong ton tai ma nay");
        }

        Brand IBrandBLL.LayNCCtheoID(int id)
        {
            Brand br = null;
            foreach (Brand brand in brDA.GetAllData())
                if (brand.Id == id)
                {
                    br = new Brand(brand); break;
                }
            return br;
        }
    }
}

