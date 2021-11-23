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
    public class FormMobile
    { 
        private IMobileBLL mobile = new MobileBLL();// Tạo 1 đối tượng để dùng các chức năng từ phần MobileBLL
         

        //hàm hiển thị điện thoại với tham số truyền vào là danh sách điện thoại , vị trí cách lề trái làn x, vị trí cách lề trên là y, chuỗi tiêu đề, chuỗi khi thực hiện xong, n là số phần tử của list được xuất hiện
         int HienMB(List<Mobile> list, int x, int y, string tieudedau, string tieudecuoi, int n)
        { 
            
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(tieudedau);// hiển thị tiêu đề
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════");
            y = y + 4;// đặt cách là 4
            Console.SetCursorPosition(x + 1, y); Console.Write("MADT");// cách lề phải 1, cách trên 4
            Console.SetCursorPosition(x + 7, y); Console.Write("Ten DT");// cách lề phải 7, cách trên 4
            Console.SetCursorPosition(x + 28, y); Console.Write("NHA CC");// cách lề phải 28, cách trên 4
            Console.SetCursorPosition(x + 37, y); Console.Write("LOAI");// cách lề phải 37, cách trên 4
            Console.SetCursorPosition(x + 45, y); Console.Write("GIA");// cách lề phải 45, cách trên 4
            Console.SetCursorPosition(x + 54, y); Console.Write("SALE");// cách lề phải 54, cách trên 4
            Console.SetCursorPosition(x + 62, y); Console.Write("SO LUONG");// cách lề phải 62, cách trên 4
            int d = 0;
            for (int i = list.Count - 1; i >= 0; --i)// Lặp qua danh sách để hiển thị các thuộc tính
            {
                y = y + 1;
                Console.SetCursorPosition(1, y); Console.Write(list[i].Id.ToString());
                Console.SetCursorPosition(7, y); Console.Write(list[i].TenDT);
                Console.SetCursorPosition(28, y); Console.Write(list[i].NhaCC);
                Console.SetCursorPosition(37, y); Console.Write(list[i].Type);
                Console.SetCursorPosition(45, y); Console.Write(list[i].Price.ToString());
                Console.SetCursorPosition(54, y); Console.Write(list[i].Sale.ToString());
                Console.SetCursorPosition(62, y); Console.Write(list[i].Quantum.ToString());
                Console.WriteLine();
                if ((++d) == n) break;//Nếu hiển thị bằng số lượng n thì dừng
            }
            Console.WriteLine();
            Console.Write(tieudecuoi);// hiển thị tiêu đề cuối
            return Console.CursorTop;
        }
        

        public void Hien() // hàm hiển thị danh sách điện thoại
        {
            
            string exit = "";// biến cục bộ dùng cho việc thoát
            do
            {
                Console.Clear();// Xóa tất cả bắt đầu để hiển thị

                IMobileBLL mobile = new MobileBLL();//tạo đối tượng mobile từ MobileBLL để dùng các chức năng từ phần đó
                
                // gọi hàm hiển thị đã có ở bên trên và truyền giá trị danh sách lấy tất cả dữ liệu và các giá trị khác 
                HienMB(mobile.GetAllData(), 0, 0, "                 DANH SACH DIEN THOAI                       ", "Nhan vào Enter de thoat!", 30);
                exit = Console.ReadLine();// Nhập thoát
                if (exit == "") return; // Nếu là rỗng thì thoát
            } while (true);//vòng lặp nhập 
        }

        public void ThongKe()
        {
            
            do
            {
                Console.Clear();// Xóa tất cả bắt đầu để hiển thị
                IMobileBLL mobile = new MobileBLL(); //tạo đối tượng mobile từ MobileBLL để dùng các chức năng từ phần đó

                // gọi hàm hiển thị đã có ở bên trên và truyền giá trị list đã thống kê và các giá trị cần khác
                HienMB(mobile.GetThongKe(), 0, 0, "                 DANH SACH DIEN THOAI CON HANG                       ", "Nhan vao Enter de thong ke!", 30);
                ConsoleKeyInfo kt = Console.ReadKey(); // Nhập ký tự

                if (kt.Key == ConsoleKey.Escape) return; // Nếu là phím Esc thì thoát

                else if (kt.Key == ConsoleKey.Enter) // ngược lại nếu nhận là phím Enter 
                    mobile.ThongKe();  // Gọi hàm Thống kê từ MobileBLL

            } while (true);//vòng lặp nhập 
        }

        public void Sort()
        {

            do
            {
                Console.Clear(); // Xóa tất cả bắt đầu để hiển thị

                IMobileBLL mobile = new MobileBLL();//tạo đối tượng mobile từ MobileBLL để dùng các chức năng từ phần đó

                // gọi hàm hiển thị đã có ở bên trên và truyền giá trị danh sách lấy tất cả dữ liệu và các giá trị khác
                HienMB(mobile.GetAllData(), 0, 0, "                 DANH SÁCH ĐIỆN THOẠI ĐÃ SẮP XẾP                      ", "Nhấn ESC để thoát và NHấn vào Enter để sắp xếp!", 30);

                ConsoleKeyInfo kt = Console.ReadKey(); // Nhập ký tự

                if (kt.Key == ConsoleKey.Escape) return; // Nếu là phím Esc thì thoát
                else if (kt.Key == ConsoleKey.Enter) //ngược lại nếu nhận là phím Enter
                    mobile.Sort();  // Gọi hàm Sắp xếp từ MobileBLL
            } while (true);
        }

        // Tạo hàm nhập điện thoại phương thức public dùng tại class MenuMobile kiểu bool 
        public bool NhapMB()
        {
            bool exit = false; // tạo biến thoát kiểu bool đặt là false
            do
            {
                IMobileBLL mobile = new MobileBLL(); //tạo đối tượng mobile từ MobileBLL để dùng các chức năng từ phần đó
                Console.Clear();
                Console.WriteLine("╔═══════════════════════════════════════════════════════════╗ ");
                Console.WriteLine("║                NHAP THONG TIN DIEN THOAI                  ║");
                Console.WriteLine("║═══════════════════════════════════════════════════════════║");
                Console.WriteLine("║                                                           ║");
                Console.WriteLine("║TEN DT:                    Nha cung cap:                   ║");
                Console.WriteLine("║                                                           ║");
                Console.WriteLine("║Loai:          Gia:          Sale:      So luong:          ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════════╝  ");
                int x = 0, y = 8;
                // Hiển thị thông tin danh sách đã nhập
                int v = HienMB(mobile.GetAllData(),x, y, "                 DANH SACH DA NHAP                      ", "Nhan Backspace de thoat, Enter de luu!", 6);

                Mobile mb = new Mobile();//tạo đối tượng mới
                // Nhập thông tin các thuộc tính và điều kiện
                Console.SetCursorPosition(10, 4);
                do
                {
                    mb.TenDT = Console.ReadLine();
                } while (mb.TenDT == "");
                Console.SetCursorPosition(43, 4);
                do
                {
                    mb.NhaCC = Console.ReadLine();
                } while (mb.NhaCC == "");
                Console.SetCursorPosition(8, 6);
                do
                {
                    mb.Type = Console.ReadLine();
                } while (mb.Type == "");
                Console.SetCursorPosition(22, 6);
                do
                {
                    mb.Price = double.Parse(Console.ReadLine());
                } while (mb.Price < 0 );
                Console.SetCursorPosition(37, 6);
                do
                {
                    mb.Sale = int.Parse(Console.ReadLine());
                } while (mb.Sale < 0);
                Console.SetCursorPosition(52, 6);
                do
                {
                    mb.Quantum = int.Parse(Console.ReadLine());
                } while (mb.Quantum < 0);
                Console.SetCursorPosition(32, v);                
                ConsoleKeyInfo kt = Console.ReadKey(); // Nhập Ký tự
                if (kt.Key == ConsoleKey.Backspace) return exit; // Nếu ấn Backspace là thoát
                else if (kt.Key == ConsoleKey.Enter) // Nhấn Enter
                    mobile.Add(mb); // Gọi hàm thêm MobileBLL
            } while (true); // Vòng lặp nhập
        }
        
        public void XoaMB()
        {
            do
            {
                Console.Clear(); // Xóa tất cả bắt đầu để hiển thị
                IMobileBLL mobile = new MobileBLL(); //tạo đối tượng mobile từ MobileBLL để dùng các chức năng từ phần đó

                // gọi hàm hiển thị đã có ở bên trên và truyền giá trị danh sách lấy tất cả dữ liệu và các giá trị khác
                HienMB(mobile.GetAllData(),0, 0, "                 DANH SACH DIEN THOAI TRONG KHO                  ", "Nhap MADT can xoa, thoat nhap 69:   ", 20);
                int id = int.Parse("0" + Console.ReadLine()); // Nhập id xóa
                if (id == 69) return; // nếu id = 69 thì thoát
                else mobile.Delete(id); // ngược lại gọi hàm xóa
            } while (true);
        }
       
        public void TimDT()
        {
            string tenDT = "";// gán tìm tên bằng xâu rỗng
            do
            {
                Console.Clear(); // Xóa tất cả bắt đầu để hiển thị

                IMobileBLL mobile = new MobileBLL();//tạo đối tượng mobile từ MobileBLL để dùng các chức năng từ phần đó

                // khởi tạo đối tượng list được lấy dữ liệu từ hàm tìm có các tham số truyền vào
                List<Mobile> list = mobile.Timdt(new Mobile(0, tenDT, null, null, 0, 0,0));

                // gọi hàm hiển thị đã có ở bên trên và truyền giá trị danh sách lấy tất cả dữ liệu và các giá trị khác
                HienMB(list,0, 0, "                 DANH SACH DIEN THOAI                      ", "Nhap  Ten can tim, Nhan vao Enter de thoat!", 30);
                
                 tenDT = Console.ReadLine(); // Nhập tên điện thoại cần tìm
                
                if (tenDT == "") return; // nếu điện thoại bằng sâu rỗng thì thoát
            } while (true);
        }

        // Hàm sửa thông tin điện thoại có phương thức public dùng trong class MenuMobile kiểu void ko trả về giá trị
        public void SuaMB()
        {
            // Khởi tạo các biến đặt giá trị mặc định để cập nhật thuộc tính mới
            string TenDT = null;
            string NhaCC = null;
            string Type = null;
            double Price = 0;
            int Sale = 0;
            int Quantum = 0;
            
            Console.Clear();
            // Phần giao diện sửa thông tin
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                            CAP NHAT THONG TIN DIEN THOAI                               ║");
            Console.WriteLine("║════════════════════════════════════════════════════════════════════════════════════════║");
            Console.WriteLine("║Nhap ID:                                                                                ║");
            Console.WriteLine("║TEN DT:                                             Nha cung cap:                       ║");
            Console.WriteLine("║                                                                                        ║");
            Console.WriteLine("║Loai:                Gia:                           Sale:           Soluong:            ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════╝");
            int v = Console.CursorTop;// biến con trỏ
            
            IMobileBLL mobile = new MobileBLL(); //tạo đối tượng mobile từ MobileBLL để dùng các chức năng từ phần đó

            // Nhập ID cần sửa thông tin 
            Console.SetCursorPosition(12, 3); int id = int.Parse(Console.ReadLine());
            Mobile mb = mobile.LayMBtheoID(id); // hàm hiển thị thông tin điện thoại khi người dùng nhập mã của nó

            if (mb != null) // nếu list khác rỗng
            {
                // Hiển thị thông tin cuả điện thoại
                Console.SetCursorPosition(10, 4); Console.Write(mb.TenDT);
                Console.SetCursorPosition(66, 4); Console.Write(mb.NhaCC);
                Console.SetCursorPosition(8, 6); Console.Write(mb.Type);
                Console.SetCursorPosition(28, 6); Console.Write(mb.Price);
                Console.SetCursorPosition(60, 6); Console.Write(mb.Sale);
                Console.SetCursorPosition(80, 6); Console.Write(mb.Quantum);
                //Nhập lại thông tin mới
                Console.SetCursorPosition(28, 4); try {
                    do
                    {
                        mb.TenDT = Console.ReadLine();
                    } while (mb.TenDT == "");
                } catch { }
                Console.SetCursorPosition(75, 4); try {
                    do
                    {
                        mb.NhaCC = Console.ReadLine();
                    } while (mb.NhaCC == "");
                } catch { }
                Console.SetCursorPosition(15, 6); try {
                    do
                    {
                        mb.Type = Console.ReadLine();
                    } while (mb.Type == "");
                } catch { }
                Console.SetCursorPosition(41, 6); try {
                    do
                    {
                        mb.Price = double.Parse(Console.ReadLine());
                    } while (mb.Price < 0);
                } catch { }
                Console.SetCursorPosition(63, 6); try {
                    do
                    {
                        mb.Sale = int.Parse(Console.ReadLine());
                    } while (mb.Sale < 0);
                } catch { }
                Console.SetCursorPosition(84, 6); try {
                    do
                    {
                        mb.Quantum = int.Parse(Console.ReadLine());
                    } while (mb.Quantum < 0);
                } catch { }
                Console.SetCursorPosition(0, v);//Đưa con trỏ tới vị trí cuối cùng của danh sách được hiện thị ở trên dựa vào v
                Console.Write("Nhan Esc de thoat, Enter de luu!");
                //Nếu có dữ liệu có thay đổi thị cập nhật lại
                if (mb.TenDT != TenDT && TenDT != null) mb.TenDT = TenDT;
                if (mb.NhaCC != NhaCC && NhaCC != null) mb.NhaCC = NhaCC;
                if (mb.Type != Type && Type != null) mb.Type = Type;
                if (mb.Price != Price && Price != 0) mb.Price = Price;
                if (mb.Sale != Sale && Sale == 0) mb.Sale = Sale;
                if (mb.Quantum != Quantum ) mb.Quantum = Quantum;
                //Đợi xem người dùng lựa chọn chức năng gì(thoát hay nhập)
                Console.SetCursorPosition(33, Console.CursorTop);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape) return;
                else if (kt.Key == ConsoleKey.Enter) { mobile.Update(mb); return; }
            }
            else Console.Write("KHong co ma dien thoai ban vua nhap xin vui long nhap lai!"); Console.ReadKey();

        }

    }
}

