using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class PurchaseOrderDetail
    {
		public int PurchaseOrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public virtual Product Product { get; set; }

        public PurchaseOrderDetail(int purchaseOrderId, int productId, int quantity)
        {
            PurchaseOrderId = purchaseOrderId;
            ProductId = productId;
            Quantity = quantity;
        }
	}
}
