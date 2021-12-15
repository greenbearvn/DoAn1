using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using Demo.Entities;
using Demo.DataAccessLayer.Services;

namespace Demo.DataAccessLayer
{
    class HoaDonDAL : IHoaDonDAL // Kế thừa các phương thức đã khai báo từ đối tượng giao diện
    {
         
        private string txtfile = "Data/HoaDon.txt"; // Khai báo biến là tệp dữ liệu hóa đơn có phương thức là private dùng trong lớp này.

        private string sort = "Data/SortBill.txt";
        public List<HoaDon> GetAllData() // Khởi tạo hàm lấy dữ liệu thông tin hóa đơn với đối tượng là 1 list điện thoại
        {
            List<HoaDon> list = new List<HoaDon>(); // tạo đối tượng list hóa đơn

            StreamReader fread = File.OpenText(txtfile); // Tạo biến fread mở file 
            string s = fread.ReadLine(); // biến s để đọc file

            while (s != null) // Vòng lặp kiểm tra điều kiện đọc file khác rỗng
            {
                if (s != "") // Nếu s khác rỗng
                { 
                    s = Demo.Utility.CongCu.CatXau(s); // công cụ chuẩn hóa xâu
                    string[] a = s.Split('#'); // tạo mảng a đọc file loại bỏ ký tự "#"
                    list.Add(new HoaDon(int.Parse(a[0]), int.Parse(a[1]), a[2],a[3], int.Parse(a[4]),a[5], a[6], int.Parse(a[7]), a[8], a[9], double.Parse(a[10]), int.Parse(a[11]), int.Parse(a[12]), double.Parse(a[13]))); // hiển thị liệt kê các thuộc tính của hóa đơn
                }
                s = fread.ReadLine();
            }
            fread.Close(); // đóng file
            return list;  // trả lại danh sách thông tin hóa đơn
        }
        List<HoaDon> IHoaDonDAL.GetSort()
        {
            List<HoaDon> list = new List<HoaDon>();
            StreamReader fread = File.OpenText(sort);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = Demo.Utility.CongCu.CatXau(s);
                    string[] a = s.Split('#');
                    list.Add(new HoaDon(int.Parse(a[0]), int.Parse(a[1]), a[2], a[3], int.Parse(a[4]), a[5], a[6], int.Parse(a[7]), a[8], a[9], double.Parse(a[10]), int.Parse(a[11]), int.Parse(a[12]), double.Parse(a[13]))); // hiển thị liệt kê cá // hiển thị liệt kê các thuộc tính của hóa đơn
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        public int GetID() // khởi tạo hàm GetID để dùng cho việc đánh mã tự động
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
                return int.Parse(a[0]); // trả lại phần tử thứ nhất là ID trong list hóa đơn
            } 
        }
        
        public void Add(HoaDon hd) // khai báo hàm Add với phương thức public để có thể sử dụng hàm thêm này ở các class khác và kiểu void ko return giá trị
        {
            int id = GetID() + 1;// lấy ID của hàm GetID để dùng cho việc đánh ID tự động thêm 1 khi thêm thông tin hóa đơn mới vào

            StreamWriter fwrite = File.AppendText(txtfile); // thêm vào file
            fwrite.WriteLine();
            fwrite.Write(id + "#" + hd.MaDT + "#"  + hd.TenDT + "#" + hd.Nhacc + "#" + hd.Makh + "#" + hd.HoTenKH + "#" + hd.Quekh
                + "#" + hd.Manv + "#" + hd.Tennv + "#" + hd.Ngaydat + "#" + hd.Price + "#"  + hd.Quantum
                + "#" + hd.Sale + "#" + hd.Total);  // ghi thông tin điện thoại vào tệp cách nhau bởi dấu "#"
            fwrite.Close();
        }
      
        public void Delete(int id) // Hàm xóa dùng public để dùng hàm ở các class khác với tham số thuyền vào là id hóa đơn người nhập muốn xóa
        {
            List<HoaDon> list = GetAllData(); // gán hàm lấy toàn bộ dữ liệu từ tệp là list
            StreamWriter fwrite = File.CreateText(txtfile); // mở file
            foreach (HoaDon hd in list)  // lặp qua list
                if (hd.Id != id) // nếu id của đối tượng hóa đơn khác id nhập

                    fwrite.Write(hd.Id + "#" + hd.MaDT + "#" + hd.TenDT + "#" + hd.Nhacc + "#" + hd.Makh + "#" + hd.HoTenKH + "#" + hd.Quekh + "#" + hd.Manv + "#" + hd.Tennv + "#" + hd.Ngaydat + "#" + hd.Price + "#" + hd.Quantum + "#" + hd.Sale + "#" + hd.Total); // ghi các id khác loại bỏ id đã nhập
            fwrite.Close();
        }

        public void Update(HoaDon id) // hàm cập nhật thông tin hóa đơn phương thức public để sử dụng ở các class khác với tham số truyền vào là id của đối tượng
        {
            List<HoaDon> list = GetAllData(); // tạo danh sách lưu các giá trị lấy từ hàm GetAllData
            for (int i = 0; i < list.Count; ++i) // Lặp các phần tử trong list
                if (list[i].Id == id.Id) { list[i] = id; break; } // kiểm tra nếu id bằng id truyền vào

            StreamWriter fwrite = File.CreateText(txtfile);  // mở file
            foreach (HoaDon hd in list) // Lặp các phần tử trong list
                fwrite.WriteLine(hd.Id + "#" + hd.MaDT + "#" + hd.TenDT + "#" + hd.Nhacc + hd.Makh + "#" + hd.HoTenKH + "#" + hd.Quekh
                + "#" + hd.Manv + "#" + hd.Tennv + "#" + hd.Ngaydat + "#" + hd.Price + "#" + hd.Quantum
                + "#" + hd.Sale + "#" + hd.Total); // Cập nhật ghi đè lên thông tin cũ

            fwrite.Close();// đóng file
        }



        public void Sort()
        {
            List<HoaDon> list = GetAllData(); // gán hàm lấy toàn bộ dữ liệu từ tệp là list
            int n = list.Count;// lấy độ dài của list
            string hoTenKH, tendt, ngaydat, tennv, quekh;
            double price, total;// biến trung gian so sánh
            int manv, makh, quantum, sale, maDT;
            for (int i = 0; i < n - 1; i++) // Lặp qua list điện thoại
            {
                int min = i; // vị trí đầu tiên
                for (int j = i + 1; j < n; j++)// lặp lồng để so sánh vị trí sau
                {
                    if (list[j].Price < list[min].Price)// Nếu vị trí đầu lớn hơn vị trí sau
                    {
                        // Thao tác trung gian đổi vị trí
                        tendt = list[i].TenDT;
                        list[i].TenDT = list[j].TenDT;
                        list[j].TenDT = tendt;

                        hoTenKH = list[i].HoTenKH;
                        list[i].HoTenKH = list[j].HoTenKH;
                        list[j].HoTenKH = hoTenKH;

                        ngaydat = list[i].Ngaydat;
                        list[i].Ngaydat = list[j].Ngaydat;
                        list[j].Ngaydat = ngaydat;

                        price = list[i].Price;
                        list[i].Price = list[j].Price;
                        list[j].Price = price;

                        sale = list[i].Sale;
                        list[i].Sale = list[j].Sale;
                        list[j].Sale = sale;

                        quantum = list[i].Quantum;
                        list[i].Quantum = list[j].Quantum;
                        list[j].Quantum = quantum;

                        total = list[i].Total;
                        list[i].Total = list[j].Total;
                        list[j].Total = total;

                        tennv = list[i].Tennv;
                        list[i].Tennv = list[j].Tennv;
                        list[j].Tennv = tennv;

                        quekh = list[i].Quekh;
                        list[i].Quekh = list[j].Quekh;
                        list[j].Quekh = quekh;

                        manv = list[i].Manv;
                        list[i].Manv = list[j].Manv;
                        list[j].Manv = manv;

                        makh = list[i].Makh;
                        list[i].Makh = list[j].Makh;
                        list[j].Makh = makh;

                        maDT = list[i].MaDT;
                        list[i].MaDT = list[j].MaDT;
                        list[j].MaDT = maDT;
                    }
                    StreamWriter fwrite = File.CreateText(sort); // mở file
                    for (int g = 0; g < n; ++g) // lặp phần tử trong list
                        fwrite.Write(list[g].MaDT + "#" + list[g].TenDT + "#" + list[g].Makh + "#" + list[g].HoTenKH + "#" + list[g].Quekh
                        + "#" + list[g].Manv + "#" + list[g].Tennv + "#" + list[g].Ngaydat + "#" + list[g].Price + "#" + list[g].Quantum
                        + "#" + list[g].Sale + "#" + list[g].Total);
                    fwrite.Close();// đóng file

                }
            }
        }

        
    }
}
