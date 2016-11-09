using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    class ArrayCalculator
    {
        public List<int> numbers = new List<int>();
        public static ArrayCalculator operator +(ArrayCalculator a, ArrayCalculator b)
        {
            ArrayCalculator c = new ArrayCalculator();
            for(int i = 0; i<= a.numbers.Count; i++)
                c.numbers[i] = a.numbers[i] + b.numbers[i];
            return c;
        }
    }
}
