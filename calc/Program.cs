using System;
using System.Collections.Generic;
using calc.Operations;
using Microsoft.Extensions.DependencyInjection;

namespace calc
{
    class Program
    {
        private static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<Addition>()
                .AddTransient<Division>()
                .AddTransient<Subtraction>()
                .AddTransient<Multiplication>()
                .AddTransient<Power>()
                .AddTransient<ICalcBase, CalcBase>()
                .AddTransient<IOperation, Subtraction>()
                .AddSingleton<IRPN, RPN>()
                .AddSingleton<ICalculator, Calculator>()
                .AddTransient<Func<string, IOperation>>(provider => key =>
                {
                    switch (key)
                    {
                        case "Addition":
                            return provider.GetService<Addition>();
                        case "Subtraction":
                            return provider.GetService<Subtraction>();
                        case "Division":
                            return provider.GetService<Division>();
                        case "Multiplication":
                            return provider.GetService<Multiplication>();
                        case "power":
                            return provider.GetService<Power>();
                        default:
                            throw new KeyNotFoundException(); // or maybe return null, up to you
                    }
                }).BuildServiceProvider();

            const string str = "5 + ( ( 1 + 2 ) *  4 ) - 3";
            Console.WriteLine(str);
                        
            var manager = serviceProvider.GetService<IRPN>();
            var calculator = serviceProvider.GetService<ICalculator>();

            var LFK = manager.LengyelFormaKonvertalas(str);
            Console.WriteLine(LFK);

            var result = calculator.Calculate(LFK);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}