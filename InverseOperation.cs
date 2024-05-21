using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class InverseOperation : IOperation
    {
        public double Calculate(double operand)
        {
            return 1 / operand;
        }
    }
}
