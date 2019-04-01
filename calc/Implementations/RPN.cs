using calc.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace calc
{
    public class RPN : CalcBase, IRPN
    {
        public string LengyelFormaKonvertalas(String input)
        {
            var stack = new Stack<char>();
            string str = input.Replace(" ", string.Empty);
            var formula = new List<char>();

            foreach (var x in str)
            {
                switch (x)
                {
                    case BRACKETS.OPEN:
                        stack.Push(x);
                        break;
                    case BRACKETS.CLOSED:
                    {
                        while (stack.Count > 0 && stack.Peek() != BRACKETS.OPEN)
                            formula.Add(stack.Pop());
                        stack.Pop();
                        break;
                    }
                    default:
                    {
                        if (IsOperandus(x))
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
                            var y = stack.Pop();
                            if (y != BRACKETS.OPEN)
                                formula.Add(y);
                        }

                        break;
                    }
                }
            }
            while (stack.Count > 0)
            {
                formula.Add(stack.Pop());
            }
            return string.Join(' ', formula);
        }

        #region Helpers

        private static int Prior(char c)
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
        #endregion
    }
}
