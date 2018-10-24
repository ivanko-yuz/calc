using Grpc.Core;
using System;
using System.Threading.Tasks;
using static calc.CalcService;

namespace calc.Grpc
{
    public class CalcServiceImplementation : CalcServiceBase
    {

        public override Task<CalcResponce> GetAnswer(CalcRequest request, ServerCallContext context) {
            Console.WriteLine("New request:");
            IRPN manager = new RPN();
            ICalculator calculator = new Calculator();

            var LFK = manager.LengyelFormaKonvertalas(request.Formula);
            Console.WriteLine(LFK);

            var result = calculator.Calculate(LFK);
            Console.WriteLine(result);

            return Task.FromResult(new CalcResponce() { Answer = result });
        }
    }
}
