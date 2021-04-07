using GFT.API.Entity;
using System;
using Xunit;

namespace GFT.TEST.Tests
{
    public class OrderTest
    {
        [Fact]
        public void ShouldReturnOrdersForMorning()
        {
            var input = "morning, 1, 2, 3";
            var order = new Order(input);
            var output = order.ToString();

            Assert.Equal("eggs, toast, coffee", output);
        }

        [Fact]
        public void ShouldReturnOrdersForNight()
        {
            var input = "night, 1, 2, 3, 4";
            var order = new Order(input);
            var output = order.ToString();

            Assert.Equal("steak, potato, wine, cake", output);
        }

        [Fact]
        public void ShouldAllowCombinePotato()
        {
            var input = "night, 1, 2, 2, 4";
            var order = new Order(input);
            var output = order.ToString();

            Assert.Equal("steak, potato(x2), cake", output);
        }

        [Fact]
        public void ShouldReturnErrorOnInvalidOrderItemNumber()
        {
            var input = "night, 1, 2, 3, 5";
            var order = new Order(input);
            var output = order.ToString();

            Assert.Equal("steak, potato, wine, error", output);
        }


        [Fact]
        public void ShouldAllowCombineCoffee()
        {
            var input = "morning, 1, 3, 3, 2, 3";
            var order = new Order(input);
            var output = order.ToString();

            Assert.Equal("eggs, toast, coffee(x3)", output);
        }


        [Fact]
        public void ShouldNotAllowCombineOthersButCoffee()
        {
            var input = "morning, 1, 2, 3, 2, 2";
            var order = new Order(input);
            var output = order.ToString();

            Assert.Equal("eggs, error", output);
        }

        [Fact]
        public void ShouldNotAllowCombineOthersButPotato()
        {
            var input = "night, 1, 1, 2, 3, 5";
            var order = new Order(input);
            var output = order.ToString();

            Assert.Equal("error", output);
        }

        [Fact]
        public void ShouldThrowsOnWrongDaytime()
        {
            var input = "afternoon, 1, 2, 3";
            
            Assert.Throws<InvalidOperationException>(() => new Order(input)) ;
        }

        [Fact]
        public void ShouldThrowsOnInvalidOrderItemType()
        {
            var input = "morning, coffee";

            Assert.Throws<InvalidOperationException>(() => new Order(input));
        }
    }
}
