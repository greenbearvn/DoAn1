using System;
using System.Collections.Generic;
using System.Text;
using Demo.DataAccessLayer;
using Demo.Entities;
using Demo.DataAccessLayer.Services;
using Demo.Business.Services;
namespace Demo.Business.Components
{
    
    public class MobileBLL : IMobileBLL // Kế thừa các phương thức đã định nghĩa từ lớp giao diện IMobileBLL 
    {
        private IMobileDAL mbDA = new MobileDAL(); // Tạo 1 đối tượng để dùng các chức năng từ phần MobileDAL
        //Thực thi các yêu cầu


        public void Delete(int id) // hàm xóa xử lí check sd phương thức public để dùng tại các lớp khác với giá trị đầu vào là id nhập void trả về ko tham số
        {
            if (CheckID(id))// Kiểm tra xem có id đó có hay không
                mbDA.Delete(id);// gọi hàm xóa bên phần DAL
            else
                throw new Exception("Khong ton tai ma nay");// Nếu không có thì văng lỗi
        }

        public bool CheckType(string tendt,string type)// hàm CheckID có thể dùng các class khác với tham số truyền vào là ID và kiểu bool để check xem có mã ko 
        {
            bool ok = false;// khai báo biến mặc định bằng false

            foreach (Mobile mobile in mbDA.GetAllData())// Lặp qua danh sách điện thoại trong DAL lấy thuộc tính của phần tử
                if (mobile.TenDT == Utility.CongCu.ChuanHoaXau(tendt) && mobile.Type == Utility.CongCu.ChuanHoaXau(type))// nếu kiểm tra id đúng 
                {
                    ok = true; break;// thì sẽ là true
                }
            return ok; // trả ra true nếu có id hoặc false nếu ko có id
        }

        public bool CheckID(int id)// hàm CheckID có thể dùng các class khác với tham số truyền vào là ID và kiểu bool để check xem có mã ko 
        {
            bool ok = false;// khai báo biến mặc định bằng false

            foreach (Mobile mobile in mbDA.GetAllData())// Lặp qua danh sách điện thoại trong DAL lấy thuộc tính của phần tử
                if (mobile.Id == id)// nếu kiểm tra id đúng 
                {
                    ok = true; break;// thì sẽ là true
                }
            return ok; // trả ra true nếu có id hoặc false nếu ko có id
        }


        //  Hàm lấy toàn bộ dữ liệu từ tệp
        List<Mobile> IMobileBLL.GetAllData()
        {
            return mbDA.GetAllData();
        }


        // hàm thêm với tham số truyền vào là đối tượng ko trả giá trị
        void IMobileBLL.Add(Mobile mb)
        {
            if (mb.TenDT != "" && mb.NhaCC != "" && mb.Type != "")// Nếu tên , nhà cung cấp , loại khác rỗng
            {
                mb.TenDT = Demo.Utility.CongCu.ChuanHoaXau(mb.TenDT);// chuẩn hóa xâu tên
                mb.NhaCC = Demo.Utility.CongCu.ChuanHoaXau(mb.NhaCC);// chuẩn hóa xâu nhà cung cấp
                mb.Type = Demo.Utility.CongCu.ChuanHoaXau(mb.Type);// chuẩn hóa xâu loại
                mbDA.Add(mb);// gọi hàm để thêm vào tệp ở phần DAL
            }
            else
                throw new Exception("Du lieu sai");// nếu bằng rỗng thì văng lỗi
        }

        // hàm tìm kiếm với tham số truyền vào là đối tượng 
        List<Mobile> IMobileBLL.Timdt(Mobile mb)
        {
            List<Mobile> list = mbDA.GetAllData(); // danh sách các điện thoại biến là list , được lấy dữ liệu từ tệp 

            List<Mobile> kq = new List<Mobile>();// danh sách kq tạm thời

            //Voi gai tri ngam dinh ban dau
            if (mb.TenDT == null && mb.NhaCC == null && mb.Id == 0)
            {
                kq = list;
            }
            //Tim theo ho ten
            if (mb.TenDT != null && mb.NhaCC == null && mb.Id == 0)// tên khác null cho người dùng nhập tham số vào tìm kiếm
            {
                foreach (Mobile mobile in list) // Lặp phần tử trong list
                    if (mobile.TenDT.IndexOf(mb.TenDT) >= 0)// số lượng so sánh lớn hơn = 0
                    {
                        kq.Add(new Mobile(mobile));// hiển thị kq danh sách tạm thời
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
            
            else kq = null; // nếu không tìm gì thì trả ra null
            return kq;// trả ra kết quả tạm thời
        }

        public void ThongKe()// Hàm Thống kê điện thoại với phương thức public để dùng trong class FormMobile
        {
                mbDA.ThongKe();// gọi hàm thống kê ở phần DAL để chạy
        }

        public void Sort()// Hàm Sắp xếp điện thoại với phương thức public để dùng trong class FormMobile
        {
            mbDA.Sort();
        }

        void IMobileBLL.Update(Mobile mb)  // hàm cập nhật xử lí check dùng phương thức public để dùng tại các lớp FormMobile với giá trị đầu vào là đối tượng điện thoại kiểu void trả về ko tham số
        {
            if (CheckID(mb.Id))//Kiểm tra nếu id là true
                mbDA.Update(mb);// gọi hàm ở phần DAL để chạy
            else
                throw new Exception("Khong ton tai ma nay");// Nếu không có mã thì văng lỗi
        }

        Mobile IMobileBLL.LayMBtheoID(int id)// Hàm lấy thông tin của điện thoại với giá trị nhập vào là id
        {
            Mobile mb = null; // Đặt mặc định dữ liệu không có
            foreach (Mobile mobile in mbDA.GetAllData()) // lặp qua danh sách ở phần DAl để lấy phần tử
                if (mobile.Id == id)// Nếu kiểm tra thuộc tính ID trùng khớp
                {
                    mb = new Mobile(mobile); break;// Trả ra thông tin của phần tử đó
                }
            return mb;// trả thông tin
        }

        List<Mobile> IMobileBLL.GetThongKe() // Hàm thống kê 
        {
            return mbDA.GetThongKe();// Gọi hàm ở phần DAL để chạy
        }

        List<Mobile> IMobileBLL.GetSort()
        {
            return mbDA.GetSort();
        }

        public void SortPriceUp()
        {
            mbDA.SortPriceUp();
        }

        

        public void TimGia(double price)
        {
            
            foreach (Mobile mobile in mbDA.GetAllData()) // lặp qua danh sách ở phần DAl để lấy phần tử
                if (mobile.Price <= price)// Nếu kiểm tra thuộc tính ID trùng khớp
                {
                    Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════");
                    Console.WriteLine(" ║    " + mobile.Id + "  ║   "  + mobile.TenDT + "  ║  " + mobile.Price + "  ║    " + mobile.NhaCC + "   ║     " + mobile.Type + "   ║   " + mobile.Sale + "  ║  " + mobile.Quantum);
                    Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════");
                }
                
        }

        public void TimID(int id)
        {
            foreach (Mobile mobile in mbDA.GetAllData()) // lặp qua danh sách ở phần DAl để lấy phần tử
                if (mobile.Id == id)// Nếu kiểm tra thuộc tính ID trùng khớp
                {
                    Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════");
                    Console.WriteLine(" ║    " + mobile.Id + "  ║   " + mobile.TenDT + "  ║  " + mobile.Price + "  ║    " + mobile.NhaCC + "   ║     " + mobile.Type + "   ║   " + mobile.Sale + "  ║  " + mobile.Quantum);
                    Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════");
                }
        }

        public void TimType(string type)
        {
            foreach (Mobile mobile in mbDA.GetAllData()) // lặp qua danh sách ở phần DAl để lấy phần tử
                if (mobile.Type == type)// Nếu kiểm tra thuộc tính ID trùng khớp
                {
                    Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════");
                    Console.WriteLine(" ║    " + mobile.Id + "  ║   " + mobile.TenDT + "  ║  " + mobile.Price + "  ║    " + mobile.NhaCC + "   ║     " + mobile.Type + "   ║   " + mobile.Sale + "  ║  " + mobile.Quantum);
                    Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════");
                }
        }
    }
}
