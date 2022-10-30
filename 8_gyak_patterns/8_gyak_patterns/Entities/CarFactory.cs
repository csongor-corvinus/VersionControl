using _8_gyak_patterns.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_gyak_patterns.Entities
{
    class CarFactory:IToyFactory
    {
        public Toy CreateNew()
        {
            return new Car();
        }
    }
}
