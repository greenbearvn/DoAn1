using System;
using System.Collections.Generic;
using System.Text;
using Demo.Entities;
using Demo.Business.Components;
using Demo.Business.Services;

namespace Demo.Presenation
{

    //Giao tiếp với người sử dụng để giải quyết vấn đề của bài toán với các yêu cầu được đặt
    //ra trong Service Interface của Business
    class FormHoaDon
    {
        private IHoaDonBLL mobile = new HoaDonBLL(); // Tạo 1 đối tượng để dùng các chức năng từ phần HoaDonBLL

        //hàm hiển thị hóa đơn với tham số truyền vào là danh sách hóa đơn , vị trí cách lề trái làn x, vị trí cách lề trên là y, chuỗi tiêu đề, chuỗi khi thực hiện xong, n là số phần tử của list được xuất hiện
        int HienHD(List<HoaDon> list, int x, int y, string tieudedau, string tieudecuoi, int n)
        {

            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine();
            
            Console.WriteLine();
            Console.WriteLine(tieudedau);
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            y = y + 4;
            Console.SetCursorPosition(x + 1, y); Console.Write("MaHD");
            Console.SetCursorPosition(x + 6, y); Console.Write("Ten DT");
            Console.SetCursorPosition(x + 25 , y); Console.Write("Ho Ten KH");
            Console.SetCursorPosition(x + 50 , y); Console.Write("Ngày đặt");
            Console.SetCursorPosition(x + 70 , y); Console.Write("Giá");
            Console.SetCursorPosition(x + 85 , y); Console.Write("Sale");
            Console.SetCursorPosition(x + 100, y); Console.Write("So Luong");
            Console.SetCursorPosition(x + 110 , y); Console.Write("Tổng");
            int d = 0;
            for (int i = list.Count - 1; i >= 0; --i) // Lặp qua danh sách để hiển thị các thuộc tính
            {
                y = y + 1;
                Console.SetCursorPosition(1, y); Console.Write(list[i].Id.ToString());
                Console.SetCursorPosition(6, y); Console.Write(list[i].TenDT);
                Console.SetCursorPosition(25, y); Console.Write(list[i].HoTenKH);
                Console.SetCursorPosition(50, y); Console.Write(list[i].Ngaydat);
                Console.SetCursorPosition(70, y); Console.Write(list[i].Price.ToString());
                Console.SetCursorPosition(85, y); Console.Write(list[i].Sale.ToString());
                Console.SetCursorPosition(100, y); Console.Write(list[i].Soluong.ToString());
                Console.SetCursorPosition(110, y); Console.Write(list[i].Total.ToString());
                Console.WriteLine();
                if ((++d) == n) break; //Nếu hiển thị bằng số lượng n thì dừng
            }
            Console.WriteLine();
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            
            Console.Write(tieudecuoi);
            return Console.CursorTop;
        }
        
        public void Hien() // hàm hiển thị danh sách điện thoại
        {

            string exit = ""; // biến cục bộ dùng cho việc thoát
            do
            {
                Console.Clear();
                IHoaDonBLL hoadon = new HoaDonBLL(); //tạo đối tượng hoadon từ HoaDonBLL để dùng các chức năng từ phần đó

                // gọi hàm hiển thị đã có ở bên trên và truyền giá trị danh sách lấy tất cả dữ liệu và các giá trị khác 
                HienHD(hoadon.GetAllData(), 0, 0, "                 DANH SACH HOA DON                      ", "Nhan vào Enter de thoat!", 30);
                exit = Console.ReadLine();
                if (exit == "") return; // Nếu là rỗng thì thoát
            } while (true);
        }

        // Tạo hàm nhập hóa đơn phương thức public dùng tại class MenuHoaDon kiểu bool 
        public bool NhapHD()
        {
            
            bool exit = false; // tạo biến thoát kiểu bool đặt là false
            do
            {
                IHoaDonBLL hoadon = new HoaDonBLL(); //tạo đối tượng hoadon từ HoaDonBLL để dùng các chức năng từ phần đó
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                     NHAP THONG TIN HOA DON                             ║");
                Console.WriteLine("║════════════════════════════════════════════════════════════════════════║");
                Console.WriteLine("║                                                                        ║");
                Console.WriteLine("║TEN DT:                        Ho Ten Khach Hang:                       ║");
                Console.WriteLine("║                                                                        ║");
                Console.WriteLine("║Ngay dat:             Gia:             So luong:       Sale:            ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════╝");
                //int x = 0, y = 8;
                // Hiển thị thông tin danh sách đã nhập
                //int v = HienHD(hoadon.GetAllData(), x, y, "                 DANH SACH DA NHAP                      ", "Nhan Backspace de thoat, Enter de luu!", 6);
                HoaDon hd = new HoaDon();//tạo đối tượng mới

                // Nhập thông tin các thuộc tính và điều kiện
                Console.SetCursorPosition(11, 4); 
                do
                {
                    hd.TenDT = Console.ReadLine();
                } while (hd.TenDT == "");
                Console.SetCursorPosition(54, 4);
                do
                {
                    hd.HoTenKH = Console.ReadLine();
                } while (hd.HoTenKH == "");
                Console.SetCursorPosition(10, 6);
                do
                {
                    hd.Ngaydat = Console.ReadLine();
                } while (hd.Ngaydat == "");
                Console.SetCursorPosition(28, 6);
                do
                {
                    hd.Price = double.Parse(Console.ReadLine());
                } while (hd.Price < 0);
                Console.SetCursorPosition(50, 6);
                do
                {
                    hd.Soluong = int.Parse(Console.ReadLine());
                } while (hd.Soluong < 0);
                Console.SetCursorPosition(65, 6);
                do
                {
                    hd.Sale = int.Parse(Console.ReadLine());
                } while (hd.Sale < 0);
               // Console.SetCursorPosition(32, v); 
                

                Console.WriteLine();
                Console.WriteLine("═════════════════════════════════════════════════════════════════════");
                Console.WriteLine("                        HÓA ĐƠN BÁN HÀNG                     ");
                Console.WriteLine("                                                             ");
                Console.WriteLine("      Tên sản phẩm: " + hd.TenDT + "                         ");
                Console.WriteLine("                                                             ");
                Console.WriteLine("      Họ tên khách hàng: " + hd.HoTenKH + "                  ");
                Console.WriteLine("                                                             ");
                Console.WriteLine("      Ngày đặt hàng: " + hd.Ngaydat + "                      ");
                Console.WriteLine("                                                             ");
                Console.WriteLine("      Giá: " + hd.Price + "                                  ");
                Console.WriteLine("                                                             ");
                Console.WriteLine("      Số lượng: " + hd.Soluong + "                           ");
                Console.WriteLine("                                                             ");
                Console.WriteLine("      Sale: " + hd.Sale + "                                  ");
                Console.WriteLine("                                                              ");
                Console.WriteLine("║═════════════════════════════════════════════════════════════════════║");
                Console.WriteLine("║                        Tổng tiền: " + hd.Total + "                  ║");
                Console.WriteLine("╚═════════════════════════════════════════════════════════════════════╝");
                ConsoleKeyInfo kt = Console.ReadKey(); // Nhập Ký tự
                if (kt.Key == ConsoleKey.Backspace) return exit; // Nếu ấn Backspace là thoát
                else if (kt.Key == ConsoleKey.Enter) // Nhấn Enter
                    hoadon.Add(hd); // Gọi hàm thêm MobileBLL

            } while (true);
        }
        
        public void XoaHD()
        {
            do
            {
                Console.Clear();
                IHoaDonBLL hoadon = new HoaDonBLL(); //tạo đối tượng hoadon từ HoaDonBLL để dùng các chức năng từ phần đó

                // gọi hàm hiển thị đã có ở bên trên và truyền giá trị danh sách lấy tất cả dữ liệu và các giá trị khác
                HienHD(hoadon.GetAllData(), 0, 0, "                 DANH SACH HOA DON                  ", "Để thoát chương trình vui lòng nhập số 69:   \n", 20);
                Console.Write("Nhập mã sản phẩm muốn xóa: ");
                int id = int.Parse("0" + Console.ReadLine()); // Nhập id xóa
                if (id == 69) return; // nếu id = 69 thì thoát
                else hoadon.Delete(id); // ngược lại gọi hàm xóa 
            } while (true);
        }

        public void TimHD()
        {
            string tenHD = ""; // gán tìm tên bằng xâu rỗng
            do
            {
                Console.Clear();
                IHoaDonBLL hoadon = new HoaDonBLL(); //tạo đối tượng hoandon từ HoaDonBLL để dùng các chức năng từ phần đó

                // khởi tạo đối tượng list được lấy dữ liệu từ hàm tìm có các tham số truyền vào
                List<HoaDon> list = mobile.TimHD(new HoaDon(0, tenHD, null, null, 0, 0,0,0));

                // gọi hàm hiển thị đã có ở bên trên và truyền giá trị danh sách lấy tất cả dữ liệu và các giá trị khác
                HienHD(list, 0, 0, "                 DANH SACH HOA DON                      ", "Nhan vào Enter de thoat! \n", 30);
                Console.Write("Nhập tên sản phẩm cần tìm: ");
                tenHD = Console.ReadLine(); // Nhập tên hóa đơn cần tìm
                if (tenHD == "") return; // nếu hóa đơn bằng sâu rỗng thì thoát
            } while (true);
        }

        // Hàm sửa thông tin điện thoại có phương thức public dùng trong class MenuHoaDon kiểu void ko trả về giá trị
        public void SuaHD()
        {

            // Khởi tạo các biến đặt giá trị mặc định để cập nhật thuộc tính mới
            string TenDT = null;
            string HoTenKH = null;
            string Ngaydat = null;
            double Price = 0;
            int Soluong = 0;
            int Sale = 0;

            //Hiên thị mẫu nhập
            Console.Clear();

            // Phần giao diện sửa thông tin
            Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                             NHAP THONG TIN HOA DON                                          ║");
            Console.WriteLine("║═════════════════════════════════════════════════════════════════════════════════════════════║");
            Console.WriteLine("║Nhap ID:                                                                                     ║");
            Console.WriteLine("║TEN DT:                         Ho Ten Khach Hang:                                           ║");
            Console.WriteLine("║                                                                                             ║");
            Console.WriteLine("║Ngay dat:                   Gia:                  So luong:                Sale:             ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════════════════╝");
            int v = Console.CursorTop; // biến con trỏ

            IHoaDonBLL hoadon = new HoaDonBLL();//tạo đối tượng hoadon từ HoaDonBLL để dùng các chức năng từ phần đó
            HienHD(hoadon.GetAllData(), 0, 8, "                 DANH SACH HOA DON                  ", "", 20);
            Console.SetCursorPosition(12, 3); int id = int.Parse(Console.ReadLine()); // Nhập ID cần sửa thông tin 

            HoaDon hd = mobile.LayHDtheoID(id);// hàm hiển thị thông tin hóa đơn khi người dùng nhập mã của nó
            if (hd != null) // nếu list khác rỗng
            {
                // Hiển thị thông tin cuả điện thoại
                Console.SetCursorPosition(11, 4); Console.Write(hd.TenDT);
                Console.SetCursorPosition(59, 4); Console.Write(hd.HoTenKH);
                Console.SetCursorPosition(12, 6); Console.Write(hd.Ngaydat);
                Console.SetCursorPosition(34, 6); Console.Write(hd.Price);
                Console.SetCursorPosition(62, 6); Console.Write(hd.Soluong);
                Console.SetCursorPosition(84, 6);
                //Nhập lại thông tin mới
                Console.SetCursorPosition(15, 4); try { TenDT = Console.ReadLine(); } catch { }
                Console.SetCursorPosition(68, 4); try { HoTenKH = Console.ReadLine(); } catch { }
                Console.SetCursorPosition(17, 6); try { Ngaydat = Console.ReadLine(); } catch { }
                Console.SetCursorPosition(37, 6); try { Price = double.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(65, 6); try { Soluong = int.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(87, 6); try { Sale = int.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(0, v);//Đưa con trỏ tới vị trí cuối cùng của danh sách được hiện thị ở trên dựa vào v
                Console.Write("Nhan Esc de thoat, Enter de luu!");
                //Nếu có dữ liệu có thay đổi thị cập nhật lại
                if (hd.TenDT != TenDT && TenDT != null) hd.TenDT = TenDT;
                if (hd.HoTenKH != HoTenKH && HoTenKH != null) hd.HoTenKH = HoTenKH;
                if (hd.Ngaydat != Ngaydat && Ngaydat != null) hd.Ngaydat = Ngaydat;
                if (hd.Price != Price && Price != 0) hd.Price = Price;
                if (hd.Soluong != Soluong && Soluong != 0) hd.Soluong = Soluong;
                if (hd.Sale != Sale && Sale != 0) hd.Sale = Sale;
                //Đợi xem người dùng lựa chọn chức năng gì(thoát hay nhập)
                Console.SetCursorPosition(33, Console.CursorTop);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape) return;
                else if (kt.Key == ConsoleKey.Enter) { hoadon.Update(hd); return; }
            }
            else Console.Write("KHong co ma hoa don ban vua nhap xin vui long nhap lai!"); Console.ReadKey();

        }
    }
}
