using Xunit;
using OrderAPI.Services;
using OrderAPI.Controllers;
using OrderAPI.Domain;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace OrderAPITest.Controller
{
    public class OrderControllerTest
    {
        [Fact]
        public void Should_Get_Order()
        {
            var input = "morning, 1, 2, 3";
            var output = new DishOutput()
                { OrderResponse = "eggs, toast, coffee" };

            // Arrange
            var mockService = new Mock<IOrderService>();
            mockService.Setup(repo => repo.CreateOrder(input)).Returns(output);
            var controller = new OrderController(mockService.Object);

            // Act
            var result = controller.Get(input) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("eggs, toast, coffee", (result.Value as DishOutput).OrderResponse);
        }

        [Fact]
        public void Should_Get_Order_Upper_Case()
        {
            var input = "MORNING, 1, 2, 3";
            var output = new DishOutput()
            { OrderResponse = "eggs, toast, coffee" };

            // Arrange
            var mockService = new Mock<IOrderService>();
            mockService.Setup(repo => repo.CreateOrder(input)).Returns(output);
            var controller = new OrderController(mockService.Object);

            // Act
            var result = controller.Get(input) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("eggs, toast, coffee", (result.Value as DishOutput).OrderResponse);
        }

        [Fact]
        public void Should_Get_Order_With_Space()
        {
            var input = "morning,1,2   ,3";
            var output = new DishOutput()
            { OrderResponse = "eggs, toast, coffee" };

            // Arrange
            var mockService = new Mock<IOrderService>();
            mockService.Setup(repo => repo.CreateOrder(input)).Returns(output);
            var controller = new OrderController(mockService.Object);

            // Act
            var result = controller.Get(input) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("eggs, toast, coffee", (result.Value as DishOutput).OrderResponse);
        }

        [Fact]
        public void Should_Get_Order_Error()
        {
            var input = "morning";
            var output = new DishOutput()
            { OrderError = "The order must have at least one item." };

            // Arrange
            var mockService = new Mock<IOrderService>();
            mockService.Setup(repo => repo.CreateOrder(input)).Returns(output);
            var controller = new OrderController(mockService.Object);

            // Act
            var result = controller.Get(input) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("The order must have at least one item.", (result.Value as DishOutput).OrderError);
        }

        [Fact]
        public void Should_Get_Order_Invalid_Time_Error()
        {
            var input = "afternoon, 1, 2, 3";
            var output = new DishOutput()
            { OrderError = "The selected time of day is not valid." };

            // Arrange
            var mockService = new Mock<IOrderService>();
            mockService.Setup(repo => repo.CreateOrder(input)).Returns(output);
            var controller = new OrderController(mockService.Object);

            // Act
            var result = controller.Get(input) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("The selected time of day is not valid.", (result.Value as DishOutput).OrderError);
        }

        [Fact]
        public void Should_Get_Order_Empty_Error()
        {
            var input = "";
            var output = new DishOutput()
            { OrderError = "The order must have at least one item." };

            // Arrange
            var mockService = new Mock<IOrderService>();
            mockService.Setup(repo => repo.CreateOrder(input)).Returns(output);
            var controller = new OrderController(mockService.Object);

            // Act
            var result = controller.Get(input) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("The order must have at least one item.", (result.Value as DishOutput).OrderError);
        }
    }
}
