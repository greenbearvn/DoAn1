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
        private IMobileBLL mobile = new MobileBLL();
         
         int HienMB(List<Mobile> list, int x, int y, string tieudedau, string tieudecuoi, int n)
        { 
            
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(tieudedau);
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            y = y + 4;
            Console.SetCursorPosition(x + 1, y); Console.Write("MADT");
            Console.SetCursorPosition(x + 10, y); Console.Write("Ten DT");
            Console.SetCursorPosition(x + 28, y); Console.Write("NHA CC");
            Console.SetCursorPosition(x + 37, y); Console.Write("LOAI");
            Console.SetCursorPosition(x + 45, y); Console.Write("GIA");
            Console.SetCursorPosition(x + 54, y); Console.Write("SALE");
            Console.SetCursorPosition(x + 62, y); Console.Write("SO LUONG");
            int d = 0;
            for (int i = list.Count - 1; i >= 0; --i)
            {
                y = y + 1;
                Console.SetCursorPosition(1, y); Console.Write(list[i].Id.ToString());
                Console.SetCursorPosition(10, y); Console.Write(list[i].TenDT);
                Console.SetCursorPosition(28, y); Console.Write(list[i].NhaCC);
                Console.SetCursorPosition(37, y); Console.Write(list[i].Type);
                Console.SetCursorPosition(45, y); Console.Write(list[i].Price.ToString());
                Console.SetCursorPosition(54, y); Console.Write(list[i].Sale.ToString());
                Console.SetCursorPosition(62, y); Console.Write(list[i].Quantum.ToString());
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
                IMobileBLL mobile = new MobileBLL();
                
                HienMB(mobile.GetAllData(), 0, 0, "                 DANH SACH DIEN THOAI                       ", "Nhan vào Enter de thoat!", 30);
                exit = Console.ReadLine();
                if (exit == "") return;
            } while (true);
        }

        public void ThongKe()
        {
            
            do
            {
                Console.Clear();
                IMobileBLL mobile = new MobileBLL();
                HienMB(mobile.GetThongKe(), 0, 0, "                 DANH SACH DIEN THOAI CON HANG                       ", "Nhan vao Enter de thong ke!", 30);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape) return;
                else if (kt.Key == ConsoleKey.Enter)
                    mobile.ThongKe();
            } while (true);
        }

        public void Sort()
        {

            do
            {
                Console.Clear();
                IMobileBLL mobile = new MobileBLL();
                HienMB(mobile.GetAllData(), 0, 0, "                 DANH SÁCH ĐIỆN THOẠI ĐÃ SẮP XẾP                      ", "Nhấn ESC để thoát và NHấn vào Enter để sắp xếp!", 30);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape) return;
                else if (kt.Key == ConsoleKey.Enter)
                    mobile.Sort();
            } while (true);
        }

        public bool NhapMB()
        {
            bool exit = false;
            do
            {
                IMobileBLL mobile = new MobileBLL(); 
                Console.Clear();
                Console.WriteLine("  ----------------------------------------------------------- ");
                Console.WriteLine("||                NHAP THONG TIN DIEN THOAI                  ||");
                Console.WriteLine("||-----------------------------------------------------------||");
                Console.WriteLine("||                                                           ||");
                Console.WriteLine("||TEN DT:                    Nha cung cap:                   ||");
                Console.WriteLine("||                                                           ||");
                Console.WriteLine("||Loai:          Gia:          Sale:      So luong:          ||");
                Console.WriteLine("  -----------------------------------------------------------  ");
                int x = 0, y = 8;
                int v = HienMB(mobile.GetAllData(),x, y, "                 DANH SACH DA NHAP                      ", "Nhan Space de thoat, Enter de luu!", 6);
                Mobile mb = new Mobile();
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
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape) return exit;
                else if (kt.Key == ConsoleKey.Enter)
                    mobile.Add(mb);
            } while (true);
        }
        
        public void XoaMB()
        {
            do
            {
                Console.Clear();
                IMobileBLL mobile = new MobileBLL();
                HienMB(mobile.GetAllData(),0, 0, "                 DANH SACH DIEN THOAI TRONG KHO                  ", "Nhap MADT can xoa, thoat nhap 69:   ", 20);
                int id = int.Parse("0" + Console.ReadLine());
                if (id == 69) return;
                else mobile.Delete(id);
            } while (true);
        }
       
        public void TimDT()
        {
            string tenDT = "";
            do
            {
                Console.Clear();
                IMobileBLL mobile = new MobileBLL();
                List<Mobile> list = mobile.Timdt(new Mobile(0, tenDT, null, null, 0, 0,0));
                HienMB(list,0, 0, "                 DANH SACH DIEN THOAI                      ", "Nhap Ho va Ten can tim, Nhan vao Enter de thoat!", 30);
                
                 tenDT = Console.ReadLine();
                
                if (tenDT == "") return; 
            } while (true);
        }

        public void SuaMB()
        {
            string TenDT = null;
            string NhaCC = null;
            string Type = null;
            double Price = 0;
            int Sale = 0;
            int Quantum = 0;
            
            Console.Clear();
            Console.WriteLine("  ----------------------------------------------------------------------------------------");
            Console.WriteLine("||                NHAP THONG TIN DIEN THOAI                                              ||");
            Console.WriteLine("||---------------------------------------------------------------------------------------||");
            Console.WriteLine("||Nhap ID:                                                                               ||");
            Console.WriteLine("||TEN DT:                                  Nha cung cap:                                 ||");
            Console.WriteLine("||                                                                                       ||");
            Console.WriteLine("||Loai:                Gia:                           Sale:           Soluong:           ||");
            Console.WriteLine("  ----------------------------------------------------------------------------------------");
            int v = Console.CursorTop;
            
            IMobileBLL mobile = new MobileBLL();
            Console.SetCursorPosition(12, 3); int id = int.Parse(Console.ReadLine());
            Mobile mb = mobile.LayMBtheoID(id);
            if (mb != null)
            {
                
                Console.SetCursorPosition(10, 4); Console.Write(mb.TenDT);
                Console.SetCursorPosition(58, 4); Console.Write(mb.NhaCC);
                Console.SetCursorPosition(8, 6); Console.Write(mb.Type);
                Console.SetCursorPosition(28, 6); Console.Write(mb.Price);
                Console.SetCursorPosition(60, 6); Console.Write(mb.Sale);
                Console.SetCursorPosition(80, 6); Console.Write(mb.Quantum);
                //Nhập lại thông tin mới
                Console.SetCursorPosition(20, 4); try {
                    do
                    {
                        mb.TenDT = Console.ReadLine();
                    } while (mb.TenDT == "");
                } catch { }
                Console.SetCursorPosition(65, 4); try {
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

