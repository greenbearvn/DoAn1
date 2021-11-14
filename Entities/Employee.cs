using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Entities
{
    class Employee : Person
    {
        
        private double hesoluong, luongcoban;
        private double phucap,tinhluong;
        public double Hesoluong
        {
            get { return hesoluong; }
            set
            {
                if (value > 0)
                    hesoluong = value;
            }
        }
        public double Luongcoban
        {
            get { return luongcoban; }
            set
            {
                if (value >= 0)
                    luongcoban = value;
            }
        }
        public double Phucap
        {
            get { return phucap; }
            set
            {
                if (value >= 0)
                    phucap = value;
            }
        }
        public double Tinhluong
        {
            get { return (luongcoban * hesoluong) + phucap; }
            set
            {
                if (value >= 0)
                    phucap = value;
            }
        }
        public Employee() { }
        public Employee(Employee em)
        {
            this.Id = em.Id;
            this.Name = string.Copy(em.Name);
            this.Address = string.Copy(em.Address);
            this.Age = em.Age;
            this.Numberphone = string.Copy(em.Numberphone);
            this.luongcoban = em.luongcoban;
            this.hesoluong = em.hesoluong;
            this.phucap = em.phucap;
            this.tinhluong = em.tinhluong;
        }

        public Employee(int id, string name, string address, int age, string numberphone, double luongcoban, double hesoluong, double phucap, double tinhluong) : base(id, name, address, age, numberphone)
        {
            this.luongcoban = luongcoban;
            this.hesoluong = hesoluong;
            this.phucap = phucap;
            this.tinhluong = tinhluong;
        }
    }
}
