using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class SquareRootOperation : IOperation
    {
        public double Calculate(double operand)
        {
            return Math.Sqrt(operand);
        }
    }
}
