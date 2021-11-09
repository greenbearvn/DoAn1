using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Entities
{
    class Customer 
    {
        private string name, address, numberphone;
        private int id, age;

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

        public Customer() { }
        public Customer(Customer cm)
        {
            this.id = cm.id;
            this.name = string.Copy(cm.name);
            this.address = string.Copy(cm.address);
            this.age = cm.age;
            this.numberphone = cm.numberphone;
        }
        public Customer(int id, string name, string address, int age, string numberphone)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.age = age;
            this.numberphone = numberphone;

        }
    }
}
