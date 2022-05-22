using BasketApp.Domain.Common;

namespace BasketApp.Domain.Entities
{
    public class Basket : BaseEntity
    {
        public int ProductCount { get; set; }
        public Guid ProductId { get; set; }

        //Referencial
        public virtual Product Product { get; set; }
    }
}
