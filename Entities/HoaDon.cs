using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Entities
{
    class HoaDon 
    {
        // Khai báo các thuộc tính của đối tượng hóa đơn
        
        private string hoTenKH,tendt, ngaydat,tennv, quekh, nhacc;
        private int id, manv, makh,quantum,sale,maDT;
        private double price ,total;

        // public các thuộc tính của đối tượng hóa đơn để có thể sử dụng ở các class khác

        public string HoTenKH {
            get { return hoTenKH; }
            set
            {
                if (value != "")
                    hoTenKH = value;
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
        

        public double Total
        {
            get { return (Price * (100 - sale) / 100)* quantum; }
            set
            {
                if (value > 0)
                    total = value ;
            }
        }

        public string Tennv {
            get { return tennv; }
            set
            {
                if (value != "")
                    tennv = value;
            }
        }
        public string Quekh {
            get { return quekh; }
            set
            {
                if (value != "")
                    quekh = value;
            }
        }
        public int Id {
            get { return id; }
            set
            {
                if (value > 0)
                    id = value;
            }
        }
        public int Manv {
            get { return manv; }
            set
            {
                if (value > 0)
                    manv = value;
            }
        }
        public int Makh {
            get { return makh; }
            set
            {
                if (value > 0)
                    makh = value;
            }
        }
        public int Quantum {
            get { return quantum; }
            set
            {
                if (value >= 0)
                    quantum = value;
            }
        }
        public int Sale {
            get { return sale; }
            set
            {
                if (value >= 0)
                    sale = value;
            }
        }
        public double Price {
            get { return price; }
            set
            {
                if (value > 0)
                    price = value;
            }
        }

        public int MaDT {
            get { return maDT; }
            set
            {
                if (value > 0)
                    maDT = value;
            }
        }

        public string TenDT {
            get { return tendt; }
            set
            {
                if (value != "")
                    tendt = value;
            }
        }

        public string Nhacc {
            get { return nhacc; }
            set
            {
                if (value != "")
                    nhacc = value;
            }
        }

        // Phương thức khởi tạo đối tượng không tham số
        public HoaDon() { }


        //Phương thức thiết lập sao chép
        public HoaDon(HoaDon hd)
        {
            this.id = hd.id;
            this.MaDT = hd.maDT;
            this.Makh = hd.makh;
            this.Manv = hd.manv;
            this.TenDT = string.Copy(hd.TenDT);
            this.Tennv = string.Copy(hd.tennv);
            this.Quekh = string.Copy(hd.quekh);
            this.HoTenKH = string.Copy(hd.hoTenKH);
            this.Ngaydat = string.Copy(hd.ngaydat);
            this.Nhacc = string.Copy(hd.Nhacc);
            this.Price = hd.price;
            this.Total = hd.total;
            this.Quantum = hd.quantum;
            this.Sale = hd.sale;
        }

        // Thiết lập phương thức khởi tạo đối tượng truyền tham số 
        public HoaDon(int id,int maDT, string tendt,string nhacc, int makh, string hoTenKH, string quekh, int manv, string tennv, string ngaydat, double price, int quantum, int sale, double total)
        {
            this.id=id;
            this.maDT = maDT;
            this.makh = makh;
            this.manv = manv;
            this.tennv = tennv;
            this.tendt = tendt;
            this.hoTenKH = hoTenKH;
            this.quekh = quekh;
            this.ngaydat = ngaydat;
            this.price = price;
            this.sale = sale;
            this.quantum = quantum;
            this.total = total;
            this.nhacc = nhacc;
        }
    }
}
