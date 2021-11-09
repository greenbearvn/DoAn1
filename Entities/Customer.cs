using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Entities
{
    class Customer : Person 
    {
        

        public Customer() { }
        public Customer(Customer cm)
        {
            this.Id = cm.Id;
            this.Name = string.Copy(cm.Name);
            this.Address = string.Copy(cm.Address);
            this.Age = cm.Age;
            this.Numberphone = cm.Numberphone;
        }
        public Customer(int id, string name, string address, int age, string numberphone) : base(id, name, address, age, numberphone) { }


    }
}
