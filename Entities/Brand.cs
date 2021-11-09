using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Entities
{
    class Brand
    {
        private int id;
        private string name, diachi;

        public int Id {
            get { return id; }
            set
            {
                if (value >= 1)
                    id = value;
            }
        }
        public string Name {
            get { return name; }
            set
            {
                if (value != "")
                    name = value;
            }
        }
        public string Diachi {
            get { return diachi; }
            set
            {
                if (value != "")
                    diachi = value;
            }
        }

        public Brand() { }
        //Phương thức thiết lập sao chép
        public Brand(Brand ncc)
        {
            this.id = ncc.id;
            this.name = string.Copy(ncc.name);
            this.diachi = string.Copy(ncc.diachi);
            
        }
        public Brand(int id, string name, string diachi)
        {
            this.id = id;
            this.name = name;
            this.diachi = diachi;
        }
    }
}
