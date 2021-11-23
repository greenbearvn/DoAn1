using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Entities
{
    class Mobile
    {
        // Khai báo các thuộc tính của đối tượng Điện thoại
        private string tenDT, nhaCC, type;
        private double price;
        private int id, sale;
        private int quantum;

        // public các thuộc tính của đối tượng Điện thoại để có thể sử dụng ở các class khác
        public string TenDT
        {
            get { return tenDT; }
            set
            {
                if (value != "")
                    tenDT = value;
            }
        }
        public string NhaCC
        {
            get { return nhaCC; }
            set
            {
                if (value != "")
                    nhaCC = value;
            }
        }
        public string Type
        {
            get { return type; }
            set
            {
                if (value != "")
                    type = value;
            }
        }
        public double Price
        {
            get { return price; }
            set
            {
                if (value >= 0)
                    price = value;
            }
        }
        public int Id
        {
            get { return id; }
            set
            {
                if (value >= 1)
                    id = value;
            }
        }
        public int Sale
        {
            get { return sale; }
            set
            {
                if (value >= 0)
                    sale = value;
            }
        }
        
        public int Quantum
        {
            get { return quantum; }
            set
            {
                if (value >= 0)
                    quantum = value;
            }
        }

        

        // Phương thức khởi tạo đối tượng không tham số
        public Mobile() { }
        //Phương thức thiết lập sao chép
        public Mobile(Mobile mb)
        {
            this.id = mb.id;
            this.tenDT = string.Copy(mb.tenDT);
            this.nhaCC = string.Copy(mb.nhaCC);
            this.type = string.Copy(mb.type);
            this.price = mb.price;
            this.sale = mb.sale;
            this.quantum = mb.quantum;
        }
        // Thiết lập phương thức khởi tạo đối tượng truyền tham số 
        public Mobile(int id, string tenDT, string nhaCC, string type, double price, int sale, int quantum)
        {
            this.id = id;
            this.tenDT = tenDT;
            this.nhaCC = nhaCC;
            this.type = type;
            this.price = price;
            this.sale = sale;
            this.quantum = quantum;
        }
    }
}

