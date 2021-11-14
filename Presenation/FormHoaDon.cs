using System;
using System.Collections.Generic;
using System.Text;
using Demo.Entities;
using Demo.Business.Components;
using Demo.Business.Services;

namespace Demo.Presenation
{
    class FormHoaDon
    {
        private IHoaDonBLL mobile = new HoaDonBLL();
        
        int HienHD(List<HoaDon> list, int x, int y, string tieudedau, string tieudecuoi, int n)
        {
            
           
            Console.WriteLine();
            
            Console.WriteLine();
            Console.WriteLine(tieudedau);
            Console.WriteLine("-----------------------------------------------------------------");
            y = y + 4;
            Console.SetCursorPosition(x + 1, y); Console.Write("MaHD");
            Console.SetCursorPosition(x + 8, y); Console.Write("Ten DT");
            Console.SetCursorPosition(x + 20 , y); Console.Write("Ho Ten KH");
            Console.SetCursorPosition(x + 35 , y); Console.Write("Ngay Dat");
            Console.SetCursorPosition(x + 50 , y); Console.Write("GIA");
            Console.SetCursorPosition(x + 60 , y); Console.Write("So Luong");
            Console.SetCursorPosition(x + 70, y); Console.Write("Sale");
            Console.SetCursorPosition(x + 80 , y); Console.Write("Tong");
            int d = 0;
            for (int i = list.Count - 1; i >= 0; --i)
            {
                y = y + 1;
                Console.SetCursorPosition(1, y); Console.Write(list[i].Id.ToString());
                Console.SetCursorPosition(8, y); Console.Write(list[i].TenDT);
                Console.SetCursorPosition(20, y); Console.Write(list[i].HoTenKH);
                Console.SetCursorPosition(35, y); Console.Write(list[i].Ngaydat);
                Console.SetCursorPosition(50, y); Console.Write(list[i].Price.ToString());
                Console.SetCursorPosition(60, y); Console.Write(list[i].Soluong.ToString());
                Console.SetCursorPosition(70, y); Console.Write(list[i].Sale.ToString());
                Console.SetCursorPosition(80, y); Console.Write(list[i].Total.ToString());
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
                IHoaDonBLL hoadon = new HoaDonBLL();

                HienHD(hoadon.GetAllData(), 0, 0, "                 DANH SACH HOA DON                      ", "Nhan vay Enter de thoat!", 30);
                exit = Console.ReadLine();
                if (exit == "") return;
            } while (true);
        }

        
        public bool NhapHD()
        {
            bool exit = false;
            do
            {
                IHoaDonBLL hoadon = new HoaDonBLL();
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------------");
                Console.WriteLine("||                  NHAP THONG TIN HOA DON                           ||");
                Console.WriteLine("||-------------------------------------------------------------------||");
                Console.WriteLine("||                                                                   ||");
                Console.WriteLine("||TEN DT:                    Ho Ten Khach Hang:                      ||");
                Console.WriteLine("||                                                                   ||");
                Console.WriteLine("||Ngay dat:        Gia:          So luong:      Sale:                ||");
                Console.WriteLine("----------------------------------------------------------------------");
                int x = 0, y = 8;
                int v = HienHD(hoadon.GetAllData(), x, y, "                 DANH SACH DA NHAP                      ", "Nhan Esc de thoat, Enter de luu!", 6);
                HoaDon hd = new HoaDon();
                Console.SetCursorPosition(11, 4); 
                do
                {
                    hd.TenDT = Console.ReadLine();
                } while (hd.TenDT == "");
                Console.SetCursorPosition(49, 4);
                do
                {
                    hd.HoTenKH = Console.ReadLine();
                } while (hd.HoTenKH == "");
                Console.SetCursorPosition(13, 6);
                do
                {
                    hd.Ngaydat = Console.ReadLine();
                } while (hd.Ngaydat == "");
                Console.SetCursorPosition(26, 6);
                do
                {
                    hd.Price = double.Parse(Console.ReadLine());
                } while (hd.Price < 0);
                Console.SetCursorPosition(47, 6);
                do
                {
                    hd.Soluong = int.Parse(Console.ReadLine());
                } while (hd.Soluong < 0);
                Console.SetCursorPosition(53, 6);
                do
                {
                    hd.Sale = int.Parse(Console.ReadLine());
                } while (hd.Sale < 0);
                Console.SetCursorPosition(32, v);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape) return exit;
                else if (kt.Key == ConsoleKey.Enter)
                    hoadon.Add(hd);
            } while (true);
        }
        
        public void XoaHD()
        {
            do
            {
                Console.Clear();
                IHoaDonBLL hoadon = new HoaDonBLL();
                HienHD(hoadon.GetAllData(), 0, 0, "                 DANH SACH HOA DON                  ", "Nhap MA Hoa Don can xoa, thoat nhap 69!", 20);
                int id = int.Parse("0" + Console.ReadLine());
                if (id == 69) return;
                else hoadon.Delete(id);
            } while (true);
        }

        public void TimHD()
        {
            string tenHD = "";
            do
            {
                Console.Clear();
                IHoaDonBLL hoadon = new HoaDonBLL();
                List<HoaDon> list = mobile.TimHD(new HoaDon(0, tenHD, null, null, 0, 0,0,0));
                HienHD(list, 0, 0, "                 DANH SACH HOA DON                      ", "Nhập tên hóa đơn cần tìm, Nhan vay Enter de thoat!", 30);
                tenHD = Console.ReadLine();
                if (tenHD == "") return;
            } while (true);
        }
        public void SuaHD()
        {
            string TenDT = null;
            string HoTenKH = null;
            string Ngaydat = null;
            double Price = 0;
            int Soluong = 0;
            int Sale = 0;

            //Hiên thị mẫu nhập
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.WriteLine("||                             NHAP THONG TIN HOA DON                                        ||");
            Console.WriteLine("||-------------------------------------------------------------------------------------------||");
            Console.WriteLine("||Nhap ID:                                                                                   ||");
            Console.WriteLine("||TEN DT:                         Ho Ten Khach Hang:                                         ||");
            Console.WriteLine("||                                                                                           ||");
            Console.WriteLine("||Ngay dat:                   Gia:                  So luong:                Sale:           ||");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            int v = Console.CursorTop;
            IHoaDonBLL hoadon = new HoaDonBLL();
            Console.SetCursorPosition(12, 3); int id = int.Parse(Console.ReadLine());
            HoaDon hd = mobile.LayHDtheoID(id);
            if (hd != null)
            {
                
                Console.SetCursorPosition(11, 4); Console.Write(hd.TenDT);
                Console.SetCursorPosition(59, 4); Console.Write(hd.HoTenKH);
                Console.SetCursorPosition(12, 6); Console.Write(hd.Ngaydat);
                Console.SetCursorPosition(34, 6); Console.Write(hd.Price);
                Console.SetCursorPosition(62, 6); Console.Write(hd.Soluong);
                Console.SetCursorPosition(84, 6);
                do
                {
                    hd.Sale = int.Parse(Console.ReadLine());
                } while (hd.Sale < 0);
                Console.SetCursorPosition(15, 4); try { TenDT = Console.ReadLine(); } catch { }
                Console.SetCursorPosition(68, 4); try { HoTenKH = Console.ReadLine(); } catch { }
                Console.SetCursorPosition(17, 6); try { Ngaydat = Console.ReadLine(); } catch { }
                Console.SetCursorPosition(37, 6); try { Price = double.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(65, 6); try { Soluong = int.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(87, 6); try { Sale = int.Parse(Console.ReadLine()); } catch { }
                Console.SetCursorPosition(0, v);//Đưa con trỏ tới vị trí cuối cùng của danh sách được hiện thị ở trên dựa vào v
                Console.Write("Nhan Esc de thoat, Enter de luu!");
                
                if (hd.TenDT != TenDT && TenDT != null) hd.TenDT = TenDT;
                if (hd.HoTenKH != HoTenKH && HoTenKH != null) hd.HoTenKH = HoTenKH;
                if (hd.Ngaydat != Ngaydat && Ngaydat != null) hd.Ngaydat = Ngaydat;
                if (hd.Price != Price && Price != 0) hd.Price = Price;
                if (hd.Soluong != Soluong && Soluong != 0) hd.Soluong = Soluong;
                if (hd.Sale != Sale && Sale != 0) hd.Sale = Sale;
                
                Console.SetCursorPosition(33, Console.CursorTop);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape) return;
                else if (kt.Key == ConsoleKey.Enter) { hoadon.Update(hd); return; }
            }
            else Console.Write("KHong co ma hoa don ban vua nhap xin vui long nhap lai!"); Console.ReadKey();

        }
    }
}
