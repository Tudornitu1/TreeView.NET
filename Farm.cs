using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Farm
    {
        public List<Tractor> _tractors { get; set; }

        public Farm()
        {
            _tractors = new List<Tractor>();
        }

       
        public void addTractor(Tractor tractor) {
            _tractors.Add(tractor);
        }


    }
}
