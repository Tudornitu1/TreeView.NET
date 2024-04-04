using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Tractor : IComparable<Tractor>
    {
        private String _name { get;set; }
        private String _model { get;set; }
        private String _color { get;set; }
        private String _year { get;set; }


        public Tractor(String name, String model, String color, String year){
            _name = name;
            _model = model;
            _color = color;
            _year = year;
        }

        public Tractor()
        {
        }
        public override string ToString()
        {
            return "Name: " + _name + "\nModel: " + _model + "\nColor: " + _color + "\nYear: " + _year + "\n";
        }

        public int CompareTo(Tractor other)
        {
            return _name.CompareTo(other._name);
        }
    }
}
