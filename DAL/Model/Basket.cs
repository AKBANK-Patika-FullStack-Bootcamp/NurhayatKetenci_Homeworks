using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Basket
    {
        public int Id { get; set; }
        public List<Product> Product_List { get; set; }
        public int Total_Price { get; set; }
    }
}
