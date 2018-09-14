using System;
using Xunit;
using FluentAssertions;

namespace calc.Test
{
    public class SubtractionOperationTesting : TestBase
    {
        [Fact]
        public void Given_Subtraction_Operation_Two_Positive_number_are_Run()
        {
            GivenSubtractionOperation.Operate(2, 2).Should().Be(0);
        }

        [Fact]
        public void Given_Subtraction_Operation_Two_Negative_number_are_Run()
        {
            GivenSubtractionOperation.Operate(-2, -7).Should().Be(5);
        }


        [Fact]
        public void Given_Subtraction_Operation_Positive_and_Negative_number_are_Run()
        {
            GivenSubtractionOperation.Operate(3, -3).Should().Be(6);
        }
    }
}
