using System;
using System.Collections.Generic;
using System.Text;
using Demo.DataAccessLayer;
using Demo.Entities;
using Demo.DataAccessLayer.Services;
using Demo.Business.Services;
namespace Demo.Business.Components
{
    
    public class MobileBLL : IMobileBLL
    {
        private IMobileDAL mbDA = new MobileDAL();
        //Thực thi các yêu cầu


        public void Delete(int id)
        {
            if (CheckID(id))
                mbDA.Delete(id);
            else
                throw new Exception("Khong ton tai ma nay");
        }
        
        
        
        public bool CheckID(int id)
        {
            bool ok = false;
            foreach (Mobile mobile in mbDA.GetAllData())
                if (mobile.Id == id)
                {
                    ok = true; break;
                }
            return ok;
        }

        

        List<Mobile> IMobileBLL.GetAllData()
        {
            return mbDA.GetAllData();
        }

        void IMobileBLL.Add(Mobile mb)
        {
            if (mb.TenDT != "" && mb.NhaCC != "" && mb.Type != "")
            {
                mb.TenDT = Demo.Utility.CongCu.ChuanHoaXau(mb.TenDT);
                mb.NhaCC = Demo.Utility.CongCu.ChuanHoaXau(mb.NhaCC);
                mb.Type = Demo.Utility.CongCu.ChuanHoaXau(mb.Type);
                mbDA.Add(mb);
            }
            else
                throw new Exception("Du lieu sai");
        }

        List<Mobile> IMobileBLL.Timdt(Mobile mb)
        {
            List<Mobile> list = mbDA.GetAllData();
            List<Mobile> kq = new List<Mobile>();
            //Voi gai tri ngam dinh ban dau
            if (mb.TenDT == null && mb.NhaCC == null && mb.Id == 0)
            {
                kq = list;
            }
            //Tim theo ho ten
            if (mb.TenDT != null && mb.NhaCC == null && mb.Id == 0)
            {
                foreach (Mobile mobile in list)
                    if (mobile.TenDT.IndexOf(mb.TenDT) >= 0)
                    {
                        kq.Add(new Mobile(mobile));
                    }
            }
            // Tim theo que quan
            else if (mb.TenDT == null && mb.NhaCC != null && mb.Id == 0)
            {
                foreach (Mobile mobile in list)
                    if (mobile.NhaCC.IndexOf(mb.NhaCC) >= 0)
                    {
                        kq.Add(new Mobile(mobile));
                    }
            }
            //Tim theo ma
            else if (mb.TenDT == null && mb.NhaCC == null && mb.Id != 0)
            {
                foreach (Mobile mobile in list)
                    if (mobile.Id == mb.Id)
                    {
                        kq.Add(new Mobile(mobile));
                    }
            }
            //Tim ket hop giua ho ten va que quan
            else if (mb.TenDT != null && mb.NhaCC != null && mb.Id == 0)
            {
                foreach (Mobile mobile in list)
                    if (mobile.TenDT.IndexOf(mb.TenDT) >= 0 && mobile.NhaCC.IndexOf(mb.NhaCC) >= 0)
                    {
                        kq.Add(new Mobile(mobile));
                    }
            }
            
            else kq = null;
            return kq;
        }

        public void ThongKe()
        {
                mbDA.ThongKe();
        }

        public void Sort()
        {
            mbDA.Sort();
        }

        void IMobileBLL.Update(Mobile mb)
        {
            if (CheckID(mb.Id))
                mbDA.Update(mb);
            else
                throw new Exception("Khong ton tai ma nay");
        }

        Mobile IMobileBLL.LayMBtheoID(int id)
        {
            Mobile mb = null;
            foreach (Mobile mobile in mbDA.GetAllData())
                if (mobile.Id == id)
                {
                    mb = new Mobile(mobile); break;
                }
            return mb;
        }

        List<Mobile> IMobileBLL.GetThongKe()
        {
            return mbDA.GetThongKe();
        }
    }
}
