using System;

namespace calc.Operations
{
    public class Division : IOperation
    {
        public double Operate(double quotient, double divisor)
        {
                if (divisor == 0) throw new DivideByZeroException();
                return quotient / divisor;
        }
    }
}
