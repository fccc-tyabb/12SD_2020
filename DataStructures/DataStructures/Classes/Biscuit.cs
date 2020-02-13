using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Classes
{
    public class Biscuit
    {
        public string Brand { get; set; }
        public string Flavour{ get; set; }
        public string Name { get; set; }
        public bool IsSweet { get; set; }
        public bool HasChocolate { get; set; }
        public List<string> Ingredients { get; set; }

        // Constructor
        public Biscuit()
        {

        }
        public Biscuit(string brand, bool isSweet)
        {
            Brand = brand;
            IsSweet = isSweet;
        }

        // Methods
        public bool SuitableForBrunch()
        {
            // You could do it this way, but it is less efficient
            //if(Brand == "Arnotts" && IsSweet)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            bool b = (Brand == "Arnotts") && IsSweet;
            return b;
        }
    }
}
