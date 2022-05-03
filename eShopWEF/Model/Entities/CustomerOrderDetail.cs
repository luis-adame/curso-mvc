using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class CustomerOrderDetail
    {
        public int CustomerOrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public virtual CustomerOrder CustomerOrder { get; set; }
        public virtual Product Product { get; set; }

        public CustomerOrderDetail(int customerOrderId, int productId, int quantity)
        {
            CustomerOrderId = customerOrderId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
