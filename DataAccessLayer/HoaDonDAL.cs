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
                    list.Add(new HoaDon(int.Parse(a[0]), a[1], a[2], a[3], double.Parse(a[4]), int.Parse(a[5]), int.Parse(a[6]), double.Parse(a[7]))); // hiển thị liệt kê các thuộc tính của hóa đơn
                }
                s = fread.ReadLine();
            }
            fread.Close(); // đóng file
            return list;  // trả lại danh sách thông tin hóa đơn
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
            fwrite.Write(id + "#" + hd.TenDT + "#" + hd.HoTenKH + "#" + hd.Ngaydat + "#" + hd.Price + "#" + hd.Sale + "#" + hd.Soluong + "#" + hd.Total);  // ghi thông tin điện thoại vào tệp cách nhau bởi dấu "#"
            fwrite.Close();
        }
      
        public void Delete(int id) // Hàm xóa dùng public để dùng hàm ở các class khác với tham số thuyền vào là id hóa đơn người nhập muốn xóa
        {
            List<HoaDon> list = GetAllData(); // gán hàm lấy toàn bộ dữ liệu từ tệp là list
            StreamWriter fwrite = File.CreateText(txtfile); // mở file
            foreach (HoaDon hd in list)  // lặp qua list
                if (hd.Id != id) // nếu id của đối tượng hóa đơn khác id nhập

                    fwrite.WriteLine(hd.Id + "#" + hd.TenDT + "#" + hd.HoTenKH + "#" + hd.Ngaydat + "#" + hd.Price + "#" + hd.Sale + "#" + hd.Soluong + "#" + hd.Total); // ghi các id khác loại bỏ id đã nhập
            fwrite.Close();
        }

        public void Update(HoaDon id) // hàm cập nhật thông tin hóa đơn phương thức public để sử dụng ở các class khác với tham số truyền vào là id của đối tượng
        {
            List<HoaDon> list = GetAllData(); // tạo danh sách lưu các giá trị lấy từ hàm GetAllData
            for (int i = 0; i < list.Count; ++i) // Lặp các phần tử trong list
                if (list[i].Id == id.Id) { list[i] = id; break; } // kiểm tra nếu id bằng id truyền vào

            StreamWriter fwrite = File.CreateText(txtfile);  // mở file
            foreach (HoaDon hd in list) // Lặp các phần tử trong list
                fwrite.WriteLine(hd.Id + "#" + hd.TenDT + "#" + hd.HoTenKH + "#" + hd.Ngaydat + "#" + hd.Price + "#" + hd.Sale + "#" + hd.Soluong + "#" + hd.Total); // Cập nhật ghi đè lên thông tin cũ

            fwrite.Close();// đóng file
        }

    }
}
