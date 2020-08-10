using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moose.Mandle
{
    class Complex
    {
        private double a;
        private double b;

        public Complex(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public void square()
        {
            double temp = (a * a) - (b * b);
            b = 2.0 * a * b;
            a = temp;
        }

        public double magnitute()
        {
            return Math.Sqrt((a * a) + (b * b));
        }

        public void add(Complex c)
        {
            a += c.a;
            b += c.b;
        }
    }
}
