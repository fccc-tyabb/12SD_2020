using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Classes
{
    public class Biscuit : BakedGood
    {
        public string Flavour{ get; set; }
        public bool IsSweet { get; set; }
        public bool HasChocolate { get; set; }

        // Constructor
        public Biscuit()
        {

        }
        public Biscuit(string brand, bool isSweet, string name)
        {
            Brand = brand;
            IsSweet = isSweet;
            Name = name;    
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

        public override string ToString()
        {
            return Brand;
        }
    }
}
