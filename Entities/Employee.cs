using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Entities
{
    class Employee
    {
        private string name, address, numberphone;
        private int id, age;
        private double hesoluong, luongcoban;
        private double phucap;

        public int Id
        {
            get { return id; }
            set
            {
                if (value >= 1)
                    id = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value != "")
                    name = value;
            }
        }
        public string Address
        {
            get { return address; }
            set
            {
                if (value != "")
                    address = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 1 && value < 100)
                    age = value;
            }
        }
        public string Numberphone
        {
            get { return numberphone; }
            set
            {
                if (value != "")
                    numberphone = value;
            }
        }
        public double Hesoluong
        {
            get { return hesoluong; }
            set
            {
                if (value >= 0)
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
        public Employee() { }
        public Employee(Employee em)
        {
            this.id = em.id;
            this.name = string.Copy(em.name);
            this.address = string.Copy(em.address);
            this.age = em.age;
            this.numberphone = em.numberphone;
            this.luongcoban = em.luongcoban;
            this.hesoluong = em.hesoluong;
            this.phucap = em.phucap;

        }
        public Employee(int id, string name, string address, int age, string numberphone,double luongcoban, double hesoluong,double phucap)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.age = age;
            this.numberphone = numberphone;
            this.luongcoban = luongcoban;
            this.hesoluong = hesoluong;
            this.phucap = phucap;

        }


    }
}
