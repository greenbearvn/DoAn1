using System;
using System.Collections.Generic;
using System.Text;
using Demo.DataAccessLayer;
using Demo.Entities;
using Demo.DataAccessLayer.Services;
using Demo.Business.Services;
namespace Demo.Business.Components
{
    
    public class HoaDonBLL : IHoaDonBLL
    {
        private IHoaDonDAL hdDA = new HoaDonDAL();
        //Thực thi các yêu cầu


        public void Delete(int id)
        {
            if (CheckID(id))
                hdDA.Delete(id);
            else
                throw new Exception("Khong ton tai ma nay");
        }


        
        public bool CheckID(int id)
        {
            bool ok = false;
            foreach (HoaDon hd in hdDA.GetAllData())
                if (hd.Id == id)
                {
                    ok = true; break;
                }
            return ok;
        }


        List<HoaDon> IHoaDonBLL.GetAllData()
        {
            return hdDA.GetAllData();
        }

        void IHoaDonBLL.Add(HoaDon hd)
        {
            if (hd.TenDT != "" && hd.HoTenKH != "" && hd.Ngaydat != "")
            {
                hd.TenDT = Demo.Utility.CongCu.ChuanHoaXau(hd.TenDT);
                hd.HoTenKH = Demo.Utility.CongCu.ChuanHoaXau(hd.HoTenKH);
                hd.Ngaydat = Demo.Utility.CongCu.ChuanHoaXau(hd.Ngaydat);
                hdDA.Add(hd);
            }
            else
                throw new Exception("Du lieu sai");
        }

        List<HoaDon> IHoaDonBLL.TimHD(HoaDon hd)
        {
            List<HoaDon> list = hdDA.GetAllData();
            List<HoaDon> kq = new List<HoaDon>();
            //Voi gai tri ngam dinh ban dau
            if (hd.TenDT == null && hd.HoTenKH == null && hd.Id == 0)
            {
                kq = list;
            }
            //Tim theo ho ten
            if (hd.TenDT != null && hd.HoTenKH == null && hd.Id == 0)
            {
                foreach (HoaDon hoadon in list)
                    if (hoadon.TenDT.IndexOf(hd.TenDT) >= 0)
                    {
                        kq.Add(new HoaDon(hoadon));
                    }
            }
            // Tim theo que quan
            else if (hd.TenDT == null && hd.HoTenKH != null && hd.Id == 0)
            {
                foreach (HoaDon hoadon in list)
                    if (hoadon.HoTenKH.IndexOf(hd.HoTenKH) >= 0)
                    {
                        kq.Add(new HoaDon(hoadon));
                    }
            }
            //Tim theo ma
            else if (hd.TenDT == null && hd.HoTenKH == null && hd.Id != 0)
            {
                foreach (HoaDon hoadon in list)
                    if (hoadon.Id == hd.Id)
                    {
                        kq.Add(new HoaDon(hoadon));
                    }
            }
            //Tim ket hop giua ho ten va que quan
            else if (hd.TenDT != null && hd.HoTenKH != null && hd.Id == 0)
            {
                foreach (HoaDon hoadon in list)
                    if (hoadon.TenDT.IndexOf(hd.TenDT) >= 0 && hoadon.HoTenKH.IndexOf(hd.HoTenKH) >= 0)
                    {
                        kq.Add(new HoaDon(hoadon));
                    }
            }
            //
            else kq = null;
            return kq;
        }

        void IHoaDonBLL.Update(HoaDon hd)
        {
            if (CheckID(hd.Id))
                hdDA.Update(hd);
            else
                throw new Exception("Khong ton tai ma nay");
        }

        HoaDon IHoaDonBLL.LayHDtheoID(int id)
        {
            HoaDon hd = null;
            foreach (HoaDon hoadon in hdDA.GetAllData())
                if (hoadon.Id == id)
                {
                    hd = new HoaDon(hoadon); break;
                }
            return hd;
        }

        
    }
}
