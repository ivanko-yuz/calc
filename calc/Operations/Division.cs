namespace calc.Operations
{
    public class Division : IOperation
    {
        public double Operate(double quotient, double divisor) => quotient / divisor;
    }
}
