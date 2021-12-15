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
        private IHoaDonBLL hoadon = new HoaDonBLL(); // Tạo 1 đối tượng để dùng các chức năng từ phần HoaDonBLL
        private MobileBLL mobile = new MobileBLL();
        private EmployeeBLL employee = new EmployeeBLL();
        private CustomerBLL customer = new CustomerBLL();


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
            Console.SetCursorPosition(x + 1, y); Console.Write("║ MaHD");
            Console.SetCursorPosition(x + 6, y); Console.Write("║ Ten DT");
            Console.SetCursorPosition(x + 25 , y); Console.Write("║ Ho Ten KH");
            Console.SetCursorPosition(x + 50 , y); Console.Write("║ Ngày đặt");
            Console.SetCursorPosition(x + 70 , y); Console.Write("║ Giá");
            Console.SetCursorPosition(x + 85 , y); Console.Write("║ Sale");
            Console.SetCursorPosition(x + 95, y); Console.Write("║ So Luong");
            Console.SetCursorPosition(x + 110 , y); Console.Write("║ Tổng  ");
            int d = 0;
            for (int i = list.Count - 1; i >= 0; --i) // Lặp qua danh sách để hiển thị các thuộc tính
            {
                y = y + 1;
                Console.SetCursorPosition(1, y); Console.Write("║ " + list[i].Id.ToString());
                Console.SetCursorPosition(6, y); Console.Write("║ " + list[i].TenDT);
                Console.SetCursorPosition(25, y); Console.Write("║ " + list[i].HoTenKH);
                Console.SetCursorPosition(50, y); Console.Write("║ " + list[i].Ngaydat);
                Console.SetCursorPosition(70, y); Console.Write("║ " + list[i].Price.ToString());
                Console.SetCursorPosition(85, y); Console.Write("║ " + list[i].Sale.ToString());
                Console.SetCursorPosition(95, y); Console.Write("║ " + list[i].Quantum.ToString());
                Console.SetCursorPosition(110, y); Console.Write("║ " + list[i].Total.ToString());
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

        public bool NhapHD()
        {

            bool exit = false; // tạo biến thoát kiểu bool đặt là false
            do
            {
                IHoaDonBLL hoadon = new HoaDonBLL(); //tạo đối tượng hoadon từ HoaDonBLL để dùng các chức năng từ phần đó
                Console.Clear();
                Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                                HOÁ ĐƠN NHẬP                                       ║");
                Console.WriteLine("║═══════════════════════════════════════════════════════════════════════════════════║");
                Console.WriteLine("║                                                                                   ║");
                Console.WriteLine("║ Mã điện thoại:                                                                    ║");
                Console.WriteLine("║                                                                                   ║");
                Console.WriteLine("║ Tên điện thoại:                                                                   ║");
                Console.WriteLine("║                                                                                   ║");
                Console.WriteLine("║ Giá:                                           Nhà cung cấp:                      ║");
                Console.WriteLine("║                                                                                   ║");
                Console.WriteLine("║ Mã khách hàng:                                                                    ║");
                Console.WriteLine("║                                                                                   ║");
                Console.WriteLine("║ Tên khách hàng:                                Địa chỉ:                           ║");
                Console.WriteLine("║                                                                                   ║");
                Console.WriteLine("║ Mã nhân viên:                                                                     ║");
                Console.WriteLine("║                                                                                   ║");
                Console.WriteLine("║ Tên nhân viên:                                                                    ║");
                Console.WriteLine("║                                                                                   ║");
                Console.WriteLine("║ Ngày nhập:                                                                        ║");
                Console.WriteLine("║                                                                                   ║");
                Console.WriteLine("║ Số lượng:                                       Giảm giá:                         ║");
                Console.WriteLine("║                                                                                   ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════╝");
                //int x = 0, y = 8;
                // Hiển thị thông tin danh sách đã nhập
                //int v = HienHD(hoadon.GetAllData(), x, y, "                 DANH SACH DA NHAP                      ", "Nhan Backspace de thoat, Enter de luu!", 6);
                HoaDon hd = new HoaDon();//tạo đối tượng mới
                Console.SetCursorPosition(0, 25);
                Console.WriteLine("Nhấn Enter để lưu, nhấn phím Backspace để thoát,\nnếu muốn thoát giữa chừng nếu nhập số điền là 0, nếu là chuỗi thì ấn enter để thoát nhập!");
            // Nhập thông tin các thuộc tính và điều kiện
            m: try
                {
                    do
                    {
                        Console.SetCursorPosition(17, 4);
                        hd.MaDT = int.Parse(Console.ReadLine());

                        if (hd.MaDT == 0)
                        {
                            return exit;
                        }

                        if (mobile.CheckID(hd.MaDT))
                        {
                            break;
                        }
                        else
                            Console.SetCursorPosition(0, 22);
                            Console.WriteLine("Mã điện thoại không tồn tại vui lòng nhập mã khác");
                        
                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 22);
                    Console.WriteLine(" Mã điện thoại không đúng định dạng vui lòng nhập mã khác \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto m;
                    }
                    else
                        return exit;
                }
                IMobileBLL mobi = new MobileBLL();
                Mobile mb = mobi.LayMBtheoID(hd.MaDT);
                Console.SetCursorPosition(18, 6);
                Console.Write(hoadon.GetMobileName(hd));
                hd.TenDT = hoadon.GetMobileName(hd);
                Console.SetCursorPosition(7, 8);
                Console.Write(hoadon.GetPrice(hd));
                hd.Price = hoadon.GetPrice(hd);
                Console.SetCursorPosition(63, 20);
                Console.WriteLine(mb.Sale);
                hd.Sale = mb.Sale;
                Console.SetCursorPosition(63, 8);
                Console.WriteLine(mb.NhaCC);
                hd.Nhacc = mb.NhaCC;

            c: try
                {
                    do
                    {
                        Console.SetCursorPosition(17, 10);
                        hd.Makh = int.Parse(Console.ReadLine());

                        if (customer.CheckID(hd.Makh))
                        {
                            break;
                        }
                        else if (hd.Makh == 0)
                        {
                            return exit;
                        }
                        else
                            Console.SetCursorPosition(0, 22);
                            Console.WriteLine("Mã khách hàng không tồn tại vui lòng nhập mã khác");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 22);
                    Console.WriteLine(" Mã khách hàng không đúng định dạng vui lòng nhập mã khác \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto c;
                    }
                    else
                        return exit;
                }
                Console.SetCursorPosition(18, 12);
                Console.Write(hoadon.GetCustomerName(hd));
                hd.HoTenKH = hoadon.GetCustomerName(hd);
                Console.SetCursorPosition(59, 12);
                Console.Write(hoadon.GetAddressCustomer(hd));
                hd.Quekh = hoadon.GetAddressCustomer(hd);


            e: try
                {
                    do
                    {
                        Console.SetCursorPosition(16, 14);
                        hd.Manv = int.Parse(Console.ReadLine());

                        if (employee.CheckID(hd.Manv))
                        {
                            break;
                        }
                        else if (hd.Manv == 0)
                        {
                            return exit;
                        }
                        else
                            Console.SetCursorPosition(0, 22);
                            Console.WriteLine("Mã nhân viên không tồn tại vui lòng nhập mã khác");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 22);
                    Console.WriteLine(" Mã nhân viên không đúng định dạng vui lòng nhập mã khác \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto e;
                    }
                    else
                        return exit;
                }
                Console.SetCursorPosition(17, 16);
                Console.Write(hoadon.GetEmployeeName(hd));
                hd.Tennv = hoadon.GetEmployeeName(hd);
                Console.SetCursorPosition(0, 16);

            z: try
                {
                    do
                    {
                        Console.SetCursorPosition(13, 18);
                        hd.Ngaydat = Console.ReadLine().Trim();

                        if (int.Parse(hd.Ngaydat.Substring(0, 2)) < 32 && int.Parse(hd.Ngaydat.Substring(3, 2)) < 13 && int.Parse(hd.Ngaydat.Substring(6, 4)) <= 2021)
                        {
                            break;
                        }
                        else if (hd.Ngaydat == "0")
                        {
                            return exit;
                        }
                        else
                            Console.SetCursorPosition(0, 22);
                            Console.WriteLine("Kiểu dữ liệu ngày tháng năm không hợp lệ. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 22);
                    Console.WriteLine(" Kiểu dữ liệu ngày tháng năm không hợp lệ. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto z;
                    }
                    else
                        return exit;
                }

            q: try
                {
                    do
                    {
                        Console.SetCursorPosition(12, 20);
                        hd.Quantum = int.Parse(Console.ReadLine());

                        if (hd.Quantum > 0)
                        {
                            break;
                        }
                        else if (hd.Quantum == 0)
                        {
                            return exit;
                        }
                        else
                            Console.SetCursorPosition(0, 22);
                            Console.WriteLine("Số lượng nhỏ hơn 0. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 22);
                    Console.WriteLine(" Số lượng nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto q;
                    }
                    else
                        return exit;
                }

                Console.SetCursorPosition(0, 22);
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
                Console.SetCursorPosition(0, 12);
                Console.Write("Nhập mã sản phẩm muốn xóa: ");
                int id;
                HoaDonBLL hd = new HoaDonBLL();
            s: try
                {
                    do
                    {
                        Console.SetCursorPosition(30,12);
                        id = int.Parse("0" + Console.ReadLine()); // Nhập id xóa

                        if(hd.CheckID(id))
                        {
                            break;
                        }
                        else if (id == 0) return ;
                        else if(id < 0)
                        {
                            Console.SetCursorPosition(0, 15);
                            Console.WriteLine("Mã hoá đơn lớn hơn 0. Vui lòng nhập lại");
                        }
                        else
                            Console.SetCursorPosition(0, 15);
                            Console.WriteLine("Mã hoá đơn không tồn tại. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception ex)
                {
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine(" Mã hoá đơn nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto s;
                    }
                    else
                        return ;
                }
                hoadon.Delete(id); // ngược lại gọi hàm xóa 
            } while (true);
        }

        

        public void TimID()
        {
            int id = 0;
            do
            {
                Console.Clear(); // Xóa tất cả bắt đầu để hiển thị

                IHoaDonBLL mobile = new HoaDonBLL();//tạo đối tượng mobile từ MobileBLL để dùng các chức năng từ phần đó

                // khởi tạo đối tượng list được lấy dữ liệu từ hàm tìm có các tham số truyền vào


                // gọi hàm hiển thị đã có ở bên trên và truyền giá trị danh sách lấy tất cả dữ liệu và các giá trị khác
                HienHD(mobile.GetAllData(), 0, 0, "                 DANH SACH HOA DON                      ", "Nhập mã bằng 0 để thoát chương trình!\n", 30);
                Console.SetCursorPosition(0, 12);
                Console.Write("Nhập mã sản phẩm muốn tìm kiếm: ");
                HoaDonBLL hd = new HoaDonBLL();
            s: try
                {
                    do
                    {
                        Console.SetCursorPosition(40, 12);
                        id = int.Parse("0" + Console.ReadLine()); // Nhập id xóa

                        if (hd.CheckID(id))
                        {
                            break;
                        }
                        else if (id == 0) return;
                        else if (id < 0)
                        {
                            Console.SetCursorPosition(0, 15);
                            Console.WriteLine("Mã hoá đơn lớn hơn 0. Vui lòng nhập lại");
                        }
                        else
                            Console.SetCursorPosition(0, 15);
                        Console.WriteLine("Mã hoá đơn không tồn tại. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine(" Mã hoá đơn nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto s;
                    }
                    else
                        return;
                }
                hoadon.TimID(id);
                Console.ReadLine();
            } while (true);
        }

        public void DoanhThu()
        {
            string tenHD = ""; // gán tìm tên bằng xâu rỗng
            do
            {
                Console.Clear();
                IHoaDonBLL hoadon = new HoaDonBLL(); //tạo đối tượng hoandon từ HoaDonBLL để dùng các chức năng từ phần đó

                // khởi tạo đối tượng list được lấy dữ liệu từ hàm tìm có các tham số truyền vào
                

                // gọi hàm hiển thị đã có ở bên trên và truyền giá trị danh sách lấy tất cả dữ liệu và các giá trị khác
                HienHD(hoadon.GetAllData(), 0, 0, "                 DANH SACH HOA DON                      ", "Nhan vào Enter de thoat! \n", 30);
                Console.Write("Tống doanh thu của cửa hàng là: ");
                Console.WriteLine(hoadon.TongDoanhThu());
                tenHD = Console.ReadLine(); // Nhập tên hóa đơn cần tìm
                if (tenHD == "") return;
                else return;// nếu hóa đơn bằng sâu rỗng thì thoát
            } while (true);
        }

        public void DoanhThuThang()
        {
            string month = ""; // gán tìm tên bằng xâu rỗng
            string year = "";
            do
            {
                Console.Clear();
                IHoaDonBLL hoadon = new HoaDonBLL(); //tạo đối tượng hoandon từ HoaDonBLL để dùng các chức năng từ phần đó

                // khởi tạo đối tượng list được lấy dữ liệu từ hàm tìm có các tham số truyền vào


                // gọi hàm hiển thị đã có ở bên trên và truyền giá trị danh sách lấy tất cả dữ liệu và các giá trị khác
                HienHD(hoadon.GetAllData(), 0, 0, "                 DANH SACH HOA DON                      ", "Nhấn số 0 de thoat! \n", 30);
            s: try
                {
                    do
                    {
                        Console.SetCursorPosition(0, 18);
                        Console.Write("Nhập tháng muốn thống kê doanh thu: ");
                        
                        Console.WriteLine(month.Length);

                        if (int.Parse(month) < 13 && month.Length == 2)
                        {
                            break;
                        }
                        else if (month == "0") return;
                        else
                            Console.SetCursorPosition(0, 15);
                            Console.WriteLine("Kiểu dữ liệu tháng chưa đúng. Vui lòng nhập lại");


                    } while (true);
                }
                catch (Exception )
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine(" Kiểu dữ liệu tháng chưa đúng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto s;
                    }
                    else
                        return;
                }

            a: try
                {
                    do
                    {
                        Console.SetCursorPosition(0, 19);
                        Console.Write("Nhập năm muốn thống kê doanh thu: ");
                        year = Console.ReadLine();


                        if (int.Parse(year) < 2022)
                        {
                            break;
                        }
                        else if (year.Length != 4)
                        {
                            Console.SetCursorPosition(0, 15);
                            Console.WriteLine("Số năm không được quá 4 số. Vui lòng nhập lại");
                        }
                        else if (year == "0") return;
                        else
                            Console.SetCursorPosition(0, 15);
                        Console.WriteLine("Kiểu dữ liệu năm chưa đúng. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine(" Kiểu dữ liệu năm chưa đúng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto a;
                    }
                    else
                        return;
                }

                Console.SetCursorPosition(0, 20);
                Console.Write("Tống doanh thu của cửa hàng tháng {0} năm {1} là: ", month, year);
                Console.WriteLine(hoadon.DoanhThuThang(month, year));
                Console.ReadLine();
            } while (true);
        }

        public void Sort()
        {

            do
            {
                Console.Clear(); // Xóa tất cả bắt đầu để hiển thị

                IHoaDonBLL hoadon = new HoaDonBLL();//tạo đối tượng mobile từ MobileBLL để dùng các chức năng từ phần đó
                HienHD(hoadon.GetAllData(), 0, 0, "                 DANH SACH HOA DON                       ", "", 30);
                // gọi hàm hiển thị đã có ở bên trên và truyền giá trị danh sách lấy tất cả dữ liệu và các giá trị khác

                HienHD(hoadon.GetSort(), 0, 12, "                 DANH SÁCH HÓA ĐƠN ĐÃ SẮP XẾP                      ", " Nhấn ESC để thoát \n Nhấn vào Enter để sắp xếp giá giảm dần \n", 30);
                ConsoleKeyInfo kt = Console.ReadKey(); // Nhập ký tự

                if (kt.Key == ConsoleKey.Escape) return; // Nếu là phím Esc thì thoát
                else if (kt.Key == ConsoleKey.Enter) //ngược lại nếu nhận là phím Enter
                    hoadon.Sort();  // Gọi hàm Sắp xếp từ HoaDonBLL
                

            } while (true);
        }
        public void DoanhThuNgay()
        {
            string day = ""; // gán tìm tên bằng xâu rỗng
            string month = "";
            string year = "";
            do
            {
                Console.Clear();
                IHoaDonBLL hoadon = new HoaDonBLL(); //tạo đối tượng hoandon từ HoaDonBLL để dùng các chức năng từ phần đó

                // khởi tạo đối tượng list được lấy dữ liệu từ hàm tìm có các tham số truyền vào


                // gọi hàm hiển thị đã có ở bên trên và truyền giá trị danh sách lấy tất cả dữ liệu và các giá trị khác
                HienHD(hoadon.GetAllData(), 0, 0, "                 DANH SÁCH HOÁ ĐƠN                      ", "Nhấn phím số 0 để thoát! \n", 30);

            b: try
                {
                    do
                    {
                        Console.SetCursorPosition(0, 17);
                        Console.Write("Nhập ngày muốn thống kê doanh thu: ");
                        day = Console.ReadLine();

                        if (day == "0") return;

                        if (int.Parse(day) < 32 && day.Length == 2)
                        {
                            break;
                        }
                        else
                            Console.SetCursorPosition(0, 15);
                        Console.WriteLine("Kiểu dữ liệu ngày chưa đúng. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine(" Kiểu dữ liệu ngày chưa đúng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto b;
                    }
                    else
                        return;
                }


            s: try
                {
                    do
                    {
                        Console.SetCursorPosition(0, 18);
                        Console.Write("Nhập tháng muốn thống kê doanh thu: ");
                        month = Console.ReadLine();

                        if (month == "0") return;

                        if (int.Parse(month) < 13 && month.Length == 2)
                        {
                            break;
                        }
                        else
                            Console.SetCursorPosition(0, 15);
                        Console.WriteLine("Kiểu dữ liệu tháng chưa đúng. Vui lòng nhập lại");


                    } while (true);
                }
                catch (Exception )
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine(" Kiểu dữ liệu tháng chưa đúng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto s;
                    }
                    else
                        return;
                }

            a: try
                {
                    do
                    {
                        Console.SetCursorPosition(0, 19);
                        Console.Write("Nhập năm muốn thống kê doanh thu: ");
                        year = Console.ReadLine();

                        if (year == "0") return;

                        if (int.Parse(year) < 2022)
                        {
                            break;
                        }
                        else if (year.Length != 4)
                        {
                            Console.SetCursorPosition(0, 15);
                            Console.WriteLine("Số năm không được quá 4 số. Vui lòng nhập lại");
                        }
                        else
                            Console.SetCursorPosition(0, 15);
                        Console.WriteLine("Kiểu dữ liệu năm chưa đúng. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine(" Kiểu dữ liệu năm chưa đúng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto a;
                    }
                    else
                        return;
                }

                Console.Write("Tống doanh thu của cửa hàng ngày {0} tháng {1} năm {2} là: ", day,month,year);
                Console.WriteLine(hoadon.DoanhThuNgay(day,month,year));
                Console.ReadLine();
            } while (true);
        }

        // Hàm sửa thông tin điện thoại có phương thức public dùng trong class MenuHoaDon kiểu void ko trả về giá trị
        public void SuaHD()
        {

            // Khởi tạo các biến đặt giá trị mặc định để cập nhật thuộc tính mới
            string TenDT = null;
            string HoTenKH = null;
            string Ngaydat = null;
            string TenNV = null;
            string Address = null;
            string Nhacc = null;
            double Price = 0;
            int Quantum = 0;
            int Sale = 0;
            int Madt = 0;
            int Makh = 0;
            int Manv = 0;

            //Hiên thị mẫu nhập
            Console.Clear();

            // Phần giao diện sửa thông tin
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                CẬP NHẬT THÔNG TIN HOÁ ĐƠN                                              ║");
            Console.WriteLine("║════════════════════════════════════════════════════════════════════════════════════════════════════════║");
            Console.WriteLine("║Nhập ID:                                                                                                ║");
            Console.WriteLine("║Mã điện thoại:                          Tên điện thoại:                                                 ║");
            Console.WriteLine("║                                                          Nhà cung cấp:                                 ║");
            Console.WriteLine("║Số lượng:                                                                                               ║");
            Console.WriteLine("║Mã khách Hàng:                                                                                          ║");
            Console.WriteLine("║Tên khách hàng:                                                   Địa chỉ:                              ║");
            Console.WriteLine("║                                                                                                        ║");
            Console.WriteLine("║Ngày xuất:                                                                                              ║");
            Console.WriteLine("║Mã nhân viên:                                              Tên nhân viên:                               ║");
            Console.WriteLine("║Giá gốc:                                                                                                ║");
            Console.WriteLine("║                                                                                                        ║");
            Console.WriteLine("║Khuyến mại:    %                                                                                        ║");
            Console.WriteLine("║                                                                                                        ║");
            Console.WriteLine("║════════════════════════════════════════════════════════════════════════════════════════════════════════║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            int v = Console.CursorTop; // biến con trỏ

            IHoaDonBLL hoadon = new HoaDonBLL();//tạo đối tượng hoadon từ HoaDonBLL để dùng các chức năng từ phần đó

            HienHD(hoadon.GetAllData(), 0, 19, "                 DANH SACH HOA DON                  ", "", 20);
            int id;
            HoaDonBLL hdb = new HoaDonBLL();
        s: try
            {
                do
                {
                    Console.SetCursorPosition(12, 3);
                    id = int.Parse(Console.ReadLine()); // Nhập id xóa

                    if (hdb.CheckID(id))
                    {
                        break;
                    }
                    else if (id == 0) return;
                    else if (id < 0)
                    {
                        Console.SetCursorPosition(0, 25);
                        Console.WriteLine("Mã hoá đơn lớn hơn 0. Vui lòng nhập lại");
                    }
                    else
                        Console.SetCursorPosition(0, 25);
                        Console.WriteLine("Mã hoá đơn không tồn tại. Vui lòng nhập lại");

                } while (true);
            }
            catch (Exception )
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(0, 25);
                Console.WriteLine(" Mã hoá đơn nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                ConsoleKeyInfo check = Console.ReadKey();
                if (check.Key == ConsoleKey.Enter)
                {
                    goto s;
                }
                else
                    return;
            }
            HoaDon hd = hoadon.LayHDtheoID(id);// hàm hiển thị thông tin hóa đơn khi người dùng nhập mã của nó
            if (hd != null) // nếu list khác rỗng
            {
                Console.SetCursorPosition(57, 4); Console.Write(hd.TenDT);
                Console.SetCursorPosition(74, 5); Console.Write(hd.Nhacc);
                Console.SetCursorPosition(11, 6); Console.Write(hd.Quantum);
                Console.SetCursorPosition(17, 8); Console.Write(hd.HoTenKH);
                Console.SetCursorPosition(75, 8); Console.Write(hd.Quekh);
                Console.SetCursorPosition(12, 10); Console.Write(hd.Ngaydat);
                Console.SetCursorPosition(75, 11); Console.Write(hd.Tennv);
                Console.SetCursorPosition(10, 12); Console.Write(hd.Price);
                Console.SetCursorPosition(13, 14); Console.Write(hd.Sale);
                Console.SetCursorPosition(16, 7); Console.Write(hd.Makh);
                Console.SetCursorPosition(16, 4); Console.Write(hd.MaDT);
                Console.SetCursorPosition(15, 11); Console.Write(hd.Manv);
                Console.SetCursorPosition(84, 6);
                //Nhập lại thông tin mới


            m: try
                {
                    do
                    {
                        Console.SetCursorPosition(18, 4);
                        Madt = int.Parse(Console.ReadLine());

                        if (mobile.CheckID(Madt))
                        {
                            break;
                        }
                        else if (Madt == 0)
                        {
                            return;
                        }
                        else
                            Console.SetCursorPosition(0, 15);
                            Console.WriteLine("Mã điện thoại không tồn tại vui lòng nhập mã khác");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine(" Mã điện thoại không đúng định dạng vui lòng nhập mã khác \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto m;
                    }
                    else
                        return;
                }
                IMobileBLL mobi = new MobileBLL();
                Mobile mb = mobi.LayMBtheoID(Madt);
                Console.SetCursorPosition(70, 4);
                Console.Write(mb.TenDT);
                TenDT = mb.TenDT;
                Console.SetCursorPosition(21, 12);
                Console.Write(mb.Price);
                Price = mb.Price;
                Console.SetCursorPosition(20, 14);
                Console.Write(mb.Sale);
                Sale = mb.Sale;
                Console.SetCursorPosition(82, 5);
                Console.Write(mb.NhaCC);
                Nhacc = mb.NhaCC;

            q: try
                {
                    do
                    {
                        Console.SetCursorPosition(14, 6);
                        Quantum = int.Parse(Console.ReadLine());

                        if (Quantum > 0)
                        {
                            break;
                        }
                        else if (Quantum == 0)
                        {
                            return;
                        }
                        else
                            Console.SetCursorPosition(0, 15);
                            Console.WriteLine("Số lượng nhỏ hơn 0. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine(" Số lượng nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto q;
                    }
                    else
                        return;
                }

            //////////


            c: try
                {
                    do
                    {
                        Console.SetCursorPosition(18, 7);
                        Makh = int.Parse(Console.ReadLine());

                        if (customer.CheckID(Makh))
                        {
                            break;
                        }
                        else if (Makh == 0)
                        {
                            return;
                        }
                        else
                            Console.SetCursorPosition(0, 15);
                            Console.WriteLine("Mã khách hàng không tồn tại vui lòng nhập mã khác");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine(" Mã khách hàng không đúng định dạng vui lòng nhập mã khác \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto c;
                    }
                    else
                        return ;
                }
                ICustomerBLL cus = new CustomerBLL();
                Customer cm = cus.LayKHtheoID(Makh);
                Console.SetCursorPosition(40, 8);
                Console.Write(cm.Name);
                HoTenKH = cm.Name;
                Console.SetCursorPosition(88, 8);
                Console.Write(cm.Address);
                Address = cm.Address;
                

            h: try
                {
                    do
                    {
                        Console.SetCursorPosition(35, 10);
                        Ngaydat = Console.ReadLine().Trim();

                        if (int.Parse(Ngaydat.Substring(0, 2)) < 32 && int.Parse(Ngaydat.Substring(3, 2)) < 13 && int.Parse(Ngaydat.Substring(6, 4)) <= 2021)
                        {
                            break;
                        }
                        else if (Ngaydat == "0")
                        {
                            return ;
                        }
                        else
                            Console.SetCursorPosition(0, 15);
                            Console.WriteLine("Kiểu dữ liệu ngày tháng năm không hợp lệ. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine(" Kiểu dữ liệu ngày tháng năm không hợp lệ. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto h;
                    }
                    else
                        return ;
                }


            e: try
                {
                    do
                    {
                        Console.SetCursorPosition(17, 11);
                        Manv = int.Parse(Console.ReadLine());

                        if (employee.CheckID(Manv))
                        {
                            break;
                        }
                        else if (Manv == 0)
                        {
                            return;
                        }
                        else
                            Console.SetCursorPosition(0, 15);
                        Console.WriteLine("Mã nhân viên không tồn tại vui lòng nhập mã khác");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine(" Mã nhân viên không đúng định dạng vui lòng nhập mã khác \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto e;
                    }
                    else
                        return;
                }
                IEmployeeBLL Em = new EmployeeBLL();
                Employee em = Em.LayNVtheoID(Manv);
                Console.SetCursorPosition(90, 11);
                Console.Write(em.Name);
                TenNV = em.Name;


            


                Console.SetCursorPosition(0, v);//Đưa con trỏ tới vị trí cuối cùng của danh sách được hiện thị ở trên dựa vào v
                Console.Write("Nhan Esc de thoat, Enter de luu!");
                //Nếu có dữ liệu có thay đổi thị cập nhật lại

                if (hd.Ngaydat != Ngaydat && Ngaydat != null) hd.Ngaydat = Ngaydat;
                if (hd.HoTenKH != HoTenKH && HoTenKH != null) hd.HoTenKH = HoTenKH;
                if (hd.Quekh != Address && Address != null) hd.Quekh = Address;
                if (hd.TenDT != TenDT && TenDT != null) hd.TenDT = TenDT;
                if (hd.Tennv != TenNV && TenNV != null) hd.Tennv = TenNV;
                if (hd.Price != Price && Price != 0) hd.Price = Price;
                if (hd.Quantum != Quantum && Quantum != 0) hd.Quantum = Quantum;
                if (hd.Sale != Sale && Sale != 0) hd.Sale = Sale;
                if (hd.Nhacc != Nhacc && Nhacc != null) hd.Nhacc = Nhacc;
                if (hd.MaDT != Madt && Madt != 0) hd.MaDT = Madt;
                if (hd.Makh != Makh && Makh != 0) hd.Makh = Makh;
                if (hd.Manv != Manv && Manv != 0) hd.Manv = Manv;

                //Đợi xem người dùng lựa chọn chức năng gì(thoát hay nhập)
                Console.SetCursorPosition(33, Console.CursorTop);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape) return;
                else if (kt.Key == ConsoleKey.Enter) { hoadon.Update(hd); return; }
            }
            else Console.Write("KHong co ma hoa don ban vua nhap xin vui long nhap lai!"); Console.ReadKey();

        }

        public void XuatBill()
        {

            

            //Hiên thị mẫu nhập
            Console.Clear();

            // Phần giao diện sửa thông tin
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                BIÊN NHẬN THANH TOÁN                                          ║");
            Console.WriteLine("║══════════════════════════════════════════════════════════════════════════════════════════════║");
            Console.WriteLine("║ Nhập ID:                                                                                     ║");
            Console.WriteLine("║ Tên điện thoại:                                Nhà cung cấp:                                 ║");
            Console.WriteLine("║                                                                                              ║");
            Console.WriteLine("║ Số lượng:                                                                                    ║");
            Console.WriteLine("║                                                                                              ║");
            Console.WriteLine("║ Tên khách hàng:                                Địa chỉ:                                      ║");
            Console.WriteLine("║                                                                                              ║");
            Console.WriteLine("║ Ngày xuất:                                                                                   ║");
            Console.WriteLine("║                                                                                              ║");
            Console.WriteLine("║ Giá gốc:            ₫                                                                        ║");
            Console.WriteLine("║                                                                                              ║");
            Console.WriteLine("║ Khuyến mại:    %                                                                             ║");
            Console.WriteLine("║                                                                                              ║");
            Console.WriteLine("║══════════════════════════════════════════════════════════════════════════════════════════════║");
            Console.WriteLine("║ Tổng tiền sản phẩm:            ₫                                                             ║");
            Console.WriteLine("║                                                                                              ║");
            Console.WriteLine("║                                                  Nhân viên phụ trách hoá đơn                 ║");
            Console.WriteLine("║                                                                                              ║");
            Console.WriteLine("║                                                                                              ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine(" Cảm ơn quý khách đã tin tưởng ủng hộ mua hàng tại shop của chúng tôi.\n Nếu muốn được tư vấn về kỹ thuật vui lòng gọi hotline 1900100 có");
            int v = Console.CursorTop; // biến con trỏ
            Console.WriteLine();
            Console.WriteLine("Nhấn Enter để tiến hành thanh thoán, Nhấn phím Space để chọn phương thức trả góp 10% và mỗi tháng 0% lãi suất");
            IHoaDonBLL hoadon = new HoaDonBLL();//tạo đối tượng hoadon từ HoaDonBLL để dùng các chức năng từ phần đó
            HienHD(hoadon.GetAllData(), 0, 30, "                 DANH SACH HOA DON                  ", "", 20);
            int id;
            HoaDonBLL hdb = new HoaDonBLL();
        s: try
            {
                do
                {
                    Console.SetCursorPosition(12, 3);
                    id = int.Parse(Console.ReadLine()); // Nhập id xóa

                    if (hdb.CheckID(id))
                    {
                        break;
                    }
                    else if (id == 0) return;
                    else if (id < 0)
                    {
                        Console.SetCursorPosition(0, 25);
                        Console.WriteLine("Mã hoá đơn lớn hơn 0. Vui lòng nhập lại");
                    }
                    else
                        Console.SetCursorPosition(0, 25);
                    Console.WriteLine("Mã hoá đơn không tồn tại. Vui lòng nhập lại");

                } while (true);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(0, 25);
                Console.WriteLine(" Mã hoá đơn nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                ConsoleKeyInfo check = Console.ReadKey();
                if (check.Key == ConsoleKey.Enter)
                {
                    goto s;
                }
                else
                    return;
            }
            HoaDon hd = hoadon.LayHDtheoID(id);// hàm hiển thị thông tin hóa đơn khi người dùng nhập mã của nó
            if (hd != null) // nếu list khác rỗng
            {
                // Hiển thị thông tin cuả điện thoại
                Console.SetCursorPosition(18, 4); Console.Write(hd.TenDT);
                Console.SetCursorPosition(64, 4); Console.Write(hd.Nhacc);
                Console.SetCursorPosition(12, 6); Console.Write(hd.Quantum);
                Console.SetCursorPosition(18, 8); Console.Write(hd.HoTenKH);
                Console.SetCursorPosition(58, 8); Console.Write(hd.Quekh);
                Console.SetCursorPosition(13, 10); Console.Write(hd.Ngaydat);
                Console.SetCursorPosition(57, 20); Console.Write(hd.Tennv);
                Console.SetCursorPosition(11, 12); Console.Write(hd.Price);
                Console.SetCursorPosition(14, 14); Console.Write(hd.Sale);
                Console.SetCursorPosition(23, 17); Console.Write(hd.Total);
                Console.SetCursorPosition(84, 6);
                Console.SetCursorPosition(0, v);//Đưa con trỏ tới vị trí cuối cùng của danh sách được hiện thị ở trên dựa vào v
                //Đợi xem người dùng lựa chọn chức năng gì(thoát hay nhập)
                Console.SetCursorPosition(33, Console.CursorTop);
                
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Enter) return;
                else if (kt.Key == ConsoleKey.Spacebar)
                {

                    double i = hd.Total;
                    int count = 0;
                    while (i >= 0)
                    {
                        i *= 0.1;
                        i--;
                        count += 1;

                    }
                    Console.WriteLine("Ban phai tra {0} trong vong {1} tháng !",hd.Total * 0.1,count);
                    Console.ReadLine();
                }
            }
        }
    }
}
