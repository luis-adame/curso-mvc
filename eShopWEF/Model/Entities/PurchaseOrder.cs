using Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class PurchaseOrder
    {
		public int Id { get; set; }
		public decimal Total { get; set; }	//tenia private set
		public DateTime PurchaseDate { get; set; }
		public PurchaseOrderStatus Status { get; set; }
		public int ProviderId { get; set; }
		public virtual Provider Provider { get; set; }
		public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
		
		public PurchaseOrder(decimal total, int providerId)
        {
			Total = total;
			PurchaseDate = DateTime.Now;
			Status = PurchaseOrderStatus.Pending;
			ProviderId = providerId;
        }
	}
}
