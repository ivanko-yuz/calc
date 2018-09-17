using System;

namespace calc
{
    class Program
    {
        static void Main(string[] args)
        {
            String str = "5 + ( ( 1 + 2 ) *  4 ) - 3";
            Console.WriteLine(str);
            IRPN manager = new RPN();
            ICalculator calculator = new Calculator();

            var LFK = manager.LengyelFormaKonvertalas(str);
            Console.WriteLine(LFK);

            var result = calculator.Calculate(LFK);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
