﻿using System;
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


            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine(tieudedau);
            Console.WriteLine("-----------------------------------------------------------------");
            y = y + 4;
            Console.SetCursorPosition(x + 1, y); Console.Write("MaKH");
            Console.SetCursorPosition(x + 8, y); Console.Write("TenKH");
            Console.SetCursorPosition(x + 20, y); Console.Write("Dia Chi");
            Console.SetCursorPosition(x + 30, y); Console.Write("Tuoi");
            Console.SetCursorPosition(x + 35, y); Console.Write("So DT");
            Console.SetCursorPosition(x + 45, y); Console.Write("Luong co ban");
            Console.SetCursorPosition(x + 55, y); Console.Write("He so luong");
            Console.SetCursorPosition(x + 60, y); Console.Write("Phu Cap");
            int d = 0;
            for (int i = list.Count - 1; i >= 0; --i)
            {
                y = y + 1;
                Console.SetCursorPosition(1, y); Console.Write(list[i].Id.ToString());
                Console.SetCursorPosition(8, y); Console.Write(list[i].Name);
                Console.SetCursorPosition(20, y); Console.Write(list[i].Address);
                Console.SetCursorPosition(30, y); Console.Write(list[i].Age.ToString());
                Console.SetCursorPosition(35, y); Console.Write(list[i].Numberphone);
                Console.SetCursorPosition(45, y); Console.Write(list[i].Luongcoban.ToString());
                Console.SetCursorPosition(55, y); Console.Write(list[i].Hesoluong.ToString());
                Console.SetCursorPosition(60, y); Console.Write(list[i].Phucap.ToString());
                Console.WriteLine();
                if ((++d) == n) break;
            }
            Console.WriteLine();
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

                HienNV(employee.GetAllData(), 0, 0, "                 DANH SACH NHAN VIEN                      ", "Nhan vay Enter de thoat!", 30);
                exit = Console.ReadLine();
                if (exit == "") return;
            } while (true);
        }


        public void NhapNV()
        {
            do
            {
                IEmployeeBLL employee = new EmployeeBLL();
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("||                NHAP THONG TIN NHAN VIEN               ||");
                Console.WriteLine("||-------------------------------------------------------||");
                Console.WriteLine("||                                                       ||");
                Console.WriteLine("||TEN KH:                    Dia chi:                    ||");
                Console.WriteLine("||                                                       ||");
                Console.WriteLine("||Tuoi:                      So Dien Thoai:              ||");
                Console.WriteLine("||                                                       ||");
                Console.WriteLine("||Luong Co Ban:        He So Luong:         Phu cap:     ||");
                Console.WriteLine("-----------------------------------------------------------");
                int x = 0, y = 8;
                int v = HienNV(employee.GetAllData(), x, y, "                 DANH SACH DA NHAP                      ", "Nhan Esc de thoat, Enter de luu!", 4);
                Employee cm = new Employee();
                Console.SetCursorPosition(7, 4); cm.Name = Console.ReadLine();
                Console.SetCursorPosition(37, 4); cm.Address = Console.ReadLine();
                Console.SetCursorPosition(10, 6); cm.Age = int.Parse(Console.ReadLine());
                Console.SetCursorPosition(28, 6); cm.Numberphone = Console.ReadLine();
                Console.SetCursorPosition(15, 7); cm.Luongcoban = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(35, 7); cm.Hesoluong = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(49, 7); cm.Phucap = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(32, v);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape) return;
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
                HienNV(employee.GetAllData(), 0, 0, "                 DANH SACH HOA DON                  ", "Nhap MA Hoa Don can xoa, thoat nhap 69!", 20);
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
                List<Employee> list = employee.TimNV(new Employee(0, tenNV, null, 0, null,0,0,0));
                HienNV(list, 0, 0, "                 DANH SACH KHACH HANG                     ", "Nhap Ho va Ten KH can tim, Nhan vay Enter de thoat!", 30);
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
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("||                       NHAP THONG TIN NHAN VIEN                                ||");
            Console.WriteLine("||---------------------------------------------------------------                ||");
            Console.WriteLine("||Nhap ID:                                                                       ||");
            Console.WriteLine("||TEN KH:                    Dia chi:                                            ||");
            Console.WriteLine("||                                                                               ||");
            Console.WriteLine("||Tuoi:                      So Dien Thoai:                                      ||");
            Console.WriteLine("||                                                                               ||");
            Console.WriteLine("||Luong Co Ban:               He So Luong:              Phu cap:                 ||");
            Console.WriteLine("---------------------------------------------------------------------------------");   
            int v = Console.CursorTop;
            
            IEmployeeBLL employee = new EmployeeBLL();
            Console.SetCursorPosition(12, 2); int id = int.Parse(Console.ReadLine());
            Employee em = employee.LayNVtheoID(id);
            if (em != null)
            {
                
                Console.SetCursorPosition(7, 3); Console.Write(em.Name);
                Console.SetCursorPosition(37, 3); Console.Write(em.Address);
                Console.SetCursorPosition(10, 5); Console.Write(em.Age);
                Console.SetCursorPosition(28, 5); Console.Write(em.Numberphone);
                Console.SetCursorPosition(15, 7); Console.Write(em.Luongcoban);
                Console.SetCursorPosition(35, 7); Console.Write(em.Hesoluong);
                Console.SetCursorPosition(49, 7); Console.Write(em.Phucap);
                //Nhập lại thông tin mới
                Console.SetCursorPosition(10, 3); try { Name = Console.ReadLine(); } catch { }
                Console.SetCursorPosition(48, 3); try { Address = Console.ReadLine(); } catch { }
                Console.SetCursorPosition(15, 5); try { Age = int.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(35, 5); try { Numberphone = Console.ReadLine(); } catch { }
                Console.SetCursorPosition(20, 7); try { Luongcoban = double.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(40, 7); try { Hesoluong = double.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(55, 7); try { Phucap = double.Parse(Console.ReadLine()); } catch { }
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

