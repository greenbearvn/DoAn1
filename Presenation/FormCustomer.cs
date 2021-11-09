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
        private ICustomerBLL mobile = new CustomerBLL();

        int HienKH(List<Customer> list, int x, int y, string tieudedau, string tieudecuoi, int n)
        {


            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine(tieudedau);
            Console.WriteLine("-----------------------------------------------------------------");
            y = y + 4;
            Console.SetCursorPosition(x + 1, y); Console.Write("MaKH");
            Console.SetCursorPosition(x + 8, y); Console.Write("TenKH");
            Console.SetCursorPosition(x + 10, y); Console.Write("Dia Chi");
            Console.SetCursorPosition(x + 12, y); Console.Write("Tuoi");
            Console.SetCursorPosition(x + 24, y); Console.Write("So DT");
            int d = 0;
            for (int i = list.Count - 1; i >= 0; --i)
            {
                y = y + 1;
                Console.SetCursorPosition(1, y); Console.Write(list[i].Id.ToString());
                Console.SetCursorPosition(8, y); Console.Write(list[i].Name);
                Console.SetCursorPosition(10, y); Console.Write(list[i].Address);
                Console.SetCursorPosition(12, y); Console.Write(list[i].Age.ToString());
                Console.SetCursorPosition(24, y); Console.Write(list[i].Numberphone);
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
                ICustomerBLL customer = new CustomerBLL();

                HienKH(customer.GetAllData(), 0, 0, "                 DANH SACH KAHCH HANG                      ", "Nhan vay Enter de thoat!", 30);
                exit = Console.ReadLine();
                if (exit == "") return;
            } while (true);
        }


        public void NhapHK()
        {
            do
            {
                ICustomerBLL customer = new CustomerBLL();
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("||                NHAP THONG TIN KHACH HANG              ||");
                Console.WriteLine("||-------------------------------------------------------||");
                Console.WriteLine("||                                                       ||");
                Console.WriteLine("||TEN KH:                    Dia chi:                    ||");
                Console.WriteLine("||                                                       ||");
                Console.WriteLine("||Tuoi:                      So Dien Thoai:              ||");
                Console.WriteLine("-----------------------------------------------------------");
                int x = 0, y = 8;
                int v = HienKH(customer.GetAllData(), x, y, "                 DANH SACH DA NHAP                      ", "Nhan Esc de thoat, Enter de luu!", 4);
                Customer cm = new Customer();
                Console.SetCursorPosition(10, 4); cm.Name = Console.ReadLine();
                Console.SetCursorPosition(37, 4); cm.Address = Console.ReadLine();
                Console.SetCursorPosition(10, 6); cm.Age = int.Parse(Console.ReadLine());
                Console.SetCursorPosition(44, 6); cm.Numberphone = Console.ReadLine();
                Console.SetCursorPosition(32, v);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape) return;
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
                HienKH(customer.GetAllData(), 0, 0, "                 DANH SACH HOA DON                  ", "Nhap MA Hoa Don can xoa, thoat nhap 69!", 20);
                int id = int.Parse("0" + Console.ReadLine());
                if (id == 69) return;
                else customer.Delete(id);
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
                HienKH(list, 0, 0, "                 DANH SACH KHACH HANG                     ", "Nhap Ho va Ten KH can tim, Nhan vay Enter de thoat!", 30);
                tenKH = Console.ReadLine();
                if (tenKH == "") return;
            } while (true);
        }
        public void SuaCS()
        {
            string Name = null;
            string Address = null;
            int Age = 0;
            string Numberphone = null;
            
           
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("||                NHAP THONG TIN KHACH HANG              ||");
            Console.WriteLine("||-------------------------------------------------------||");
            Console.WriteLine("||Nhap ID:                                               ||");
            Console.WriteLine("||TEN KH:                    Dia chi:                    ||");
            Console.WriteLine("||                                                       ||");
            Console.WriteLine("||Tuoi:                      So Dien Thoai:              ||");
            Console.WriteLine("-----------------------------------------------------------");
            int v = Console.CursorTop;
            
            ICustomerBLL customer = new CustomerBLL();
            Console.SetCursorPosition(12, 4); int id = int.Parse(Console.ReadLine());
            Customer cm = customer.LayKHtheoID(id);
            if (cm != null)
            {
                
                Console.SetCursorPosition(10, 3); Console.Write(cm.Name);
                Console.SetCursorPosition(37, 3); Console.Write(cm.Address);
                Console.SetCursorPosition(10, 5); Console.Write(cm.Age);
                Console.SetCursorPosition(44, 5); Console.Write(cm.Numberphone);

                //Nhập lại thông tin mới
                Console.SetCursorPosition(15, 3); try { Name = Console.ReadLine(); } catch { }
                Console.SetCursorPosition(46, 3); try { Address = Console.ReadLine(); } catch { }
                Console.SetCursorPosition(15, 5); try { Age = int.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(47, 5); try { Numberphone = Console.ReadLine(); } catch { }
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

