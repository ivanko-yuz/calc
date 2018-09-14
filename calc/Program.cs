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

            var LFK = manager.LengyelFormaKonvertalas(str);
            Console.WriteLine(LFK);

            var result = manager.Calculate(LFK);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
