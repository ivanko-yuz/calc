using calc.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace calc
{
    public class RPN : CalcBase, IRPN
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

        #region Helpers
       
        protected int Prior(char c)
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
