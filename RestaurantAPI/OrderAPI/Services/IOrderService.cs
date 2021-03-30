using OrderAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAPI.Services
{
    public interface IOrderService
    {
        DishOutput CreateOrder(string input);
    }
}
