using System;
using Xunit;
using FluentAssertions;

namespace calc.Test
{
    public class AdditionOperationTesting : TestBase
    {
        [Fact]
        public void Given_Addition_Operation_Two_Positive_number_are_Run()
        {
            GivenAdditionOperation.Operate(2, 2).Should().Be(4);
        }

        [Fact]
        public void Given_Addition_Operation_Two_Negative_number_are_Run()
        {
            GivenAdditionOperation.Operate(-2, -7).Should().Be(-9);
        }


        [Fact]
        public void Given_Addition_Operation_Positive_and_Negative_number_are_Run()
        {
            GivenAdditionOperation.Operate(3, -3).Should().Be(0);
        }
    }
}
