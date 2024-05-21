using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class LogarithmOperation : IOperation
    {
        public double Calculate(double operand)
        {
            return Math.Log10(operand);
        }
    }
}
