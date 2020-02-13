using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Classes
{
    public class Bakery
    {
        public string Address { get; set; }
        public string Owner { get; set; }
        public bool IsFranchise { get; set; }
        List<Product> Products { get; set; }
    }
}
