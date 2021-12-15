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
        private MobileBLL mobi = new MobileBLL();

        //hàm hiển thị điện thoại với tham số truyền vào là danh sách điện thoại , vị trí cách lề trái làn x, vị trí cách lề trên là y, chuỗi tiêu đề, chuỗi khi thực hiện xong, n là số phần tử của list được xuất hiện
        int HienMB(List<Mobile> list, int x, int y, string tieudedau, string tieudecuoi, int n)
        { 
            
            
            Console.WriteLine(tieudedau);// hiển thị tiêu đề
            
            
            Console.WriteLine("══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            y = y + 4;// đặt cách là 4
            Console.SetCursorPosition(x + 1, y); Console.Write("║ ID ");// cách lề phải 1, cách trên 4
            Console.SetCursorPosition(x + 7, y); Console.Write("║ Tên Điện Thoại ");// cách lề phải 7, cách trên 4
            Console.SetCursorPosition(x + 30, y); Console.Write("║ Nhà cung cấp ");// cách lề phải 28, cách trên 4
            Console.SetCursorPosition(x + 50, y); Console.Write("║ Loại ");// cách lề phải 37, cách trên 4
            Console.SetCursorPosition(x + 65, y); Console.Write("║ Giá ");// cách lề phải 45, cách trên 4
            Console.SetCursorPosition(x + 80, y); Console.Write("║ Sale ");// cách lề phải 54, cách trên 4
            Console.SetCursorPosition(x + 95, y); Console.Write("║ Số lượng ");// cách lề phải 62, cách trên 4
            int d = 0;
            for (int i = list.Count - 1; i >= 0; --i)// Lặp qua danh sách để hiển thị các thuộc tính
            {
                y = y + 1;
                Console.SetCursorPosition(1, y); Console.Write("║ " + list[i].Id.ToString());
                Console.SetCursorPosition(7, y); Console.Write("║ " + list[i].TenDT);
                Console.SetCursorPosition(30, y); Console.Write("║ " + list[i].NhaCC);
                Console.SetCursorPosition(50, y); Console.Write("║ " + list[i].Type);
                Console.SetCursorPosition(65, y); Console.Write("║ " + list[i].Price.ToString());
                Console.SetCursorPosition(80, y); Console.Write("║ " + list[i].Sale.ToString());
                Console.SetCursorPosition(95, y); Console.Write("║ " + list[i].Quantum.ToString());
                Console.WriteLine();
                if ((++d) == n) break;//Nếu hiển thị bằng số lượng n thì dừng
            }
           
            Console.WriteLine();
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
                HienMB(mobile.GetAllData(), 0, 0, "                                 DANH SÁCH ĐIỆN THOẠI                       ", "Nhan vào Enter de thoat!", 30);
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
                HienMB(mobile.GetAllData(), 0, 0, "                 DANH SÁCH ĐIỆN THOẠI                       ", "", 30);

                HienMB(mobile.GetThongKe(), 0, 12, "                 DANH SÁCH ĐIỆN THOẠI CÒN HÀNG                       ", "Nhan vao Enter de thong ke!", 30);// gọi hàm hiển thị đã có ở bên trên và truyền giá trị list đã thống kê và các giá trị cần khác

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
                HienMB(mobile.GetAllData(), 0, 0, "                 DANH SÁCH ĐIỆN THOẠI                       ", "", 30);
                // gọi hàm hiển thị đã có ở bên trên và truyền giá trị danh sách lấy tất cả dữ liệu và các giá trị khác

                HienMB(mobile.GetSort(), 0, 12, "                 DANH SÁCH ĐIỆN THOẠI ĐÃ SẮP XẾP                      ", " Nhấn ESC để thoát \n Nhấn vào Enter để sắp xếp giá giảm dần \n Nhấn phím Cách để sắp xếp tăng dần! \n", 30);
                ConsoleKeyInfo kt = Console.ReadKey(); // Nhập ký tự

                if (kt.Key == ConsoleKey.Escape) return; // Nếu là phím Esc thì thoát
                else if (kt.Key == ConsoleKey.Enter) //ngược lại nếu nhận là phím Enter
                    mobile.Sort();  // Gọi hàm Sắp xếp từ MobileBLL
                else if (kt.Key == ConsoleKey.Spacebar) //ngược lại nếu nhận là phím Enter
                    mobile.SortPriceUp();
               
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
                Console.WriteLine("╔════════════════════════════════════════════════════════════════╗ ");
                Console.WriteLine("║                NHẬP THÔNG TIN ĐIỆN THOẠI                       ║");
                Console.WriteLine("║════════════════════════════════════════════════════════════════║");
                Console.WriteLine("║                                                                ║");
                Console.WriteLine("║ Tên điện thoại:                                                ║");
                Console.WriteLine("║                                                                ║");
                Console.WriteLine("║ Mã nhà cung cấp:                    Nhà cung cấp:              ║");
                Console.WriteLine("║                                                                ║");
                Console.WriteLine("║ Loại:                               Giá:                       ║");
                Console.WriteLine("║                                                                ║");
                Console.WriteLine("║ Sale:                               Số lượng:                  ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════╝  ");
                int x = 0, y = 10;
                // Hiển thị thông tin danh sách đã nhập
                int v = HienMB(mobile.GetAllData(),x, y, "                            DANH SÁCH ĐIỆN THOẠI                      ", "Nhan Backspace de thoat, Enter de luu! \n Nhập 123456789 nếu bạn muốn thoát chương trình khi đang nhập!", 6);

                Mobile mb = new Mobile();//tạo đối tượng mới
                                         // Nhập thông tin các thuộc tính và điều kiện
                BrandBLL brand = new BrandBLL();

            a: try
                {
                    do
                    {
                        Console.SetCursorPosition(18, 4);
                        mb.TenDT = Console.ReadLine();

                        if (mb.TenDT == "12345")
                        {
                            return exit;
                        }

                        if (mb.TenDT != null)
                        {
                            break;
                        }
                        else
                            Console.SetCursorPosition(0, 18);
                            Console.WriteLine(" Mã điện thoại không được để trống. Vui lòng nhập lại!");
                    } while (true);
                }
                catch (Exception )
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine(" Mã điện thoại nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto a;
                    }
                    else
                        return exit;
                }

            x: try
                {
                    do
                    {
                        Console.SetCursorPosition(19, 6);
                        mb.Mancc = int.Parse(Console.ReadLine());

                        if (mb.Mancc == 12345)
                        {
                            return exit;
                        }

                        if (brand.CheckID(mb.Mancc))
                        {
                            break;
                        }
                        else
                            Console.SetCursorPosition(0, 18);
                        Console.WriteLine(" Mã nhà cung cấp không được để trống. Vui lòng nhập lại!");
                    } while (true);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine(" Mã nhà cung cấp nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto x;
                    }
                    else
                        return exit;
                }
                IBrandBLL bra = new BrandBLL();
                Brand br = bra.LayNCCtheoID(mb.Mancc);
                Console.SetCursorPosition(53, 6);
                Console.Write(br.Name);
                mb.NhaCC = br.Name;

            

            c: try
                {
                    do
                    {
                        Console.SetCursorPosition(8, 8);
                        mb.Type = Console.ReadLine();

                        if (mb.Type == "12345")
                        {
                            return exit;
                        }

                        if (mb.Type != null)
                        {
                            break;
                        }
                        else if(mobi.CheckType(mb.TenDT, mb.Type))
                        {
                            Console.SetCursorPosition(0, 18);
                            Console.WriteLine(" Đã có điện thoại tồn tại loại này. Vui lòng nhập lại loại khác!");
                        }
                        else
                            Console.SetCursorPosition(0, 18);
                            Console.WriteLine(" Loại điện thoại không được để trống. Vui lòng nhập lại!");
                    } while (true);
                }
                catch (Exception )
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine(" Loại điện thoại nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto c;
                    }
                    else
                        return exit;
                }

            d: try
                {
                    do
                    {
                        Console.SetCursorPosition(44, 8);
                        mb.Price = double.Parse(Console.ReadLine());

                        if (mb.Price > 0)
                        {
                            break;
                        }
                        else if(mb.Price == 12345)
                        {
                            return exit;
                        }
                        else
                            Console.SetCursorPosition(0, 18);
                            Console.WriteLine("Giá tiền mặt hàng phải lớn hơn 0. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine(" Giá tiền mặt hàng nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto d;
                    }
                    else
                        return exit;
                }


            e: try
                {
                    do
                    {
                        Console.SetCursorPosition(7, 10);
                        mb.Sale = int.Parse(Console.ReadLine());

                        if (mb.Sale >= 0 )
                        {
                            break;
                        }
                        else if( mb.Sale == 12345)
                        {
                            return exit;
                        }
                        else
                            Console.SetCursorPosition(0, 18);
                            Console.WriteLine("Khuyến mại không được âm. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine(" Khuyến mại nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto e;
                    }
                    else
                        return exit;
                }


            f: try
                {
                    do
                    {
                        Console.SetCursorPosition(48, 10);
                        mb.Quantum = int.Parse(Console.ReadLine());

                        if (mb.Quantum > -1)
                        {
                            break;
                        }
                        else if (mb.Quantum == 1)
                        {
                            return exit;
                        }
                        else
                            Console.SetCursorPosition(0, 18);
                        Console.WriteLine("Số lượng không được âm. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine(" Số lượng nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto f;
                    }
                    else
                        return exit;
                }

                Console.SetCursorPosition(32, v);

                ConsoleKeyInfo kt = Console.ReadKey(); // Nhập Ký tự
                if (kt.Key == ConsoleKey.Backspace) return exit; // Nếu ấn Backspace là thoát
                else if (kt.Key == ConsoleKey.Enter) // Nhấn Enter
                    mobile.Add(mb); // Gọi hàm thêm MobileBLL
            } while (true); // Vòng lặp nhập
        }
        
        public void XoaMB()
        {
            int id;
            do
            {
                Console.Clear(); // Xóa tất cả bắt đầu để hiển thị
                IMobileBLL mobile = new MobileBLL(); //tạo đối tượng mobile từ MobileBLL để dùng các chức năng từ phần đó

                // gọi hàm hiển thị đã có ở bên trên và truyền giá trị danh sách lấy tất cả dữ liệu và các giá trị khác
                HienMB(mobile.GetAllData(),0, 0, "                 DANH SACH DIEN THOAI TRONG KHO                  ", "", 20);
                Console.SetCursorPosition(0, 12);
                Console.Write("Nhập mã sản phẩm muốn xóa: ");
                MobileBLL hd = new MobileBLL();
            s: try
                {
                    do
                    {
                        Console.SetCursorPosition(32, 12);
                        id = int.Parse("0" + Console.ReadLine()); // Nhập id xóa

                        if (hd.CheckID(id))
                        {
                            break;
                        }
                        else if (id == 0) return;
                        else if (id < 0)
                        {
                            Console.SetCursorPosition(0, 15);
                            Console.WriteLine("Mã điện thoại phải lớn hơn 0. Vui lòng nhập lại");
                        }
                        else
                            Console.SetCursorPosition(0, 15);
                        Console.WriteLine("Mã điện thoại không tồn tại. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine(" Mã điện thoại nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto s;
                    }
                    else
                        return;
                }
                mobile.Delete(id);
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
                List<Mobile> list = mobile.Timdt(new Mobile(0, tenDT,0, null, null, 0, 0,0));

                // gọi hàm hiển thị đã có ở bên trên và truyền giá trị danh sách lấy tất cả dữ liệu và các giá trị khác
                HienMB(list,0, 0, "                 DANH SACH DIEN THOAI                      ", "Nhan phím 0 de thoat!\n", 30);
            n: try
                {
                    do
                    {
                        Console.SetCursorPosition(0, 12);
                        Console.Write("Nhập tên điện thoại :");
                        Console.SetCursorPosition(25, 12);
                        tenDT = Console.ReadLine();

                        if (tenDT != null)
                        {
                            break;
                        }
                        else if (tenDT == "0")
                        {
                            return;
                        }
                        else
                            Console.SetCursorPosition(0, 18);
                        Console.WriteLine(" Tên điện thoại không được để trống. Vui lòng nhập lại!");

                    } while (true);
                }
                catch (Exception ex)
                {
                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine(" Tên điện thoại nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto n;
                    }
                    else
                        return;
                }
                if (tenDT == "") return; // nếu điện thoại bằng sâu rỗng thì thoát
            } while (true);
        }

        public void TimGia()
        {
            double price = 0;
            do
            {
                Console.Clear(); // Xóa tất cả bắt đầu để hiển thị

                IMobileBLL mobile = new MobileBLL();//tạo đối tượng mobile từ MobileBLL để dùng các chức năng từ phần đó

                // khởi tạo đối tượng list được lấy dữ liệu từ hàm tìm có các tham số truyền vào
                

                // gọi hàm hiển thị đã có ở bên trên và truyền giá trị danh sách lấy tất cả dữ liệu và các giá trị khác
                HienMB(mobile.GetAllData(), 0, 0, "                 DANH SACH DIEN THOAI                      ", "Nhập giá bằng 0 để thoát chương trình !\n", 30);
                Console.SetCursorPosition(0, 12);
                Console.Write("Nhập giá sản phẩm muốn tìm");
            d: try
                {
                    do
                    {
                        Console.SetCursorPosition(30, 12);
                        price = double.Parse(Console.ReadLine());

                        if (price > 0)
                        {
                            break;
                        }
                        else if (price == 0)
                        {
                            return ;
                        }
                        else
                            Console.SetCursorPosition(0, 18);
                        Console.WriteLine("Giá tiền mặt hàng phải lớn hơn 0. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine(" Giá tiền mặt hàng nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto d;
                    }
                    else
                        return ;
                }
                if (price == 0) return; // 
                else
                    Console.WriteLine("                   DANH SÁCH ĐIỆN THOẠI ĐÃ TÌM THẤY       ");
                    mobile.TimGia(price);
                Console.ReadLine();
            } while (true);
        }

        public void TimID()
        {
            int id = 0;
            do
            {
                Console.Clear(); // Xóa tất cả bắt đầu để hiển thị

                IMobileBLL mobile = new MobileBLL();//tạo đối tượng mobile từ MobileBLL để dùng các chức năng từ phần đó

                // khởi tạo đối tượng list được lấy dữ liệu từ hàm tìm có các tham số truyền vào


                // gọi hàm hiển thị đã có ở bên trên và truyền giá trị danh sách lấy tất cả dữ liệu và các giá trị khác
                HienMB(mobile.GetAllData(), 0, 0, "                 DANH SACH DIEN THOAI                      ", "Nhập mã bằng 0 để thoát chương trình!\n", 30);
                Console.SetCursorPosition(0, 12);
                Console.Write("Nhập mã sản phẩm muốn tìm kiếm: ");
                MobileBLL hd = new MobileBLL();
            s: try
                {
                    do
                    {
                        Console.SetCursorPosition(30, 12);
                        id = int.Parse(Console.ReadLine()); // Nhập id xóa

                        if (hd.CheckID(id))
                        {
                            break;
                        }
                        else if (id == 0) return;
                        else if (id < 0)
                        {
                            Console.SetCursorPosition(0, 15);
                            Console.WriteLine("Mã điện thoại phải lớn hơn 0. Vui lòng nhập lại");
                        }
                        else
                            Console.SetCursorPosition(0, 15);
                        Console.WriteLine("Mã điện thoại không tồn tại. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception)
                {
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine(" Mã điện thoại nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto s;
                    }
                    else
                        return;
                }

                if (id == 0) return; // 
                else
                    Console.WriteLine("                      DANH SÁCH ĐIỆN THOẠI ĐÃ TÌM THẤY       ");
                    mobile.TimID(id);
                Console.ReadLine();
            } while (true);
        }

        public void TimType()
        {
            string type = "";
            do
            {
                Console.Clear(); // Xóa tất cả bắt đầu để hiển thị

                IMobileBLL mobile = new MobileBLL();//tạo đối tượng mobile từ MobileBLL để dùng các chức năng từ phần đó

                // khởi tạo đối tượng list được lấy dữ liệu từ hàm tìm có các tham số truyền vào


                // gọi hàm hiển thị đã có ở bên trên và truyền giá trị danh sách lấy tất cả dữ liệu và các giá trị khác
                HienMB(mobile.GetAllData(), 0, 0, "                 DANH SACH DIEN THOAI                      ", "Nhập mã bằng 0 để thoát chương trình!\n", 30);
                Console.SetCursorPosition(0, 12);
                Console.Write("Nhập loại sản phẩm muốn tìm");
            d: try
                {
                    do
                    {
                        Console.SetCursorPosition(30, 12);
                        type = Console.ReadLine();

                        if (type != null )
                        {
                            break;
                        }
                        else if (type == "0")
                        {
                            return;
                        }
                        else
                            Console.SetCursorPosition(0, 18);
                        Console.WriteLine("Loại mặt hàng tìm không được để trống. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine(" Giá tiền mặt hàng nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto d;
                    }
                    else
                        return;
                }
                if (type == "") return; // 
                else
                    Console.WriteLine("                      DANH SÁCH ĐIỆN THOẠI ĐÃ TÌM THẤY       ");
                    mobile.TimType(type);
                Console.ReadLine();
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
            int Mancc = 0;
            
            Console.Clear();
            // Phần giao diện sửa thông tin
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                            CẬP NHẬT THÔNG TIN ĐIỆN THOẠI                                   ║");
            Console.WriteLine("║════════════════════════════════════════════════════════════════════════════════════════════║");
            Console.WriteLine("║ Nhập ID:                                              Mã nhà cung cấp:                     ║");
            Console.WriteLine("║ Tên điện thoại:                                       Nhà cung cấp:                        ║");
            Console.WriteLine("║                                                                                            ║");
            Console.WriteLine("║ Loại:                                             Giá:                                     ║");
            Console.WriteLine("║                                                                                            ║");
            Console.WriteLine("║ Sale:                                             Số lượng:                                ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════╝");
            int v = Console.CursorTop;// biến con trỏ
            
            IMobileBLL mobile = new MobileBLL(); //tạo đối tượng mobile từ MobileBLL để dùng các chức năng từ phần đó
            HienMB(mobile.GetAllData(), 0, 8, "                         DANH SÁCH ĐIỆN THOẠI                       ", "Nhập 12345 để thoát vòng lặp", 30);
            // Nhập ID cần sửa thông tin 
            int id;
            MobileBLL mobi = new MobileBLL();
        s: try
            {
                do
                {
                    Console.SetCursorPosition(12, 3);
                    id = int.Parse(Console.ReadLine()); // Nhập id xóa

                    if (mobi.CheckID(id))
                    {
                        break;
                    }
                    else if (id == 0) return;
                    else if (id < 0)
                    {
                        Console.SetCursorPosition(0, 25);
                        Console.WriteLine("Mã điện thoại phải lớn hơn 0. Vui lòng nhập lại");
                    }
                    else
                        Console.SetCursorPosition(0, 25);
                    Console.WriteLine("Mã điện thoại không tồn tại. Vui lòng nhập lại");

                } while (true);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(0, 25);
                Console.WriteLine(" Mã điện thoại không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                ConsoleKeyInfo check = Console.ReadKey();
                if (check.Key == ConsoleKey.Enter)
                {
                    goto s;
                }
                else
                    return;
            }

            Mobile mb = mobile.LayMBtheoID(id);// hàm hiển thị thông tin điện thoại khi người dùng nhập mã của nó

            if (mb != null) // nếu list khác rỗng
            {
                // Hiển thị thông tin cuả điện thoại
                Console.SetCursorPosition(74, 3); Console.Write(mb.Mancc);
                Console.SetCursorPosition(18, 4); Console.Write(mb.TenDT);
                Console.SetCursorPosition(71, 4); Console.Write(mb.NhaCC);
                Console.SetCursorPosition(8, 6); Console.Write(mb.Type);
                Console.SetCursorPosition(58, 6); Console.Write(mb.Price);
                Console.SetCursorPosition(8, 8); Console.Write(mb.Sale);
                Console.SetCursorPosition(63, 8); Console.Write(mb.Quantum);
            //Nhập lại thông tin mới

            a: try
                {
                    do
                    {
                        Console.SetCursorPosition(35, 4);
                        mb.TenDT = Console.ReadLine();

                        if (mb.TenDT == "12345")
                        {
                            return ;
                        }

                        if (mb.TenDT != null)
                        {
                            break;
                        }
                        else
                            Console.SetCursorPosition(0, 18);
                            Console.WriteLine(" Mã điện thoại không được để trống. Vui lòng nhập lại!");
                    } while (true);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine(" Mã điện thoại nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto a;
                    }
                    else
                        return ;
                }
                BrandBLL brand = new BrandBLL();
            b:  Console.SetCursorPosition(76, 3); try
                {
                    do
                    {
                        mb.Mancc = int.Parse(Console.ReadLine());
                        if (brand.CheckID(mb.Mancc))
                        {
                            break;
                        }
                        else if (mb.Mancc == 0)
                        {
                            return;
                        }
                        else
                            Console.SetCursorPosition(0, 15);
                            Console.WriteLine("Mã nhà cung cấp không tồn tại vui lòng nhập mã khác");

                    } while (true);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine(" Mã nhà cung cấp không đúng định dạng vui lòng nhập mã khác \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto b;
                    }
                    else
                        return;
                }
                IBrandBLL bra = new BrandBLL();
                Brand br = bra.LayNCCtheoID(mb.Mancc);
                Console.SetCursorPosition(79,4);
                Console.WriteLine(br.Name);
                mb.NhaCC = br.Name;
             c: try
                {
                    do
                    {
                        Console.SetCursorPosition(15, 6);
                        mb.Type = Console.ReadLine();

                        if (mb.Type == "12345")
                        {
                            return;
                        }

                        if (mb.Type != null)
                        {
                            break;
                        }
                        else
                            Console.SetCursorPosition(0, 18);
                            Console.WriteLine(" Loại điện thoại không được để trống. Vui lòng nhập lại!");


                    } while (true);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine(" Loại điện thoại không đúng định dạng vui lòng nhập mã khác \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto c;
                    }
                    else
                        return;
                }
                
             d: try
                {
                    do
                    {
                        Console.SetCursorPosition(72, 6);
                        mb.Price = double.Parse(Console.ReadLine());

                        if (mb.Price > 0)
                        {
                            break;
                        }
                        else if (mb.Price == 12345)
                        {
                            return;
                        }
                        else
                            Console.SetCursorPosition(0, 15);
                            Console.WriteLine("Giá phải hơn 0. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine(" Giá cả nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto d;
                    }
                    else
                        return;
                }
            e:   try
                {
                    do
                    {
                        Console.SetCursorPosition(11, 8);
                        mb.Sale = int.Parse(Console.ReadLine());

                        if (mb.Sale >= 0)
                        {
                            break;
                        }
                        else if (mb.Price == 12345)
                        {
                            return;
                        }
                        else
                            Console.SetCursorPosition(0, 15);
                            Console.WriteLine("Khuyến mãi không âm. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine(" Khuyến mãi nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto e;
                    }
                    else
                        return;
                }
             f: try
                {
                    do
                    {
                        Console.SetCursorPosition(66, 8);
                        mb.Quantum = int.Parse(Console.ReadLine());

                        if (mb.Quantum >= 0)
                        {
                            break;
                        }
                        else if (mb.Quantum == 12345)
                        {
                            return;
                        }
                        else
                            Console.SetCursorPosition(0, 15);
                            Console.WriteLine("Số lượng không âm. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine(" số lượng nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto f;
                    }
                    else
                        return;
                }
                Console.SetCursorPosition(0, v);//Đưa con trỏ tới vị trí cuối cùng của danh sách được hiện thị ở trên dựa vào v
                Console.Write("Nhan Esc de thoat, Enter de luu!");
                //Nếu có dữ liệu có thay đổi thị cập nhật lại
                if (mb.TenDT != TenDT && TenDT != null) mb.TenDT = TenDT;
                if (mb.NhaCC != NhaCC && NhaCC != null) mb.NhaCC = NhaCC;
                if (mb.Type != Type && Type != null) mb.Type = Type;
                if (mb.Price != Price && Price != 0) mb.Price = Price;
                if (mb.Sale != Sale && Sale != 0) mb.Sale = Sale;
                if (mb.Mancc != Mancc && Mancc != 0) mb.Mancc = Mancc;
                if (mb.Quantum != Quantum && Quantum != 0) mb.Quantum = Quantum;

                //Đợi xem người dùng lựa chọn chức năng gì(thoát hay nhập)
                Console.SetCursorPosition(33, Console.CursorTop);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape) return;
                else if (kt.Key == ConsoleKey.Enter) { mobile.Update(mb); return; }
            }
            else
                Console.SetCursorPosition(0, 20);
                Console.Write("KHong co ma dien thoai ban vua nhap xin vui long nhap lai!");
        }

    }
}

