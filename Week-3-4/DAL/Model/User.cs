using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public  class User
    {

        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public int Adress_Id { get; set; }
        public int Product_Id { get; set; }
        public int Basket_Id { get; set; }

    }
}
