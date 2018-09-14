using calc.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace calc
{
    public class RPN : IRPN
    {
        public String LengyelFormaKonvertalas(String input)
        {
            Stack<char> stack = new Stack<char>();
            String str = input.Replace(" ", string.Empty);
            var formula = new List<char>();

            for (int i = 0; i < str.Length; i++)
            {
                char x = str[i];
                if (x == BRACKETS.OPEN)
                    stack.Push(x);
                else if (x == BRACKETS.CLOSED)
                {
                    while (stack.Count > 0 && stack.Peek() != BRACKETS.OPEN)
                        formula.Add(stack.Pop());
                    stack.Pop();
                }
                else if (IsOperandus(x))
                {
                    formula.Add(x);
                }
                else if (IsOperator(x))
                {
                    while (stack.Count > 0 && stack.Peek() != BRACKETS.OPEN && Prior(x) <= Prior(stack.Peek()))
                        formula.Add(stack.Pop());
                    stack.Push(x);
                }
                else
                {
                    char y = stack.Pop();
                    if (y != BRACKETS.OPEN)
                        formula.Add(y);
                }
            }
            while (stack.Count > 0)
            {
                formula.Add(stack.Pop());
            }
            return String.Join(' ', formula);
        }


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
                    var operationresult = DoAction(x, first, second);
                    stack.Push(operationresult);
                }
            }

            return stack.Pop().ToString();
        }


        #region Helpers
        public bool IsOperator(char c)
        {
            return (c == OPERATION.MINUS || c == OPERATION.PLUS || c == OPERATION.MULTIPLY || c == OPERATION.DIVITE);
        }
        public bool IsOperandus(char c)
        {
            return (c >= '0' && c <= '9' || c == '.');
        }
        public int Prior(char c)
        {
            switch (c)
            {
                case OPERATION.EQUAL:
                    return 1;
                case OPERATION.PLUS:
                    return 2;
                case OPERATION.MINUS:
                    return 2;
                case OPERATION.MULTIPLY:
                    return 3;
                case OPERATION.DIVITE:
                    return 3;
                case OPERATION.POWER:
                    return 4;
                default:
                    throw new ArgumentException("Rossz parameter");
            }
        }

        public double DoAction(char c, double a, double b)
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
        #endregion
    }
}
