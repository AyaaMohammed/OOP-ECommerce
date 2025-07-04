using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class ShippableItem:IShippable
    {
        string _name;
        double _weight;

        public ShippableItem(string name, double weight)
        {
            _name = name;
            _weight = weight;
        }

        public string GetName() => _name;

        public double GetWeight() => _weight;
        override public string ToString()
        {
            return $"{_name} - Weight: {_weight}kg";
        }
    }

}
