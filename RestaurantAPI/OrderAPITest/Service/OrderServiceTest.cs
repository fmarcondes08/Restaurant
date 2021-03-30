using Xunit;
using OrderAPI.Services;
using OrderAPI.Repository;
using OrderAPI.Domain;
using OrderAPI.Domain.Enums;
using Moq;

namespace OrderAPITest.Service
{
    public class OrderServiceTest
    {
        [Fact]
        public void Should_Create_Order()
        {
            var input = "morning, 1, 2, 3";

            var inputArray = new string[4]
                {
                    "morning", "1", "2", "3"
                };

            var output = new DishOutput()
            { OrderResponse = "eggs, toast, coffee" };

            Dish[] MorningDishes = new Dish[]
            {
                new Dish(DishEnum.Entree, "eggs"),
                new Dish(DishEnum.Side, "toast"),
                new Dish(DishEnum.Drink, "coffee", true)
            };

        // Arrange
        var mockService = new Mock<IOrderRepository>();
            mockService.Setup(repo => repo.GetTypeOfDish(inputArray[0])).Returns(MorningDishes);
            mockService.Setup(repo => repo.GetDishes(MorningDishes, inputArray)).Returns("eggs, toast, coffee");
            var orderService = new OrderService(mockService.Object);

            // Act
            var result = orderService.CreateOrder(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("eggs, toast, coffee", result.OrderResponse);
        }

        [Fact]
        public void Should_Create_Order_Time_Error()
        {
            var input = "afternoon, 1, 2, 3";

            var inputArray = new string[4]
                {
                    "afternoon", "1", "2", "3"
                };

            var output = new DishOutput()
            { OrderError = "The selected time of day is not valid." };

            // Arrange
            var mockService = new Mock<IOrderRepository>();
            mockService.Setup(repo => repo.GetTypeOfDish(inputArray[0])).Returns((Dish[])null);
            var orderService = new OrderService(mockService.Object);

            // Act
            var result = orderService.CreateOrder(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("The selected time of day is not valid.", result.OrderError);
        }
    }
}
