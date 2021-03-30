using OrderAPI.Domain.Enums;

namespace OrderAPI.Domain
{
    public class Dish
    {
        public Dish(DishEnum type, string name, bool multiple = false)
        {
            Type = type;
            Name = name;
            IsMultiple = multiple;
        }

        /// <summary>
        /// Type of the dish
        /// </summary>
        public DishEnum Type { get; }
        /// <summary>
        /// Name of the dish
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Flag to indicate if a dish can be ordered multiple times
        /// </summary>
        public bool IsMultiple { get; }
    }
}
