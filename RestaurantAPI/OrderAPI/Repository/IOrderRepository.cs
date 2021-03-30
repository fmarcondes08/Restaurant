using OrderAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAPI.Repository
{
    public interface IOrderRepository
    {
        Dish[] GetTypeOfDish(string time);
        string GetDishes(Dish[] menuType, string[] orders);
    }
}
