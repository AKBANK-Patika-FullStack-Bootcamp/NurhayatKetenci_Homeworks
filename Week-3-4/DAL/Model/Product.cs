using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public  class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Product_Code { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }

    }
}
