
namespace calc
{
    public class CalcBase : ICalcBase
    {
        public bool IsOperator(char c)
        {
            return (c == OPERATION.MINUS || c == OPERATION.PLUS || c == OPERATION.MULTIPLY || c == OPERATION.DIVITE);
        }
        public bool IsOperandus(char c)
        {
            return (c >= '0' && c <= '9' || c == '.');
        }
    }
}
