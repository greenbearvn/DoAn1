using System;
using System.Collections.Generic;
using System.Text;
using Demo.DataAccessLayer;
using Demo.Entities;
using Demo.DataAccessLayer.Services;
using Demo.Business.Services;
namespace Demo.Business.Components
{
    
    public class HoaDonBLL : IHoaDonBLL // Kế thừa các phương thức đã định nghĩa từ lớp giao diện IHoaDonBLL
    {
        private IHoaDonDAL hdDA = new HoaDonDAL(); // Tạo 1 đối tượng để dùng các chức năng từ phần HoaDonDAL
        //Thực thi các yêu cầu
        private IMobileDAL mbDA = new MobileDAL();

        private ICustomerDAL cmDA = new CustomerDAL();
        private IEmployeeDAL emDA = new EmployeeDAL();

        public void Delete(int id)// hàm xóa xử lí check sd phương thức public để dùng tại các lớp khác với giá trị đầu vào là id nhập void trả về ko tham số
        {
            if (CheckID(id)) // Kiểm tra xem có id đó có hay không
                hdDA.Delete(id); // gọi hàm xóa bên phần DAL
            else
                throw new Exception("Khong ton tai ma nay"); // Nếu không có thì văng lỗi
        }


        
        public bool CheckID(int id) // hàm CheckID có thể dùng các class khác với tham số truyền vào là ID và kiểu bool để check xem có mã ko 
        {
            bool ok = false; // khai báo biến mặc định bằng false

            foreach (HoaDon hd in hdDA.GetAllData()) // Lặp qua danh sách hóa đơn trong DAL lấy thuộc tính của phần tử
                if (hd.Id == id) // nếu kiểm tra id đúng
                {
                    ok = true; break; // thì sẽ là true
                }
            return ok; // trả ra true nếu có id hoặc false nếu ko có id
        }

        

        //  Hàm lấy toàn bộ dữ liệu từ tệp
        List<HoaDon> IHoaDonBLL.GetAllData()
        {
            return hdDA.GetAllData();
        }

        // hàm thêm với tham số truyền vào là đối tượng ko trả giá trị
        void IHoaDonBLL.Add(HoaDon hd)
        {
            if (hd.TenDT != "" && hd.HoTenKH != "" && hd.Ngaydat != "")
            {
                hd.TenDT = Demo.Utility.CongCu.ChuanHoaXau(hd.TenDT);
                hd.HoTenKH = Demo.Utility.CongCu.ChuanHoaXau(hd.HoTenKH);
                hd.Ngaydat = Demo.Utility.CongCu.ChuanHoaXau(hd.Ngaydat);
                hdDA.Add(hd); // gọi hàm để thêm vào tệp ở phần DAL
            }
            else
                throw new Exception("Du lieu sai"); // nếu bằng rỗng thì văng lỗi
        }

        // hàm tìm kiếm với tham số truyền vào là đối tượng 
        List<HoaDon> IHoaDonBLL.TimHD(HoaDon hd)
        {
            List<HoaDon> list = hdDA.GetAllData(); // danh sách các điện thoại biến là list , được lấy dữ liệu từ tệp 
            List<HoaDon> kq = new List<HoaDon>(); // danh sách kq tạm thời
            //Voi gai tri ngam dinh ban dau
            if (hd.TenDT == null && hd.HoTenKH == null && hd.Id == 0)
            {
                kq = list;
            }
            //Tim theo ho ten
            if (hd.TenDT != null && hd.HoTenKH == null && hd.Id == 0)
            {
                foreach (HoaDon hoadon in list) // Lặp phần tử trong list
                    if (hoadon.TenDT.IndexOf(hd.TenDT) >= 0) // số lượng so sánh lớn hơn = 0
                    {
                        kq.Add(new HoaDon(hoadon));  // hiển thị kq danh sách tạm thời
                    }
            }
            
            else kq = null;
            return kq;
        }


        // hàm cập nhật xử lí check dùng phương thức public để dùng tại các lớp FormMobile với giá trị đầu vào là đối tượng hóa đơn kiểu void trả về ko tham số
        void IHoaDonBLL.Update(HoaDon hd)
        {
            if (CheckID(hd.Id)) //Kiểm tra nếu id là true
                hdDA.Update(hd); // gọi hàm ở phần DAL để chạy
            else
                throw new Exception("Khong ton tai ma nay"); // Nếu không có mã thì văng lỗi
        }

        HoaDon IHoaDonBLL.LayHDtheoID(int id) // Hàm lấy thông tin của hóa đơni với giá trị nhập vào là id
        {
            HoaDon hd = null; // Đặt mặc định dữ liệu không có
            foreach (HoaDon hoadon in hdDA.GetAllData()) // lặp qua danh sách ở phần DAl để lấy phần tử
                if (hoadon.Id == id) // Nếu kiểm tra thuộc tính ID trùng khớp
                {
                    hd = new HoaDon(hoadon); break; // Trả ra thông tin của phần tử đó
                }
            return hd;
        }

        double IHoaDonBLL.TongDoanhThu()
        {
            double tong = 0;
            foreach (HoaDon hd in hdDA.GetAllData()) // Lặp qua danh sách hóa đơn trong DAL lấy thuộc tính của phần tử
                tong += hd.Total;
            return tong; // trả ra true nếu có id hoặc false nếu ko có id
        }

        public double DoanhThuThang(string month, string year)
        {
            double tong = 0;
            foreach (HoaDon hd in hdDA.GetAllData()) // Lặp qua danh sách hóa đơn trong DAL lấy thuộc tính của phần tử
                if (hd.Ngaydat.Substring(3, 2) == month && hd.Ngaydat.Substring(6, 4) == year) // Nếu kiểm tra thuộc tính ID trùng khớp
                {
                    tong += hd.Total; 
                }
            return tong;
        }

        public double DoanhThuNgay(string day, string month, string year)
        {
            double tong = 0;
            foreach (HoaDon hd in hdDA.GetAllData()) // Lặp qua danh sách hóa đơn trong DAL lấy thuộc tính của phần tử
                if (hd.Ngaydat.Substring(0, 2) == day && hd.Ngaydat.Substring(3,2) == month && hd.Ngaydat.Substring(6, 4) == year) 
                {
                    tong += hd.Total; 
                }
            return tong;
        }


        public void Sort()
        {
            hdDA.Sort();
        }

        List<HoaDon> IHoaDonBLL.GetSort()
        {
            return hdDA.GetSort();
        }


        string IHoaDonBLL.GetMobileName(HoaDon hd)
        {
            string kq = "";

            List<Mobile> list = mbDA.GetAllData();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Id == hd.MaDT)
                {
                    kq = list[i].TenDT;
                }
            }
            return kq;
        }

        string IHoaDonBLL.GetCustomerName(HoaDon hd)
        {
            string kq = "";

            List<Customer> list = cmDA.GetAllData();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Id == hd.Makh)
                {
                    kq = list[i].Name;
                }
            }
            return kq;
        }

        string IHoaDonBLL.GetEmployeeName(HoaDon hd)
        {
            string kq = "";

            List<Employee> list = emDA.GetAllData();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Id == hd.Manv)
                {
                    kq = list[i].Name;
                }
            }
            return kq;
        }

        string IHoaDonBLL.GetAddressCustomer(HoaDon hd)
        {
            string kq = "";

            List<Customer> list = cmDA.GetAllData();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Id == hd.Makh)
                {
                    kq = list[i].Address;
                }
            }
            return kq;
        }

        double IHoaDonBLL.GetPrice(HoaDon hd)
        {
            double kq = 0;

            List<Mobile> list = mbDA.GetAllData();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Id == hd.MaDT)
                {
                    kq = list[i].Price;
                }
            }
            return kq;
        }

        public void TimID(int id)
        {
            foreach (HoaDon hoadon in hdDA.GetAllData()) // lặp qua danh sách ở phần DAl để lấy phần tử
                if (hoadon.Id == id)// Nếu kiểm tra thuộc tính ID trùng khớp
                {
                    Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════");
                    Console.WriteLine(" ║    " + hoadon.Id + "  ║   " + hoadon.TenDT + "  ║  " + hoadon.HoTenKH + "  ║    " + hoadon.Price + "   ║     " + hoadon.Sale + "   ║   " + hoadon.Quantum + "  ║  " + hoadon.Total);
                    Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════");
                }
        }
    }
}
