
using System;
using System.Collections.Generic;
using System.Text;
using Demo.Entities;
using Demo.Business.Components;
using Demo.Business.Services;

namespace Demo.Presenation
{
    class FormEmployee
    {
        private ICustomerBLL mobile = new CustomerBLL();

        int HienNV(List<Employee> list, int x, int y, string tieudedau, string tieudecuoi, int n)
        {

            Console.WriteLine(tieudedau);
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            y = y + 4;
            Console.SetCursorPosition(x + 1, y); Console.Write("║ MaNV");
            Console.SetCursorPosition(x + 8, y); Console.Write("║ TênNV");
            Console.SetCursorPosition(x + 25, y); Console.Write("║ Địa chỉ");
            Console.SetCursorPosition(x + 40, y); Console.Write("║ Tuổi");
            Console.SetCursorPosition(x + 50, y); Console.Write("║ Số ĐT");
            Console.SetCursorPosition(x + 70, y); Console.Write("║ Lương cơ bản");
            Console.SetCursorPosition(x + 85, y); Console.Write("║ Hệ số lương");
            Console.SetCursorPosition(x + 98, y); Console.Write("║ Phụ cấp");
            Console.SetCursorPosition(x + 108, y); Console.Write("║Tổng lương");
            int d = 0;
            for (int i = list.Count - 1; i >= 0; --i)
            {
                y = y + 1;
                Console.SetCursorPosition(1, y); Console.Write("║ " + list[i].Id.ToString());
                Console.SetCursorPosition(8, y); Console.Write("║ " + list[i].Name);
                Console.SetCursorPosition(25, y); Console.Write("║ " + list[i].Address);
                Console.SetCursorPosition(40, y); Console.Write("║ " + list[i].Age.ToString());
                Console.SetCursorPosition(50, y); Console.Write("║ " + list[i].Numberphone);
                Console.SetCursorPosition(70, y); Console.Write("║ " + list[i].Luongcoban.ToString());
                Console.SetCursorPosition(85, y); Console.Write("║ " + list[i].Hesoluong.ToString());
                Console.SetCursorPosition(98, y); Console.Write("║ " + list[i].Phucap.ToString());
                Console.SetCursorPosition(108, y); Console.Write("║ " + list[i].Tinhluong.ToString());
                Console.WriteLine();
                if ((++d) == n) break;
            }
            Console.WriteLine();
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.Write(tieudecuoi);
            return Console.CursorTop;
        }
        public void Hien()
        {

            string exit = "";
            do
            {
                Console.Clear();
                IEmployeeBLL employee = new EmployeeBLL();

                HienNV(employee.GetAllData(), 0, 0, "                          DANH SÁCH NHÂN VIÊN                      ", "Nhan vao Enter de thoat!", 30);
                exit = Console.ReadLine();
                if (exit == "") return;
            } while (true);
        }


        public bool NhapNV()
        {
            bool exit = false;
            do
            {
                IEmployeeBLL employee = new EmployeeBLL();
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                         NHẬP THÔNG TIN NHÂN VIÊN                       ║");
                Console.WriteLine("║════════════════════════════════════════════════════════════════════════║");
                Console.WriteLine("║                                                                        ║");
                Console.WriteLine("║ Tên nhân viên:                                                         ║");
                Console.WriteLine("║                                                                        ║");
                Console.WriteLine("║ Địa chỉ:                                                               ║");
                Console.WriteLine("║                                                                        ║");
                Console.WriteLine("║ Tuổi:                              Số điện thoại:                      ║");
                Console.WriteLine("║                                                                        ║");
                Console.WriteLine("║ Lương cơ bản:                      Hệ số lương:                        ║");
                Console.WriteLine("║                                                                        ║");
                Console.WriteLine("║ Phụ cấp:                                                               ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════╝");
                int x = 0, y = 14;
                int v = HienNV(employee.GetAllData(), x, y, "                           DANH SÁCH ĐÃ NHẬP                      ", "Nhan Backspace de thoat, Enter de luu!", 4);
                Employee cm = new Employee();

            n: try
                {
                    do
                    {
                        Console.SetCursorPosition(17, 4);
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
                        return exit;
                }
            a: try
                {
                    do
                    {
                        Console.SetCursorPosition(12, 6);
                        cm.Address = Console.ReadLine();

                        if (cm.Address == "0")
                        {
                            return exit;
                        }

                        if (cm.Address != null)
                        { break; }
                        else Console.SetCursorPosition(0, 18); Console.WriteLine("Địa chỉ khách hàng không được trống");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 18);
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
                        Console.SetCursorPosition(8, 8);
                        cm.Age = int.Parse(Console.ReadLine());

                        if (cm.Age >= 19)
                        {
                            break;
                        }
                        else
                            Console.SetCursorPosition(0, 18);
                        Console.WriteLine("Tuổi nhân viên phải lớn hơn 18. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 18);
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
                        Console.SetCursorPosition(52, 8);
                        cm.Numberphone = Console.ReadLine().Trim();

                        if (cm.Numberphone == "0")
                        {
                            return exit;
                        }

                        if (cm.Numberphone.Length <= 10)
                        {
                            break;
                        }
                        else
                            Console.SetCursorPosition(0, 18);
                        Console.WriteLine("Số điện thoại có độ dài nhỏ hơn 11 số. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception)
                {
                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine(" Kiểu số điện thoại không hợp lệ. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto x;
                    }
                    else
                        return exit;
                }

            z: try
                {
                    do
                    {
                        Console.SetCursorPosition(16, 10);
                        cm.Luongcoban = double.Parse(Console.ReadLine());

                        if (cm.Luongcoban > 0)
                        {
                            break;
                        }
                        else
                            Console.SetCursorPosition(0, 18);
                        Console.WriteLine("Lương cơ bản phải lớn hơn 0. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine(" Lương cơ bản nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto z;
                    }
                    else
                        return exit;
                }

            w: try
                {
                    do
                    {
                        Console.SetCursorPosition(51, 10);
                        cm.Hesoluong = double.Parse(Console.ReadLine());

                        if (cm.Hesoluong > 0)
                        {
                            break;
                        }
                        else
                            Console.SetCursorPosition(0, 18);
                        Console.WriteLine("Hệ số lương phải lớn hơn 0. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine(" Hệ số lương nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto w;
                    }
                    else
                        return exit;
                }

            t: try
                {
                    do
                    {
                        Console.SetCursorPosition(11, 12);
                        cm.Phucap = double.Parse(Console.ReadLine());

                        if (cm.Phucap >= 0)
                        {
                            break;
                        }
                        else
                            Console.SetCursorPosition(0, 18);
                        Console.WriteLine("Tiền phụ cấp không được < 0. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine(" Tiền phụ cấp nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto t;
                    }
                    else
                        return exit;
                }
                 Console.SetCursorPosition(32, v);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Backspace) return exit;
                else if (kt.Key == ConsoleKey.Enter)
                    employee.Add(cm);
            } while (true);
        }

        public void XoaNV()
        {
            do
            {
                Console.Clear();
                IEmployeeBLL employee = new EmployeeBLL();
                HienNV(employee.GetAllData(), 0, 0, "                 DANH SACH HOA DON                  ", "Thoat nhap 69! \n", 20);
                Console.SetCursorPosition(0, 12);
                Console.Write("Nhập mã nhân viên muốn xóa: ");
                int id;
                EmployeeBLL hd = new EmployeeBLL();
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
                            Console.WriteLine("Mã Nhân viên phải lớn hơn 0. Vui lòng nhập lại");
                        }
                        else
                            Console.SetCursorPosition(0, 15);
                        Console.WriteLine("Mã nhân viên không tồn tại. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine(" Mã nhân viên nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto s;
                    }
                    else
                        return;
                }
                employee.Delete(id);
            } while (true);
        }

        public void TimNV()
        {
            string tenNV = "";
            do
            {
                Console.Clear();
                IEmployeeBLL employee = new EmployeeBLL();
                List<Employee> list = employee.TimNV(new Employee(0, tenNV, null, 0, null,0,0,0,0));
                HienNV(list, 0, 0, "                 DANH SÁCH NHÂN VIÊN                     ", "Nhấn 0 de thoat! \n", 30);
            n: try
                {
                    do
                    {
                        Console.SetCursorPosition(0, 12);
                        Console.Write("Nhập tên nhân viên :");
                        Console.SetCursorPosition(22, 12);
                        tenNV = Console.ReadLine();

                        if (tenNV != null)
                        {
                            break;
                        }
                        else if (tenNV == "0")
                        {
                            return;
                        }
                        else
                            Console.SetCursorPosition(0, 18);
                        Console.WriteLine(" Tên nhân viên không được để trống. Vui lòng nhập lại!");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine(" Tên nhân viên nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto n;
                    }
                    else
                        return;
                }
                if (tenNV == "0") return;
            } while (true);
        }

        public void Sort()
        {

            do
            {
                Console.Clear(); // Xóa tất cả bắt đầu để hiển thị

                IEmployeeBLL employee = new EmployeeBLL();
                HienNV(employee.GetAllData(), 0, 0, "                 DANH SACH NHAN VIEN                       ", "", 30);
                // gọi hàm hiển thị đã có ở bên trên và truyền giá trị danh sách lấy tất cả dữ liệu và các giá trị khác

                HienNV(employee.GetSort(), 0, 12, "                 DANH SÁCH NHÂN VIÊN ĐÃ SẮP XẾP                      ", " Nhấn ESC để thoát \n Nhấn phím Enter để sắp xếp danh sách nhân viên theo bảng chữ cái! \n", 30);
                ConsoleKeyInfo kt = Console.ReadKey(); // Nhập ký tự

                if (kt.Key == ConsoleKey.Escape) return; // Nếu là phím Esc thì thoát
                else if (kt.Key == ConsoleKey.Enter) //ngược lại nếu nhận là phím Enter
                    employee.Sort();  // Gọi hàm Sắp xếp từ MobileBLL
                
                
            } while (true);
        }

        public void SuaNV()
        {
            string Name = null;
            string Address = null;
            int Age = 0;
            string Numberphone = null;
            double Luongcoban = 0;
            double Hesoluong = 0;
            double Phucap = 0;

            //Hiên thị mẫu nhập
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                             CẬP NHẬT THÔNG TIN NHÂN VIÊN                                           ║");
            Console.WriteLine("║════════════════════════════════════════════════════════════════════════════════════════════════════║");
            Console.WriteLine("║Nhập ID:                                                                                            ║");
            Console.WriteLine("║Tên NV:                                          Địa chỉ:                                           ║");
            Console.WriteLine("║                                                                                                    ║");
            Console.WriteLine("║Tuổi:                      Số điện thoại:                                                           ║");
            Console.WriteLine("║                                                                                                    ║");
            Console.WriteLine("║Lương cơ bản:                         Hệ số lương:                 Phụ cấp:                         ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════════╝");   
            int v = Console.CursorTop;
            
            IEmployeeBLL employee = new EmployeeBLL();
            HienNV(employee.GetAllData(), 0, 15, "                 DANH SACH NHAN VIEN                      ", "", 30);
            int id;
            EmployeeBLL hdb = new EmployeeBLL();
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
                        Console.SetCursorPosition(0, 22);
                        Console.WriteLine("Mã nhân viên phải lớn hơn 0. Vui lòng nhập lại");
                    }
                    else
                        Console.SetCursorPosition(0, 22);
                    Console.WriteLine("Mã nhân viên không tồn tại. Vui lòng nhập lại");

                } while (true);
            }
            catch (Exception )
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(0, 22);
                Console.WriteLine(" Mã nhân viên nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                ConsoleKeyInfo check = Console.ReadKey();
                if (check.Key == ConsoleKey.Enter)
                {
                    goto s;
                }
                else
                    return;
            }
            Employee em = employee.LayNVtheoID(id);
            if (em != null)
            {
                
                Console.SetCursorPosition(9, 4); Console.Write(em.Name);
                Console.SetCursorPosition(60, 4); Console.Write(em.Address);
                Console.SetCursorPosition(10, 6); Console.Write(em.Age);
                Console.SetCursorPosition(45, 6); Console.Write(em.Numberphone);
                Console.SetCursorPosition(15, 8); Console.Write(em.Luongcoban);
                Console.SetCursorPosition(53, 8); Console.Write(em.Hesoluong);
                Console.SetCursorPosition(78, 8); Console.Write(em.Phucap);
                //Nhập lại thông tin mới

                n: try
                {
                    do
                    {
                        Console.SetCursorPosition(30, 4);
                        Name = Console.ReadLine();

                        if (Name == "0")
                        {
                            return;
                        }

                        if (Name != null)
                        {
                            break;
                        }
                        else
                            Console.SetCursorPosition(0, 22);
                            Console.WriteLine(" Tên nhân viên không được để trống. Vui lòng nhập lại!");
                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 22);
                    Console.WriteLine(" Tên nhân viên nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
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
                        Console.SetCursorPosition(70, 4);
                        Address = Console.ReadLine();

                        if (Address == "0")
                        {
                            return;
                        }

                        if (Address != null)
                        { break; }
                        else Console.SetCursorPosition(0, 22); Console.WriteLine("Địa chỉ nhân viên không được trống");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 22);
                    Console.WriteLine(" Địa chỉ nhân viên nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
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
                        Console.SetCursorPosition(13, 6);
                        Age = int.Parse(Console.ReadLine());

                        if (Age >= 19)
                        {
                            break;
                        }
                        else
                            Console.SetCursorPosition(0, 22);
                            Console.WriteLine("Tuổi nhân viên phải lớn hơn 18. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 22);
                    Console.WriteLine(" Tuổi nhân viên nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto o;
                    }
                    else
                        return ;
                }

            x: try
                {
                    do
                    {
                        Console.SetCursorPosition(58, 6);
                        Numberphone = Console.ReadLine().Trim();

                        if (Numberphone == "0")
                        {
                            return;
                        }

                        if (Numberphone.Length <= 10)
                        {
                            break;
                        }
                        else
                            Console.SetCursorPosition(0, 22);
                            Console.WriteLine("Số điện thoại có độ dài nhỏ hơn 11 số. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 22);
                    Console.WriteLine(" Kiểu số điện thoại không hợp lệ. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto x;
                    }
                    else
                        return ;
                }

            z: try
                {
                    do
                    {
                        Console.SetCursorPosition(26, 8);
                        Luongcoban = double.Parse(Console.ReadLine());

                        if (Luongcoban > 0)
                        {
                            break;
                        }
                        else
                            Console.SetCursorPosition(0, 22);
                            Console.WriteLine("Lương cơ bản phải lớn hơn 0. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 22);
                    Console.WriteLine(" Lương cơ bản nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto z;
                    }
                    else
                        return ;
                }

            w: try
                {
                    do
                    {
                        Console.SetCursorPosition(55, 8);
                        Hesoluong = double.Parse(Console.ReadLine());

                        if (Hesoluong > 0)
                        {
                            break;
                        }
                        else
                            Console.SetCursorPosition(0, 22);
                            Console.WriteLine("Hệ số lương phải lớn hơn 0. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 22);
                    Console.WriteLine(" Hệ số lương nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto w;
                    }
                    else
                        return ;
                }

            t: try
                {
                    do
                    {
                        Console.SetCursorPosition(88, 8);
                        Phucap = double.Parse(Console.ReadLine());

                        if (Phucap >= 0)
                        {
                            break;
                        }
                        else
                            Console.SetCursorPosition(0, 22);
                            Console.WriteLine("Tiền phụ cấp không được < 0. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 22);
                    Console.WriteLine(" Tiền phụ cấp nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto t;
                    }
                    else
                        return ;
                }

                Console.SetCursorPosition(0, v);//Đưa con trỏ tới vị trí cuối cùng của danh sách được hiện thị ở trên dựa vào v
                Console.Write("Nhan Esc de thoat, Enter de luu!");
                //Nếu có dữ liệu có thay đổi thị cập nhật lại
                if (em.Name != Name && Name != null) em.Name = Name;
                if (em.Address != Address && Address != null) em.Address = Address;
                if (em.Numberphone != Numberphone && Numberphone != null) em.Numberphone = Numberphone;
                if (em.Age != Age && Age != 0) em.Age = Age;
                if (em.Luongcoban != Luongcoban && Luongcoban != 0) em.Luongcoban = Luongcoban;
                if (em.Phucap != Phucap && Phucap != 0) em.Phucap = Phucap;
                //Đợi xem người dùng lựa chọn chức năng gì(thoát hay nhập)
                Console.SetCursorPosition(33, Console.CursorTop);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape) return;
                else if (kt.Key == ConsoleKey.Enter) { employee.Update(em); return; }
            }
            else Console.Write("KHong co ma dien thoai ban vua nhap xin vui long nhap lai!"); Console.ReadKey();

        }
    }
}

