using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Console
{
    internal class Product : IProduct
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }

        public string GetId()
        {
            return null;
        }
        public string DoThis()
        {
            return IProduct.GetName("Orange");
        }
        public void GetOrangeType()
        {            
            var type = Orange.GetTypeName;
        }
    }

    public interface IProduct
    {
        public string GetId();
        public static string GetName(string name)
        {
            name = "Product Name is: " + name;
            return name;
        }
    }
    internal abstract class Orange
    {
        private int Id { get; }
        public int GetId()
        {
            return Id;
        }
        internal static string GetTypeName(string name)
        {
            name = "Orange Type is: " + name;
            return name;
        }
    }
}
