using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Entities
{
    class HoaDon
    {
        private int id, soluong,sale;
        private string hoTenKH, tenDT, ngaydat;
        private double total,price;

        public int Id {
            get { return id; }
            set
            {
                if (value >= 0)
                    id = value;
            }
        }
        public int Soluong {
            get { return soluong; }
            set
            {
                if (value > 0)
                    soluong = value;
            }
        }
        public string HoTenKH {
            get { return hoTenKH; }
            set
            {
                if (value != "")
                    hoTenKH = value;
            }
        }
        public string TenDT {
            get { return tenDT; }
            set
            {
                if (value != "")
                    tenDT = value;
            }
        }
        public string Ngaydat {
            get { return ngaydat; }
            set
            {
                if (value != "")
                    ngaydat = value;
            }
        }
        public double Total {
            get { return (price *(100 -sale)/100) * soluong; }
            set
            {
                if (value > 0)
                    total = value;
            }
        }

        public double Price { get => price; set => price = value; }
        public int Sale {
            get { return sale; }
            set
            {
                if (value >= 0)
                    sale = value;
            }
        }

        public HoaDon() { }
        //Phương thức thiết lập sao chép
        public HoaDon(HoaDon hd)
        {
            this.id = hd.id;
            this.tenDT = string.Copy(hd.tenDT);
            this.hoTenKH = string.Copy(hd.hoTenKH);
            this.ngaydat = string.Copy(hd.ngaydat);
            this.price = hd.price;
            this.total = hd.total;
            this.soluong = hd.soluong;
            this.sale = hd.sale;
        }
        public HoaDon(int id, string tenDT, string hoTenKH, string ngaydat, double price, int soluong, int sale, double total)
        {
            this.id = id;
            this.tenDT = tenDT;
            this.hoTenKH = hoTenKH;
            this.ngaydat = ngaydat;
            this.price = price;
            this.sale = sale;
            this.soluong = soluong;
            this.total = total;
        }
    }
}
