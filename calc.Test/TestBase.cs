using calc.Operations;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;

namespace calc.Test
{
    public class TestBase
    {
        public TestBase()
        {
            GivenAdditionOperation = new Addition();
            GivenSubtractionOperation = new Subtraction();
            GivenDivisionOperation = new Division();
            GivenMultyplicationOperation = new Multiplication();
            GivenPowerOperation = new Power();
        }

        protected IOperation GivenAdditionOperation { get; set; }
        protected IOperation GivenSubtractionOperation { get; set; }
        protected IOperation GivenDivisionOperation { get; set; }
        protected IOperation GivenMultyplicationOperation { get; set; }
        protected IOperation GivenPowerOperation { get; set; }

        protected IRPN ReversePolishNotationMock { get; set; } =
            Substitute.For<IRPN>();
    }
}
