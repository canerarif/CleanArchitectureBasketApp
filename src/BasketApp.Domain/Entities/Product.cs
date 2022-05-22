using BasketApp.Domain.Common;

namespace BasketApp.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public int Stock { get; set; }
    }
}
