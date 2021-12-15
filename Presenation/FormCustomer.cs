using System;
using System.Collections.Generic;
using System.Text;
using Demo.Entities;
using Demo.Business.Components;
using Demo.Business.Services;

namespace Demo.Presenation
{
    class FormCustomer
    {
        private ICustomerBLL customer = new CustomerBLL();

        int HienKH(List<Customer> list, int x, int y, string tieudedau, string tieudecuoi, int n)
        {


            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine(tieudedau);
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════");
            y = y + 4;
            Console.SetCursorPosition(x + 1, y); Console.Write("║ MaKH");
            Console.SetCursorPosition(x + 8, y); Console.Write("║ TenKH");
            Console.SetCursorPosition(x + 25, y); Console.Write("║ Dia Chi");
            Console.SetCursorPosition(x + 40, y); Console.Write("║ Tuoi");
            Console.SetCursorPosition(x + 50, y); Console.Write("║ So DT");
            int d = 0;
            for (int i = list.Count - 1; i >= 0; --i)
            {
                y = y + 1;
                Console.SetCursorPosition(1, y); Console.Write("║ " + list[i].Id.ToString());
                Console.SetCursorPosition(8, y); Console.Write("║ " + list[i].Name);
                Console.SetCursorPosition(25, y); Console.Write("║ " + list[i].Address);
                Console.SetCursorPosition(40, y); Console.Write("║ " + list[i].Age.ToString());
                Console.SetCursorPosition(50, y); Console.Write("║ " + list[i].Numberphone);
                Console.WriteLine();
                if ((++d) == n) break;
            }
            Console.WriteLine();
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════");
            Console.Write(tieudecuoi);
            return Console.CursorTop;
        }
        public void Hien()
        {

            string exit = "";
            do
            {
                Console.Clear();
                ICustomerBLL customer = new CustomerBLL();

                HienKH(customer.GetAllData(), 0, 0, "                 DANH SACH KAHCH HANG                      ", "Nhan vay Enter de thoat!", 30);
                exit = Console.ReadLine();
                if (exit == "") return;
            } while (true);
        }


        public bool NhapHK()
        {
            bool exit = false;
            do
            {
                ICustomerBLL customer = new CustomerBLL();
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                NHẬP THÔNG TIN KHÁCH HÀNG                   ║");
                Console.WriteLine("║════════════════════════════════════════════════════════════║");
                Console.WriteLine("║                                                            ║");
                Console.WriteLine("║ Tên khách hàng:                        Tuổi:               ║");
                Console.WriteLine("║                                                            ║");
                Console.WriteLine("║ Địa chỉ:                                                   ║");
                Console.WriteLine("║                                                            ║");
                Console.WriteLine("║ Số điện thoại:                                             ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
                int x = 0, y = 10;
                int v = HienKH(customer.GetAllData(), x, y, "                 DANH SACH DA NHAP                      ", "Nhan Backspace de thoat, Enter de luu!", 4);
                Customer cm = new Customer();


            n: try
                {
                    do
                    {
                        Console.SetCursorPosition(18, 4);
                        cm.Name = Console.ReadLine();

                        if (cm.Name == "0")
                        {
                            return exit;
                        }

                        if (cm.Name != null)
                        {
                            break;
                        }

                        else
                            Console.SetCursorPosition(0, 20);
                            Console.WriteLine(" Tên khách hàng không được để trống. Vui lòng nhập lại!");
                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine(" Tên khách hàng nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto n;
                    }
                    else
                        return exit;
                }
            a: try
                {
                    do
                    {
                        Console.SetCursorPosition(11, 6);
                        cm.Address = Console.ReadLine();

                        if (cm.Address == "0")
                        {
                            return exit;
                        }

                        if (cm.Address != null)
                        { break; }
                        else Console.SetCursorPosition(0, 20); Console.WriteLine("Địa chỉ khách hàng không được trống");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 20);
                    Console.WriteLine(" Địa chỉ khách hàng nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto a;
                    }
                    else
                        return exit;
                }

            o: try
                {
                    do
                    {
                        Console.SetCursorPosition(48, 4);
                        cm.Age = int.Parse(Console.ReadLine());

                        if (cm.Age >= 16)
                        {
                            break;
                        }
                        else if (cm.Age == 0) return exit;
                        else
                            Console.SetCursorPosition(0, 20);
                        Console.WriteLine("Tuổi khách hàng phải lớn hơn 15. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 20);
                    Console.WriteLine(" Tuổi khách hàng nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto o;
                    }
                    else
                        return exit;
                }

            x: try
                {
                    do
                    {
                        Console.SetCursorPosition(18, 8);
                        cm.Numberphone = Console.ReadLine().Trim();

                        if (cm.Numberphone.Length <=10)
                        {
                            break;
                        }
                        else if (cm.Numberphone == "0")
                        {
                            return exit;
                        }
                        else
                            Console.SetCursorPosition(0, 20);
                        Console.WriteLine("Số điện thoại có độ dài nhỏ hơn 11 số. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 20);
                    Console.WriteLine(" Kiểu số điện thoại không hợp lệ. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto x;
                    }
                    else
                        return exit;
                }
                Console.SetCursorPosition(32, v);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Backspace) return exit;
                else if (kt.Key == ConsoleKey.Enter)
                    customer.Add(cm);
            } while (true);
        }

        public void XoaKH()
        {
            do
            {
                Console.Clear();
                ICustomerBLL customer = new CustomerBLL();
                HienKH(customer.GetAllData(), 0, 0, "                 DANH SACH HOA DON                  ", "Thoat nhap 69! \n", 20);
                Console.SetCursorPosition(0, 12);
                Console.Write("Nhập mã khách hàng muốn xóa: ");
                int id;
                CustomerBLL hd = new CustomerBLL();
            s: try
                {
                    do
                    {
                        Console.SetCursorPosition(30, 12);
                        id = int.Parse("0" + Console.ReadLine()); // Nhập id xóa

                        if (hd.CheckID(id))
                        {
                            break;
                        }
                        else if (id == 0) return;
                        else if (id < 0)
                        {
                            Console.SetCursorPosition(0, 15);
                            Console.WriteLine("Mã khách hàng lớn hơn 0. Vui lòng nhập lại");
                        }
                        else
                            Console.SetCursorPosition(0, 15);
                        Console.WriteLine("Mã khách hàng không tồn tại. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine(" Mã khách hàng nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto s;
                    }
                    else
                        return;
                }
                customer.Delete(id); // ngược lại gọi hàm xóa 
            } while (true);
        }

        public void TimKH()
        {
            string tenKH = "";
            do
            {
                Console.Clear();
                ICustomerBLL customer = new CustomerBLL();
                List<Customer> list = customer.TimKH(new Customer(0, tenKH, null, 0, null));
                HienKH(list, 0, 0, "                 DANH SACH KHACH HANG                     ", "Nhấn 0 de thoat!\n", 30);
            n: try
                {
                    do
                    {
                        Console.SetCursorPosition(0, 12);
                        Console.Write("Nhập tên khách hàng :");
                        Console.SetCursorPosition(22, 12);
                        tenKH = Console.ReadLine();

                        if (tenKH != null)
                        {
                            break;
                        }
                        else if (tenKH == "0")
                        {
                            return ;
                        }
                        else
                            Console.SetCursorPosition(0, 18);
                        Console.WriteLine(" Tên khách hàng không được để trống. Vui lòng nhập lại!");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine(" Tên khách hàng nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto n;
                    }
                    else
                        return ;
                }
                if (tenKH == "0") return;
            } while (true);
        }
        public void Sort()
        {

            do
            {
                Console.Clear(); // Xóa tất cả bắt đầu để hiển thị

                IEmployeeBLL employee = new EmployeeBLL();
                HienKH(customer.GetAllData(), 0, 0, "                 DANH SACH KHACH HANG                       ", "", 30);
                // gọi hàm hiển thị đã có ở bên trên và truyền giá trị danh sách lấy tất cả dữ liệu và các giá trị khác

                HienKH(customer.GetSort(), 0, 12, "                 DANH SÁCH KHÁCH HÀNG ĐÃ SẮP XẾP                      ", " Nhấn ESC để thoát \n Nhấn phím Enter để sắp xếp danh sách khách hàng theo bảng chữ cái! \n", 30);
                ConsoleKeyInfo kt = Console.ReadKey(); // Nhập ký tự

                if (kt.Key == ConsoleKey.Escape) return; // Nếu là phím Esc thì thoát
                else if (kt.Key == ConsoleKey.Enter) //ngược lại nếu nhận là phím Enter
                    customer.Sort();  // Gọi hàm Sắp xếp 
            } while (true);
        }

        public void SuaCS()
        {
            string Name = null;
            string Address = null;
            int Age = 0;
            string Numberphone = null;
            
           
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                            CẬP NHẬT THÔNG TIN KHÁCH HÀNG                           ║");
            Console.WriteLine("║------------------------------------------------------------------------------------║");
            Console.WriteLine("║Nhập ID:                                                                            ║");
            Console.WriteLine("║Tên KH:                                             Địa chỉ:                        ║");
            Console.WriteLine("║                                                                                    ║");
            Console.WriteLine("║Tuổi:                               Số điện thoại:                                  ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════╝");
            int v = Console.CursorTop;
            
            ICustomerBLL customer = new CustomerBLL();
            HienKH(customer.GetAllData(), 0, 10, "                 DANH SACH HOA DON                  ", "Thoat nhap 69! \n", 20);
            int id;
            CustomerBLL hdb = new CustomerBLL();
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
                        Console.SetCursorPosition(0, 20);
                        Console.WriteLine("Mã khách hàng phải lớn hơn 0. Vui lòng nhập lại");
                    }
                    else
                        Console.SetCursorPosition(0, 20);
                        Console.WriteLine("Mã khách hàng không tồn tại. Vui lòng nhập lại");

                } while (true);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(0, 20);
                Console.WriteLine(" Mã khách hàng nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                ConsoleKeyInfo check = Console.ReadKey();
                if (check.Key == ConsoleKey.Enter)
                {
                    goto s;
                }
                else
                    return;
            }
            Customer cm = customer.LayKHtheoID(id);
            if (cm != null)
            {
                
                Console.SetCursorPosition(9, 4); Console.Write(cm.Name);
                Console.SetCursorPosition(62, 4); Console.Write(cm.Address);
                Console.SetCursorPosition(7, 6); Console.Write(cm.Age);
                Console.SetCursorPosition(52, 6); Console.Write(cm.Numberphone);

            //Nhập lại thông tin mới

            n: try
                {
                    do
                    {
                        Console.SetCursorPosition(25, 4);
                        Name = Console.ReadLine();

                        if (Name != null)
                        {
                            break;
                        }
                        else if (Name == "0")
                        {
                            return;
                        }
                        else
                            Console.SetCursorPosition(0, 20);
                            Console.WriteLine(" Tên khách hàng không được để trống. Vui lòng nhập lại!");
                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 20);
                    Console.WriteLine(" Tên khách hàng nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto n;
                    }
                    else
                        return ;
                }

            a: try
                {
                    do
                    {
                        Console.SetCursorPosition(74, 4);
                        Address = Console.ReadLine();

                        if (Address != null)
                        { break; }
                        else if (Address == "0")
                        {
                            return ;
                        }
                        else Console.SetCursorPosition(0, 20); Console.WriteLine("Địa chỉ khách hàng không được trống. Vui lòng nhập lại!");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 20);
                    Console.WriteLine(" Địa chỉ khách hàng nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto a;
                    }
                    else
                        return ;
                }


            o: try
                {
                    do
                    {
                        Console.SetCursorPosition(10, 6); 
                        Age = int.Parse(Console.ReadLine());

                        if (Age >= 16)
                        {
                            break;
                        }
                        else
                            Console.SetCursorPosition(0, 20);
                            Console.WriteLine("Tuổi khách hàng phải lớn hơn 15. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 20);
                    Console.WriteLine(" Tuổi khách hàng nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto o;
                    }
                    else
                        return;
                }

            x: try
                {
                    do
                    {
                        Console.SetCursorPosition(66, 6);
                        Numberphone = Console.ReadLine().Trim();

                        if (Numberphone.Length <= 10)
                        {
                            break;
                        }
                        else if (cm.Numberphone == "0")
                        {
                            return ;
                        }
                        else
                            Console.SetCursorPosition(0, 20);
                            Console.WriteLine("Số điện thoại có độ dài nhỏ hơn 11 số. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 20);
                    Console.WriteLine(" Kiểu số điện thoại không hợp lệ. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto x;
                    }
                    else
                        return ;
                }

                Console.SetCursorPosition(0, v);//Đưa con trỏ tới vị trí cuối cùng của danh sách được hiện thị ở trên dựa vào v
                Console.Write("Nhan Esc de thoat, Enter de luu!");
                //Nếu có dữ liệu có thay đổi thị cập nhật lại
                if (cm.Name != Name && Name != null) cm.Name = Name;
                if (cm.Address != Address && Address != null) cm.Address = Address;
                if (cm.Numberphone != Numberphone && Numberphone != null) cm.Numberphone = Numberphone;
                if (cm.Age != Age && Age != 0) cm.Age = Age;

                Console.SetCursorPosition(33, Console.CursorTop);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape) return;
                else if (kt.Key == ConsoleKey.Enter) { customer.Update(cm); return; }
            }
            else Console.Write("KHong co ma khach hang ban vua nhap xin vui long nhap lai!"); Console.ReadKey();

        }
    }
}

