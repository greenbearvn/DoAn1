using System;
using System.Collections.Generic;
using System.Text;
using Demo.Entities;
using Demo.Business.Components;
using Demo.Business.Services;

namespace Demo.Presenation
{
    
    public class FormBrand
    {
        private IBrandBLL mobile = new BrandBLL();

        int HienNCC(List<Brand> list, int x, int y, string tieudedau, string tieudecuoi, int n)
        {

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(tieudedau);
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════");
            y = y + 4;
            Console.SetCursorPosition(x + 1, y); Console.Write("MA NhaCC");
            Console.SetCursorPosition(x + 15, y); Console.Write("Ten Ncc");
            Console.SetCursorPosition(x + 30, y); Console.Write("Dia Chi");
            int d = 0;
            for (int i = list.Count - 1; i >= 0; --i)
            {
                y = y + 1;
                Console.SetCursorPosition(1, y); Console.Write(list[i].Id.ToString());
                Console.SetCursorPosition(15, y); Console.Write(list[i].Name);
                Console.SetCursorPosition(30, y); Console.Write(list[i].Diachi);
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
                IBrandBLL brand = new BrandBLL();

                HienNCC(mobile.GetAllData(), 0, 0, "                 DANH SACH NHA CUNG CAP                       ", "Nhan vay Enter de thoat!", 30);
                exit = Console.ReadLine();
                if (exit == "") return;
            } while (true);
        }

        
        public bool NhapNCC()
        {
            bool exit = false;
            do
            {
                IBrandBLL brand = new BrandBLL();
                Console.Clear();
                Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                          NHAP THONG TIN NHA CUNG CAP                            ║");
                Console.WriteLine("║═════════════════════════════════════════════════════════════════════════════════║");
                Console.WriteLine("║                                                                                 ║");
                Console.WriteLine("║TEN nha cung cap:                              Dia chi:                          ║");
                Console.WriteLine("║                                                                                 ║");
                Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════════╝");
                int x = 0, y = 8;
                int v = HienNCC(brand.GetAllData(), x, y, "                 DANH SACH DA NHAP                      ", "Nhan Backspace de thoat, Enter de luu!", 6);
                Brand br = new Brand();
                Console.SetCursorPosition(21, 4);
                do
                {
                    br.Name = Console.ReadLine();
                } while (br.Name == "");
                Console.SetCursorPosition(65, 4);
                do
                {
                    br.Diachi = Console.ReadLine();
                } while (br.Diachi == "");

                Console.SetCursorPosition(32, v);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Backspace) return exit;
                else if (kt.Key == ConsoleKey.Enter)
                    mobile.Add(br);
            } while (true);
        }

        public void XoaNCC()
        {
            do
            {
                Console.Clear();
                IBrandBLL brand = new BrandBLL();
                HienNCC(brand.GetAllData(), 0, 0, "                 DANH SACH DIEN THOAI TRONG KHO                  ", "Nhap MANCC can xoa, thoat nhap 69:   ", 20);
                int id = int.Parse("0" + Console.ReadLine());
                if (id == 69) return;
                else mobile.Delete(id);
            } while (true);
        }

        public void TimNCC()
        {
            string tenNCC = "";
            do
            {
                Console.Clear();
                IBrandBLL brand = new BrandBLL();
                List<Brand> list = brand.TimNCC(new Brand(0, null, null));
                HienNCC(list, 0, 0, "                 DANH SACH NHA CUNG CAP                      ", "Nhap Ho va Ten can tim, Nhan vao Enter de thoat!", 30);
                tenNCC = Console.ReadLine();
                if (tenNCC == "") return;
            } while (true);
        }

        public void SuaNCC()
        {
            string Name = null;
            string Diachi = null;

            
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                        CAP NHAT THONG TIN NHA CUNG CAP                         ║");
            Console.WriteLine("║------------------------------------------------------------------------------- ║");
            Console.WriteLine("║                                                                                ║");
            Console.WriteLine("║TEN nha cung cap:                              Nha cung cap:                    ║");
            Console.WriteLine("║                                                                                ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════╝");
            int v = Console.CursorTop;
            
            IBrandBLL brand = new BrandBLL();
            Console.SetCursorPosition(12, 3); int id = int.Parse(Console.ReadLine());
            Brand br = brand.LayNCCtheoID(id);
            if (br != null)
            {
                
                Console.SetCursorPosition(21, 4); Console.Write(br.Name);
                Console.SetCursorPosition(65, 4); Console.Write(br.Diachi);
                //Nhập lại thông tin mới
                Console.SetCursorPosition(27, 4); try { Name = Console.ReadLine(); } catch { }
                Console.SetCursorPosition(75, 4); try { Diachi = Console.ReadLine(); } catch { }

                Console.SetCursorPosition(0, v);
                Console.Write("Nhan Esc de thoat, Enter de luu!");
                
                if (br.Name != Name && Name != null) br.Name = Name;
                if (br.Diachi != Diachi && Diachi != null) br.Diachi = Diachi;

                
                Console.SetCursorPosition(33, Console.CursorTop);
                ConsoleKeyInfo kt = Console.ReadKey();
                if (kt.Key == ConsoleKey.Escape) return;
                else if (kt.Key == ConsoleKey.Enter) { brand.Update(br); return; }
            }
            else Console.Write("KHong co ma dien thoai ban vua nhap xin vui long nhap lai!"); Console.ReadKey();

        }

    }
}

