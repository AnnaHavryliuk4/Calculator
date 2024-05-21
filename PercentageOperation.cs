using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class PercentageOperation : IOperation
    {
        public double Calculate(double operand)
        {
            return operand / 100;
        }
    }
}
