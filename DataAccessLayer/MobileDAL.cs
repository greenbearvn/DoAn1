using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using Demo.Entities;
using Demo.DataAccessLayer.Services;

namespace Demo.DataAccessLayer
{
    class MobileDAL : IMobileDAL // Kế thừa các phương thức đã khai báo từ đối tượng giao diện
    {
        
        private string txtfile = "Data/Mobile.txt"; // Khai báo biến là tệp dữ liệu điện thoại có phương thức là private dùng trong lớp này.

        private string f = "Data/ThongKe.txt"; // Khai báo biến là tệp dữ liệu thống kê có phương thức là private dùng trong lớp này.

        public List<Mobile> GetAllData() // Khởi tạo hàm lấy dữ liệu thông tin điện thoại với đối tượng là 1 list điện thoại
        {
            List<Mobile> list = new List<Mobile>();// tạo đối tượng list điện thoại 

            StreamReader fread = File.OpenText(txtfile); // Tạo biến fread mở file 
            string s = fread.ReadLine(); // biến s để đọc file
            while (s != null) // Vòng lặp kiểm tra điều kiện đọc file khác rỗng
            {
                if (s != "")  
                {
                    s = Demo.Utility.CongCu.CatXau(s); // công cụ chuẩn hóa xâu
                    string[] a = s.Split('#');// tạo mảng a đọc file loại bỏ ký tự "#"
                    list.Add(new Mobile(int.Parse(a[0]), a[1], a[2], a[3], double.Parse(a[4]), int.Parse(a[5]), int.Parse(a[6])));// hiển thị liệt kê các thuộc tính của điện thoại
                }
                s = fread.ReadLine();
            }
            fread.Close(); // đóng file
            return list; // trả lại danh sách thông tin điện thoại
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
       
        public int GetID() // khởi tạo hàm GetID để dùng cho việc đánh mã tự động
        { 
            StreamReader fread = File.OpenText(txtfile); // mở file
            string s = fread.ReadLine();// đọc file
            string tmp = "";
            while (s != null)// vòng lặp kiểm tra điều kiện
            {
                if(s!="")tmp = s;
                s = fread.ReadLine();
            }
            fread.Close(); // đóng file
            if (tmp == "") return 0;
            else
            {
                tmp = Demo.Utility.CongCu.ChuanHoaXau(tmp);
                string[] a = tmp.Split('#');
                return int.Parse(a[0]);// trả lại phần tử thứ nhất là ID trong list điện thoại
            }
        }
        
        public void Add(Mobile mb) // khai báo hàm Add với phương thức public để có thể sử dụng hàm thêm này ở các class khác và kiểu void ko return giá trị
        {
            int id = GetID()+1; // lấy ID của hàm GetID để dùng cho việc đánh ID tự động thêm 1 khi thêm thông tin điện thoại mới vào

            StreamWriter fwrite = File.AppendText(txtfile); // thêm vào file

            fwrite.WriteLine();
            fwrite.Write(id + "#" + mb.TenDT + "#" + mb.NhaCC + "#" + mb.Type + "#" + mb.Price + "#" + mb.Sale + "#" + mb.Quantum);// ghi thông tin điện thoại vào tệp cách nhau bởi dấu "#"

            fwrite.Close();// đóng file
        }
        //Xóa một điện thoại khi biết mã
        public void Delete(int id) // Hàm xóa dùng public để dùng hàm ở các class khác với tham số thuyền vào là id điện thoại người nhập muốn xóa
        { 
            List<Mobile> list = GetAllData(); // gán hàm lấy toàn bộ dữ liệu từ tệp là list

            StreamWriter fwrite = File.CreateText(txtfile); // mở file

            foreach(Mobile mb in list) // lặp qua list
                if (mb.Id != id) // nếu id của đối tượng điện thoại khác id nhập
                    fwrite.WriteLine(mb.Id + "#" + mb.TenDT + "#" + mb.NhaCC + "#" + mb.Type + "#" + mb.Price + "#" + mb.Sale + "#" + mb.Quantum); // ghi các id khác loại bỏ id đã nhập

            fwrite.Close(); // đóng file
        }

        // Hàm thống kê phương thức public dùng trong class khác
        public void ThongKe()
        {
            List<Mobile> list = GetAllData();// gán hàm lấy toàn bộ dữ liệu từ tệp là list

            StreamWriter fwrite = File.CreateText(f);// mở file

            foreach (Mobile mb in list)// lặp qua list
                if (mb.Quantum >0) // Nếu số lượng > 0
                    fwrite.WriteLine(mb.Id + "#" + mb.TenDT + "#" + mb.NhaCC + "#" + mb.Type + "#" + mb.Price + "#" + mb.Sale + "#" + mb.Quantum);// ghi vào file
            fwrite.Close();// đóng file
        }

        public void Update(Mobile id) // hàm cập nhật thông tin điện thoại phương thức public để sử dụng ở các class khác với tham số truyền vào là id của đối tượng
        {
            List<Mobile> list = GetAllData(); // tạo danh sách lưu các giá trị lấy từ hàm GetAllData
            for (int i = 0; i < list.Count; ++i) // Lặp các phần tử trong list
                if (list[i].Id == id.Id) { list[i] = id; break; } // kiểm tra nếu id bằng id truyền vào

            StreamWriter fwrite = File.CreateText(txtfile); // mở file

            foreach (Mobile mb in list)// Lặp các phần tử trong list

                fwrite.WriteLine(mb.Id + "#" + mb.TenDT + "#" + mb.NhaCC + "#" + mb.Type + "#" + mb.Price + "#" + mb.Sale + "#" + mb.Quantum);// Cập nhật ghi đè lên thông tin cũ

            fwrite.Close();// đóng file
        }

        public void Sort() // khai báo hàm sắp xếp giảm dần phương thức public để dùng ở các class khác và kiểu void ko return giá trị
        {
            List<Mobile> list = GetAllData(); // gán hàm lấy toàn bộ dữ liệu từ tệp là list
            int n = list.Count;// lấy độ dài của list
            double price;// biến trung gian so sánh
            for (int i = 0; i < n-1; i++) // Lặp qua list điện thoại
            {
                int min = i; // vị trí đầu tiên
                for (int j = i + 1; j < n; j++)// lặp lồng để so sánh vị trí sau
                {
                    if (list[j].Price < list[min].Price)// Nếu vị trí đầu lớn hơn vị trí sau
                    {
                       // Thao tác trung gian đổi vị trí
                        price = list[i].Price;
                        list[i].Price = list[j].Price;
                        list[j].Price = price;
                    }
                    StreamWriter fwrite = File.CreateText(txtfile); // mở file
                    for (int g = 0; g < n; ++g) // lặp phần tử trong list
                        fwrite.WriteLine(list[g].Id + "#" + list[g].TenDT + "#" + list[g].NhaCC + "#" + list[g].Type + "#" + list[g].Price + "#" + list[g].Sale + "#" + list[g].Quantum); // ghi lại thông tin điện thoại đã được sắp xếp

                    fwrite.Close();// đóng file

                }
            }      
        }

    }
}
