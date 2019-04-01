using calc.Operations;
using System;
using System.Collections.Generic;

namespace calc
{
    public class Calculator : CalcBase, ICalculator
    {
        private readonly Func<string, IOperation> serviceAccessor;

        public Calculator(
            Func<string, IOperation> serviceAccessor)
        {
            this.serviceAccessor = serviceAccessor;
        }

        public string Calculate(string input)
        {
            var stack = new Stack<double>();
            var array = input.Replace(" ", string.Empty).ToCharArray();

            foreach (var x in array)
            {
                if (IsOperandus(x))
                {
                    stack.Push(int.Parse(x.ToString()));
                }

                if (IsOperator(x))
                {
                    var second = stack.Pop();
                    var first = stack.Pop();
                    var operationResult = DoOperations(x, first, second);
                    stack.Push(operationResult);
                }
            }

            return stack.Pop().ToString();
        }

        protected double DoOperations(char c, double a, double b)
        {
            switch (c)
            {
                case OPERATION.PLUS:
                    return serviceAccessor("Addition").Operate(a, b);
                case OPERATION.MINUS:
                    return serviceAccessor("Subtraction").Operate(a, b);
                case OPERATION.MULTIPLY:
                    return serviceAccessor("Multiplication").Operate(a, b);
                case OPERATION.DIVITE:
                    return serviceAccessor("Division").Operate(a, b);
                case OPERATION.POWER:
                    return serviceAccessor("Power").Operate(a, b);
                default:
                    throw new ArgumentException("Rossz parameter");
            }
        }
    }
}