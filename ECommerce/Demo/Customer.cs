using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public Customer(string _name , double _balance)
        {
            Name = _name;
            Balance = _balance;
        }
        override public string ToString()
        {
            return $"{Name} - Balance: {Balance:C}";
        }
    }
}
