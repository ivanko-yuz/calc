using System;
using Xunit;
using FluentAssertions;

namespace calc.Test
{
    public class DivisionOperationTesting : TestBase
    {
        [Fact]
        public void Given_Division_Operation_Two_Positive_number_are_Run()
        {
            GivenDivisionOperation.Operate(2, 2).Should().Be(1);
        }

        [Fact]
        public void Given_Division_Operation_Two_Negative_number_are_Run()
        {
            GivenDivisionOperation.Operate(-8, -2).Should().Be(4);
        }


        [Fact]
        public void Given_Division_Operation_Positive_and_Negative_number_are_Run()
        {
            GivenDivisionOperation.Operate(3, -3).Should().Be(-1);
        }

        [Fact]
        public void Given_Division_Operation_with_zero_as_divisior_are_Run()
        {
            GivenDivisionOperation.Invoking(x => x.Operate(3, 0)).Should().Throw<DivideByZeroException>();
        }
    }
}
