using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_gyak_patterns.Entities
{
    class BallFactory
    {
        public Ball CreateNew()
        {
            return new Ball();
        }
    }
}
