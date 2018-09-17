using System;

namespace calc.Operations
{
    public class Power : IOperation
    {
        public double Operate(double first, double second) => Math.Pow(first, second);
    }
}
