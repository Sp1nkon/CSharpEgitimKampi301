using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.EntityLayer.Concrete
{
    public class Category
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public int CategoryStatus { get; set; }

        public List<Product> Products { get; set; }


    }
}
