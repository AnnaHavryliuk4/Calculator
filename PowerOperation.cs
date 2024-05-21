using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class PowerOperation : IOperation
    {
        public double Calculate(double operand)
        {
            return Math.Pow(operand, 2);
        }
    }
}
