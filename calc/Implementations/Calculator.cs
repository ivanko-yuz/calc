using calc.Operations;
using System;
using System.Collections.Generic;

namespace calc
{
    public class Calculator : CalcBase, ICalculator
    {
        public String Calculate(String input)
        {
            var stack = new Stack<double>();
            var array = input.Replace(" ", string.Empty).ToCharArray();

            for (int i = 0; i < array.Length; i++)
            {
                char x = array[i];
                if (IsOperandus(x))
                {
                    stack.Push(int.Parse(x.ToString()));
                }
                if (IsOperator(x))
                {
                    var second = stack.Pop();
                    var first = stack.Pop();
                    var operationresult = DoOperations(x, first, second);
                    stack.Push(operationresult);
                }
            }

            return stack.Pop().ToString();
        }

        protected double DoOperations(char c, double a, double b)
        {
            switch (c)
            {
                case OPERATION.PLUS:
                    return new Addition().Operate(a, b);
                case OPERATION.MINUS:
                    return new Subtraction().Operate(a, b);
                case OPERATION.MULTIPLY:
                    return new Multiplication().Operate(a, b);
                case OPERATION.DIVITE:
                    return new Division().Operate(a, b);
                case OPERATION.POWER:
                    return new Power().Operate(a, b);
                default:
                    throw new ArgumentException("Rossz parameter");
            }
        }
    }
}
