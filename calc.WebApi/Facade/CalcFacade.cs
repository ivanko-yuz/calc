
namespace calc.WebApi.Managers
{
    public class CalcFacade
    {
        private ICalculator Calculator;
        private IRPN RPN;
        public CalcFacade()
        {
            RPN = new RPN();
            Calculator = new Calculator();
        }

        public string Action(string value)
        {
            return Calculator.Calculate(RPN.LengyelFormaKonvertalas(value));
        }




    }
}
