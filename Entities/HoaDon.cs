using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Entities
{
    class HoaDon
    {
        // Khai báo các thuộc tính của đối tượng hóa đơn
        private int id, soluong,sale;
        private string hoTenKH, tenDT, ngaydat;
        private double total,price;

        // public các thuộc tính của đối tượng hóa đơn để có thể sử dụng ở các class khác
        public int Id {
            get { return id; }
            set
            {
                if (value >= 0)
                    id = value;
            }
        }
        public int Sale
        {
            get { return sale; }
            set
            {
                if (value > 0)
                    sale = value;
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
        

        public double Price { get => price; set => price = value; }
        public int Soluong {
            get { return soluong; }
            set
            {
                if (value >= 0)
                    soluong = value;
            }
        }
        public double Total
        {
            get { return (price * (100 - sale) / 100)* soluong; }
            set
            {
                if (value > 0)
                    total = value ;
            }
        }
        // Phương thức khởi tạo đối tượng không tham số
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

        // Thiết lập phương thức khởi tạo đối tượng truyền tham số 
        public HoaDon(int id, string tenDT, string hoTenKH, string ngaydat, double price, int soluong, int sale, double total)
        {
            this.id = id;
            this.tenDT = tenDT;
            this.hoTenKH = hoTenKH;
            this.ngaydat = ngaydat;
            this.price = price;
            this.soluong = soluong;
            this.sale = sale;
            this.total = total;
        }
    }
}
