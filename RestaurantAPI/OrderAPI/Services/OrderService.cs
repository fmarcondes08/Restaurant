using OrderAPI.Domain;
using OrderAPI.Repository;
using System;
using System.Reflection;
using System.Runtime.ExceptionServices;

namespace OrderAPI.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {;
            _orderRepository = orderRepository;
        }
        public DishOutput CreateOrder(string input)
        {
            var order = NormalizeOrder(input);

            var menuType = _orderRepository.GetTypeOfDish(order[0]);

            var response = new DishOutput();

            if (menuType == null)
            {
                response.OrderError = "The selected time of day is not valid.";
                return response;
            }

            try
            {
                response.OrderResponse = _orderRepository.GetDishes(menuType, order);
                return response;
            }
            catch (TargetInvocationException ex)
            {
                if (ex.InnerException.GetType() == typeof(FormatException))
                {
                    response.OrderError = "One of the selected dishes is not valid.";
                }
                else if (ex.InnerException.GetType() == typeof(InvalidOperationException))
                {
                    response.OrderError = "The order must have at least one item.";
                }
                else
                {
                    ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                }

                return response;
            }
        }

        private string[] NormalizeOrder(string input)
        {
            var order = input.ToLower().Split(',');
            for (int i = 0; i < order.Length; i++)
            {
                order[i] = order[i].Trim();
            }

            return order;
        }
    }
}
