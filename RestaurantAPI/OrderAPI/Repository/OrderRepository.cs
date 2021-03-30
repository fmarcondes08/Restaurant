using OrderAPI.Domain;
using OrderAPI.Domain.Enums;
using System;
using System.Linq;
using System.Text;

namespace OrderAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        protected Dish[] MorningDishes => new Dish[]
        {
            new Dish(DishEnum.Entree, "eggs"),
            new Dish(DishEnum.Side, "toast"),
            new Dish(DishEnum.Drink, "coffee", true)
        };

        protected Dish[] NightDishes => new Dish[]
        {
            new Dish(DishEnum.Entree, "steak"),
            new Dish(DishEnum.Side, "potato", true),
            new Dish(DishEnum.Drink, "wine"),
            new Dish(DishEnum.Dessert, "cake")
        };

        public Dish[] GetTypeOfDish(string time)
        {
            switch (time)
            {
                case "morning":
                    return MorningDishes;
                case "night":
                     return NightDishes;
                default:
                    return null;
            }
        }

        public string GetDishes(Dish[] menuType, string[] orders)
        {
            if (orders.Length - 1 <= 0)
            {
                throw new Exception("The order must have at least one item.");
            }

            var order = MapOrderToString(menuType, orders);

            return order;
        }

        private string MapOrderToString(Dish[] menuType, string[] orders)
        {
            var order = new StringBuilder();
            var multipleDish = 0;

            for (var i = 1; i < orders.Length; i++)
            {
                if (!Enum.IsDefined(typeof(DishEnum), int.Parse(orders[i])))
                {
                    order.Append("error");
                    break;
                }

                Dish dish = menuType.Where(x => x.Type == (DishEnum)int.Parse(orders[i])).FirstOrDefault();

                if (dish == null)
                {
                    order.Append("error");
                    break;
                }

                if (i < orders.Length - 1 && orders[i] == orders[i + 1])
                {
                    //Verify if next dish is the same
                    multipleDish++;
                    continue;
                }

                order.Append(dish.Name);

                if (multipleDish > 0)
                {
                    //Verify if dish have multiple itens
                    if (!dish.IsMultiple)
                    {
                        order.Append(", ");
                        order.Append("error");
                        break;
                    }

                    order.Append($"(x{multipleDish + 1})");
                    multipleDish = 0;
                }

                if (i < orders.Length - 1)
                {
                    order.Append(", ");
                }
            }

            return order.ToString();
        }
    }
}
