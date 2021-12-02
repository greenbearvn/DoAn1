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
            Console.SetCursorPosition(x + 8, y); Console.Write("║ TenNV");
            Console.SetCursorPosition(x + 25, y); Console.Write("║ Dia Chi");
            Console.SetCursorPosition(x + 40, y); Console.Write("║ Tuoi");
            Console.SetCursorPosition(x + 55, y); Console.Write("║ So DT");
            Console.SetCursorPosition(x + 70, y); Console.Write("║ Luong co ban");
            Console.SetCursorPosition(x + 85, y); Console.Write("║ He so luong");
            Console.SetCursorPosition(x + 100, y); Console.Write("║ Phu Cap");
            Console.SetCursorPosition(x + 110, y); Console.Write("║ Tong Luong");
            int d = 0;
            for (int i = list.Count - 1; i >= 0; --i)
            {
                y = y + 1;
                Console.SetCursorPosition(1, y); Console.Write("║ " + list[i].Id.ToString());
                Console.SetCursorPosition(8, y); Console.Write("║ " + list[i].Name);
                Console.SetCursorPosition(25, y); Console.Write("║ " + list[i].Address);
                Console.SetCursorPosition(40, y); Console.Write("║ " + list[i].Age.ToString());
                Console.SetCursorPosition(55, y); Console.Write("║ " + list[i].Numberphone);
                Console.SetCursorPosition(70, y); Console.Write("║ " + list[i].Luongcoban.ToString());
                Console.SetCursorPosition(85, y); Console.Write("║ " + list[i].Hesoluong.ToString());
                Console.SetCursorPosition(100, y); Console.Write("║ " + list[i].Phucap.ToString());
                Console.SetCursorPosition(110, y); Console.Write("║ " + list[i].Tinhluong.ToString());
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

                HienNV(employee.GetAllData(), 0, 0, "                 DANH SACH NHAN VIEN                      ", "Nhan vao Enter de thoat!", 30);
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
                Console.WriteLine("╔═════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                NHAP THONG TIN NHAN VIEN                     ║");
                Console.WriteLine("║═════════════════════════════════════════════════════════════║");
                Console.WriteLine("║                                                             ║");
                Console.WriteLine("║TEN KH:                    Dia chi:                          ║");
                Console.WriteLine("║                                                             ║");
                Console.WriteLine("║Tuoi:                      So Dien Thoai:                    ║");
                Console.WriteLine("║                                                             ║");
                Console.WriteLine("║Luong Co Ban:          He So Luong:       Phu cap:           ║");
                Console.WriteLine("╚═════════════════════════════════════════════════════════════╝");
                int x = 0, y = 8;
                int v = HienNV(employee.GetAllData(), x, y, "                 DANH SACH DA NHAP                      ", "Nhan Backspace de thoat, Enter de luu!", 4);
                Employee cm = new Employee();
                Console.SetCursorPosition(9, 4);
                do
                {
                    cm.Name = Console.ReadLine();
                } while (cm.Name == "");
                Console.SetCursorPosition(37, 4);
                do
                {
                    cm.Address = Console.ReadLine();
                } while (cm.Address == "");
                Console.SetCursorPosition(8, 6);
                do
                {
                    cm.Age = int.Parse(Console.ReadLine());
                } while (cm.Age < 18 && cm.Age > 100);
                Console.SetCursorPosition(45, 6);
                do
                {
                    cm.Numberphone = Console.ReadLine();
                } while (cm.Numberphone == "");
                Console.SetCursorPosition(17, 8);
                do {
                    cm.Luongcoban = double.Parse(Console.ReadLine()); 
                } while (cm.Luongcoban < 0);
                Console.SetCursorPosition(40, 8);
                do
                {
                    cm.Hesoluong = double.Parse(Console.ReadLine());
                } while (cm.Hesoluong < 0);
                Console.SetCursorPosition(53, 8);
                do
                {
                    cm.Phucap = double.Parse(Console.ReadLine());
                } while (cm.Phucap < 0);
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
                Console.Write("Nhập mã nhân viên muốn xóa: ");
                int id = int.Parse("0" + Console.ReadLine());
                if (id == 69) return;
                else employee.Delete(id);
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
                HienNV(list, 0, 0, "                 DANH SACH KHACH HANG                     ", "Nhan vay Enter de thoat! \n", 30);
                Console.Write("Nhập tên nhân viên cần tìm: ");
                tenNV = Console.ReadLine();
                if (tenNV == "") return;
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
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                             NHAP THONG TIN NHAN VIEN                                       ║");
            Console.WriteLine("║════════════════════════════════════════════════════════════════════════════════════════════║");
            Console.WriteLine("║Nhap ID:                                                                                    ║");
            Console.WriteLine("║TEN KH:                    Dia chi:                                                         ║");
            Console.WriteLine("║                                                                                            ║");
            Console.WriteLine("║Tuoi:                      So Dien Thoai:                                                   ║");
            Console.WriteLine("║                                                                                            ║");
            Console.WriteLine("║Luong Co Ban:                      He So Luong:                    Phu cap:                 ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════╝");   
            int v = Console.CursorTop;
            
            IEmployeeBLL employee = new EmployeeBLL();
            HienNV(employee.GetAllData(), 0, 10, "                 DANH SACH NHAN VIEN                      ", "", 30);
            Console.SetCursorPosition(12, 2); int id = int.Parse(Console.ReadLine());
            Employee em = employee.LayNVtheoID(id);
            if (em != null)
            {
                
                Console.SetCursorPosition(7, 3); Console.Write(em.Name);
                Console.SetCursorPosition(37, 3); Console.Write(em.Address);
                Console.SetCursorPosition(10, 5); Console.Write(em.Age);
                Console.SetCursorPosition(28, 5); Console.Write(em.Numberphone);
                Console.SetCursorPosition(16, 7); Console.Write(em.Luongcoban);
                Console.SetCursorPosition(50, 7); Console.Write(em.Hesoluong);
                Console.SetCursorPosition(78, 7); Console.Write(em.Phucap);
                //Nhập lại thông tin mới
                Console.SetCursorPosition(10, 3); try { Name = Console.ReadLine(); } catch { }
                Console.SetCursorPosition(48, 3); try { Address = Console.ReadLine(); } catch { }
                Console.SetCursorPosition(15, 5); try { Age = int.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(35, 5); try { Numberphone = Console.ReadLine(); } catch { }
                Console.SetCursorPosition(21, 7); try { Luongcoban = double.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(55, 7); try { Hesoluong = double.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(85, 7); try { Phucap = double.Parse(Console.ReadLine()); } catch { }
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

