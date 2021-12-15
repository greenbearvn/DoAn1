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
            Console.SetCursorPosition(x + 1, y); Console.Write("║ MA NhaCC");
            Console.SetCursorPosition(x + 15, y); Console.Write("║ Ten Ncc");
            Console.SetCursorPosition(x + 30, y); Console.Write("║ Dia Chi");
            int d = 0;
            for (int i = list.Count - 1; i >= 0; --i)
            {
                y = y + 1;
                Console.SetCursorPosition(1, y); Console.Write("║ " + list[i].Id.ToString());
                Console.SetCursorPosition(15, y); Console.Write("║ " + list[i].Name);
                Console.SetCursorPosition(30, y); Console.Write("║ " + list[i].Diachi);
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
                int v = HienNCC(brand.GetAllData(), x, y, "                 DANH SACH DA NHAP                      ", "Nhan Backspace de thoat, Enter de luu. Muốn thoát khi đang nhập nên nhập 0!", 6);
                Brand br = new Brand();

            n: try
                {
                    do
                    {
                        Console.SetCursorPosition(21, 4);
                        br.Name = Console.ReadLine();

                        if (br.Name != null)
                        {
                            break;
                        }
                        else if (br.Name == "0")
                        {
                            return exit;
                        }
                        else
                            Console.SetCursorPosition(0, 18);
                        Console.WriteLine(" Tên nhà cung cấp không được để trống. Vui lòng nhập lại!");
                    } while (true);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine(" Tên nhà cung cấp nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
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
                        Console.SetCursorPosition(65, 4);
                        br.Diachi = Console.ReadLine();

                        if (br.Diachi != null)
                        {
                            break;
                        }
                        else if (br.Diachi == "0")
                        {
                            return exit;
                        }
                        else
                            Console.SetCursorPosition(0, 18);
                        Console.WriteLine(" Địa chỉ nhà cung cấp không được để trống. Vui lòng nhập lại!");
                    } while (true);
                }
                catch (Exception )
                {
                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine(" Địa chỉ nhà cung cấp nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto a;
                    }
                    else
                        return exit;
                }

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
                HienNCC(brand.GetAllData(), 0, 0, "                 DANH SACH DIEN NHA CUNG CAP                  ", "Thoat nhap 69:   \n", 20);
                Console.SetCursorPosition(0, 12);
                Console.Write("Nhập mã nhà cung cấp muốn xóa: ");
                int id;
                BrandBLL hd = new BrandBLL();
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
                            Console.WriteLine("Mã nhà cung cấp phải lớn hơn 0. Vui lòng nhập lại");
                        }
                        else
                            Console.SetCursorPosition(0, 15);
                        Console.WriteLine("Mã nhà cung cấp không tồn tại. Vui lòng nhập lại");

                    } while (true);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine(" Mã nhà cung cấp nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto s;
                    }
                    else
                        return;
                }
                brand.Delete(id);
            } while (true);
        }

        public void TimNCC()
        {
            string tenNCC = "";
            do
            {
                Console.Clear();
                IBrandBLL brand = new BrandBLL();
                List<Brand> list = brand.TimNCC(new Brand(0, tenNCC, null));
                HienNCC(list, 0, 0, "                 DANH SACH NHA CUNG CAP                      ", "Nhan vao Enter de thoat!\n", 30);
                Console.Write("Nhập tên nhà cung cấp cần tìm: ");
            n: try
                {
                    do
                    {
                        Console.SetCursorPosition(0, 12);
                        Console.Write("Nhập tên nhà cung cấp :");
                        Console.SetCursorPosition(22, 12);
                        tenNCC = Console.ReadLine();

                        if (tenNCC != null)
                        {
                            break;
                        }
                        else if (tenNCC == "0")
                        {
                            return;
                        }
                        else
                            Console.SetCursorPosition(0, 18);
                        Console.WriteLine(" Tên nhà cung cấp không được để trống. Vui lòng nhập lại!");

                    } while (true);
                }
                catch (Exception)
                {
                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine(" Tên nhà cung cấp nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto n;
                    }
                    else
                        return;
                }
                if (tenNCC == "0") return;
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
            Console.WriteLine("║Nhập ID:                                                                        ║");
            Console.WriteLine("║Tên nhà cung cấp:                              Địa chỉ :                        ║");
            Console.WriteLine("║                                                                                ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════╝");
            int v = Console.CursorTop;
            
            IBrandBLL brand = new BrandBLL();
            HienNCC(brand.GetAllData(), 0, 10, "                 DANH SACH NHÀ CUNG CẤP                  ", "", 20);
            int id;
            BrandBLL hdb = new BrandBLL();
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
                        Console.WriteLine("Mã nhà cung cấp lớn hơn 0. Vui lòng nhập lại");
                    }
                    else
                        Console.SetCursorPosition(0, 20);
                    Console.WriteLine("Mã nhà cung cấp không tồn tại. Vui lòng nhập lại");

                } while (true);
            }
            catch (Exception )
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(0, 20);
                Console.WriteLine(" Mã nhà cung cấp nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                ConsoleKeyInfo check = Console.ReadKey();
                if (check.Key == ConsoleKey.Enter)
                {
                    goto s;
                }
                else
                    return;
            }
            Brand br = brand.LayNCCtheoID(id);
            if (br != null)
            {
                
                Console.SetCursorPosition(21, 4); Console.Write(br.Name);
                Console.SetCursorPosition(65, 4); Console.Write(br.Diachi);
            //Nhập lại thông tin mới

            n: try
                {
                    do
                    {
                        Console.SetCursorPosition(27, 4);
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
                            Console.SetCursorPosition(0, 18);
                        Console.WriteLine(" Tên nhà cung cấp không được để trống. Vui lòng nhập lại!");
                    } while (true);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine(" Tên nhà cung cấp nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
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
                        Console.SetCursorPosition(75, 4);
                        Diachi = Console.ReadLine();

                        if (Diachi != null)
                        {
                            break;
                        }
                        else if (Diachi == "0")
                        {
                            return ;
                        }
                        else
                            Console.SetCursorPosition(0, 18);
                        Console.WriteLine(" Địa chỉ nhà cung cấp không được để trống. Vui lòng nhập lại!");
                    } while (true);
                }
                catch (Exception)
                {
                    Console.SetCursorPosition(0, 18);
                    Console.WriteLine(" Địa chỉ nhà cung cấp nhập không đúng định dạng. \n Bấm Enter để tiến hành nhập lại");
                    ConsoleKeyInfo check = Console.ReadKey();
                    if (check.Key == ConsoleKey.Enter)
                    {
                        goto a;
                    }
                    else
                        return ;
                }

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

